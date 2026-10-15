Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Microsoft.EntityFrameworkCore
Imports ZXing
Imports ZXing.Common
Imports ZXing.Windows.Compatibility

Public Class FrmProductos

    Private _idSeleccionado As Integer = 0
    Private _versionLeida As Integer = 0
    Private _cargandoFormulario As Boolean = True

    ' =====================================================
    ' CARGA INICIAL
    ' =====================================================

    Private Async Sub FrmProductos_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        _cargandoFormulario = True

        Try
            dgvProductos.ReadOnly = True
            dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect
            dgvProductos.MultiSelect = False
            dgvProductos.AllowUserToAddRows = False
            dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill

            Await CargarCategoriasAsync()
            Await CargarFiltroCategoriasAsync()

        Catch ex As Exception
            MostrarError("No fue posible cargar los datos.", ex)
        Finally
            _cargandoFormulario = False
        End Try

        Try
            Await AplicarFiltrosAsync()
        Catch ex As Exception
            MostrarError("No fue posible cargar los productos.", ex)
        End Try

    End Sub

    ' =====================================================
    ' CARGAR CATEGORÍAS
    ' =====================================================

    Private Async Function CargarCategoriasAsync() As Task

        Using ctx As New AppDbContext()

            Dim categorias = Await ctx.Categorias _
                .AsNoTracking() _
                .OrderBy(Function(c) c.Nombre) _
                .ToListAsync()

            cboCategoria.DisplayMember = NameOf(Categoria.Nombre)
            cboCategoria.ValueMember = NameOf(Categoria.Id)
            cboCategoria.DataSource = categorias

        End Using

    End Function

    Private Async Function CargarFiltroCategoriasAsync() As Task

        Using ctx As New AppDbContext()

            Dim categorias = Await ctx.Categorias _
                .AsNoTracking() _
                .OrderBy(Function(c) c.Nombre) _
                .Select(Function(c) New With {
                    .Id = c.Id,
                    .Nombre = c.Nombre
                }) _
                .ToListAsync()

            Dim opciones As New List(
                Of KeyValuePair(Of Integer, String)) From {
                New KeyValuePair(Of Integer, String)(
                    0, "Todas las categorías")
            }

            For Each categoria In categorias
                opciones.Add(
                    New KeyValuePair(Of Integer, String)(
                        categoria.Id, categoria.Nombre))
            Next

            cboFiltroCategoria.DisplayMember = "Value"
            cboFiltroCategoria.ValueMember = "Key"
            cboFiltroCategoria.DataSource = opciones
            cboFiltroCategoria.DropDownStyle =
                ComboBoxStyle.DropDownList

        End Using

    End Function

    ' =====================================================
    ' ABRIR MANTENIMIENTO DE CATEGORÍAS
    ' =====================================================

    Private Async Sub btnCategorias_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCategorias.Click

        Try
            Using formulario As New FrmCategorias()
                formulario.ShowDialog(Me)
            End Using

            _cargandoFormulario = True

            Await CargarCategoriasAsync()
            Await CargarFiltroCategoriasAsync()

            _cargandoFormulario = False

            Await AplicarFiltrosAsync()

        Catch ex As Exception
            _cargandoFormulario = False
            MostrarError(
                "No se pudieron recargar las categorías.", ex)
        End Try

    End Sub

    ' =====================================================
    ' UTILIDADES
    ' =====================================================

    Private Sub EstablecerOcupado(
        ocupado As Boolean,
        Optional mensaje As String = ""
    )

        UseWaitCursor = ocupado

        btnNuevo.Enabled = Not ocupado
        btnGuardar.Enabled = Not ocupado
        btnActualizar.Enabled = Not ocupado
        btnEliminar.Enabled = Not ocupado
        btnBuscar.Enabled = Not ocupado
        btnCategorias.Enabled = Not ocupado

        If mensaje <> "" Then
            lblEstado.Text = mensaje
        End If

    End Sub

    Private Function DatosValidos() As Boolean

        If String.IsNullOrWhiteSpace(txtNombre.Text) Then

            MessageBox.Show(
                "Escriba el nombre del producto.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            txtNombre.Focus()
            Return False

        End If

        If cboCategoria.SelectedValue Is Nothing Then

            MessageBox.Show(
                "Seleccione una categoría.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            cboCategoria.Focus()
            Return False

        End If

        Dim categoriaId As Integer

        If Not Integer.TryParse(
            cboCategoria.SelectedValue.ToString(),
            categoriaId) OrElse categoriaId <= 0 Then

            MessageBox.Show(
                "Seleccione una categoría válida.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            cboCategoria.Focus()
            Return False

        End If

        If txtCodigoBarras.Text.Trim().Length > 20 Then

            MessageBox.Show(
                "El código de barras no puede superar 20 caracteres.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtCodigoBarras.Focus()
            Return False

        End If

        Return True

    End Function

    Private Sub LimpiarCampos()

        _idSeleccionado = 0
        _versionLeida = 0

        txtNombre.Clear()
        txtCodigoBarras.Clear()
        nudPrecio.Value = 0
        nudExistencia.Value = 0

        If cboCategoria.Items.Count > 0 Then
            cboCategoria.SelectedIndex = 0
        End If

        dgvProductos.ClearSelection()
        txtNombre.Focus()

    End Sub

    Private Sub MostrarError(
        mensaje As String,
        ex As Exception
    )

        lblEstado.Text = "Error: " & ex.Message

        MessageBox.Show(
            mensaje & vbCrLf & vbCrLf & ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

    End Sub

    ' =====================================================
    ' CONSULTAR Y FILTRAR PRODUCTOS
    ' =====================================================

    Private Async Function CargarProductosAsync(
        Optional filtro As String = "",
        Optional idCategoria As Integer = 0
    ) As Task

        EstablecerOcupado(True, "Consultando productos...")

        Try
            Using ctx As New AppDbContext()

                Dim consulta = ctx.Productos.AsNoTracking()

                If Not String.IsNullOrWhiteSpace(filtro) Then

                    Dim texto As String = filtro.Trim()

                    consulta = consulta.Where(
                        Function(p) p.Nombre.Contains(texto) OrElse
                        (p.CodigoBarras IsNot Nothing AndAlso
                         p.CodigoBarras.Contains(texto)))

                End If

                If idCategoria > 0 Then
                    consulta = consulta.Where(
                        Function(p) p.CategoriaId = idCategoria)
                End If

                If chkBajoStock.Checked Then
                    consulta = consulta.Where(
                        Function(p) p.Existencia < 10)
                End If

                Dim lista = Await consulta _
                    .OrderBy(Function(p) p.Nombre) _
                    .Select(Function(p) New ProductoVista With {
                        .Id = p.Id,
                        .Nombre = p.Nombre,
                        .Categoria = p.Categoria.Nombre,
                        .CategoriaId = p.CategoriaId,
                        .Precio = p.Precio,
                        .Existencia = p.Existencia,
                        .VersionFila = p.VersionFila,
                        .CodigoBarras = p.CodigoBarras
                    }) _
                    .ToListAsync()

                dgvProductos.DataSource = lista

                FormatearGrilla()

                lblEstado.Text =
                    $"{lista.Count} producto(s) cargado(s)."

            End Using

            Await ActualizarValorInventarioAsync()

        Finally
            EstablecerOcupado(False)
        End Try

    End Function

    ' =====================================================
    ' FORMATO DE LA GRILLA
    ' =====================================================

    Private Sub FormatearGrilla()

        If dgvProductos.Columns.Count = 0 Then Return

        With dgvProductos.Columns

            If .Contains("CategoriaId") Then
                .Item("CategoriaId").Visible = False
            End If

            If .Contains("Id") Then
                .Item("Id").HeaderText = "ID"
                .Item("Id").FillWeight = 30
            End If

            If .Contains("Nombre") Then
                .Item("Nombre").HeaderText = "Producto"
                .Item("Nombre").FillWeight = 140
            End If

            If .Contains("Categoria") Then
                .Item("Categoria").HeaderText = "Categoría"
            End If

            If .Contains("CodigoBarras") Then
                .Item("CodigoBarras").HeaderText =
                    "Código de barras"
                .Item("CodigoBarras").FillWeight = 100
            End If

            If .Contains("Precio") Then
                .Item("Precio").HeaderText = "Precio"
                .Item("Precio").DefaultCellStyle.Format =
                    "'C$' #,##0.00"
                .Item("Precio").DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight
            End If

            If .Contains("Existencia") Then
                .Item("Existencia").HeaderText = "Existencia"
            End If

            If .Contains("VersionFila") Then
                .Item("VersionFila").HeaderText = "Versión"
                .Item("VersionFila").Visible = False
            End If

        End With

    End Sub

    ' =====================================================
    ' VALOR TOTAL DEL INVENTARIO
    ' =====================================================

    Private Async Function ActualizarValorInventarioAsync() As Task

        Using ctx As New AppDbContext()

            Dim totalNullable As Decimal? =
                Await ctx.Productos _
                    .Select(Function(p) _
                        CType(p.Precio * p.Existencia, Decimal?)) _
                    .SumAsync()

            Dim total As Decimal = If(totalNullable, 0D)

            lblValorInventario.Text =
                $"Valor total del inventario: C$ {total:N2}"

        End Using

    End Function

    ' =====================================================
    ' VALIDAR NOMBRES DUPLICADOS
    ' =====================================================

    Private Async Function ExisteNombreDuplicadoAsync(
        nombre As String,
        Optional idExcluir As Integer = 0
    ) As Task(Of Boolean)

        Dim nombreBuscado As String = nombre.Trim()

        Using ctx As New AppDbContext()

            Return Await ctx.Productos.AnyAsync(
                Function(p) p.Nombre = nombreBuscado AndAlso
                            p.Id <> idExcluir)

        End Using

    End Function

    ' =====================================================
    ' BUSCAR
    ' =====================================================

    Private Async Sub btnBuscar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBuscar.Click

        Try
            Await AplicarFiltrosAsync()
        Catch ex As Exception
            MostrarError("No se pudo realizar la búsqueda.", ex)
        End Try

    End Sub

    Private Async Function AplicarFiltrosAsync() As Task

        Dim idCategoria As Integer = 0

        If cboFiltroCategoria.SelectedValue IsNot Nothing Then
            Integer.TryParse(
                cboFiltroCategoria.SelectedValue.ToString(),
                idCategoria)
        End If

        Await CargarProductosAsync(
            txtBuscar.Text,
            idCategoria)

    End Function

    Private Async Sub cboFiltroCategoria_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cboFiltroCategoria.SelectedIndexChanged

        If _cargandoFormulario Then Return

        Try
            Await AplicarFiltrosAsync()
        Catch ex As Exception
            MostrarError(
                "No se pudo filtrar por categoría.", ex)
        End Try

    End Sub

    Private Async Sub chkBajoStock_CheckedChanged(
        sender As Object,
        e As EventArgs
    ) Handles chkBajoStock.CheckedChanged

        If _cargandoFormulario Then Return

        Try
            Await AplicarFiltrosAsync()
        Catch ex As Exception
            MostrarError(
                "No se pudo filtrar por existencia.", ex)
        End Try

    End Sub

    ' =====================================================
    ' SELECCIONAR PRODUCTO
    ' =====================================================

    Private Sub dgvProductos_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles dgvProductos.SelectionChanged

        If dgvProductos.CurrentRow Is Nothing Then Return
        If Not dgvProductos.CurrentRow.Selected Then Return

        Dim fila = TryCast(
            dgvProductos.CurrentRow.DataBoundItem,
            ProductoVista)

        If fila Is Nothing Then Return

        _idSeleccionado = fila.Id
        _versionLeida = fila.VersionFila

        txtNombre.Text = fila.Nombre
        txtCodigoBarras.Text = If(fila.CodigoBarras, "")

        cboCategoria.SelectedValue = fila.CategoriaId

        nudPrecio.Value = Math.Max(
            nudPrecio.Minimum,
            Math.Min(nudPrecio.Maximum, fila.Precio))

        nudExistencia.Value = Math.Max(
            nudExistencia.Minimum,
            Math.Min(
                nudExistencia.Maximum,
                CDec(fila.Existencia)))

    End Sub

    ' =====================================================
    ' NUEVO
    ' =====================================================

    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnNuevo.Click

        LimpiarCampos()

        lblEstado.Text =
            "Escriba los datos del nuevo producto y presione Guardar."

    End Sub

    ' =====================================================
    ' GUARDAR PRODUCTO
    ' =====================================================

    Private Async Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnGuardar.Click

        If Not DatosValidos() Then Return

        Try
            If Await ExisteNombreDuplicadoAsync(txtNombre.Text) Then

                MessageBox.Show(
                    "Ya existe un producto con ese nombre.",
                    "Producto duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                txtNombre.Focus()
                txtNombre.SelectAll()
                Return

            End If

            EstablecerOcupado(True, "Guardando producto...")

            Using ctx As New AppDbContext()

                Dim nuevo As New Producto With {
                    .Nombre = txtNombre.Text.Trim(),
                    .CategoriaId = CInt(cboCategoria.SelectedValue),
                    .Precio = nudPrecio.Value,
                    .Existencia = CInt(nudExistencia.Value),
                    .VersionFila = 1,
                    .CodigoBarras = If(
                        String.IsNullOrWhiteSpace(txtCodigoBarras.Text),
                        Nothing,
                        txtCodigoBarras.Text.Trim())
                }

                ctx.Productos.Add(nuevo)
                Await ctx.SaveChangesAsync()

                lblEstado.Text =
                    $"Producto #{nuevo.Id} guardado correctamente."

            End Using

            Await AplicarFiltrosAsync()
            LimpiarCampos()

        Catch ex As Exception
            MostrarError("No se pudo guardar el producto.", ex)
        Finally
            EstablecerOcupado(False)
        End Try

    End Sub

    ' =====================================================
    ' ACTUALIZAR PRODUCTO
    ' =====================================================

    Private Async Sub btnActualizar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnActualizar.Click

        If _idSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un producto de la lista.",
                "Actualizar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Return

        End If

        If Not DatosValidos() Then Return

        Dim huboConflicto As Boolean = False

        Try
            If Await ExisteNombreDuplicadoAsync(
                txtNombre.Text, _idSeleccionado) Then

                MessageBox.Show(
                    "Ya existe otro producto con ese nombre.",
                    "Producto duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                txtNombre.Focus()
                txtNombre.SelectAll()
                Return

            End If

            EstablecerOcupado(True, "Actualizando producto...")

            Using ctx As New AppDbContext()

                Dim p = Await ctx.Productos.FindAsync(_idSeleccionado)

                If p Is Nothing Then
                    huboConflicto = True
                Else
                    ctx.Entry(p) _
                        .Property(Function(x) x.VersionFila) _
                        .OriginalValue = _versionLeida

                    p.Nombre = txtNombre.Text.Trim()
                    p.CategoriaId = CInt(cboCategoria.SelectedValue)
                    p.Precio = nudPrecio.Value
                    p.Existencia = CInt(nudExistencia.Value)
                    p.CodigoBarras = If(
                        String.IsNullOrWhiteSpace(txtCodigoBarras.Text),
                        Nothing,
                        txtCodigoBarras.Text.Trim())

                    p.VersionFila = _versionLeida + 1

                    Await ctx.SaveChangesAsync()

                    lblEstado.Text =
                        $"Producto #{p.Id} actualizado correctamente."
                End If

            End Using

        Catch ex As DbUpdateConcurrencyException
            huboConflicto = True

        Catch ex As Exception
            MostrarError(
                "No se pudo actualizar el producto.", ex)
            Return

        Finally
            EstablecerOcupado(False)
        End Try

        If huboConflicto Then
            MessageBox.Show(
                "Otro usuario modificó o eliminó este producto." &
                vbCrLf & "Se mostrarán los datos actuales.",
                "Conflicto de concurrencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
        End If

        Await AplicarFiltrosAsync()

    End Sub

    ' =====================================================
    ' ELIMINAR PRODUCTO
    ' =====================================================

    Private Async Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEliminar.Click

        If _idSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un producto de la lista.",
                "Eliminar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Return

        End If

        Dim respuesta = MessageBox.Show(
            $"¿Eliminar definitivamente ""{txtNombre.Text}""?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If respuesta <> DialogResult.Yes Then Return

        Dim huboConflicto As Boolean = False

        Try
            EstablecerOcupado(True, "Eliminando producto...")

            Using ctx As New AppDbContext()

                Dim p = Await ctx.Productos.FindAsync(_idSeleccionado)

                If p Is Nothing Then
                    huboConflicto = True
                Else
                    ctx.Entry(p) _
                        .Property(Function(x) x.VersionFila) _
                        .OriginalValue = _versionLeida

                    ctx.Productos.Remove(p)
                    Await ctx.SaveChangesAsync()

                    lblEstado.Text =
                        "Producto eliminado correctamente."
                End If

            End Using

        Catch ex As DbUpdateConcurrencyException
            huboConflicto = True

        Catch ex As Exception
            MostrarError(
                "No se pudo eliminar el producto.", ex)
            Return

        Finally
            EstablecerOcupado(False)
        End Try

        If huboConflicto Then
            MessageBox.Show(
                "El producto fue modificado o eliminado por otro usuario.",
                "Conflicto de concurrencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
        End If

        Await AplicarFiltrosAsync()
        LimpiarCampos()

    End Sub

    Private Sub btnCodigoBarras_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCodigoBarras.Click

        If _idSeleccionado = 0 Then
            MessageBox.Show(
                "Seleccione un producto de la lista.",
                "Código de barras",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        Dim codigo As String = txtCodigoBarras.Text.Trim()

        If String.IsNullOrWhiteSpace(codigo) Then
            codigo = "PROD" & _idSeleccionado.ToString("D8")
            txtCodigoBarras.Text = codigo
        End If

        Try
            Dim escritor As New BarcodeWriter()
            escritor.Format = BarcodeFormat.CODE_128
            escritor.Options = New EncodingOptions With {
                .Width = 400,
                .Height = 120,
                .Margin = 10
            }

            Using imagen As Bitmap = escritor.Write(codigo)
                Using ventana As New Form()

                    ventana.Text = "Código de barras - " & txtNombre.Text
                    ventana.StartPosition = FormStartPosition.CenterParent
                    ventana.ClientSize = New Size(440, 220)

                    Dim vista As New PictureBox With {
                        .Dock = DockStyle.Fill,
                        .SizeMode = PictureBoxSizeMode.Zoom,
                        .Image = New Bitmap(imagen)
                    }

                    Dim etiqueta As New Label With {
                        .Text = codigo,
                        .Dock = DockStyle.Bottom,
                        .Height = 35,
                        .TextAlign = ContentAlignment.MiddleCenter
                    }

                    ventana.Controls.Add(vista)
                    ventana.Controls.Add(etiqueta)

                    ventana.ShowDialog(Me)

                    vista.Image.Dispose()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
                "No se pudo generar el código de barras: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub


End Class
