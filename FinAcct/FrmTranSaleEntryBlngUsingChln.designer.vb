<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTranSaleEntryBlngUsingChln
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranSaleEntryBlngUsingChln))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbxSplr = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtInvNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DtpBilldt = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDis = New System.Windows.Forms.TextBox
        Me.TxtValue = New System.Windows.Forms.TextBox
        Me.TxtOthrChrgs = New System.Windows.Forms.TextBox
        Me.TxtChrgsTxable = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtTxAble = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtInVat = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtInVatSurChrgs = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtRondOff = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtGrand = New System.Windows.Forms.TextBox
        Me.CmbxVATrate = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.LstVewChllans = New System.Windows.Forms.ListView
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.Label14 = New System.Windows.Forms.Label
        Me.BtnExit = New System.Windows.Forms.Button
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnOk = New System.Windows.Forms.Button
        Me.DgChlnInv = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CmbxDisType = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtDisRate = New System.Windows.Forms.TextBox
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DgChlnInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'CmbxSplr
        '
        Me.CmbxSplr.FormattingEnabled = True
        Me.CmbxSplr.Location = New System.Drawing.Point(86, 32)
        Me.CmbxSplr.Name = "CmbxSplr"
        Me.CmbxSplr.Size = New System.Drawing.Size(743, 22)
        Me.CmbxSplr.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Inv./Bill No. "
        '
        'TxtInvNo
        '
        Me.TxtInvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInvNo.Location = New System.Drawing.Point(86, 7)
        Me.TxtInvNo.Name = "TxtInvNo"
        Me.TxtInvNo.Size = New System.Drawing.Size(119, 22)
        Me.TxtInvNo.TabIndex = 0
        Me.TxtInvNo.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(666, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 14)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Date"
        '
        'DtpBilldt
        '
        Me.DtpBilldt.CustomFormat = "dd/MM/yyyy"
        Me.DtpBilldt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBilldt.Location = New System.Drawing.Point(707, 7)
        Me.DtpBilldt.Name = "DtpBilldt"
        Me.DtpBilldt.Size = New System.Drawing.Size(122, 22)
        Me.DtpBilldt.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 457)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Value"
        '
        'TxtDis
        '
        Me.TxtDis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDis.Location = New System.Drawing.Point(254, 504)
        Me.TxtDis.Name = "TxtDis"
        Me.TxtDis.ReadOnly = True
        Me.TxtDis.Size = New System.Drawing.Size(117, 22)
        Me.TxtDis.TabIndex = 8
        Me.TxtDis.TabStop = False
        Me.TxtDis.Text = "0"
        Me.TxtDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtValue
        '
        Me.TxtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtValue.Location = New System.Drawing.Point(49, 457)
        Me.TxtValue.Name = "TxtValue"
        Me.TxtValue.ReadOnly = True
        Me.TxtValue.Size = New System.Drawing.Size(119, 22)
        Me.TxtValue.TabIndex = 5
        Me.TxtValue.TabStop = False
        Me.TxtValue.Text = "0"
        Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtOthrChrgs
        '
        Me.TxtOthrChrgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOthrChrgs.Location = New System.Drawing.Point(683, 520)
        Me.TxtOthrChrgs.Name = "TxtOthrChrgs"
        Me.TxtOthrChrgs.Size = New System.Drawing.Size(119, 22)
        Me.TxtOthrChrgs.TabIndex = 11
        Me.TxtOthrChrgs.Text = "0"
        Me.TxtOthrChrgs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtChrgsTxable
        '
        Me.TxtChrgsTxable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtChrgsTxable.Location = New System.Drawing.Point(514, 457)
        Me.TxtChrgsTxable.Name = "TxtChrgsTxable"
        Me.TxtChrgsTxable.Size = New System.Drawing.Size(70, 22)
        Me.TxtChrgsTxable.TabIndex = 8
        Me.TxtChrgsTxable.Text = "0"
        Me.TxtChrgsTxable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(172, 457)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Dis.Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(560, 520)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "(+)Other Charges"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(378, 457)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "(+)Taxable Charges"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(586, 457)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 14)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Taxable Value"
        '
        'TxtTxAble
        '
        Me.TxtTxAble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTxAble.Location = New System.Drawing.Point(683, 457)
        Me.TxtTxAble.Name = "TxtTxAble"
        Me.TxtTxAble.ReadOnly = True
        Me.TxtTxAble.Size = New System.Drawing.Size(119, 22)
        Me.TxtTxAble.TabIndex = 8
        Me.TxtTxAble.TabStop = False
        Me.TxtTxAble.Text = "0"
        Me.TxtTxAble.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(611, 478)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 14)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Input VAT"
        '
        'TxtInVat
        '
        Me.TxtInVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInVat.Location = New System.Drawing.Point(683, 478)
        Me.TxtInVat.Name = "TxtInVat"
        Me.TxtInVat.ReadOnly = True
        Me.TxtInVat.Size = New System.Drawing.Size(119, 22)
        Me.TxtInVat.TabIndex = 9
        Me.TxtInVat.TabStop = False
        Me.TxtInVat.Text = "0"
        Me.TxtInVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(545, 499)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 14)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Surcharge (00.00%)"
        '
        'TxtInVatSurChrgs
        '
        Me.TxtInVatSurChrgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInVatSurChrgs.Location = New System.Drawing.Point(683, 499)
        Me.TxtInVatSurChrgs.Name = "TxtInVatSurChrgs"
        Me.TxtInVatSurChrgs.ReadOnly = True
        Me.TxtInVatSurChrgs.Size = New System.Drawing.Size(119, 22)
        Me.TxtInVatSurChrgs.TabIndex = 10
        Me.TxtInVatSurChrgs.TabStop = False
        Me.TxtInVatSurChrgs.Text = "0"
        Me.TxtInVatSurChrgs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(583, 541)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 14)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "(+-) Round Off"
        '
        'TxtRondOff
        '
        Me.TxtRondOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRondOff.Location = New System.Drawing.Point(683, 541)
        Me.TxtRondOff.Name = "TxtRondOff"
        Me.TxtRondOff.ReadOnly = True
        Me.TxtRondOff.Size = New System.Drawing.Size(119, 22)
        Me.TxtRondOff.TabIndex = 12
        Me.TxtRondOff.TabStop = False
        Me.TxtRondOff.Text = "0"
        Me.TxtRondOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(599, 562)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 14)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Grand Total"
        '
        'TxtGrand
        '
        Me.TxtGrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGrand.Location = New System.Drawing.Point(683, 562)
        Me.TxtGrand.Name = "TxtGrand"
        Me.TxtGrand.ReadOnly = True
        Me.TxtGrand.Size = New System.Drawing.Size(119, 22)
        Me.TxtGrand.TabIndex = 13
        Me.TxtGrand.TabStop = False
        Me.TxtGrand.Text = "0"
        Me.TxtGrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbxVATrate
        '
        Me.CmbxVATrate.FormattingEnabled = True
        Me.CmbxVATrate.Location = New System.Drawing.Point(86, 58)
        Me.CmbxVATrate.Name = "CmbxVATrate"
        Me.CmbxVATrate.Size = New System.Drawing.Size(743, 22)
        Me.CmbxVATrate.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 14)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "VAT/CST"
        '
        'LstVewChllans
        '
        Me.LstVewChllans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVewChllans.CheckBoxes = True
        Me.LstVewChllans.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10})
        Me.LstVewChllans.GridLines = True
        Me.LstVewChllans.Location = New System.Drawing.Point(86, 86)
        Me.LstVewChllans.Name = "LstVewChllans"
        Me.LstVewChllans.Size = New System.Drawing.Size(254, 134)
        Me.LstVewChllans.TabIndex = 4
        Me.LstVewChllans.UseCompatibleStateImageBehavior = False
        Me.LstVewChllans.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Challan No."
        Me.ColumnHeader9.Width = 120
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Date"
        Me.ColumnHeader10.Width = 100
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 14)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Challans"
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
        Me.BtnExit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.ForeColor = System.Drawing.Color.Navy
        Me.BtnExit.Location = New System.Drawing.Point(700, 596)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(128, 33)
        Me.BtnExit.TabIndex = 16
        Me.BtnExit.Text = "&Exit"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(834, 632)
        Me.ShapeContainer1.TabIndex = 15
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = -3
        Me.LineShape1.X2 = 833
        Me.LineShape1.Y1 = 587
        Me.LineShape1.Y2 = 590
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFind.FlatAppearance.BorderSize = 0
        Me.BtnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.ForeColor = System.Drawing.Color.Navy
        Me.BtnFind.Location = New System.Drawing.Point(551, 594)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(128, 33)
        Me.BtnFind.TabIndex = 15
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Navy
        Me.BtnSave.Location = New System.Drawing.Point(402, 594)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(128, 33)
        Me.BtnSave.TabIndex = 14
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
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
        Me.BtnOk.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.ForeColor = System.Drawing.Color.Navy
        Me.BtnOk.Location = New System.Drawing.Point(701, 187)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(128, 33)
        Me.BtnOk.TabIndex = 5
        Me.BtnOk.Text = "&OK"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'DgChlnInv
        '
        Me.DgChlnInv.AllowUserToAddRows = False
        Me.DgChlnInv.AllowUserToDeleteRows = False
        Me.DgChlnInv.BackgroundColor = System.Drawing.Color.Cyan
        Me.DgChlnInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgChlnInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.DgChlnInv.GridColor = System.Drawing.Color.Blue
        Me.DgChlnInv.Location = New System.Drawing.Point(5, 226)
        Me.DgChlnInv.Name = "DgChlnInv"
        Me.DgChlnInv.Size = New System.Drawing.Size(824, 230)
        Me.DgChlnInv.TabIndex = 17
        '
        'Column1
        '
        Me.Column1.HeaderText = "Challan No."
        Me.Column1.MaxInputLength = 50
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Item Name"
        Me.Column2.MaxInputLength = 200
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 275
        '
        'Column3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N3"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "Quantity"
        Me.Column3.MaxInputLength = 20
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "U.O.M."
        Me.Column4.MaxInputLength = 50
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PapayaWhip
        DataGridViewCellStyle3.Format = "N2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Rate(Per UOM)"
        Me.Column5.MaxInputLength = 20
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 95
        '
        'Column6
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.NullValue = "N3"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column6.HeaderText = "Amount"
        Me.Column6.MaxInputLength = 20
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 118
        '
        'Column7
        '
        Me.Column7.HeaderText = "Row Id"
        Me.Column7.MaxInputLength = 50
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        Me.Column7.Width = 5
        '
        'CmbxDisType
        '
        Me.CmbxDisType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbxDisType.FormattingEnabled = True
        Me.CmbxDisType.Items.AddRange(New Object() {"Discount Value", "Discount Percentage"})
        Me.CmbxDisType.Location = New System.Drawing.Point(234, 457)
        Me.CmbxDisType.Name = "CmbxDisType"
        Me.CmbxDisType.Size = New System.Drawing.Size(142, 21)
        Me.CmbxDisType.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(172, 504)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 14)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "(-)Discount"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(172, 483)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 14)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Discount Rate"
        '
        'TxtDisRate
        '
        Me.TxtDisRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDisRate.Location = New System.Drawing.Point(290, 483)
        Me.TxtDisRate.Name = "TxtDisRate"
        Me.TxtDisRate.Size = New System.Drawing.Size(81, 22)
        Me.TxtDisRate.TabIndex = 7
        Me.TxtDisRate.Text = "0"
        Me.TxtDisRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Challan No."
        Me.DataGridViewTextBoxColumn1.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 200
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 275
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N3"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn3.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn4.HeaderText = "U.O.M."
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.PapayaWhip
        DataGridViewCellStyle7.Format = "N2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn5.HeaderText = "Rate(Per UOM)"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 95
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.NullValue = "N3"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn6.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 118
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Row Id"
        Me.DataGridViewTextBoxColumn7.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 5
        '
        'FrmTranSaleEntryBlngUsingChln
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.SpringGreen
        Me.ClientSize = New System.Drawing.Size(834, 632)
        Me.Controls.Add(Me.TxtDisRate)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CmbxDisType)
        Me.Controls.Add(Me.DgChlnInv)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.LstVewChllans)
        Me.Controls.Add(Me.CmbxVATrate)
        Me.Controls.Add(Me.DtpBilldt)
        Me.Controls.Add(Me.TxtInVatSurChrgs)
        Me.Controls.Add(Me.TxtInVat)
        Me.Controls.Add(Me.TxtTxAble)
        Me.Controls.Add(Me.TxtChrgsTxable)
        Me.Controls.Add(Me.TxtGrand)
        Me.Controls.Add(Me.TxtRondOff)
        Me.Controls.Add(Me.TxtOthrChrgs)
        Me.Controls.Add(Me.TxtDis)
        Me.Controls.Add(Me.TxtValue)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtInvNo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CmbxSplr)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranSaleEntryBlngUsingChln"
        Me.Text = "Purchase Entry Using Challan"
        CType(Me.DgChlnInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbxSplr As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtInvNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtpBilldt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDis As System.Windows.Forms.TextBox
    Friend WithEvents TxtValue As System.Windows.Forms.TextBox
    Friend WithEvents TxtOthrChrgs As System.Windows.Forms.TextBox
    Friend WithEvents TxtChrgsTxable As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtTxAble As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtInVat As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtInVatSurChrgs As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtRondOff As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtGrand As System.Windows.Forms.TextBox
    Friend WithEvents CmbxVATrate As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LstVewChllans As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents DgChlnInv As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmbxDisType As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtDisRate As System.Windows.Forms.TextBox
End Class
