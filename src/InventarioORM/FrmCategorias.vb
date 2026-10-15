
Imports System
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Microsoft.EntityFrameworkCore

Public Class FrmCategorias

    Private _idSeleccionado As Integer = 0
    Private _cargandoFormulario As Boolean = True

    ' CARGA INICIAL
    Private Async Sub FrmCategorias_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        _cargandoFormulario = True

        Try
            dgvCategorias.AutoGenerateColumns = True
            dgvCategorias.ReadOnly = True
            dgvCategorias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect
            dgvCategorias.MultiSelect = False
            dgvCategorias.AllowUserToAddRows = False
            dgvCategorias.AllowUserToDeleteRows = False
            dgvCategorias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill
            dgvCategorias.DataSource = Nothing

            Await CargarCategoriasAsync()

        Catch ex As Exception
            MostrarError("No se pudieron cargar las categorías.", ex)
        Finally
            _cargandoFormulario = False
        End Try

    End Sub

    ' CARGAR CATEGORÍAS EN LA TABLA
    Private Async Function CargarCategoriasAsync() As Task

        Using ctx As New AppDbContext()

            Dim lista As List(Of Categoria) =
                Await ctx.Categorias _
                    .AsNoTracking() _
                    .OrderBy(Function(c) c.Nombre) _
                    .ToListAsync()

            dgvCategorias.DataSource = Nothing
            dgvCategorias.DataSource = lista

            If dgvCategorias.Columns.Contains("Id") Then
                dgvCategorias.Columns("Id").HeaderText = "Código"
                dgvCategorias.Columns("Id").FillWeight = 25
            End If

            If dgvCategorias.Columns.Contains("Nombre") Then
                dgvCategorias.Columns("Nombre").HeaderText =
                    "Nombre de categoría"
                dgvCategorias.Columns("Nombre").FillWeight = 100
            End If

            ' Ocultar propiedades de navegación si existen
            For Each columna As DataGridViewColumn In dgvCategorias.Columns
                If columna.Name <> "Id" AndAlso
                   columna.Name <> "Nombre" Then
                    columna.Visible = False
                End If
            Next

            If lista.Count = 0 Then
                lblEstado.Text = "No hay categorías registradas."
            Else
                lblEstado.Text =
                    lista.Count.ToString() &
                    " categoría(s) cargada(s)."
            End If

        End Using

    End Function

    ' VALIDAR DATOS
    Private Function DatosValidos() As Boolean

        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show(
                "Escriba el nombre de la categoría.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            txtNombre.Focus()
            Return False
        End If

        If txtNombre.Text.Trim().Length > 100 Then
            MessageBox.Show(
                "El nombre no puede superar 100 caracteres.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtNombre.Focus()
            Return False
        End If

        Return True

    End Function

    ' VERIFICAR NOMBRES DUPLICADOS
    Private Async Function ExisteNombreDuplicadoAsync(
        nombre As String,
        Optional idExcluir As Integer = 0
    ) As Task(Of Boolean)

        Dim nombreBuscado As String = nombre.Trim()

        Using ctx As New AppDbContext()
            Return Await ctx.Categorias.AnyAsync(
                Function(c) c.Nombre = nombreBuscado AndAlso
                            c.Id <> idExcluir)
        End Using

    End Function

    ' MOSTRAR ERRORES
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

    ' LIMPIAR CAMPOS
    Private Sub LimpiarCampos()

        _idSeleccionado = 0
        txtNombre.Clear()
        dgvCategorias.ClearSelection()
        txtNombre.Focus()
        lblEstado.Text = "Ingrese una categoría nueva."

    End Sub

    ' SELECCIONAR CATEGORÍA
    Private Sub dgvCategorias_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles dgvCategorias.SelectionChanged

        If _cargandoFormulario Then Return
        If dgvCategorias.CurrentRow Is Nothing Then Return
        If Not dgvCategorias.CurrentRow.Selected Then Return

        Dim fila As Categoria =
            TryCast(dgvCategorias.CurrentRow.DataBoundItem, Categoria)

        If fila Is Nothing Then Return

        _idSeleccionado = fila.Id
        txtNombre.Text = fila.Nombre

    End Sub

    ' NUEVA CATEGORÍA
    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnNuevo.Click

        LimpiarCampos()

    End Sub

    ' GUARDAR CATEGORÍA
    Private Async Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnGuardar.Click

        If Not DatosValidos() Then Return

        Try
            If Await ExisteNombreDuplicadoAsync(txtNombre.Text) Then
                MessageBox.Show(
                    "Ya existe una categoría con ese nombre.",
                    "Categoría duplicada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
                Return
            End If

            Using ctx As New AppDbContext()

                Dim nueva As New Categoria With {
                    .Nombre = txtNombre.Text.Trim()
                }

                ctx.Categorias.Add(nueva)
                Await ctx.SaveChangesAsync()

            End Using

            Await CargarCategoriasAsync()
            LimpiarCampos()

            MessageBox.Show(
                "Categoría guardada correctamente.",
                "Categorías",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception
            MostrarError("No se pudo guardar la categoría.", ex)
        End Try

    End Sub

    ' ACTUALIZAR CATEGORÍA
    Private Async Sub btnActualizar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnActualizar.Click

        If _idSeleccionado = 0 Then
            MessageBox.Show(
                "Seleccione una categoría de la lista.",
                "Actualizar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        If Not DatosValidos() Then Return

        Try
            If Await ExisteNombreDuplicadoAsync(
                txtNombre.Text, _idSeleccionado) Then

                MessageBox.Show(
                    "Ya existe otra categoría con ese nombre.",
                    "Categoría duplicada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
                Return
            End If

            Using ctx As New AppDbContext()

                Dim categoria =
                    Await ctx.Categorias.FindAsync(_idSeleccionado)

                If categoria Is Nothing Then
                    MessageBox.Show(
                        "La categoría ya no existe.",
                        "Actualizar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
                    Await CargarCategoriasAsync()
                    LimpiarCampos()
                    Return
                End If

                categoria.Nombre = txtNombre.Text.Trim()
                Await ctx.SaveChangesAsync()

            End Using

            Await CargarCategoriasAsync()
            LimpiarCampos()

            MessageBox.Show(
                "Categoría actualizada correctamente.",
                "Categorías",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception
            MostrarError("No se pudo actualizar la categoría.", ex)
        End Try

    End Sub

    ' ELIMINAR CATEGORÍA
    Private Async Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEliminar.Click

        If _idSeleccionado = 0 Then
            MessageBox.Show(
                "Seleccione una categoría de la lista.",
                "Eliminar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        Try
            Using ctx As New AppDbContext()

                Dim cantidadProductos As Integer =
                    Await ctx.Productos.CountAsync(
                        Function(p) p.CategoriaId = _idSeleccionado)

                If cantidadProductos > 0 Then
                    MessageBox.Show(
                        "No se puede eliminar esta categoría porque " &
                        cantidadProductos.ToString() &
                        " producto(s) la utilizan.",
                        "Categoría en uso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
                    Return
                End If

                Dim respuesta As DialogResult = MessageBox.Show(
                    "¿Desea eliminar la categoría """ &
                    txtNombre.Text & """?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)

                If respuesta <> DialogResult.Yes Then Return

                Dim categoria =
                    Await ctx.Categorias.FindAsync(_idSeleccionado)

                If categoria Is Nothing Then
                    MessageBox.Show(
                        "La categoría ya no existe.",
                        "Eliminar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
                    Await CargarCategoriasAsync()
                    LimpiarCampos()
                    Return
                End If

                ctx.Categorias.Remove(categoria)
                Await ctx.SaveChangesAsync()

            End Using

            Await CargarCategoriasAsync()
            LimpiarCampos()

            MessageBox.Show(
                "Categoría eliminada correctamente.",
                "Categorías",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception
            MostrarError("No se pudo eliminar la categoría.", ex)
        End Try

    End Sub

End Class
