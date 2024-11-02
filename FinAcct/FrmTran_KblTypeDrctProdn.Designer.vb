<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTran_KblTypeDrctProdn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTran_KblTypeDrctProdn))
        Me.DTPprod1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblEntyNo = New System.Windows.Forms.Label
        Me.TxtQnty = New System.Windows.Forms.TextBox
        Me.CmbxItm = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtItmcost = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.CmbxFind = New System.Windows.Forms.ComboBox
        Me.LblFind = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'DTPprod1
        '
        Me.DTPprod1.CustomFormat = "dd/MM/yyyy"
        Me.DTPprod1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPprod1.Location = New System.Drawing.Point(172, 9)
        Me.DTPprod1.Name = "DTPprod1"
        Me.DTPprod1.Size = New System.Drawing.Size(125, 23)
        Me.DTPprod1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PRODUCTION DATE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ENTRY No."
        '
        'LblEntyNo
        '
        Me.LblEntyNo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblEntyNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEntyNo.Location = New System.Drawing.Point(172, 72)
        Me.LblEntyNo.Name = "LblEntyNo"
        Me.LblEntyNo.Size = New System.Drawing.Size(125, 21)
        Me.LblEntyNo.TabIndex = 20
        '
        'TxtQnty
        '
        Me.TxtQnty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtQnty.Location = New System.Drawing.Point(172, 197)
        Me.TxtQnty.Name = "TxtQnty"
        Me.TxtQnty.Size = New System.Drawing.Size(125, 23)
        Me.TxtQnty.TabIndex = 2
        Me.TxtQnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbxItm
        '
        Me.CmbxItm.FormattingEnabled = True
        Me.CmbxItm.Location = New System.Drawing.Point(172, 133)
        Me.CmbxItm.Name = "CmbxItm"
        Me.CmbxItm.Size = New System.Drawing.Size(286, 24)
        Me.CmbxItm.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "ITEM NAME"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 260)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "ITEM COST"
        '
        'TxtItmcost
        '
        Me.TxtItmcost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtItmcost.Location = New System.Drawing.Point(172, 260)
        Me.TxtItmcost.Name = "TxtItmcost"
        Me.TxtItmcost.Size = New System.Drawing.Size(125, 23)
        Me.TxtItmcost.TabIndex = 3
        Me.TxtItmcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "PRODUCED QUANTITY"
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Location = New System.Drawing.Point(15, 327)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(133, 33)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.FlatAppearance.BorderSize = 0
        Me.BtnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Location = New System.Drawing.Point(170, 327)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(133, 33)
        Me.BtnFind.TabIndex = 5
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.Transparent
        Me.BtnExit.BackgroundImage = CType(resources.GetObject("BtnExit.BackgroundImage"), System.Drawing.Image)
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.FlatAppearance.BorderSize = 0
        Me.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Location = New System.Drawing.Point(325, 326)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(133, 33)
        Me.BtnExit.TabIndex = 6
        Me.BtnExit.Text = "&Exit"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'CmbxFind
        '
        Me.CmbxFind.Enabled = False
        Me.CmbxFind.FormattingEnabled = True
        Me.CmbxFind.Location = New System.Drawing.Point(172, 38)
        Me.CmbxFind.Name = "CmbxFind"
        Me.CmbxFind.Size = New System.Drawing.Size(121, 24)
        Me.CmbxFind.TabIndex = 21
        Me.CmbxFind.Visible = False
        '
        'LblFind
        '
        Me.LblFind.AutoSize = True
        Me.LblFind.Location = New System.Drawing.Point(12, 38)
        Me.LblFind.Name = "LblFind"
        Me.LblFind.Size = New System.Drawing.Size(100, 16)
        Me.LblFind.TabIndex = 1
        Me.LblFind.Text = "FIND AN ITEM"
        Me.LblFind.Visible = False
        '
        'FrmTran_KblTypeDrctProdn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Turquoise
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(477, 371)
        Me.Controls.Add(Me.CmbxFind)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.CmbxItm)
        Me.Controls.Add(Me.TxtItmcost)
        Me.Controls.Add(Me.TxtQnty)
        Me.Controls.Add(Me.LblEntyNo)
        Me.Controls.Add(Me.LblFind)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DTPprod1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Navy
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTran_KblTypeDrctProdn"
        Me.Text = "Finished Item Production (Direct Entry)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DTPprod1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblEntyNo As System.Windows.Forms.Label
    Friend WithEvents TxtQnty As System.Windows.Forms.TextBox
    Friend WithEvents CmbxItm As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtItmcost As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents CmbxFind As System.Windows.Forms.ComboBox
    Friend WithEvents LblFind As System.Windows.Forms.Label
End Class
