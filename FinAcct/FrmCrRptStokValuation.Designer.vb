<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptStokValuation
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DgStkVal = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnOk = New System.Windows.Forms.Button
        Me.ChkbxItm = New System.Windows.Forms.CheckBox
        Me.CmbxItems = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RbStnd = New System.Windows.Forms.RadioButton
        Me.RbMnthlyAvg = New System.Windows.Forms.RadioButton
        Me.RbOalAvg = New System.Windows.Forms.RadioButton
        Me.RbFifo = New System.Windows.Forms.RadioButton
        Me.Grpbox1 = New System.Windows.Forms.GroupBox
        Me.RbSaleItm = New System.Windows.Forms.RadioButton
        Me.RbPurItm = New System.Windows.Forms.RadioButton
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DgStkVal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Grpbox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgStkVal
        '
        Me.DgStkVal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgStkVal.BackgroundColor = System.Drawing.Color.NavajoWhite
        Me.DgStkVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgStkVal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column6, Me.Column7, Me.Column2, Me.Column5, Me.Column3, Me.Column4})
        Me.DgStkVal.Location = New System.Drawing.Point(3, 125)
        Me.DgStkVal.Name = "DgStkVal"
        Me.DgStkVal.Size = New System.Drawing.Size(894, 155)
        Me.DgStkVal.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Particulars "
        Me.Column1.MaxInputLength = 100
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 200
        '
        'Column6
        '
        Me.Column6.HeaderText = "Quantity (IN)"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Quantity (OUT)"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column2
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N3"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column2.HeaderText = "Stock In Hand"
        Me.Column2.MaxInputLength = 20
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Unit"
        Me.Column5.MaxInputLength = 30
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Rate"
        Me.Column3.MaxInputLength = 20
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "Amount"
        Me.Column4.MaxInputLength = 20
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 125
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.FinAcct.My.Resources.Resources.METALC4C1
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.BtnOk)
        Me.Panel1.Controls.Add(Me.ChkbxItm)
        Me.Panel1.Controls.Add(Me.CmbxItems)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Grpbox1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(894, 124)
        Me.Panel1.TabIndex = 0
        '
        'BtnOk
        '
        Me.BtnOk.BackgroundImage = Global.FinAcct.My.Resources.Resources.METALC5C
        Me.BtnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOk.FlatAppearance.BorderSize = 0
        Me.BtnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.ForeColor = System.Drawing.Color.Navy
        Me.BtnOk.Location = New System.Drawing.Point(634, 87)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(105, 25)
        Me.BtnOk.TabIndex = 12
        Me.BtnOk.Text = "&OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'ChkbxItm
        '
        Me.ChkbxItm.AutoSize = True
        Me.ChkbxItm.ForeColor = System.Drawing.Color.Navy
        Me.ChkbxItm.Location = New System.Drawing.Point(97, 91)
        Me.ChkbxItm.Name = "ChkbxItm"
        Me.ChkbxItm.Size = New System.Drawing.Size(93, 17)
        Me.ChkbxItm.TabIndex = 10
        Me.ChkbxItm.Text = "ALL ITEMS"
        Me.ChkbxItm.UseVisualStyleBackColor = True
        '
        'CmbxItems
        '
        Me.CmbxItems.Enabled = False
        Me.CmbxItems.FormattingEnabled = True
        Me.CmbxItems.Location = New System.Drawing.Point(228, 91)
        Me.CmbxItems.Name = "CmbxItems"
        Me.CmbxItems.Size = New System.Drawing.Size(400, 21)
        Me.CmbxItems.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbStnd)
        Me.GroupBox1.Controls.Add(Me.RbMnthlyAvg)
        Me.GroupBox1.Controls.Add(Me.RbOalAvg)
        Me.GroupBox1.Controls.Add(Me.RbFifo)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(228, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 39)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "METHOD"
        '
        'RbStnd
        '
        Me.RbStnd.AutoSize = True
        Me.RbStnd.Location = New System.Drawing.Point(428, 15)
        Me.RbStnd.Name = "RbStnd"
        Me.RbStnd.Size = New System.Drawing.Size(120, 17)
        Me.RbStnd.TabIndex = 6
        Me.RbStnd.TabStop = True
        Me.RbStnd.Text = "MANUAL PRICE"
        Me.RbStnd.UseVisualStyleBackColor = True
        '
        'RbMnthlyAvg
        '
        Me.RbMnthlyAvg.AutoSize = True
        Me.RbMnthlyAvg.Location = New System.Drawing.Point(261, 15)
        Me.RbMnthlyAvg.Name = "RbMnthlyAvg"
        Me.RbMnthlyAvg.Size = New System.Drawing.Size(161, 17)
        Me.RbMnthlyAvg.TabIndex = 5
        Me.RbMnthlyAvg.TabStop = True
        Me.RbMnthlyAvg.Text = "MONTHLY AVG. PRICE"
        Me.RbMnthlyAvg.UseVisualStyleBackColor = True
        '
        'RbOalAvg
        '
        Me.RbOalAvg.AutoSize = True
        Me.RbOalAvg.Location = New System.Drawing.Point(69, 15)
        Me.RbOalAvg.Name = "RbOalAvg"
        Me.RbOalAvg.Size = New System.Drawing.Size(186, 17)
        Me.RbOalAvg.TabIndex = 4
        Me.RbOalAvg.TabStop = True
        Me.RbOalAvg.Text = "OVERALL AVERAGE PRICE"
        Me.RbOalAvg.UseVisualStyleBackColor = True
        '
        'RbFifo
        '
        Me.RbFifo.AutoSize = True
        Me.RbFifo.Checked = True
        Me.RbFifo.Location = New System.Drawing.Point(7, 15)
        Me.RbFifo.Name = "RbFifo"
        Me.RbFifo.Size = New System.Drawing.Size(56, 17)
        Me.RbFifo.TabIndex = 3
        Me.RbFifo.TabStop = True
        Me.RbFifo.Text = "FIFO"
        Me.RbFifo.UseVisualStyleBackColor = True
        '
        'Grpbox1
        '
        Me.Grpbox1.Controls.Add(Me.RbSaleItm)
        Me.Grpbox1.Controls.Add(Me.RbPurItm)
        Me.Grpbox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grpbox1.ForeColor = System.Drawing.Color.Navy
        Me.Grpbox1.Location = New System.Drawing.Point(228, 7)
        Me.Grpbox1.Name = "Grpbox1"
        Me.Grpbox1.Size = New System.Drawing.Size(400, 39)
        Me.Grpbox1.TabIndex = 7
        Me.Grpbox1.TabStop = False
        Me.Grpbox1.Text = "TYPE OF STOCK"
        '
        'RbSaleItm
        '
        Me.RbSaleItm.AutoSize = True
        Me.RbSaleItm.Location = New System.Drawing.Point(210, 15)
        Me.RbSaleItm.Name = "RbSaleItm"
        Me.RbSaleItm.Size = New System.Drawing.Size(181, 17)
        Me.RbSaleItm.TabIndex = 9
        Me.RbSaleItm.TabStop = True
        Me.RbSaleItm.Text = "SALE ITEMS (OUTWARD)"
        Me.RbSaleItm.UseVisualStyleBackColor = True
        '
        'RbPurItm
        '
        Me.RbPurItm.AutoSize = True
        Me.RbPurItm.Checked = True
        Me.RbPurItm.Location = New System.Drawing.Point(7, 15)
        Me.RbPurItm.Name = "RbPurItm"
        Me.RbPurItm.Size = New System.Drawing.Size(197, 17)
        Me.RbPurItm.TabIndex = 8
        Me.RbPurItm.TabStop = True
        Me.RbPurItm.Text = "PURCHAE ITEMS (INWARD)"
        Me.RbPurItm.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Particulars "
        Me.DataGridViewTextBoxColumn1.MaxInputLength = 400
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 400
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn2.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 18
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn3.HeaderText = "Rate"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 18
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn4.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 18
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 30
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn6.HeaderText = "Rate"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn7.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn7.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 125
        '
        'FrmCrRptStokValuation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(894, 277)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DgStkVal)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCrRptStokValuation"
        Me.Text = "Stock Valuation "
        CType(Me.DgStkVal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Grpbox1.ResumeLayout(False)
        Me.Grpbox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgStkVal As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Grpbox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkbxItm As System.Windows.Forms.CheckBox
    Friend WithEvents CmbxItems As System.Windows.Forms.ComboBox
    Friend WithEvents RbPurItm As System.Windows.Forms.RadioButton
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RbSaleItm As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbOalAvg As System.Windows.Forms.RadioButton
    Friend WithEvents RbFifo As System.Windows.Forms.RadioButton
    Friend WithEvents RbStnd As System.Windows.Forms.RadioButton
    Friend WithEvents RbMnthlyAvg As System.Windows.Forms.RadioButton
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
