<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptRoContri
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnEsiGo = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.DgvewEsiRoc = New System.Windows.Forms.DataGridView
        Me.Coldepdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TempEsiRoCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtnEsibnk = New System.Windows.Forms.Button
        Me.CrVewRoContri = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptInsurance1 = New FinAcct.CrRptInsurance
        Me.Btnsave = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.DgvewEsiRoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TempEsiRoCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnEsiGo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.dtpick2)
        Me.Panel1.Controls.Add(Me.DgvewEsiRoc)
        Me.Panel1.Location = New System.Drawing.Point(2, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1003, 178)
        Me.Panel1.TabIndex = 0
        '
        'BtnEsiGo
        '
        Me.BtnEsiGo.Location = New System.Drawing.Point(850, 6)
        Me.BtnEsiGo.Name = "BtnEsiGo"
        Me.BtnEsiGo.Size = New System.Drawing.Size(144, 23)
        Me.BtnEsiGo.TabIndex = 2
        Me.BtnEsiGo.Text = "<Go>"
        Me.BtnEsiGo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(455, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 18)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "To Month"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 18)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Contribution Period From Month"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "MMMM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(231, 6)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(151, 20)
        Me.Dtpick1.TabIndex = 0
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "MMMM/yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(546, 6)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.ShowUpDown = True
        Me.dtpick2.Size = New System.Drawing.Size(151, 20)
        Me.dtpick2.TabIndex = 1
        '
        'DgvewEsiRoc
        '
        Me.DgvewEsiRoc.AllowUserToOrderColumns = True
        Me.DgvewEsiRoc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvewEsiRoc.AutoGenerateColumns = False
        Me.DgvewEsiRoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvewEsiRoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Coldepdate})
        Me.DgvewEsiRoc.DataSource = Me.TempEsiRoCBindingSource
        Me.DgvewEsiRoc.Location = New System.Drawing.Point(7, 35)
        Me.DgvewEsiRoc.Name = "DgvewEsiRoc"
        Me.DgvewEsiRoc.Size = New System.Drawing.Size(991, 140)
        Me.DgvewEsiRoc.TabIndex = 3
        '
        'Coldepdate
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Coldepdate.DefaultCellStyle = DataGridViewCellStyle8
        Me.Coldepdate.HeaderText = "Deposit Date"
        Me.Coldepdate.Name = "Coldepdate"
        '
        'TempEsiRoCBindingSource
        '
        Me.TempEsiRoCBindingSource.DataMember = "Temp_Esi_RoC"
        '
        'BtnEsibnk
        '
        Me.BtnEsibnk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEsibnk.Enabled = False
        Me.BtnEsibnk.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEsibnk.Location = New System.Drawing.Point(629, 189)
        Me.BtnEsibnk.Name = "BtnEsibnk"
        Me.BtnEsibnk.Size = New System.Drawing.Size(376, 23)
        Me.BtnEsibnk.TabIndex = 4
        Me.BtnEsibnk.Text = "View Report"
        Me.BtnEsibnk.UseVisualStyleBackColor = True
        '
        'CrVewRoContri
        '
        Me.CrVewRoContri.ActiveViewIndex = 0
        Me.CrVewRoContri.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewRoContri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewRoContri.DisplayGroupTree = False
        Me.CrVewRoContri.Enabled = False
        Me.CrVewRoContri.Location = New System.Drawing.Point(2, 218)
        Me.CrVewRoContri.Name = "CrVewRoContri"
        Me.CrVewRoContri.ReportSource = Me.CrRptInsurance1
        Me.CrVewRoContri.ShowRefreshButton = False
        Me.CrVewRoContri.Size = New System.Drawing.Size(1003, 0)
        Me.CrVewRoContri.TabIndex = 5
        '
        'Btnsave
        '
        Me.Btnsave.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnsave.Location = New System.Drawing.Point(2, 189)
        Me.Btnsave.Name = "Btnsave"
        Me.Btnsave.Size = New System.Drawing.Size(124, 23)
        Me.Btnsave.TabIndex = 6
        Me.Btnsave.Text = "Save this report"
        Me.Btnsave.UseVisualStyleBackColor = True
        Me.Btnsave.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(142, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Warning!"
        Me.Label2.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(216, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(407, 28)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Once you save this report you can't edit or delete this report. So make sure that" & _
            " all enteries are correct."
        Me.Label4.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "mnthname"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn1.HeaderText = "mnthname"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "mnthno"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn2.HeaderText = "mnthno"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 180
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "empEsi"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.Format = "C2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn3.HeaderText = "empEsi"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 180
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "emplrEsi"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.Format = "C2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn4.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "emplrEsi"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "mnthname"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.Format = "C2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn5.HeaderText = "Deposit Date"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 200
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "mnthname"
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.Format = "00/00/0000"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn6.HeaderText = "Deposit Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'FrmCrRptRoContri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 215)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Btnsave)
        Me.Controls.Add(Me.CrVewRoContri)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnEsibnk)
        Me.Name = "FrmCrRptRoContri"
        Me.Text = "Employee's State Insurance Corporation Return Of Contribution (Regulation 26)"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DgvewEsiRoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TempEsiRoCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnEsibnk As System.Windows.Forms.Button
    Friend WithEvents CrVewRoContri As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptInsurance1 As FinAcct.CrRptInsurance
    Friend WithEvents DgvewEsiRoc As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    'Friend WithEvents HrPrData08DataSet As FinAcct.HrPrData08DataSet
    Friend WithEvents TempEsiRoCBindingSource As System.Windows.Forms.BindingSource
    ' Friend WithEvents Temp_Esi_RoCTableAdapter As FinAcct.HrPrData08DataSetTableAdapters.Temp_Esi_RoCTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnEsiGo As System.Windows.Forms.Button
    Friend WithEvents MnthnameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpEsiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmplrEsiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotlernDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotlesiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Coldepdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
