<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txtBuscar = New System.Windows.Forms.TextBox()
        txtNombre = New System.Windows.Forms.TextBox()
        btnBuscar = New System.Windows.Forms.Button()
        btnNuevo = New System.Windows.Forms.Button()
        btnGuardar = New System.Windows.Forms.Button()
        btnActualizar = New System.Windows.Forms.Button()
        btnEliminar = New System.Windows.Forms.Button()
        lblBuscar = New System.Windows.Forms.Label()
        lblNombre = New System.Windows.Forms.Label()
        lblCategoria = New System.Windows.Forms.Label()
        dgvProductos = New System.Windows.Forms.DataGridView()
        MySqlCommand1 = New MySqlConnector.MySqlCommand()
        cboCategoria = New System.Windows.Forms.ComboBox()
        lblPrecio = New System.Windows.Forms.Label()
        nudPrecio = New System.Windows.Forms.NumericUpDown()
        nudExistencia = New System.Windows.Forms.NumericUpDown()
        lblExistencia = New System.Windows.Forms.Label()
        lblEstado = New System.Windows.Forms.Label()
        lblFiltroCategoria = New System.Windows.Forms.Label()
        cboFiltroCategoria = New System.Windows.Forms.ComboBox()
        chkBajoStock = New System.Windows.Forms.CheckBox()
        lblValorInventario = New System.Windows.Forms.Label()
        txtCodigoBarras = New System.Windows.Forms.TextBox()
        btnCategorias = New System.Windows.Forms.Button()
        btnCodigoBarras = New System.Windows.Forms.Button()
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudPrecio, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudExistencia, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New System.Drawing.Point(67, 14)
        txtBuscar.Margin = New System.Windows.Forms.Padding(2)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New System.Drawing.Size(279, 23)
        txtBuscar.TabIndex = 0
        ' 
        ' txtNombre
        ' 
        txtNombre.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        txtNombre.Location = New System.Drawing.Point(552, 85)
        txtNombre.Margin = New System.Windows.Forms.Padding(2)
        txtNombre.MaxLength = 100
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New System.Drawing.Size(176, 23)
        txtNombre.TabIndex = 1
        ' 
        ' btnBuscar
        ' 
        btnBuscar.BackColor = Drawing.Color.DarkSlateBlue
        btnBuscar.Font = New System.Drawing.Font("Segoe UI", 9F, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, CByte(0))
        btnBuscar.ForeColor = Drawing.Color.White
        btnBuscar.Location = New System.Drawing.Point(362, 14)
        btnBuscar.Margin = New System.Windows.Forms.Padding(2)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New System.Drawing.Size(78, 25)
        btnBuscar.TabIndex = 2
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
        btnNuevo.Location = New System.Drawing.Point(554, 365)
        btnNuevo.Margin = New System.Windows.Forms.Padding(2)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New System.Drawing.Size(78, 25)
        btnNuevo.TabIndex = 3
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
        btnGuardar.BackColor = Drawing.Color.DarkSlateBlue
        btnGuardar.Font = New System.Drawing.Font("Segoe UI", 9F, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, CByte(0))
        btnGuardar.ForeColor = Drawing.Color.White
        btnGuardar.Location = New System.Drawing.Point(650, 365)
        btnGuardar.Margin = New System.Windows.Forms.Padding(2)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New System.Drawing.Size(78, 25)
        btnGuardar.TabIndex = 4
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
        btnActualizar.BackColor = Drawing.Color.DarkSlateBlue
        btnActualizar.Font = New System.Drawing.Font("Segoe UI", 9F, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, CByte(0))
        btnActualizar.ForeColor = Drawing.Color.White
        btnActualizar.Location = New System.Drawing.Point(554, 389)
        btnActualizar.Margin = New System.Windows.Forms.Padding(2)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New System.Drawing.Size(78, 25)
        btnActualizar.TabIndex = 5
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
        btnEliminar.BackColor = Drawing.Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnEliminar.Font = New System.Drawing.Font("Segoe UI", 9F, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, CByte(0))
        btnEliminar.ForeColor = Drawing.Color.White
        btnEliminar.Location = New System.Drawing.Point(650, 389)
        btnEliminar.Margin = New System.Windows.Forms.Padding(2)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New System.Drawing.Size(78, 25)
        btnEliminar.TabIndex = 6
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New System.Drawing.Point(18, 16)
        lblBuscar.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New System.Drawing.Size(45, 15)
        lblBuscar.TabIndex = 7
        lblBuscar.Text = "Buscar:"
        ' 
        ' lblNombre
        ' 
        lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        lblNombre.AutoSize = True
        lblNombre.Location = New System.Drawing.Point(552, 68)
        lblNombre.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New System.Drawing.Size(51, 15)
        lblNombre.TabIndex = 8
        lblNombre.Text = "Nombre"
        ' 
        ' lblCategoria
        ' 
        lblCategoria.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        lblCategoria.AutoSize = True
        lblCategoria.Location = New System.Drawing.Point(552, 119)
        lblCategoria.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        lblCategoria.Name = "lblCategoria"
        lblCategoria.Size = New System.Drawing.Size(58, 15)
        lblCategoria.TabIndex = 9
        lblCategoria.Text = "Categoria"
        ' 
        ' dgvProductos
        ' 
        dgvProductos.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        dgvProductos.BackgroundColor = Drawing.SystemColors.Control
        dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Location = New System.Drawing.Point(11, 105)
        dgvProductos.Margin = New System.Windows.Forms.Padding(2)
        dgvProductos.Name = "dgvProductos"
        dgvProductos.RowHeadersWidth = 62
        dgvProductos.Size = New System.Drawing.Size(510, 267)
        dgvProductos.TabIndex = 11
        ' 
        ' MySqlCommand1
        ' 
        MySqlCommand1.CommandTimeout = 0
        MySqlCommand1.Connection = Nothing
        MySqlCommand1.Transaction = Nothing
        MySqlCommand1.UpdatedRowSource = Data.UpdateRowSource.None
        ' 
        ' cboCategoria
        ' 
        cboCategoria.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboCategoria.FormattingEnabled = True
        cboCategoria.Location = New System.Drawing.Point(552, 136)
        cboCategoria.Margin = New System.Windows.Forms.Padding(2)
        cboCategoria.Name = "cboCategoria"
        cboCategoria.Size = New System.Drawing.Size(176, 23)
        cboCategoria.TabIndex = 12
        ' 
        ' lblPrecio
        ' 
        lblPrecio.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        lblPrecio.AutoSize = True
        lblPrecio.Location = New System.Drawing.Point(552, 173)
        lblPrecio.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        lblPrecio.Name = "lblPrecio"
        lblPrecio.Size = New System.Drawing.Size(65, 15)
        lblPrecio.TabIndex = 13
        lblPrecio.Text = "Precio (C$)"
        ' 
        ' nudPrecio
        ' 
        nudPrecio.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        nudPrecio.DecimalPlaces = 2
        nudPrecio.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        nudPrecio.Location = New System.Drawing.Point(552, 190)
        nudPrecio.Margin = New System.Windows.Forms.Padding(2)
        nudPrecio.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        nudPrecio.Name = "nudPrecio"
        nudPrecio.Size = New System.Drawing.Size(126, 23)
        nudPrecio.TabIndex = 14
        ' 
        ' nudExistencia
        ' 
        nudExistencia.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        nudExistencia.Location = New System.Drawing.Point(552, 249)
        nudExistencia.Margin = New System.Windows.Forms.Padding(2)
        nudExistencia.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        nudExistencia.Name = "nudExistencia"
        nudExistencia.Size = New System.Drawing.Size(126, 23)
        nudExistencia.TabIndex = 15
        ' 
        ' lblExistencia
        ' 
        lblExistencia.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        lblExistencia.AutoSize = True
        lblExistencia.Location = New System.Drawing.Point(552, 232)
        lblExistencia.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        lblExistencia.Name = "lblExistencia"
        lblExistencia.Size = New System.Drawing.Size(58, 15)
        lblExistencia.TabIndex = 16
        lblExistencia.Text = "Existencia"
        ' 
        ' lblEstado
        ' 
        lblEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        lblEstado.Location = New System.Drawing.Point(0, 416)
        lblEstado.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New System.Drawing.Size(751, 23)
        lblEstado.TabIndex = 17
        lblEstado.Text = "Estado"
        ' 
        ' lblFiltroCategoria
        ' 
        lblFiltroCategoria.AutoSize = True
        lblFiltroCategoria.Location = New System.Drawing.Point(18, 60)
        lblFiltroCategoria.Name = "lblFiltroCategoria"
        lblFiltroCategoria.Size = New System.Drawing.Size(113, 15)
        lblFiltroCategoria.TabIndex = 18
        lblFiltroCategoria.Text = "Filtrar por categoría:"
        ' 
        ' cboFiltroCategoria
        ' 
        cboFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboFiltroCategoria.FormattingEnabled = True
        cboFiltroCategoria.Location = New System.Drawing.Point(137, 60)
        cboFiltroCategoria.Name = "cboFiltroCategoria"
        cboFiltroCategoria.Size = New System.Drawing.Size(209, 23)
        cboFiltroCategoria.TabIndex = 19
        ' 
        ' chkBajoStock
        ' 
        chkBajoStock.AutoSize = True
        chkBajoStock.Location = New System.Drawing.Point(356, 62)
        chkBajoStock.Name = "chkBajoStock"
        chkBajoStock.Size = New System.Drawing.Size(165, 19)
        chkBajoStock.TabIndex = 20
        chkBajoStock.Text = "Solo existencia menor a 10"
        chkBajoStock.UseVisualStyleBackColor = True
        ' 
        ' lblValorInventario
        ' 
        lblValorInventario.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left
        lblValorInventario.AutoSize = True
        lblValorInventario.Location = New System.Drawing.Point(12, 389)
        lblValorInventario.Name = "lblValorInventario"
        lblValorInventario.Size = New System.Drawing.Size(179, 15)
        lblValorInventario.TabIndex = 21
        lblValorInventario.Text = "Valor total del inventario: C$ 0.00"
        ' 
        ' txtCodigoBarras
        ' 
        txtCodigoBarras.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        txtCodigoBarras.Location = New System.Drawing.Point(552, 288)
        txtCodigoBarras.Name = "txtCodigoBarras"
        txtCodigoBarras.Size = New System.Drawing.Size(174, 23)
        txtCodigoBarras.TabIndex = 22
        ' 
        ' btnCategorias
        ' 
        btnCategorias.Location = New System.Drawing.Point(455, 14)
        btnCategorias.Name = "btnCategorias"
        btnCategorias.Size = New System.Drawing.Size(75, 25)
        btnCategorias.TabIndex = 23
        btnCategorias.Text = "Categorías"
        btnCategorias.UseVisualStyleBackColor = True
        ' 
        ' btnCodigoBarras
        ' 
        btnCodigoBarras.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        btnCodigoBarras.Location = New System.Drawing.Point(589, 317)
        btnCodigoBarras.Name = "btnCodigoBarras"
        btnCodigoBarras.Size = New System.Drawing.Size(108, 23)
        btnCodigoBarras.TabIndex = 24
        btnCodigoBarras.Text = "Código de barras "
        btnCodigoBarras.UseVisualStyleBackColor = True
        ' 
        ' FrmProductos
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(7F, 15F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(751, 439)
        Controls.Add(btnCodigoBarras)
        Controls.Add(btnCategorias)
        Controls.Add(txtCodigoBarras)
        Controls.Add(lblValorInventario)
        Controls.Add(chkBajoStock)
        Controls.Add(cboFiltroCategoria)
        Controls.Add(lblFiltroCategoria)
        Controls.Add(lblEstado)
        Controls.Add(lblExistencia)
        Controls.Add(nudExistencia)
        Controls.Add(nudPrecio)
        Controls.Add(lblPrecio)
        Controls.Add(cboCategoria)
        Controls.Add(dgvProductos)
        Controls.Add(lblCategoria)
        Controls.Add(lblNombre)
        Controls.Add(lblBuscar)
        Controls.Add(btnEliminar)
        Controls.Add(btnActualizar)
        Controls.Add(btnGuardar)
        Controls.Add(btnNuevo)
        Controls.Add(btnBuscar)
        Controls.Add(txtNombre)
        Controls.Add(txtBuscar)
        Margin = New System.Windows.Forms.Padding(2)
        Name = "FrmProductos"
        Text = "FrmProductos"
        CType(dgvProductos, ComponentModel.ISupportInitialize).EndInit()
        CType(nudPrecio, ComponentModel.ISupportInitialize).EndInit()
        CType(nudExistencia, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents MySqlCommand1 As MySqlConnector.MySqlCommand
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents nudPrecio As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudExistencia As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblExistencia As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblFiltroCategoria As System.Windows.Forms.Label
    Friend WithEvents cboFiltroCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents chkBajoStock As System.Windows.Forms.CheckBox
    Friend WithEvents lblValorInventario As System.Windows.Forms.Label
    Friend WithEvents txtCodigoBarras As System.Windows.Forms.TextBox
    Friend WithEvents btnCategorias As System.Windows.Forms.Button
    Friend WithEvents btnCodigoBarras As System.Windows.Forms.Button
End Class
