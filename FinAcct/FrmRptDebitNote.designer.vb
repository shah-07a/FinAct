<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptDebitNote
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
        Me.ChkRptJrnl = New System.Windows.Forms.CheckBox
        Me.BtnRptVewJrnl = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpJrnl2 = New System.Windows.Forms.DateTimePicker
        Me.DtpJrnl1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewDrn = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptDebitNote1 = New FinAcct.CrRptDebitNote
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ChkRptJrnl)
        Me.Panel1.Controls.Add(Me.BtnRptVewJrnl)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpJrnl2)
        Me.Panel1.Controls.Add(Me.DtpJrnl1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1015, 48)
        Me.Panel1.TabIndex = 0
        '
        'ChkRptJrnl
        '
        Me.ChkRptJrnl.AutoSize = True
        Me.ChkRptJrnl.Checked = True
        Me.ChkRptJrnl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptJrnl.Location = New System.Drawing.Point(9, 14)
        Me.ChkRptJrnl.Name = "ChkRptJrnl"
        Me.ChkRptJrnl.Size = New System.Drawing.Size(211, 17)
        Me.ChkRptJrnl.TabIndex = 1
        Me.ChkRptJrnl.Text = "Company Information Required "
        Me.ChkRptJrnl.UseVisualStyleBackColor = True
        '
        'BtnRptVewJrnl
        '
        Me.BtnRptVewJrnl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVewJrnl.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnRptVewJrnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewJrnl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewJrnl.Location = New System.Drawing.Point(863, 7)
        Me.BtnRptVewJrnl.Name = "BtnRptVewJrnl"
        Me.BtnRptVewJrnl.Size = New System.Drawing.Size(143, 33)
        Me.BtnRptVewJrnl.TabIndex = 4
        Me.BtnRptVewJrnl.Text = "Report View"
        Me.BtnRptVewJrnl.UseVisualStyleBackColor = True
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
        'DtpJrnl2
        '
        Me.DtpJrnl2.CustomFormat = "dd/MM/yyyy"
        Me.DtpJrnl2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpJrnl2.Location = New System.Drawing.Point(535, 14)
        Me.DtpJrnl2.Name = "DtpJrnl2"
        Me.DtpJrnl2.Size = New System.Drawing.Size(114, 21)
        Me.DtpJrnl2.TabIndex = 3
        '
        'DtpJrnl1
        '
        Me.DtpJrnl1.CustomFormat = "dd/MM/yyyy"
        Me.DtpJrnl1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpJrnl1.Location = New System.Drawing.Point(357, 14)
        Me.DtpJrnl1.Name = "DtpJrnl1"
        Me.DtpJrnl1.Size = New System.Drawing.Size(114, 21)
        Me.DtpJrnl1.TabIndex = 2
        '
        'CrRptVewDrn
        '
        Me.CrRptVewDrn.ActiveViewIndex = 0
        Me.CrRptVewDrn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewDrn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewDrn.Location = New System.Drawing.Point(0, 52)
        Me.CrRptVewDrn.Name = "CrRptVewDrn"
        Me.CrRptVewDrn.ReportSource = Me.CrRptDebitNote1
        Me.CrRptVewDrn.Size = New System.Drawing.Size(1016, 0)
        Me.CrRptVewDrn.TabIndex = 0
        '
        'FrmRptDebitNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1017, 49)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrRptVewDrn)
        Me.Name = "FrmRptDebitNote"
        Me.Text = "Report Journal "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewDrn As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ChkRptJrnl As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVewJrnl As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpJrnl2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpJrnl1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrRptDebitNote1 As FinAcct.CrRptDebitNote
End Class
