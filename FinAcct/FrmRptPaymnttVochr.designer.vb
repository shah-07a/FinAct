<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptPaymnttVochr
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
        Me.CrRptVewPay = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptPayment1 = New FinAcct.CrRptPayment
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Txtvno1 = New System.Windows.Forms.TextBox
        Me.Txtvno2 = New System.Windows.Forms.TextBox
        Me.CmbxAct = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Rball = New System.Windows.Forms.RadioButton
        Me.RbVno = New System.Windows.Forms.RadioButton
        Me.Rbact = New System.Windows.Forms.RadioButton
        Me.ChkRptcbook = New System.Windows.Forms.CheckBox
        Me.BtnRptVewCb = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpCb2 = New System.Windows.Forms.DateTimePicker
        Me.DtpCb1 = New System.Windows.Forms.DateTimePicker
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrRptVewPay
        '
        Me.CrRptVewPay.ActiveViewIndex = 0
        Me.CrRptVewPay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewPay.Location = New System.Drawing.Point(0, 105)
        Me.CrRptVewPay.Name = "CrRptVewPay"
        Me.CrRptVewPay.ReportSource = Me.CrRptPayment1
        Me.CrRptVewPay.ShowGroupTreeButton = False
        Me.CrRptVewPay.ShowRefreshButton = False
        Me.CrRptVewPay.Size = New System.Drawing.Size(1016, 0)
        Me.CrRptVewPay.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Txtvno1)
        Me.Panel1.Controls.Add(Me.Txtvno2)
        Me.Panel1.Controls.Add(Me.CmbxAct)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ChkRptcbook)
        Me.Panel1.Controls.Add(Me.BtnRptVewCb)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpCb2)
        Me.Panel1.Controls.Add(Me.DtpCb1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1015, 98)
        Me.Panel1.TabIndex = 0
        '
        'Txtvno1
        '
        Me.Txtvno1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtvno1.Enabled = False
        Me.Txtvno1.Location = New System.Drawing.Point(553, 64)
        Me.Txtvno1.MaxLength = 10
        Me.Txtvno1.Name = "Txtvno1"
        Me.Txtvno1.Size = New System.Drawing.Size(82, 21)
        Me.Txtvno1.TabIndex = 9
        '
        'Txtvno2
        '
        Me.Txtvno2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtvno2.Enabled = False
        Me.Txtvno2.Location = New System.Drawing.Point(764, 64)
        Me.Txtvno2.MaxLength = 10
        Me.Txtvno2.Name = "Txtvno2"
        Me.Txtvno2.Size = New System.Drawing.Size(82, 21)
        Me.Txtvno2.TabIndex = 10
        '
        'CmbxAct
        '
        Me.CmbxAct.Enabled = False
        Me.CmbxAct.FormattingEnabled = True
        Me.CmbxAct.Location = New System.Drawing.Point(553, 14)
        Me.CmbxAct.Name = "CmbxAct"
        Me.CmbxAct.Size = New System.Drawing.Size(293, 21)
        Me.CmbxAct.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rball)
        Me.GroupBox1.Controls.Add(Me.RbVno)
        Me.GroupBox1.Controls.Add(Me.Rbact)
        Me.GroupBox1.Location = New System.Drawing.Point(231, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 90)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selection Range"
        '
        'Rball
        '
        Me.Rball.AutoSize = True
        Me.Rball.Checked = True
        Me.Rball.Location = New System.Drawing.Point(6, 14)
        Me.Rball.Name = "Rball"
        Me.Rball.Size = New System.Drawing.Size(39, 17)
        Me.Rball.TabIndex = 5
        Me.Rball.TabStop = True
        Me.Rball.Text = "All"
        Me.Rball.UseVisualStyleBackColor = True
        '
        'RbVno
        '
        Me.RbVno.AutoSize = True
        Me.RbVno.Location = New System.Drawing.Point(6, 40)
        Me.RbVno.Name = "RbVno"
        Me.RbVno.Size = New System.Drawing.Size(95, 17)
        Me.RbVno.TabIndex = 6
        Me.RbVno.Text = "Voucher No."
        Me.RbVno.UseVisualStyleBackColor = True
        '
        'Rbact
        '
        Me.Rbact.AutoSize = True
        Me.Rbact.Location = New System.Drawing.Point(6, 64)
        Me.Rbact.Name = "Rbact"
        Me.Rbact.Size = New System.Drawing.Size(128, 17)
        Me.Rbact.TabIndex = 7
        Me.Rbact.Text = "Particular Account"
        Me.Rbact.UseVisualStyleBackColor = True
        '
        'ChkRptcbook
        '
        Me.ChkRptcbook.AutoSize = True
        Me.ChkRptcbook.Checked = True
        Me.ChkRptcbook.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptcbook.Location = New System.Drawing.Point(9, 14)
        Me.ChkRptcbook.Name = "ChkRptcbook"
        Me.ChkRptcbook.Size = New System.Drawing.Size(211, 17)
        Me.ChkRptcbook.TabIndex = 1
        Me.ChkRptcbook.Text = "Company Information Required "
        Me.ChkRptcbook.UseVisualStyleBackColor = True
        '
        'BtnRptVewCb
        '
        Me.BtnRptVewCb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVewCb.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnRptVewCb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewCb.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewCb.Location = New System.Drawing.Point(860, 33)
        Me.BtnRptVewCb.Name = "BtnRptVewCb"
        Me.BtnRptVewCb.Size = New System.Drawing.Size(143, 33)
        Me.BtnRptVewCb.TabIndex = 11
        Me.BtnRptVewCb.Text = "Report View"
        Me.BtnRptVewCb.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(659, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "To  Voucher No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(437, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "From Voucher No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Account Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'DtpCb2
        '
        Me.DtpCb2.CustomFormat = "dd/MM/yyyy"
        Me.DtpCb2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpCb2.Location = New System.Drawing.Point(51, 64)
        Me.DtpCb2.Name = "DtpCb2"
        Me.DtpCb2.Size = New System.Drawing.Size(114, 21)
        Me.DtpCb2.TabIndex = 3
        '
        'DtpCb1
        '
        Me.DtpCb1.CustomFormat = "dd/MM/yyyy"
        Me.DtpCb1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpCb1.Location = New System.Drawing.Point(51, 37)
        Me.DtpCb1.Name = "DtpCb1"
        Me.DtpCb1.Size = New System.Drawing.Size(114, 21)
        Me.DtpCb1.TabIndex = 2
        '
        'FrmRptPaymnttVochr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1017, 101)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrRptVewPay)
        Me.Name = "FrmRptPaymnttVochr"
        Me.Text = "Payment Voucher"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewPay As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ChkRptcbook As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVewCb As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpCb2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpCb1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rball As System.Windows.Forms.RadioButton
    Friend WithEvents RbVno As System.Windows.Forms.RadioButton
    Friend WithEvents Rbact As System.Windows.Forms.RadioButton
    Friend WithEvents Txtvno1 As System.Windows.Forms.TextBox
    Friend WithEvents Txtvno2 As System.Windows.Forms.TextBox
    Friend WithEvents CmbxAct As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CrRptPayment1 As FinAcct.CrRptPayment
End Class
