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
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudPrecio, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudExistencia, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New System.Drawing.Point(104, 24)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New System.Drawing.Size(340, 31)
        txtBuscar.TabIndex = 0
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New System.Drawing.Point(676, 128)
        txtNombre.MaxLength = 100
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New System.Drawing.Size(249, 31)
        txtNombre.TabIndex = 1
        ' 
        ' btnBuscar
        ' 
        btnBuscar.BackColor = Drawing.Color.DarkSlateBlue
        btnBuscar.Font = New System.Drawing.Font("Segoe UI", 9F, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, CByte(0))
        btnBuscar.ForeColor = Drawing.Color.White
        btnBuscar.Location = New System.Drawing.Point(468, 25)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New System.Drawing.Size(112, 34)
        btnBuscar.TabIndex = 2
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New System.Drawing.Point(676, 434)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New System.Drawing.Size(112, 34)
        btnNuevo.TabIndex = 3
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Drawing.Color.DarkSlateBlue
        btnGuardar.Font = New System.Drawing.Font("Segoe UI", 9F, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, CByte(0))
        btnGuardar.ForeColor = Drawing.Color.White
        btnGuardar.Location = New System.Drawing.Point(833, 434)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New System.Drawing.Size(112, 34)
        btnGuardar.TabIndex = 4
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' btnActualizar
        ' 
        btnActualizar.BackColor = Drawing.Color.DarkSlateBlue
        btnActualizar.Font = New System.Drawing.Font("Segoe UI", 9F, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, CByte(0))
        btnActualizar.ForeColor = Drawing.Color.White
        btnActualizar.Location = New System.Drawing.Point(676, 474)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New System.Drawing.Size(112, 34)
        btnActualizar.TabIndex = 5
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = Drawing.Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnEliminar.Font = New System.Drawing.Font("Segoe UI", 9F, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, CByte(0))
        btnEliminar.ForeColor = Drawing.Color.White
        btnEliminar.Location = New System.Drawing.Point(833, 474)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New System.Drawing.Size(112, 34)
        btnEliminar.TabIndex = 6
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New System.Drawing.Point(25, 27)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New System.Drawing.Size(67, 25)
        lblBuscar.TabIndex = 7
        lblBuscar.Text = "Buscar:"
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Location = New System.Drawing.Point(676, 100)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New System.Drawing.Size(78, 25)
        lblNombre.TabIndex = 8
        lblNombre.Text = "Nombre"
        ' 
        ' lblCategoria
        ' 
        lblCategoria.AutoSize = True
        lblCategoria.Location = New System.Drawing.Point(676, 185)
        lblCategoria.Name = "lblCategoria"
        lblCategoria.Size = New System.Drawing.Size(88, 25)
        lblCategoria.TabIndex = 9
        lblCategoria.Text = "Categoria"
        ' 
        ' dgvProductos
        ' 
        dgvProductos.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        dgvProductos.BackgroundColor = Drawing.SystemColors.Control
        dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Location = New System.Drawing.Point(25, 80)
        dgvProductos.Name = "dgvProductos"
        dgvProductos.RowHeadersWidth = 62
        dgvProductos.Size = New System.Drawing.Size(613, 405)
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
        cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboCategoria.FormattingEnabled = True
        cboCategoria.Location = New System.Drawing.Point(676, 222)
        cboCategoria.Name = "cboCategoria"
        cboCategoria.Size = New System.Drawing.Size(249, 33)
        cboCategoria.TabIndex = 12
        ' 
        ' lblPrecio
        ' 
        lblPrecio.AutoSize = True
        lblPrecio.Location = New System.Drawing.Point(676, 274)
        lblPrecio.Name = "lblPrecio"
        lblPrecio.Size = New System.Drawing.Size(96, 25)
        lblPrecio.TabIndex = 13
        lblPrecio.Text = "Precio (C$)"
        ' 
        ' nudPrecio
        ' 
        nudPrecio.DecimalPlaces = 2
        nudPrecio.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        nudPrecio.Location = New System.Drawing.Point(676, 302)
        nudPrecio.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        nudPrecio.Name = "nudPrecio"
        nudPrecio.Size = New System.Drawing.Size(180, 31)
        nudPrecio.TabIndex = 14
        ' 
        ' nudExistencia
        ' 
        nudExistencia.Location = New System.Drawing.Point(676, 384)
        nudExistencia.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        nudExistencia.Name = "nudExistencia"
        nudExistencia.Size = New System.Drawing.Size(180, 31)
        nudExistencia.TabIndex = 15
        ' 
        ' lblExistencia
        ' 
        lblExistencia.AutoSize = True
        lblExistencia.Location = New System.Drawing.Point(676, 356)
        lblExistencia.Name = "lblExistencia"
        lblExistencia.Size = New System.Drawing.Size(87, 25)
        lblExistencia.TabIndex = 16
        lblExistencia.Text = "Existencia"
        ' 
        ' lblEstado
        ' 
        lblEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        lblEstado.Location = New System.Drawing.Point(0, 519)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New System.Drawing.Size(957, 38)
        lblEstado.TabIndex = 17
        lblEstado.Text = "Estado"
        ' 
        ' FrmProductos
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(10F, 25F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(957, 557)
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
End Class
