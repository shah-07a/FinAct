<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWorkOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWorkOrder))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lbldelvdt = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblsoamt = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblsodt = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Btnwrkexit = New System.Windows.Forms.Button
        Me.BtnwrkCancel = New System.Windows.Forms.Button
        Me.btnwrkSave = New System.Windows.Forms.Button
        Me.Dtpplanfins = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Dtpplanstrt = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblcust2 = New System.Windows.Forms.Label
        Me.lblcust1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbxSaleorderno = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Lblwrno = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DtpWrkordrdt = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LstvewWrkorder = New System.Windows.Forms.ListView
        Me.ColIname = New System.Windows.Forms.ColumnHeader
        Me.ColItmqnty = New System.Windows.Forms.ColumnHeader
        Me.Colunit = New System.Windows.Forms.ColumnHeader
        Me.ColSiH = New System.Windows.Forms.ColumnHeader
        Me.ColSres = New System.Windows.Forms.ColumnHeader
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Colintrans = New System.Windows.Forms.ColumnHeader
        Me.Colnetavail = New System.Windows.Forms.ColumnHeader
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 74)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbldelvdt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblsoamt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblsodt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btnwrkexit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnwrkCancel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnwrkSave)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dtpplanfins)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dtpplanstrt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblcust2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblcust1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbxSaleorderno)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lblwrno)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DtpWrkordrdt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.WindowText
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1064, 502)
        Me.SplitContainer1.SplitterDistance = 245
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 0
        '
        'lbldelvdt
        '
        Me.lbldelvdt.BackColor = System.Drawing.Color.GhostWhite
        Me.lbldelvdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbldelvdt.Location = New System.Drawing.Point(92, 170)
        Me.lbldelvdt.Name = "lbldelvdt"
        Me.lbldelvdt.Size = New System.Drawing.Size(127, 21)
        Me.lbldelvdt.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Delivery  Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 226)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "City"
        '
        'lblsoamt
        '
        Me.lblsoamt.BackColor = System.Drawing.Color.GhostWhite
        Me.lblsoamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblsoamt.Location = New System.Drawing.Point(92, 139)
        Me.lblsoamt.Name = "lblsoamt"
        Me.lblsoamt.Size = New System.Drawing.Size(127, 21)
        Me.lblsoamt.TabIndex = 18
        Me.lblsoamt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Sale Order Amt."
        '
        'lblsodt
        '
        Me.lblsodt.BackColor = System.Drawing.Color.GhostWhite
        Me.lblsodt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblsodt.Location = New System.Drawing.Point(92, 108)
        Me.lblsodt.Name = "lblsodt"
        Me.lblsodt.Size = New System.Drawing.Size(127, 21)
        Me.lblsodt.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Sale Order Date"
        '
        'Btnwrkexit
        '
        Me.Btnwrkexit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnwrkexit.BackColor = System.Drawing.Color.Transparent
        Me.Btnwrkexit.BackgroundImage = CType(resources.GetObject("Btnwrkexit.BackgroundImage"), System.Drawing.Image)
        Me.Btnwrkexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnwrkexit.ForeColor = System.Drawing.Color.Navy
        Me.Btnwrkexit.Location = New System.Drawing.Point(165, 458)
        Me.Btnwrkexit.Name = "Btnwrkexit"
        Me.Btnwrkexit.Size = New System.Drawing.Size(74, 37)
        Me.Btnwrkexit.TabIndex = 14
        Me.Btnwrkexit.Text = "E&xit"
        Me.Btnwrkexit.UseVisualStyleBackColor = False
        '
        'BtnwrkCancel
        '
        Me.BtnwrkCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnwrkCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnwrkCancel.BackgroundImage = CType(resources.GetObject("BtnwrkCancel.BackgroundImage"), System.Drawing.Image)
        Me.BtnwrkCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnwrkCancel.ForeColor = System.Drawing.Color.Navy
        Me.BtnwrkCancel.Location = New System.Drawing.Point(85, 458)
        Me.BtnwrkCancel.Name = "BtnwrkCancel"
        Me.BtnwrkCancel.Size = New System.Drawing.Size(74, 37)
        Me.BtnwrkCancel.TabIndex = 14
        Me.BtnwrkCancel.Text = "&Cancel"
        Me.BtnwrkCancel.UseVisualStyleBackColor = False
        '
        'btnwrkSave
        '
        Me.btnwrkSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnwrkSave.BackColor = System.Drawing.Color.Transparent
        Me.btnwrkSave.BackgroundImage = Global.FinAcct.My.Resources.Resources.button2
        Me.btnwrkSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnwrkSave.ForeColor = System.Drawing.Color.Navy
        Me.btnwrkSave.Location = New System.Drawing.Point(5, 458)
        Me.btnwrkSave.Name = "btnwrkSave"
        Me.btnwrkSave.Size = New System.Drawing.Size(74, 37)
        Me.btnwrkSave.TabIndex = 14
        Me.btnwrkSave.Text = "&Save"
        Me.btnwrkSave.UseVisualStyleBackColor = False
        '
        'Dtpplanfins
        '
        Me.Dtpplanfins.CustomFormat = "dd/MM/yyyy"
        Me.Dtpplanfins.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpplanfins.Location = New System.Drawing.Point(92, 281)
        Me.Dtpplanfins.Name = "Dtpplanfins"
        Me.Dtpplanfins.Size = New System.Drawing.Size(127, 20)
        Me.Dtpplanfins.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(3, 284)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Planned Finish"
        '
        'Dtpplanstrt
        '
        Me.Dtpplanstrt.CustomFormat = "dd/MM/yyyy"
        Me.Dtpplanstrt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpplanstrt.Location = New System.Drawing.Point(92, 255)
        Me.Dtpplanstrt.Name = "Dtpplanstrt"
        Me.Dtpplanstrt.Size = New System.Drawing.Size(127, 20)
        Me.Dtpplanstrt.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(3, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Planned Start"
        '
        'lblcust2
        '
        Me.lblcust2.BackColor = System.Drawing.Color.GhostWhite
        Me.lblcust2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblcust2.Location = New System.Drawing.Point(54, 225)
        Me.lblcust2.Name = "lblcust2"
        Me.lblcust2.Size = New System.Drawing.Size(184, 20)
        Me.lblcust2.TabIndex = 9
        '
        'lblcust1
        '
        Me.lblcust1.BackColor = System.Drawing.Color.GhostWhite
        Me.lblcust1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblcust1.Location = New System.Drawing.Point(54, 201)
        Me.lblcust1.Name = "lblcust1"
        Me.lblcust1.Size = New System.Drawing.Size(184, 21)
        Me.lblcust1.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Customer  "
        '
        'CmbxSaleorderno
        '
        Me.CmbxSaleorderno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxSaleorderno.FormattingEnabled = True
        Me.CmbxSaleorderno.Location = New System.Drawing.Point(92, 76)
        Me.CmbxSaleorderno.Name = "CmbxSaleorderno"
        Me.CmbxSaleorderno.Size = New System.Drawing.Size(127, 21)
        Me.CmbxSaleorderno.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Sale Order No."
        '
        'Lblwrno
        '
        Me.Lblwrno.BackColor = System.Drawing.Color.GhostWhite
        Me.Lblwrno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblwrno.Location = New System.Drawing.Point(92, 44)
        Me.Lblwrno.Name = "Lblwrno"
        Me.Lblwrno.Size = New System.Drawing.Size(127, 21)
        Me.Lblwrno.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Work Order No."
        '
        'DtpWrkordrdt
        '
        Me.DtpWrkordrdt.CustomFormat = "dd/MM/yyyy"
        Me.DtpWrkordrdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpWrkordrdt.Location = New System.Drawing.Point(92, 12)
        Me.DtpWrkordrdt.Name = "DtpWrkordrdt"
        Me.DtpWrkordrdt.Size = New System.Drawing.Size(127, 20)
        Me.DtpWrkordrdt.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Work Order Date"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.LstvewWrkorder)
        Me.Panel1.Location = New System.Drawing.Point(3, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(511, 498)
        Me.Panel1.TabIndex = 0
        '
        'LstvewWrkorder
        '
        Me.LstvewWrkorder.AllowColumnReorder = True
        Me.LstvewWrkorder.BackColor = System.Drawing.Color.AliceBlue
        Me.LstvewWrkorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstvewWrkorder.CheckBoxes = True
        Me.LstvewWrkorder.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColIname, Me.ColItmqnty, Me.Colunit, Me.ColSiH, Me.ColSres, Me.Colintrans, Me.Colnetavail})
        Me.LstvewWrkorder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstvewWrkorder.FullRowSelect = True
        Me.LstvewWrkorder.GridLines = True
        Me.LstvewWrkorder.Location = New System.Drawing.Point(0, 0)
        Me.LstvewWrkorder.MultiSelect = False
        Me.LstvewWrkorder.Name = "LstvewWrkorder"
        Me.LstvewWrkorder.Size = New System.Drawing.Size(511, 498)
        Me.LstvewWrkorder.TabIndex = 0
        Me.LstvewWrkorder.UseCompatibleStateImageBehavior = False
        Me.LstvewWrkorder.View = System.Windows.Forms.View.Details
        '
        'ColIname
        '
        Me.ColIname.Text = "Item Name"
        Me.ColIname.Width = 150
        '
        'ColItmqnty
        '
        Me.ColItmqnty.Text = "Required Qnty"
        Me.ColItmqnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColItmqnty.Width = 80
        '
        'Colunit
        '
        Me.Colunit.Text = "Unit"
        Me.Colunit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Colunit.Width = 80
        '
        'ColSiH
        '
        Me.ColSiH.Text = "Avilable Stock"
        Me.ColSiH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColSiH.Width = 80
        '
        'ColSres
        '
        Me.ColSres.Text = "Restricted Stock"
        Me.ColSres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColSres.Width = 83
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1065, 73)
        Me.Panel4.TabIndex = 29
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.FinAcct.My.Resources.Resources.K31
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(992, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Colintrans
        '
        Me.Colintrans.Text = "Stock In Transfer"
        '
        'FrmWorkOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1064, 577)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmWorkOrder"
        Me.Text = "Production/Work Order "
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lblwrno As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtpWrkordrdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbxSaleorderno As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblcust1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblcust2 As System.Windows.Forms.Label
    Friend WithEvents Dtpplanstrt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Dtpplanfins As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Btnwrkexit As System.Windows.Forms.Button
    Friend WithEvents BtnwrkCancel As System.Windows.Forms.Button
    Friend WithEvents btnwrkSave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LstvewWrkorder As System.Windows.Forms.ListView
    Friend WithEvents lblsodt As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblsoamt As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbldelvdt As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ColIname As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColItmqnty As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colunit As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColSiH As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColSres As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colintrans As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colnetavail As System.Windows.Forms.ColumnHeader
End Class
