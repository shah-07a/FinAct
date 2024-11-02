<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEmpAttend
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
        Me.CrVewAttnd = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptEmp_Attnd_mnthly1 = New fINACCT.CrRptEmp_Attnd_mnthly
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnAttndVew = New System.Windows.Forms.Button
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtp1 = New System.Windows.Forms.DateTimePicker
        Me.Combdesi = New System.Windows.Forms.ComboBox
        Me.Lbldesi = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Rb2 = New System.Windows.Forms.RadioButton
        Me.Rb1 = New System.Windows.Forms.RadioButton
        Me.lbldeptcriteria = New System.Windows.Forms.Label
        Me.Combodeptnm = New System.Windows.Forms.ComboBox
        Me.Lbldept = New System.Windows.Forms.Label
        Me.Combotoid = New System.Windows.Forms.ComboBox
        Me.Lbltoid = New System.Windows.Forms.Label
        Me.Combofromid = New System.Windows.Forms.ComboBox
        Me.Lblempid = New System.Windows.Forms.Label
        Me.Combename = New System.Windows.Forms.ComboBox
        Me.Lblempnm = New System.Windows.Forms.Label
        Me.Combcatgry = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrVewAttnd
        '
        Me.CrVewAttnd.ActiveViewIndex = 0
        Me.CrVewAttnd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewAttnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewAttnd.DisplayGroupTree = False
        Me.CrVewAttnd.Location = New System.Drawing.Point(7, 102)
        Me.CrVewAttnd.Name = "CrVewAttnd"
        Me.CrVewAttnd.ReportSource = Me.CrRptEmp_Attnd_mnthly1
        Me.CrVewAttnd.ShowRefreshButton = False
        Me.CrVewAttnd.Size = New System.Drawing.Size(859, 0)
        Me.CrVewAttnd.TabIndex = 21
        Me.CrVewAttnd.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnAttndVew)
        Me.Panel2.Controls.Add(Me.Dtpick1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.dtp1)
        Me.Panel2.Controls.Add(Me.Combdesi)
        Me.Panel2.Controls.Add(Me.Lbldesi)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.lbldeptcriteria)
        Me.Panel2.Controls.Add(Me.Combodeptnm)
        Me.Panel2.Controls.Add(Me.Lbldept)
        Me.Panel2.Controls.Add(Me.Combotoid)
        Me.Panel2.Controls.Add(Me.Lbltoid)
        Me.Panel2.Controls.Add(Me.Combofromid)
        Me.Panel2.Controls.Add(Me.Lblempid)
        Me.Panel2.Controls.Add(Me.Combename)
        Me.Panel2.Controls.Add(Me.Lblempnm)
        Me.Panel2.Controls.Add(Me.Combcatgry)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(7, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(859, 93)
        Me.Panel2.TabIndex = 0
        '
        'BtnAttndVew
        '
        Me.BtnAttndVew.Location = New System.Drawing.Point(748, 64)
        Me.BtnAttndVew.Name = "BtnAttndVew"
        Me.BtnAttndVew.Size = New System.Drawing.Size(106, 23)
        Me.BtnAttndVew.TabIndex = 40
        Me.BtnAttndVew.Text = "View Report"
        Me.BtnAttndVew.UseVisualStyleBackColor = True
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "MMMM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(143, 8)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(122, 20)
        Me.Dtpick1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 18)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Month/Year"
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "dd/MM/yyyy"
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp1.Location = New System.Drawing.Point(475, 65)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(83, 20)
        Me.dtp1.TabIndex = 38
        Me.dtp1.Visible = False
        '
        'Combdesi
        '
        Me.Combdesi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combdesi.DropDownWidth = 100
        Me.Combdesi.FormattingEnabled = True
        Me.Combdesi.Location = New System.Drawing.Point(143, 64)
        Me.Combdesi.Name = "Combdesi"
        Me.Combdesi.Size = New System.Drawing.Size(140, 21)
        Me.Combdesi.TabIndex = 5
        Me.Combdesi.Visible = False
        '
        'Lbldesi
        '
        Me.Lbldesi.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbldesi.Location = New System.Drawing.Point(3, 64)
        Me.Lbldesi.Name = "Lbldesi"
        Me.Lbldesi.Size = New System.Drawing.Size(129, 19)
        Me.Lbldesi.TabIndex = 37
        Me.Lbldesi.Text = "Designation  Name"
        Me.Lbldesi.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Rb2)
        Me.Panel1.Controls.Add(Me.Rb1)
        Me.Panel1.Location = New System.Drawing.Point(552, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(192, 26)
        Me.Panel1.TabIndex = 30
        Me.Panel1.Visible = False
        '
        'Rb2
        '
        Me.Rb2.AutoSize = True
        Me.Rb2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb2.Location = New System.Drawing.Point(63, 6)
        Me.Rb2.Name = "Rb2"
        Me.Rb2.Size = New System.Drawing.Size(124, 19)
        Me.Rb2.TabIndex = 5
        Me.Rb2.Text = "Designation Wise"
        Me.Rb2.UseVisualStyleBackColor = True
        '
        'Rb1
        '
        Me.Rb1.AutoSize = True
        Me.Rb1.Checked = True
        Me.Rb1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb1.Location = New System.Drawing.Point(8, 5)
        Me.Rb1.Name = "Rb1"
        Me.Rb1.Size = New System.Drawing.Size(39, 19)
        Me.Rb1.TabIndex = 4
        Me.Rb1.TabStop = True
        Me.Rb1.Text = "All"
        Me.Rb1.UseVisualStyleBackColor = True
        '
        'lbldeptcriteria
        '
        Me.lbldeptcriteria.BackColor = System.Drawing.SystemColors.Control
        Me.lbldeptcriteria.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldeptcriteria.Location = New System.Drawing.Point(478, 35)
        Me.lbldeptcriteria.Name = "lbldeptcriteria"
        Me.lbldeptcriteria.Size = New System.Drawing.Size(80, 19)
        Me.lbldeptcriteria.TabIndex = 36
        Me.lbldeptcriteria.Text = "Search By"
        Me.lbldeptcriteria.Visible = False
        '
        'Combodeptnm
        '
        Me.Combodeptnm.FormattingEnabled = True
        Me.Combodeptnm.Location = New System.Drawing.Point(143, 35)
        Me.Combodeptnm.Name = "Combodeptnm"
        Me.Combodeptnm.Size = New System.Drawing.Size(237, 21)
        Me.Combodeptnm.TabIndex = 3
        Me.Combodeptnm.Visible = False
        '
        'Lbldept
        '
        Me.Lbldept.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbldept.Location = New System.Drawing.Point(3, 37)
        Me.Lbldept.Name = "Lbldept"
        Me.Lbldept.Size = New System.Drawing.Size(129, 19)
        Me.Lbldept.TabIndex = 35
        Me.Lbldept.Text = "Department  Name"
        Me.Lbldept.Visible = False
        '
        'Combotoid
        '
        Me.Combotoid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combotoid.FormattingEnabled = True
        Me.Combotoid.Location = New System.Drawing.Point(334, 36)
        Me.Combotoid.Name = "Combotoid"
        Me.Combotoid.Size = New System.Drawing.Size(140, 21)
        Me.Combotoid.TabIndex = 4
        Me.Combotoid.Visible = False
        '
        'Lbltoid
        '
        Me.Lbltoid.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbltoid.Location = New System.Drawing.Point(289, 36)
        Me.Lbltoid.Name = "Lbltoid"
        Me.Lbltoid.Size = New System.Drawing.Size(29, 19)
        Me.Lbltoid.TabIndex = 34
        Me.Lbltoid.Text = "To"
        Me.Lbltoid.Visible = False
        '
        'Combofromid
        '
        Me.Combofromid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combofromid.FormattingEnabled = True
        Me.Combofromid.Location = New System.Drawing.Point(143, 35)
        Me.Combofromid.Name = "Combofromid"
        Me.Combofromid.Size = New System.Drawing.Size(140, 21)
        Me.Combofromid.TabIndex = 29
        Me.Combofromid.Visible = False
        '
        'Lblempid
        '
        Me.Lblempid.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblempid.Location = New System.Drawing.Point(8, 37)
        Me.Lblempid.Name = "Lblempid"
        Me.Lblempid.Size = New System.Drawing.Size(56, 19)
        Me.Lblempid.TabIndex = 33
        Me.Lblempid.Text = "From "
        Me.Lblempid.Visible = False
        '
        'Combename
        '
        Me.Combename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combename.FormattingEnabled = True
        Me.Combename.Location = New System.Drawing.Point(143, 37)
        Me.Combename.Name = "Combename"
        Me.Combename.Size = New System.Drawing.Size(268, 21)
        Me.Combename.TabIndex = 28
        Me.Combename.Visible = False
        '
        'Lblempnm
        '
        Me.Lblempnm.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblempnm.Location = New System.Drawing.Point(4, 37)
        Me.Lblempnm.Name = "Lblempnm"
        Me.Lblempnm.Size = New System.Drawing.Size(123, 19)
        Me.Lblempnm.TabIndex = 31
        Me.Lblempnm.Text = "Employee Name"
        Me.Lblempnm.Visible = False
        '
        'Combcatgry
        '
        Me.Combcatgry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combcatgry.FormattingEnabled = True
        Me.Combcatgry.Items.AddRange(New Object() {"All", "Employee Name", "Employee ID", "Department wise"})
        Me.Combcatgry.Location = New System.Drawing.Point(401, 7)
        Me.Combcatgry.Name = "Combcatgry"
        Me.Combcatgry.Size = New System.Drawing.Size(453, 21)
        Me.Combcatgry.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(271, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 19)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Selection Criteria"
        '
        'FrmCrRptEmpAttend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(873, 103)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CrVewAttnd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCrRptEmpAttend"
        Me.Text = "Attendance"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrVewAttnd As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptEmp_Attnd_mnthly1 As fINACCT.CrRptEmp_Attnd_mnthly
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnAttndVew As System.Windows.Forms.Button
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Combdesi As System.Windows.Forms.ComboBox
    Friend WithEvents Lbldesi As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents Rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents lbldeptcriteria As System.Windows.Forms.Label
    Friend WithEvents Combodeptnm As System.Windows.Forms.ComboBox
    Friend WithEvents Lbldept As System.Windows.Forms.Label
    Friend WithEvents Combotoid As System.Windows.Forms.ComboBox
    Friend WithEvents Lbltoid As System.Windows.Forms.Label
    Friend WithEvents Combofromid As System.Windows.Forms.ComboBox
    Friend WithEvents Lblempid As System.Windows.Forms.Label
    Friend WithEvents Combename As System.Windows.Forms.ComboBox
    Friend WithEvents Lblempnm As System.Windows.Forms.Label
    Friend WithEvents Combcatgry As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
