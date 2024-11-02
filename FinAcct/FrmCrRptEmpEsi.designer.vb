<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEmpEsi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Combcatgry = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Chbxall = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'Combcatgry
        '
        Me.Combcatgry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combcatgry.FormattingEnabled = True
        Me.Combcatgry.Location = New System.Drawing.Point(205, 51)
        Me.Combcatgry.Name = "Combcatgry"
        Me.Combcatgry.Size = New System.Drawing.Size(476, 21)
        Me.Combcatgry.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Selection Criteria"
        '
        'Chbxall
        '
        Me.Chbxall.AutoSize = True
        Me.Chbxall.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chbxall.Location = New System.Drawing.Point(159, 54)
        Me.Chbxall.Name = "Chbxall"
        Me.Chbxall.Size = New System.Drawing.Size(40, 19)
        Me.Chbxall.TabIndex = 2
        Me.Chbxall.Text = "All"
        Me.Chbxall.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Selection Criteria"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(343, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 18)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(156, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 18)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "From"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(214, 18)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.Size = New System.Drawing.Size(123, 20)
        Me.Dtpick1.TabIndex = 0
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "dd/MM/yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(385, 18)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.Size = New System.Drawing.Size(115, 20)
        Me.dtpick2.TabIndex = 1
        '
        'FrmCrRptEmpEsi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 273)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Dtpick1)
        Me.Controls.Add(Me.dtpick2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Chbxall)
        Me.Controls.Add(Me.Combcatgry)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCrRptEmpEsi"
        Me.Text = "ESI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Combcatgry As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Chbxall As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
End Class
