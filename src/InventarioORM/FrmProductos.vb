Imports System.Windows.Forms
Imports Microsoft.EntityFrameworkCore

Public Class FrmProductos

    ' Producto seleccionado en la grilla (0 = ninguno)
    Private _idSeleccionado As Integer = 0
    ' Versión que el usuario vio al seleccionar: base del control de concurrencia
    Private _versionLeida As Integer = 0

    ' ===================== CARGA INICIAL =====================
    Private Async Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvProductos.ReadOnly = True
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProductos.MultiSelect = False
        dgvProductos.AllowUserToAddRows = False
        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Try
            Await CargarCategoriasAsync()
            Await CargarProductosAsync()
        Catch ex As Exception
            MostrarError("No fue posible conectar con MariaDB.", ex)
        End Try
    End Sub

    ''' <summary>READ: llena el ComboBox con las categorías.</summary>
    Private Async Function CargarCategoriasAsync() As Task
        Using ctx As New AppDbContext()
            Dim categorias = Await ctx.Categorias.
                AsNoTracking().
                OrderBy(Function(c) c.Nombre).
                ToListAsync()

            cboCategoria.DisplayMember = NameOf(Categoria.Nombre)
            cboCategoria.ValueMember = NameOf(Categoria.Id)
            cboCategoria.DataSource = categorias
        End Using
    End Function

    ' ===================== UTILIDADES =====================
    ''' <summary>Bloquea los botones mientras se espera a la base de datos.</summary>
    Private Sub EstablecerOcupado(ocupado As Boolean, Optional mensaje As String = "")
        UseWaitCursor = ocupado
        For Each b In {btnNuevo, btnGuardar, btnActualizar, btnEliminar, btnBuscar}
            b.Enabled = Not ocupado
        Next
        If mensaje <> "" Then lblEstado.Text = mensaje
    End Sub

    Private Function DatosValidos() As Boolean
        If txtNombre.Text.Trim() = "" Then
            MessageBox.Show("Escriba el nombre del producto.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNombre.Focus()
            Return False
        End If
        If cboCategoria.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione una categoría.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function

    Private Sub LimpiarCampos()
        _idSeleccionado = 0
        _versionLeida = 0
        txtNombre.Clear()
        nudPrecio.Value = 0
        nudExistencia.Value = 0
        If cboCategoria.Items.Count > 0 Then cboCategoria.SelectedIndex = 0
        dgvProductos.ClearSelection()
        txtNombre.Focus()
    End Sub

    Private Sub MostrarError(mensaje As String, ex As Exception)
        lblEstado.Text = "Error: " & ex.Message
        MessageBox.Show(mensaje & vbCrLf & vbCrLf & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' ===================== READ =====================
    ''' <summary>Consulta los productos (opcionalmente filtrados) y los muestra.</summary>
    Private Async Function CargarProductosAsync(Optional filtro As String = "") As Task
        EstablecerOcupado(True, "Consultando productos…")
        Try
            Using ctx As New AppDbContext()
                ' La consulta se arma por partes; aún no se ejecuta
                Dim consulta = ctx.Productos.AsNoTracking()

                If filtro.Trim() <> "" Then
                    consulta = consulta.Where(Function(p) p.Nombre.Contains(filtro.Trim()))
                End If

                ' ToListAsync() es el momento en que se envía el SELECT
                Dim lista = Await consulta.
                OrderBy(Function(p) p.Nombre).
                Select(Function(p) New ProductoVista With {
                    .Id = p.Id,
                    .Nombre = p.Nombre,
                    .Categoria = p.Categoria.Nombre,
                    .CategoriaId = p.CategoriaId,
                    .Precio = p.Precio,
                    .Existencia = p.Existencia,
                    .VersionFila = p.VersionFila
                }).
                ToListAsync()

                dgvProductos.DataSource = lista
                FormatearGrilla()
                lblEstado.Text = $"{lista.Count} producto(s) cargado(s)"
            End Using
        Finally
            EstablecerOcupado(False)
        End Try
    End Function

    Private Sub FormatearGrilla()
        With dgvProductos.Columns
            .Item("CategoriaId").Visible = False
            .Item("Id").FillWeight = 30
            .Item("Nombre").FillWeight = 160
            .Item("Precio").DefaultCellStyle.Format = "'C$' #,##0.00"
            .Item("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("VersionFila").HeaderText = "Versión"
        End With
    End Sub

    Private Async Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Await CargarProductosAsync(txtBuscar.Text)
        Catch ex As Exception
            MostrarError("No se pudo realizar la búsqueda.", ex)
        End Try
    End Sub

    ''' <summary>Al seleccionar una fila, se copian sus datos a los controles.</summary>
    Private Sub dgvProductos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductos.SelectionChanged
        Dim fila = TryCast(dgvProductos.CurrentRow?.DataBoundItem, ProductoVista)
        If fila Is Nothing OrElse Not dgvProductos.CurrentRow.Selected Then Return

        _idSeleccionado = fila.Id
        _versionLeida = fila.VersionFila      ' guardamos la versión que vio el usuario
        txtNombre.Text = fila.Nombre
        cboCategoria.SelectedValue = fila.CategoriaId
        nudPrecio.Value = fila.Precio
        nudExistencia.Value = fila.Existencia
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()
        lblEstado.Text = "Escriba los datos del nuevo producto y presione Guardar."
    End Sub

    ' ===================== CREATE =====================
    Private Async Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not DatosValidos() Then Return

        EstablecerOcupado(True, "Guardando…")
        Try
            Using ctx As New AppDbContext()
                Dim nuevo As New Producto With {
                .Nombre = txtNombre.Text.Trim(),
                .CategoriaId = CInt(cboCategoria.SelectedValue),
                .Precio = nudPrecio.Value,
                .Existencia = CInt(nudExistencia.Value),
                .VersionFila = 1
            }
                ctx.Productos.Add(nuevo)          ' estado: Added
                Await ctx.SaveChangesAsync()      ' INSERT + recupera el AUTO_INCREMENT

                lblEstado.Text = $"Producto #{nuevo.Id} guardado."
            End Using
        Catch ex As Exception
            MostrarError("No se pudo guardar el producto.", ex)
        Finally
            EstablecerOcupado(False)
        End Try

        Await CargarProductosAsync()
        LimpiarCampos()
    End Sub

    ' ===================== UPDATE =====================
    Private Async Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If _idSeleccionado = 0 Then
            MessageBox.Show("Seleccione un producto de la lista.", "Actualizar")
            Return
        End If
        If Not DatosValidos() Then Return

        Dim huboConflicto As Boolean = False
        EstablecerOcupado(True, "Actualizando…")
        Try
            Using ctx As New AppDbContext()
                Dim p = Await ctx.Productos.FindAsync(_idSeleccionado)   ' estado: Unchanged
                If p Is Nothing Then
                    huboConflicto = True          ' otro usuario lo eliminó
                Else
                    ' El valor original del token = la versión que vio el usuario
                    ctx.Entry(p).Property(Function(x) x.VersionFila).OriginalValue = _versionLeida

                    p.Nombre = txtNombre.Text.Trim()       ' estado: Modified
                    p.CategoriaId = CInt(cboCategoria.SelectedValue)
                    p.Precio = nudPrecio.Value
                    p.Existencia = CInt(nudExistencia.Value)
                    p.VersionFila = _versionLeida + 1      ' nueva versión

                    Await ctx.SaveChangesAsync()           ' UPDATE … WHERE id AND version
                    lblEstado.Text = $"Producto #{p.Id} actualizado."
                End If
            End Using
        Catch ex As DbUpdateConcurrencyException
            huboConflicto = True                  ' 0 filas afectadas
        Catch ex As Exception
            MostrarError("No se pudo actualizar el producto.", ex)
        Finally
            EstablecerOcupado(False)
        End Try

        If huboConflicto Then
            MessageBox.Show("Otro usuario modificó o eliminó este producto mientras usted lo editaba." &
                        vbCrLf & "Se mostrarán los datos actuales; revise y vuelva a intentarlo.",
                        "Conflicto de concurrencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Await CargarProductosAsync()
    End Sub

    ' ===================== DELETE =====================
    Private Async Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If _idSeleccionado = 0 Then
            MessageBox.Show("Seleccione un producto de la lista.", "Eliminar")
            Return
        End If

        Dim r = MessageBox.Show($"¿Eliminar definitivamente ""{txtNombre.Text}""?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If r <> DialogResult.Yes Then Return

        Dim huboConflicto As Boolean = False
        EstablecerOcupado(True, "Eliminando…")
        Try
            Using ctx As New AppDbContext()
                Dim p = Await ctx.Productos.FindAsync(_idSeleccionado)
                If p Is Nothing Then
                    huboConflicto = True
                Else
                    ctx.Entry(p).Property(Function(x) x.VersionFila).OriginalValue = _versionLeida
                    ctx.Productos.Remove(p)                ' estado: Deleted
                    Await ctx.SaveChangesAsync()           ' DELETE … WHERE id AND version
                    lblEstado.Text = "Producto eliminado."
                End If
            End Using
        Catch ex As DbUpdateConcurrencyException
            huboConflicto = True
        Catch ex As Exception
            MostrarError("No se pudo eliminar el producto.", ex)
        Finally
            EstablecerOcupado(False)
        End Try

        If huboConflicto Then
            MessageBox.Show("El producto fue modificado o eliminado por otro usuario.",
                            "Conflicto de concurrencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Await CargarProductosAsync()
        LimpiarCampos()
    End Sub

End Class