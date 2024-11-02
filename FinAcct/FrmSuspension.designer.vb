<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSuspension
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpkrDt = New System.Windows.Forms.DateTimePicker
        Me.Label31 = New System.Windows.Forms.Label
        Me.CmbxEmp = New System.Windows.Forms.ComboBox
        Me.DtpkrFrm = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DtpkrTo = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PnlSuspnd = New System.Windows.Forms.Panel
        Me.TxtResn = New System.Windows.Forms.TextBox
        Me.LblEmpid = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnFnd = New System.Windows.Forms.Button
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.BtnCls = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.LstSuspnd = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.PnlSuspnd.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Employee Name:-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpkrDt
        '
        Me.DtpkrDt.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrDt.Location = New System.Drawing.Point(128, 11)
        Me.DtpkrDt.Name = "DtpkrDt"
        Me.DtpkrDt.Size = New System.Drawing.Size(86, 20)
        Me.DtpkrDt.TabIndex = 75
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(15, 11)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 20)
        Me.Label31.TabIndex = 76
        Me.Label31.Text = "Date:-"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxEmp
        '
        Me.CmbxEmp.FormattingEnabled = True
        Me.CmbxEmp.Location = New System.Drawing.Point(128, 51)
        Me.CmbxEmp.Name = "CmbxEmp"
        Me.CmbxEmp.Size = New System.Drawing.Size(185, 21)
        Me.CmbxEmp.TabIndex = 78
        '
        'DtpkrFrm
        '
        Me.DtpkrFrm.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrFrm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrFrm.Location = New System.Drawing.Point(128, 97)
        Me.DtpkrFrm.Name = "DtpkrFrm"
        Me.DtpkrFrm.Size = New System.Drawing.Size(86, 20)
        Me.DtpkrFrm.TabIndex = 79
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 20)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "From:-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpkrTo
        '
        Me.DtpkrTo.CustomFormat = "dd/MM/yyyy"
        Me.DtpkrTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpkrTo.Location = New System.Drawing.Point(401, 97)
        Me.DtpkrTo.Name = "DtpkrTo"
        Me.DtpkrTo.Size = New System.Drawing.Size(86, 20)
        Me.DtpkrTo.TabIndex = 81
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(336, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 20)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "To:-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 20)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Reason:-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlSuspnd
        '
        Me.PnlSuspnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlSuspnd.Controls.Add(Me.TxtResn)
        Me.PnlSuspnd.Controls.Add(Me.LblEmpid)
        Me.PnlSuspnd.Controls.Add(Me.Label5)
        Me.PnlSuspnd.Controls.Add(Me.Label31)
        Me.PnlSuspnd.Controls.Add(Me.DtpkrDt)
        Me.PnlSuspnd.Controls.Add(Me.Label4)
        Me.PnlSuspnd.Controls.Add(Me.Label1)
        Me.PnlSuspnd.Controls.Add(Me.DtpkrTo)
        Me.PnlSuspnd.Controls.Add(Me.CmbxEmp)
        Me.PnlSuspnd.Controls.Add(Me.Label3)
        Me.PnlSuspnd.Controls.Add(Me.Label2)
        Me.PnlSuspnd.Controls.Add(Me.DtpkrFrm)
        Me.PnlSuspnd.Location = New System.Drawing.Point(8, 12)
        Me.PnlSuspnd.Name = "PnlSuspnd"
        Me.PnlSuspnd.Size = New System.Drawing.Size(515, 273)
        Me.PnlSuspnd.TabIndex = 85
        '
        'TxtResn
        '
        Me.TxtResn.Location = New System.Drawing.Point(128, 146)
        Me.TxtResn.Multiline = True
        Me.TxtResn.Name = "TxtResn"
        Me.TxtResn.Size = New System.Drawing.Size(234, 93)
        Me.TxtResn.TabIndex = 87
        '
        'LblEmpid
        '
        Me.LblEmpid.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LblEmpid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEmpid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmpid.Location = New System.Drawing.Point(401, 52)
        Me.LblEmpid.Name = "LblEmpid"
        Me.LblEmpid.Size = New System.Drawing.Size(93, 20)
        Me.LblEmpid.TabIndex = 86
        Me.LblEmpid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(336, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 20)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Emp Id:-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnFnd
        '
        Me.BtnFnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnFnd.Location = New System.Drawing.Point(250, 482)
        Me.BtnFnd.Name = "BtnFnd"
        Me.BtnFnd.Size = New System.Drawing.Size(75, 23)
        Me.BtnFnd.TabIndex = 87
        Me.BtnFnd.Text = "&Find"
        Me.BtnFnd.UseVisualStyleBackColor = True
        '
        'BtnCncl
        '
        Me.BtnCncl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCncl.Location = New System.Drawing.Point(347, 482)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(75, 23)
        Me.BtnCncl.TabIndex = 88
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = True
        '
        'BtnCls
        '
        Me.BtnCls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCls.Location = New System.Drawing.Point(443, 482)
        Me.BtnCls.Name = "BtnCls"
        Me.BtnCls.Size = New System.Drawing.Size(75, 23)
        Me.BtnCls.TabIndex = 89
        Me.BtnCls.Text = "&Close"
        Me.BtnCls.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnSave.Location = New System.Drawing.Point(157, 482)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 86
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'LstSuspnd
        '
        Me.LstSuspnd.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LstSuspnd.FullRowSelect = True
        Me.LstSuspnd.GridLines = True
        Me.LstSuspnd.Location = New System.Drawing.Point(12, 325)
        Me.LstSuspnd.Name = "LstSuspnd"
        Me.LstSuspnd.Size = New System.Drawing.Size(555, 199)
        Me.LstSuspnd.TabIndex = 90
        Me.LstSuspnd.UseCompatibleStateImageBehavior = False
        Me.LstSuspnd.View = System.Windows.Forms.View.Details
        Me.LstSuspnd.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Employee Id"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "From Date"
        Me.ColumnHeader4.Width = 75
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "To Date"
        Me.ColumnHeader5.Width = 75
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Reason"
        Me.ColumnHeader8.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Employee Name"
        Me.ColumnHeader9.Width = 120
        '
        'FrmSuspension
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(533, 517)
        Me.Controls.Add(Me.LstSuspnd)
        Me.Controls.Add(Me.BtnFnd)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.BtnCls)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.PnlSuspnd)
        Me.Name = "FrmSuspension"
        Me.Text = "Suspension"
        Me.TopMost = True
        Me.PnlSuspnd.ResumeLayout(False)
        Me.PnlSuspnd.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpkrDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents CmbxEmp As System.Windows.Forms.ComboBox
    Friend WithEvents DtpkrFrm As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtpkrTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PnlSuspnd As System.Windows.Forms.Panel
    Friend WithEvents BtnFnd As System.Windows.Forms.Button
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents BtnCls As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblEmpid As System.Windows.Forms.Label
    Friend WithEvents LstSuspnd As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TxtResn As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
End Class
