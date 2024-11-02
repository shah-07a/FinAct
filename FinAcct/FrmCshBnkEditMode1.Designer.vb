<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCshBnkEditMode1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCshBnkEditMode1))
        Me.LstVewCB = New System.Windows.Forms.ListView
        Me.ColH1 = New System.Windows.Forms.ColumnHeader
        Me.ColH2 = New System.Windows.Forms.ColumnHeader
        Me.ColH3 = New System.Windows.Forms.ColumnHeader
        Me.ColH4 = New System.Windows.Forms.ColumnHeader
        Me.ColH5 = New System.Windows.Forms.ColumnHeader
        Me.ColH6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnOk = New System.Windows.Forms.Button
        Me.ChkBxAll1 = New System.Windows.Forms.CheckBox
        Me.CmbxSr2 = New System.Windows.Forms.ComboBox
        Me.CmbxSr1 = New System.Windows.Forms.ComboBox
        Me.DtpTo = New System.Windows.Forms.DateTimePicker
        Me.Dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.BtnEdt = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnRefresh = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.ChbxPDC = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LstVewCB
        '
        Me.LstVewCB.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.LstVewCB.AllowColumnReorder = True
        Me.LstVewCB.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColH1, Me.ColH2, Me.ColH3, Me.ColH4, Me.ColH5, Me.ColH6, Me.ColumnHeader2, Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.LstVewCB.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVewCB.FullRowSelect = True
        Me.LstVewCB.GridLines = True
        Me.LstVewCB.HideSelection = False
        Me.LstVewCB.Location = New System.Drawing.Point(2, 66)
        Me.LstVewCB.Name = "LstVewCB"
        Me.LstVewCB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstVewCB.ShowItemToolTips = True
        Me.LstVewCB.Size = New System.Drawing.Size(937, 473)
        Me.LstVewCB.TabIndex = 17
        Me.LstVewCB.UseCompatibleStateImageBehavior = False
        Me.LstVewCB.View = System.Windows.Forms.View.Details
        '
        'ColH1
        '
        Me.ColH1.Text = "Date"
        Me.ColH1.Width = 100
        '
        'ColH2
        '
        Me.ColH2.Text = "Particulars"
        Me.ColH2.Width = 170
        '
        'ColH3
        '
        Me.ColH3.DisplayIndex = 3
        Me.ColH3.Text = "Cash/Bank Name"
        Me.ColH3.Width = 180
        '
        'ColH4
        '
        Me.ColH4.DisplayIndex = 4
        Me.ColH4.Text = "Debit"
        Me.ColH4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColH4.Width = 100
        '
        'ColH5
        '
        Me.ColH5.DisplayIndex = 5
        Me.ColH5.Text = "Credit"
        Me.ColH5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColH5.Width = 100
        '
        'ColH6
        '
        Me.ColH6.DisplayIndex = 6
        Me.ColH6.Text = "Rec Id"
        Me.ColH6.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DisplayIndex = 7
        Me.ColumnHeader2.Text = "SpltType"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DisplayIndex = 8
        Me.ColumnHeader1.Text = "Vno"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 9
        Me.ColumnHeader3.Text = "Mode"
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 2
        Me.ColumnHeader4.Text = "Account Name"
        Me.ColumnHeader4.Width = 251
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.ChbxPDC)
        Me.Panel1.Controls.Add(Me.BtnOk)
        Me.Panel1.Controls.Add(Me.ChkBxAll1)
        Me.Panel1.Controls.Add(Me.CmbxSr2)
        Me.Panel1.Controls.Add(Me.CmbxSr1)
        Me.Panel1.Controls.Add(Me.DtpTo)
        Me.Panel1.Controls.Add(Me.Dtpfrom)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(937, 57)
        Me.Panel1.TabIndex = 0
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(863, 28)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(67, 23)
        Me.BtnOk.TabIndex = 6
        Me.BtnOk.Text = "&OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'ChkBxAll1
        '
        Me.ChkBxAll1.AutoSize = True
        Me.ChkBxAll1.Checked = True
        Me.ChkBxAll1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBxAll1.Location = New System.Drawing.Point(486, 7)
        Me.ChkBxAll1.Name = "ChkBxAll1"
        Me.ChkBxAll1.Size = New System.Drawing.Size(49, 17)
        Me.ChkBxAll1.TabIndex = 4
        Me.ChkBxAll1.Text = "ALL"
        Me.ChkBxAll1.UseVisualStyleBackColor = True
        '
        'CmbxSr2
        '
        Me.CmbxSr2.FormattingEnabled = True
        Me.CmbxSr2.Items.AddRange(New Object() {"CASH & BANK BOOK", "CASH BOOK ", "BANK BOOK"})
        Me.CmbxSr2.Location = New System.Drawing.Point(542, 5)
        Me.CmbxSr2.Name = "CmbxSr2"
        Me.CmbxSr2.Size = New System.Drawing.Size(388, 21)
        Me.CmbxSr2.TabIndex = 5
        '
        'CmbxSr1
        '
        Me.CmbxSr1.FormattingEnabled = True
        Me.CmbxSr1.Items.AddRange(New Object() {"CASH & BANK BOOK", "BANK BOOK", "CASH BOOK "})
        Me.CmbxSr1.Location = New System.Drawing.Point(307, 5)
        Me.CmbxSr1.Name = "CmbxSr1"
        Me.CmbxSr1.Size = New System.Drawing.Size(172, 21)
        Me.CmbxSr1.TabIndex = 3
        '
        'DtpTo
        '
        Me.DtpTo.CustomFormat = "dd/MM/yyyy"
        Me.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpTo.Location = New System.Drawing.Point(67, 30)
        Me.DtpTo.Name = "DtpTo"
        Me.DtpTo.Size = New System.Drawing.Size(120, 21)
        Me.DtpTo.TabIndex = 2
        '
        'Dtpfrom
        '
        Me.Dtpfrom.CustomFormat = "dd/MM/yyyy"
        Me.Dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpfrom.Location = New System.Drawing.Point(67, 3)
        Me.Dtpfrom.Name = "Dtpfrom"
        Me.Dtpfrom.Size = New System.Drawing.Size(120, 21)
        Me.Dtpfrom.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "To :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(191, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Search Range :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From :"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.NavajoWhite
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnEdt)
        Me.Panel4.Controls.Add(Me.BtnAdd)
        Me.Panel4.Controls.Add(Me.BtnRefresh)
        Me.Panel4.Controls.Add(Me.BtnClose)
        Me.Panel4.Location = New System.Drawing.Point(2, 544)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(937, 39)
        Me.Panel4.TabIndex = 7
        '
        'BtnEdt
        '
        Me.BtnEdt.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdt.BackgroundImage = CType(resources.GetObject("BtnEdt.BackgroundImage"), System.Drawing.Image)
        Me.BtnEdt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnEdt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEdt.FlatAppearance.BorderSize = 0
        Me.BtnEdt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnEdt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdt.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdt.ForeColor = System.Drawing.Color.Navy
        Me.BtnEdt.Location = New System.Drawing.Point(250, 2)
        Me.BtnEdt.Name = "BtnEdt"
        Me.BtnEdt.Size = New System.Drawing.Size(200, 30)
        Me.BtnEdt.TabIndex = 9
        Me.BtnEdt.Text = "&Delete"
        Me.BtnEdt.UseVisualStyleBackColor = False
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.BackgroundImage = CType(resources.GetObject("BtnAdd.BackgroundImage"), System.Drawing.Image)
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Navy
        Me.BtnAdd.Location = New System.Drawing.Point(3, 3)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(200, 30)
        Me.BtnAdd.TabIndex = 8
        Me.BtnAdd.Text = "&Edit"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnRefresh
        '
        Me.BtnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.BtnRefresh.BackgroundImage = CType(resources.GetObject("BtnRefresh.BackgroundImage"), System.Drawing.Image)
        Me.BtnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRefresh.FlatAppearance.BorderSize = 0
        Me.BtnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefresh.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefresh.ForeColor = System.Drawing.Color.Navy
        Me.BtnRefresh.Location = New System.Drawing.Point(487, 3)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(200, 30)
        Me.BtnRefresh.TabIndex = 10
        Me.BtnRefresh.Text = "&Refresh"
        Me.BtnRefresh.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.Transparent
        Me.BtnClose.BackgroundImage = CType(resources.GetObject("BtnClose.BackgroundImage"), System.Drawing.Image)
        Me.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClose.FlatAppearance.BorderSize = 0
        Me.BtnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.Navy
        Me.BtnClose.Location = New System.Drawing.Point(729, 3)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(200, 30)
        Me.BtnClose.TabIndex = 11
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'ChbxPDC
        '
        Me.ChbxPDC.AutoSize = True
        Me.ChbxPDC.Location = New System.Drawing.Point(194, 30)
        Me.ChbxPDC.Name = "ChbxPDC"
        Me.ChbxPDC.Size = New System.Drawing.Size(104, 17)
        Me.ChbxPDC.TabIndex = 7
        Me.ChbxPDC.Text = "Include PDC"
        Me.ChbxPDC.UseVisualStyleBackColor = True
        '
        'FrmCshBnkEditMode1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(944, 586)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LstVewCB)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(499, 90)
        Me.Name = "FrmCshBnkEditMode1"
        Me.Text = "Cash/Bank View Mode"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LstVewCB As System.Windows.Forms.ListView
    Friend WithEvents ColH1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColH2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColH3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColH4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColH5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColH6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkBxAll1 As System.Windows.Forms.CheckBox
    Friend WithEvents CmbxSr1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbxSr2 As System.Windows.Forms.ComboBox
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnEdt As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChbxPDC As System.Windows.Forms.CheckBox
End Class
