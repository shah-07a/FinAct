<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptDBook
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ChkbxRptFormat = New System.Windows.Forms.CheckBox
        Me.ChkRptDbook = New System.Windows.Forms.CheckBox
        Me.BtnRptVew = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtp2 = New System.Windows.Forms.DateTimePicker
        Me.DtpDb1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewDbook = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptDayBook1 = New FinAcct.CrRptDayBook
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ChkbxRptFormat)
        Me.Panel1.Controls.Add(Me.ChkRptDbook)
        Me.Panel1.Controls.Add(Me.BtnRptVew)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtp2)
        Me.Panel1.Controls.Add(Me.DtpDb1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 48)
        Me.Panel1.TabIndex = 0
        '
        'ChkbxRptFormat
        '
        Me.ChkbxRptFormat.AutoSize = True
        Me.ChkbxRptFormat.Location = New System.Drawing.Point(9, 28)
        Me.ChkbxRptFormat.Name = "ChkbxRptFormat"
        Me.ChkbxRptFormat.Size = New System.Drawing.Size(53, 17)
        Me.ChkbxRptFormat.TabIndex = 5
        Me.ChkbxRptFormat.Text = "Date"
        Me.ChkbxRptFormat.UseVisualStyleBackColor = True
        '
        'ChkRptDbook
        '
        Me.ChkRptDbook.AutoSize = True
        Me.ChkRptDbook.Checked = True
        Me.ChkRptDbook.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptDbook.Location = New System.Drawing.Point(9, 5)
        Me.ChkRptDbook.Name = "ChkRptDbook"
        Me.ChkRptDbook.Size = New System.Drawing.Size(211, 17)
        Me.ChkRptDbook.TabIndex = 1
        Me.ChkRptDbook.Text = "Company Information Required "
        Me.ChkRptDbook.UseVisualStyleBackColor = True
        '
        'BtnRptVew
        '
        Me.BtnRptVew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVew.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnRptVew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVew.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVew.Location = New System.Drawing.Point(863, 7)
        Me.BtnRptVew.Name = "BtnRptVew"
        Me.BtnRptVew.Size = New System.Drawing.Size(119, 33)
        Me.BtnRptVew.TabIndex = 4
        Me.BtnRptVew.Text = "Report View"
        Me.BtnRptVew.UseVisualStyleBackColor = True
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
        'Dtp2
        '
        Me.Dtp2.CustomFormat = "dd/MM/yyyy"
        Me.Dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp2.Location = New System.Drawing.Point(535, 14)
        Me.Dtp2.Name = "Dtp2"
        Me.Dtp2.Size = New System.Drawing.Size(114, 21)
        Me.Dtp2.TabIndex = 3
        '
        'DtpDb1
        '
        Me.DtpDb1.CustomFormat = "dd/MM/yyyy"
        Me.DtpDb1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDb1.Location = New System.Drawing.Point(357, 14)
        Me.DtpDb1.Name = "DtpDb1"
        Me.DtpDb1.Size = New System.Drawing.Size(114, 21)
        Me.DtpDb1.TabIndex = 2
        '
        'CrRptVewDbook
        '
        Me.CrRptVewDbook.ActiveViewIndex = 0
        Me.CrRptVewDbook.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewDbook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewDbook.Location = New System.Drawing.Point(0, 56)
        Me.CrRptVewDbook.Name = "CrRptVewDbook"
        Me.CrRptVewDbook.ReportSource = Me.CrRptDayBook1
        Me.CrRptVewDbook.ShowRefreshButton = False
        Me.CrRptVewDbook.Size = New System.Drawing.Size(995, 0)
        Me.CrRptVewDbook.TabIndex = 0
        '
        'FrmRptDBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(997, 52)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrRptVewDbook)
        Me.MinimumSize = New System.Drawing.Size(1005, 38)
        Me.Name = "FrmRptDBook"
        Me.Text = "Day- Book"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewDbook As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpDb1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkRptDbook As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVew As System.Windows.Forms.Button
    Friend WithEvents CrRptDayBook1 As FinAcct.CrRptDayBook
    Friend WithEvents ChkbxRptFormat As System.Windows.Forms.CheckBox
End Class
