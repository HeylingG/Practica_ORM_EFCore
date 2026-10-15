<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategorias
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
        txtNombre = New System.Windows.Forms.TextBox()
        dgvCategorias = New System.Windows.Forms.DataGridView()
        btnNuevo = New System.Windows.Forms.Button()
        btnGuardar = New System.Windows.Forms.Button()
        btnActualizar = New System.Windows.Forms.Button()
        btnEliminar = New System.Windows.Forms.Button()
        lblNombreCategoria = New System.Windows.Forms.Label()
        lblEstado = New System.Windows.Forms.Label()
        CType(dgvCategorias, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New System.Drawing.Point(50, 50)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New System.Drawing.Size(392, 23)
        txtNombre.TabIndex = 0
        ' 
        ' dgvCategorias
        ' 
        dgvCategorias.BackgroundColor = Drawing.SystemColors.ControlDarkDark
        dgvCategorias.Location = New System.Drawing.Point(30, 181)
        dgvCategorias.Name = "dgvCategorias"
        dgvCategorias.Size = New System.Drawing.Size(461, 311)
        dgvCategorias.TabIndex = 0
        ' 
        ' btnNuevo
        ' 
        btnNuevo.BackColor = Drawing.Color.ForestGreen
        btnNuevo.ForeColor = Drawing.SystemColors.ControlLightLight
        btnNuevo.Location = New System.Drawing.Point(158, 98)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New System.Drawing.Size(77, 30)
        btnNuevo.TabIndex = 1
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = False
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Drawing.Color.CornflowerBlue
        btnGuardar.ForeColor = Drawing.SystemColors.ControlLightLight
        btnGuardar.Location = New System.Drawing.Point(257, 98)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New System.Drawing.Size(77, 30)
        btnGuardar.TabIndex = 3
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' btnActualizar
        ' 
        btnActualizar.BackColor = Drawing.SystemColors.ControlDarkDark
        btnActualizar.ForeColor = Drawing.SystemColors.ControlLightLight
        btnActualizar.Location = New System.Drawing.Point(351, 96)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New System.Drawing.Size(77, 30)
        btnActualizar.TabIndex = 4
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = Drawing.Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnEliminar.ForeColor = Drawing.SystemColors.ControlLightLight
        btnEliminar.Location = New System.Drawing.Point(60, 96)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New System.Drawing.Size(77, 30)
        btnEliminar.TabIndex = 5
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' lblNombreCategoria
        ' 
        lblNombreCategoria.AutoSize = True
        lblNombreCategoria.Font = New System.Drawing.Font("Segoe UI", 12F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblNombreCategoria.Location = New System.Drawing.Point(50, 26)
        lblNombreCategoria.Name = "lblNombreCategoria"
        lblNombreCategoria.Size = New System.Drawing.Size(172, 21)
        lblNombreCategoria.TabIndex = 6
        lblNombreCategoria.Text = "Nombre de a categoría:"
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.Font = New System.Drawing.Font("Segoe UI", 11.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblEstado.Location = New System.Drawing.Point(50, 147)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New System.Drawing.Size(182, 20)
        lblEstado.TabIndex = 7
        lblEstado.Text = "Estado de las operaciones"
        ' 
        ' FrmCategorias
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(7F, 15F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(528, 516)
        Controls.Add(lblEstado)
        Controls.Add(lblNombreCategoria)
        Controls.Add(btnEliminar)
        Controls.Add(btnActualizar)
        Controls.Add(btnGuardar)
        Controls.Add(btnNuevo)
        Controls.Add(dgvCategorias)
        Controls.Add(txtNombre)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmCategorias"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Text = "FrmCategorias"
        CType(dgvCategorias, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents dgvCategorias As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblNombreCategoria As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
End Class
