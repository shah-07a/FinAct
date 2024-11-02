<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVAT_vat15_PriodSel
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
        Me.DtpVAT2 = New System.Windows.Forms.DateTimePicker
        Me.DtpVAT1 = New System.Windows.Forms.DateTimePicker
        Me.BtnPRDMSTR = New System.Windows.Forms.Button
        Me.CmbxPeriod = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnOK = New System.Windows.Forms.Button
        Me.Btnext = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DtpVAT2
        '
        Me.DtpVAT2.CalendarFont = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVAT2.CustomFormat = "dd/MM/yyyy"
        Me.DtpVAT2.Enabled = False
        Me.DtpVAT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVAT2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVAT2.Location = New System.Drawing.Point(115, 143)
        Me.DtpVAT2.Name = "DtpVAT2"
        Me.DtpVAT2.Size = New System.Drawing.Size(118, 21)
        Me.DtpVAT2.TabIndex = 14
        Me.DtpVAT2.TabStop = False
        '
        'DtpVAT1
        '
        Me.DtpVAT1.CalendarFont = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVAT1.CustomFormat = "dd/MM/yyyy"
        Me.DtpVAT1.Enabled = False
        Me.DtpVAT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVAT1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVAT1.Location = New System.Drawing.Point(115, 78)
        Me.DtpVAT1.Name = "DtpVAT1"
        Me.DtpVAT1.Size = New System.Drawing.Size(118, 21)
        Me.DtpVAT1.TabIndex = 13
        Me.DtpVAT1.TabStop = False
        '
        'BtnPRDMSTR
        '
        Me.BtnPRDMSTR.Location = New System.Drawing.Point(477, 12)
        Me.BtnPRDMSTR.Name = "BtnPRDMSTR"
        Me.BtnPRDMSTR.Size = New System.Drawing.Size(41, 24)
        Me.BtnPRDMSTR.TabIndex = 12
        Me.BtnPRDMSTR.TabStop = False
        Me.BtnPRDMSTR.Text = "...."
        Me.BtnPRDMSTR.UseVisualStyleBackColor = True
        '
        'CmbxPeriod
        '
        Me.CmbxPeriod.FormattingEnabled = True
        Me.CmbxPeriod.Location = New System.Drawing.Point(115, 12)
        Me.CmbxPeriod.Name = "CmbxPeriod"
        Me.CmbxPeriod.Size = New System.Drawing.Size(356, 22)
        Me.CmbxPeriod.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "TO :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "FROM :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "FOR PERIOD :"
        '
        'BtnOK
        '
        Me.BtnOK.BackgroundImage = Global.FinAcct.My.Resources.Resources.GLASSC1C
        Me.BtnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnOK.FlatAppearance.BorderSize = 0
        Me.BtnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOK.Location = New System.Drawing.Point(115, 208)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(161, 33)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "&OK"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'Btnext
        '
        Me.Btnext.BackgroundImage = Global.FinAcct.My.Resources.Resources.GLASSC1C
        Me.Btnext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnext.FlatAppearance.BorderSize = 0
        Me.Btnext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Btnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnext.Location = New System.Drawing.Point(310, 208)
        Me.Btnext.Name = "Btnext"
        Me.Btnext.Size = New System.Drawing.Size(161, 33)
        Me.Btnext.TabIndex = 2
        Me.Btnext.Text = "&Exit"
        Me.Btnext.UseVisualStyleBackColor = True
        '
        'FrmVAT_vat15_PriodSel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.ClientSize = New System.Drawing.Size(528, 250)
        Me.Controls.Add(Me.Btnext)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.DtpVAT2)
        Me.Controls.Add(Me.DtpVAT1)
        Me.Controls.Add(Me.BtnPRDMSTR)
        Me.Controls.Add(Me.CmbxPeriod)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "FrmVAT_vat15_PriodSel"
        Me.Text = "SELECT PERIOD"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtpVAT2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpVAT1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnPRDMSTR As System.Windows.Forms.Button
    Friend WithEvents CmbxPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents Btnext As System.Windows.Forms.Button
End Class
