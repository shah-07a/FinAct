<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptCformRecveivable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ChkRptLdgr = New System.Windows.Forms.CheckBox
        Me.BtnOk = New System.Windows.Forms.Button
        Me.ChkBx1 = New System.Windows.Forms.CheckBox
        Me.CmbxCForm = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DtpTo = New System.Windows.Forms.DateTimePicker
        Me.DtpFrom = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CrRptVewCform = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptCformReceivable1 = New FinAcct.CrRptCformReceivable
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.FinAcct.My.Resources.Resources.SOFTR02C
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.ChkRptLdgr)
        Me.Panel1.Controls.Add(Me.BtnOk)
        Me.Panel1.Controls.Add(Me.ChkBx1)
        Me.Panel1.Controls.Add(Me.CmbxCForm)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.DtpTo)
        Me.Panel1.Controls.Add(Me.DtpFrom)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.ForeColor = System.Drawing.Color.Navy
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(867, 86)
        Me.Panel1.TabIndex = 0
        '
        'ChkRptLdgr
        '
        Me.ChkRptLdgr.AutoSize = True
        Me.ChkRptLdgr.Checked = True
        Me.ChkRptLdgr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptLdgr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkRptLdgr.ForeColor = System.Drawing.Color.Blue
        Me.ChkRptLdgr.Location = New System.Drawing.Point(323, 12)
        Me.ChkRptLdgr.Name = "ChkRptLdgr"
        Me.ChkRptLdgr.Size = New System.Drawing.Size(234, 17)
        Me.ChkRptLdgr.TabIndex = 3
        Me.ChkRptLdgr.Text = "Company Information Required "
        Me.ChkRptLdgr.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.BackgroundImage = Global.FinAcct.My.Resources.Resources.METALC2A
        Me.BtnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOk.FlatAppearance.BorderSize = 0
        Me.BtnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.Location = New System.Drawing.Point(755, 30)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 25)
        Me.BtnOk.TabIndex = 6
        Me.BtnOk.Text = "&OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'ChkBx1
        '
        Me.ChkBx1.AutoSize = True
        Me.ChkBx1.Location = New System.Drawing.Point(323, 50)
        Me.ChkBx1.Name = "ChkBx1"
        Me.ChkBx1.Size = New System.Drawing.Size(53, 20)
        Me.ChkBx1.TabIndex = 4
        Me.ChkBx1.Text = "ALL"
        Me.ChkBx1.UseVisualStyleBackColor = True
        '
        'CmbxCForm
        '
        Me.CmbxCForm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxCForm.FormattingEnabled = True
        Me.CmbxCForm.Location = New System.Drawing.Point(377, 50)
        Me.CmbxCForm.Name = "CmbxCForm"
        Me.CmbxCForm.Size = New System.Drawing.Size(345, 21)
        Me.CmbxCForm.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "PARTY :"
        '
        'DtpTo
        '
        Me.DtpTo.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpTo.CustomFormat = "dd/MM/yyyy"
        Me.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpTo.Location = New System.Drawing.Point(83, 50)
        Me.DtpTo.Name = "DtpTo"
        Me.DtpTo.Size = New System.Drawing.Size(136, 23)
        Me.DtpTo.TabIndex = 2
        '
        'DtpFrom
        '
        Me.DtpFrom.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFrom.CustomFormat = "dd/MM/yyyy"
        Me.DtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFrom.Location = New System.Drawing.Point(83, 12)
        Me.DtpFrom.Name = "DtpFrom"
        Me.DtpFrom.Size = New System.Drawing.Size(136, 23)
        Me.DtpFrom.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "TO:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FROM:"
        '
        'CrRptVewCform
        '
        Me.CrRptVewCform.ActiveViewIndex = 0
        Me.CrRptVewCform.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewCform.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewCform.DisplayGroupTree = False
        Me.CrRptVewCform.Location = New System.Drawing.Point(0, 93)
        Me.CrRptVewCform.Name = "CrRptVewCform"
        Me.CrRptVewCform.ReportSource = Me.CrRptCformReceivable1
        Me.CrRptVewCform.ShowRefreshButton = False
        Me.CrRptVewCform.Size = New System.Drawing.Size(867, 0)
        Me.CrRptVewCform.TabIndex = 1
        '
        'FrmCrRptCformRecveivable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Turquoise
        Me.ClientSize = New System.Drawing.Size(884, 86)
        Me.Controls.Add(Me.CrRptVewCform)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(950, 700)
        Me.MinimumSize = New System.Drawing.Size(855, 117)
        Me.Name = "FrmCrRptCformRecveivable"
        Me.Text = "LETTER FOR C FORM "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkBx1 As System.Windows.Forms.CheckBox
    Friend WithEvents CmbxCForm As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents CrRptVewCform As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptCformReceivable1 As FinAcct.CrRptCformReceivable
    Friend WithEvents ChkRptLdgr As System.Windows.Forms.CheckBox
End Class
