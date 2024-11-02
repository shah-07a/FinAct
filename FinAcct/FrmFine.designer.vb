<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFine
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Txtremark = New System.Windows.Forms.TextBox
        Me.Txtdept = New System.Windows.Forms.TextBox
        Me.Cmbxemp = New System.Windows.Forms.ComboBox
        Me.txtid = New System.Windows.Forms.TextBox
        Me.Dtp1 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txtamt = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtdesi = New System.Windows.Forms.TextBox
        Me.Labelemp = New System.Windows.Forms.Label
        Me.Lblempid = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.Btnsave = New System.Windows.Forms.Button
        Me.Btnfind = New System.Windows.Forms.Button
        Me.Btnclos = New System.Windows.Forms.Button
        Me.Btndel = New System.Windows.Forms.Button
        Me.TXTDT = New System.Windows.Forms.TextBox
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TXTDT)
        Me.Panel2.Controls.Add(Me.Txtremark)
        Me.Panel2.Controls.Add(Me.Txtdept)
        Me.Panel2.Controls.Add(Me.Cmbxemp)
        Me.Panel2.Controls.Add(Me.txtid)
        Me.Panel2.Controls.Add(Me.Dtp1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Txtamt)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtdesi)
        Me.Panel2.Controls.Add(Me.Labelemp)
        Me.Panel2.Controls.Add(Me.Lblempid)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Location = New System.Drawing.Point(12, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(576, 212)
        Me.Panel2.TabIndex = 0
        '
        'Txtremark
        '
        Me.Txtremark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtremark.Location = New System.Drawing.Point(147, 178)
        Me.Txtremark.MaxLength = 70
        Me.Txtremark.Name = "Txtremark"
        Me.Txtremark.Size = New System.Drawing.Size(413, 20)
        Me.Txtremark.TabIndex = 6
        '
        'Txtdept
        '
        Me.Txtdept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtdept.Location = New System.Drawing.Point(146, 76)
        Me.Txtdept.Name = "Txtdept"
        Me.Txtdept.ReadOnly = True
        Me.Txtdept.Size = New System.Drawing.Size(226, 20)
        Me.Txtdept.TabIndex = 3
        '
        'Cmbxemp
        '
        Me.Cmbxemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxemp.FormattingEnabled = True
        Me.Cmbxemp.Location = New System.Drawing.Point(146, 44)
        Me.Cmbxemp.Name = "Cmbxemp"
        Me.Cmbxemp.Size = New System.Drawing.Size(226, 21)
        Me.Cmbxemp.TabIndex = 1
        '
        'txtid
        '
        Me.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtid.Location = New System.Drawing.Point(474, 45)
        Me.txtid.MaxLength = 10
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(87, 20)
        Me.txtid.TabIndex = 2
        '
        'Dtp1
        '
        Me.Dtp1.CustomFormat = "dd/MM/yyyy"
        Me.Dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Dtp1.Location = New System.Drawing.Point(146, 13)
        Me.Dtp1.Name = "Dtp1"
        Me.Dtp1.Size = New System.Drawing.Size(96, 20)
        Me.Dtp1.TabIndex = 0
        Me.Dtp1.Value = New Date(2008, 7, 19, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 15)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "Date"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 19)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Remarks"
        '
        'Txtamt
        '
        Me.Txtamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtamt.Location = New System.Drawing.Point(146, 144)
        Me.Txtamt.MaxLength = 10
        Me.Txtamt.Name = "Txtamt"
        Me.Txtamt.Size = New System.Drawing.Size(87, 20)
        Me.Txtamt.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 19)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Fine Amount"
        '
        'txtdesi
        '
        Me.txtdesi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdesi.Location = New System.Drawing.Point(147, 112)
        Me.txtdesi.Name = "txtdesi"
        Me.txtdesi.ReadOnly = True
        Me.txtdesi.Size = New System.Drawing.Size(225, 20)
        Me.txtdesi.TabIndex = 4
        '
        'Labelemp
        '
        Me.Labelemp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelemp.Location = New System.Drawing.Point(14, 46)
        Me.Labelemp.Name = "Labelemp"
        Me.Labelemp.Size = New System.Drawing.Size(115, 19)
        Me.Labelemp.TabIndex = 90
        Me.Labelemp.Text = "Employee Name"
        '
        'Lblempid
        '
        Me.Lblempid.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblempid.Location = New System.Drawing.Point(376, 44)
        Me.Lblempid.Name = "Lblempid"
        Me.Lblempid.Size = New System.Drawing.Size(91, 19)
        Me.Lblempid.TabIndex = 89
        Me.Lblempid.Text = "Employee Id"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 19)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "Designation  Name"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 19)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Department  Name"
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 230)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(573, 199)
        Me.ListView1.TabIndex = 3232
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        Me.ListView1.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Employee Code"
        Me.ColumnHeader2.Width = 92
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Employee Name"
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Fine Amount"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 93
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Remarks"
        Me.ColumnHeader5.Width = 165
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "id"
        Me.ColumnHeader6.Width = 0
        '
        'Btnsave
        '
        Me.Btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnsave.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnsave.Location = New System.Drawing.Point(251, 439)
        Me.Btnsave.Name = "Btnsave"
        Me.Btnsave.Size = New System.Drawing.Size(75, 28)
        Me.Btnsave.TabIndex = 7
        Me.Btnsave.Text = "&Save"
        Me.Btnsave.UseVisualStyleBackColor = False
        '
        'Btnfind
        '
        Me.Btnfind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnfind.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Btnfind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnfind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnfind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnfind.Location = New System.Drawing.Point(337, 439)
        Me.Btnfind.Name = "Btnfind"
        Me.Btnfind.Size = New System.Drawing.Size(77, 28)
        Me.Btnfind.TabIndex = 8
        Me.Btnfind.Text = "&Find"
        Me.Btnfind.UseVisualStyleBackColor = False
        '
        'Btnclos
        '
        Me.Btnclos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnclos.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Btnclos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnclos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnclos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnclos.Location = New System.Drawing.Point(501, 439)
        Me.Btnclos.Name = "Btnclos"
        Me.Btnclos.Size = New System.Drawing.Size(73, 28)
        Me.Btnclos.TabIndex = 10
        Me.Btnclos.Text = "&Close"
        Me.Btnclos.UseVisualStyleBackColor = False
        '
        'Btndel
        '
        Me.Btndel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btndel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Btndel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btndel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btndel.Location = New System.Drawing.Point(422, 439)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(72, 28)
        Me.Btndel.TabIndex = 9
        Me.Btndel.Text = "&Delete"
        Me.Btndel.UseVisualStyleBackColor = False
        '
        'TXTDT
        '
        Me.TXTDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTDT.Location = New System.Drawing.Point(146, 11)
        Me.TXTDT.MaxLength = 10
        Me.TXTDT.Name = "TXTDT"
        Me.TXTDT.ReadOnly = True
        Me.TXTDT.Size = New System.Drawing.Size(96, 20)
        Me.TXTDT.TabIndex = 0
        Me.TXTDT.Visible = False
        '
        'FrmFine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(590, 471)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Btndel)
        Me.Controls.Add(Me.Btnclos)
        Me.Controls.Add(Me.Btnfind)
        Me.Controls.Add(Me.Btnsave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmFine"
        Me.Text = "Fine Details"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Labelemp As System.Windows.Forms.Label
    Friend WithEvents Lblempid As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txtamt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtdesi As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents Btnfind As System.Windows.Forms.Button
    Friend WithEvents Btnclos As System.Windows.Forms.Button
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents Cmbxemp As System.Windows.Forms.ComboBox
    Friend WithEvents Txtdept As System.Windows.Forms.TextBox
    Friend WithEvents Txtremark As System.Windows.Forms.TextBox
    Friend WithEvents TXTDT As System.Windows.Forms.TextBox
End Class
