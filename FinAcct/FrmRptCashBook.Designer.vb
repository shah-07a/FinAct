<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCashBook
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
        Me.CrRptVewCBook = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptCashBook1 = New FinAcct.CrRptCashBook
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ChkRptcbook = New System.Windows.Forms.CheckBox
        Me.BtnRptVewCb = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpCb2 = New System.Windows.Forms.DateTimePicker
        Me.DtpCb1 = New System.Windows.Forms.DateTimePicker
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrRptVewCBook
        '
        Me.CrRptVewCBook.ActiveViewIndex = 0
        Me.CrRptVewCBook.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewCBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewCBook.Location = New System.Drawing.Point(0, 52)
        Me.CrRptVewCBook.Name = "CrRptVewCBook"
        Me.CrRptVewCBook.ReportSource = Me.CrRptCashBook1
        Me.CrRptVewCBook.ShowRefreshButton = False
        Me.CrRptVewCBook.Size = New System.Drawing.Size(1016, 0)
        Me.CrRptVewCBook.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ChkRptcbook)
        Me.Panel1.Controls.Add(Me.BtnRptVewCb)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpCb2)
        Me.Panel1.Controls.Add(Me.DtpCb1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1015, 48)
        Me.Panel1.TabIndex = 0
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
        Me.BtnRptVewCb.Location = New System.Drawing.Point(863, 7)
        Me.BtnRptVewCb.Name = "BtnRptVewCb"
        Me.BtnRptVewCb.Size = New System.Drawing.Size(143, 33)
        Me.BtnRptVewCb.TabIndex = 4
        Me.BtnRptVewCb.Text = "Report View"
        Me.BtnRptVewCb.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(493, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(315, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'DtpCb2
        '
        Me.DtpCb2.CustomFormat = "dd/MM/yyyy"
        Me.DtpCb2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpCb2.Location = New System.Drawing.Point(535, 14)
        Me.DtpCb2.Name = "DtpCb2"
        Me.DtpCb2.Size = New System.Drawing.Size(114, 21)
        Me.DtpCb2.TabIndex = 3
        '
        'DtpCb1
        '
        Me.DtpCb1.CustomFormat = "dd/MM/yyyy"
        Me.DtpCb1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpCb1.Location = New System.Drawing.Point(357, 14)
        Me.DtpCb1.Name = "DtpCb1"
        Me.DtpCb1.Size = New System.Drawing.Size(114, 21)
        Me.DtpCb1.TabIndex = 2
        '
        'FrmRptCashBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1017, 51)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrRptVewCBook)
        Me.Name = "FrmRptCashBook"
        Me.Text = "Report Cash Book"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewCBook As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptCashBook1 As FinAcct.CrRptCashBook
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ChkRptcbook As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVewCb As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpCb2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpCb1 As System.Windows.Forms.DateTimePicker
End Class
