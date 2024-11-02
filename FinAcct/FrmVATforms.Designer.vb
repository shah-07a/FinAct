<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVATforms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVATforms))
        Me.BtnPerd = New System.Windows.Forms.Button
        Me.CmbxPerd = New System.Windows.Forms.ComboBox
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnOk = New System.Windows.Forms.Button
        Me.DtpVAT2 = New System.Windows.Forms.DateTimePicker
        Me.DtpVAT1 = New System.Windows.Forms.DateTimePicker
        Me.CmbxVatfrm = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'BtnPerd
        '
        Me.BtnPerd.Location = New System.Drawing.Point(431, 166)
        Me.BtnPerd.Name = "BtnPerd"
        Me.BtnPerd.Size = New System.Drawing.Size(36, 23)
        Me.BtnPerd.TabIndex = 6
        Me.BtnPerd.TabStop = False
        Me.BtnPerd.Text = "...."
        Me.BtnPerd.UseVisualStyleBackColor = True
        '
        'CmbxPerd
        '
        Me.CmbxPerd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxPerd.FormattingEnabled = True
        Me.CmbxPerd.Location = New System.Drawing.Point(111, 167)
        Me.CmbxPerd.Name = "CmbxPerd"
        Me.CmbxPerd.Size = New System.Drawing.Size(314, 21)
        Me.CmbxPerd.TabIndex = 1
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.Transparent
        Me.BtnExit.BackgroundImage = CType(resources.GetObject("BtnExit.BackgroundImage"), System.Drawing.Image)
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnExit.FlatAppearance.BorderSize = 0
        Me.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.ForeColor = System.Drawing.Color.Navy
        Me.BtnExit.Location = New System.Drawing.Point(322, 504)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(145, 33)
        Me.BtnExit.TabIndex = 5
        Me.BtnExit.Text = "&Exit"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.Color.Transparent
        Me.BtnOk.BackgroundImage = CType(resources.GetObject("BtnOk.BackgroundImage"), System.Drawing.Image)
        Me.BtnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOk.FlatAppearance.BorderSize = 0
        Me.BtnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.ForeColor = System.Drawing.Color.Navy
        Me.BtnOk.Location = New System.Drawing.Point(111, 504)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(145, 33)
        Me.BtnOk.TabIndex = 4
        Me.BtnOk.Text = "&OK"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'DtpVAT2
        '
        Me.DtpVAT2.CustomFormat = "dd/MM/yyyy"
        Me.DtpVAT2.Enabled = False
        Me.DtpVAT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVAT2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVAT2.Location = New System.Drawing.Point(111, 326)
        Me.DtpVAT2.Name = "DtpVAT2"
        Me.DtpVAT2.Size = New System.Drawing.Size(133, 21)
        Me.DtpVAT2.TabIndex = 3
        '
        'DtpVAT1
        '
        Me.DtpVAT1.CustomFormat = "dd/MM/yyyy"
        Me.DtpVAT1.Enabled = False
        Me.DtpVAT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVAT1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVAT1.Location = New System.Drawing.Point(111, 247)
        Me.DtpVAT1.Name = "DtpVAT1"
        Me.DtpVAT1.Size = New System.Drawing.Size(133, 21)
        Me.DtpVAT1.TabIndex = 2
        '
        'CmbxVatfrm
        '
        Me.CmbxVatfrm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxVatfrm.FormattingEnabled = True
        Me.CmbxVatfrm.Items.AddRange(New Object() {"VAT 1", "VAT 15", "VAT 16", "VAT 18", "VAT 19", "VAT 20", "VAT 23", "VAT 24"})
        Me.CmbxVatfrm.Location = New System.Drawing.Point(111, 87)
        Me.CmbxVatfrm.Name = "CmbxVatfrm"
        Me.CmbxVatfrm.Size = New System.Drawing.Size(356, 21)
        Me.CmbxVatfrm.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 326)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "To:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Period:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Form:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(18, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "VAT Form:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.FinAcct.My.Resources.Resources._728x90_winning1
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(490, 81)
        Me.Panel1.TabIndex = 8
        '
        'FrmVATforms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(488, 544)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.BtnPerd)
        Me.Controls.Add(Me.CmbxPerd)
        Me.Controls.Add(Me.CmbxVatfrm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtpVAT2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtpVAT1)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmVATforms"
        Me.Text = "VAT FORMS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbxVatfrm As System.Windows.Forms.ComboBox
    Friend WithEvents DtpVAT1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtpVAT2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents CmbxPerd As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnPerd As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
