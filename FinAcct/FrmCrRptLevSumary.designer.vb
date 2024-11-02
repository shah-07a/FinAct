<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptLevSumary
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
        Me.Labtm = New System.Windows.Forms.Label
        Me.Dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.Labto = New System.Windows.Forms.Label
        Me.Labfrm = New System.Windows.Forms.Label
        Me.Lblempnm = New System.Windows.Forms.Label
        Me.Combcatgry = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Combofromid = New System.Windows.Forms.ComboBox
        Me.Lblempid = New System.Windows.Forms.Label
        Me.Combename = New System.Windows.Forms.ComboBox
        Me.BtnLww = New System.Windows.Forms.Button
        Me.CrVewLww = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptLwwRegstr1 = New FinAcct.CrRptLwwRegstr
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'Labtm
        '
        Me.Labtm.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labtm.Location = New System.Drawing.Point(12, 28)
        Me.Labtm.Name = "Labtm"
        Me.Labtm.Size = New System.Drawing.Size(86, 18)
        Me.Labtm.TabIndex = 23
        Me.Labtm.Text = "Time Period"
        '
        'Dtpick2
        '
        Me.Dtpick2.CustomFormat = "MMMM/yyyy"
        Me.Dtpick2.Enabled = False
        Me.Dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick2.Location = New System.Drawing.Point(346, 25)
        Me.Dtpick2.Name = "Dtpick2"
        Me.Dtpick2.Size = New System.Drawing.Size(120, 20)
        Me.Dtpick2.TabIndex = 1
        '
        'Labto
        '
        Me.Labto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labto.Location = New System.Drawing.Point(305, 28)
        Me.Labto.Name = "Labto"
        Me.Labto.Size = New System.Drawing.Size(35, 18)
        Me.Labto.TabIndex = 24
        Me.Labto.Text = "To"
        '
        'Labfrm
        '
        Me.Labfrm.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labfrm.Location = New System.Drawing.Point(92, 28)
        Me.Labfrm.Name = "Labfrm"
        Me.Labfrm.Size = New System.Drawing.Size(43, 18)
        Me.Labfrm.TabIndex = 25
        Me.Labfrm.Text = "From"
        '
        'Lblempnm
        '
        Me.Lblempnm.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblempnm.Location = New System.Drawing.Point(12, 95)
        Me.Lblempnm.Name = "Lblempnm"
        Me.Lblempnm.Size = New System.Drawing.Size(99, 19)
        Me.Lblempnm.TabIndex = 26
        Me.Lblempnm.Text = "Employee Name"
        Me.Lblempnm.Visible = False
        '
        'Combcatgry
        '
        Me.Combcatgry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combcatgry.DropDownWidth = 50
        Me.Combcatgry.FormattingEnabled = True
        Me.Combcatgry.Items.AddRange(New Object() {"Employee Name", "Employee ID"})
        Me.Combcatgry.Location = New System.Drawing.Point(177, 59)
        Me.Combcatgry.Name = "Combcatgry"
        Me.Combcatgry.Size = New System.Drawing.Size(198, 21)
        Me.Combcatgry.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 19)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Selection Criteria"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(486, 25)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(92, 20)
        Me.DateTimePicker2.TabIndex = 44
        Me.DateTimePicker2.Visible = False
        '
        'Combofromid
        '
        Me.Combofromid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combofromid.DropDownWidth = 70
        Me.Combofromid.FormattingEnabled = True
        Me.Combofromid.Location = New System.Drawing.Point(177, 95)
        Me.Combofromid.Name = "Combofromid"
        Me.Combofromid.Size = New System.Drawing.Size(140, 21)
        Me.Combofromid.TabIndex = 3
        Me.Combofromid.Visible = False
        '
        'Lblempid
        '
        Me.Lblempid.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblempid.Location = New System.Drawing.Point(12, 95)
        Me.Lblempid.Name = "Lblempid"
        Me.Lblempid.Size = New System.Drawing.Size(86, 19)
        Me.Lblempid.TabIndex = 39
        Me.Lblempid.Text = "Employee Id"
        Me.Lblempid.Visible = False
        '
        'Combename
        '
        Me.Combename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combename.DropDownWidth = 70
        Me.Combename.FormattingEnabled = True
        Me.Combename.Location = New System.Drawing.Point(177, 95)
        Me.Combename.Name = "Combename"
        Me.Combename.Size = New System.Drawing.Size(198, 21)
        Me.Combename.TabIndex = 3
        Me.Combename.Visible = False
        '
        'BtnLww
        '
        Me.BtnLww.Location = New System.Drawing.Point(467, 93)
        Me.BtnLww.Name = "BtnLww"
        Me.BtnLww.Size = New System.Drawing.Size(111, 23)
        Me.BtnLww.TabIndex = 5
        Me.BtnLww.Text = "View Report"
        Me.BtnLww.UseVisualStyleBackColor = True
        '
        'CrVewLww
        '
        Me.CrVewLww.ActiveViewIndex = 0
        Me.CrVewLww.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewLww.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewLww.DisplayGroupTree = False
        Me.CrVewLww.Enabled = False
        Me.CrVewLww.Location = New System.Drawing.Point(15, 127)
        Me.CrVewLww.Name = "CrVewLww"
        Me.CrVewLww.ReportSource = Me.CrRptLwwRegstr1
        Me.CrVewLww.ShowGroupTreeButton = False
        Me.CrVewLww.ShowRefreshButton = False
        Me.CrVewLww.Size = New System.Drawing.Size(1000, 0)
        Me.CrVewLww.TabIndex = 6
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "MMMM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(177, 25)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.Size = New System.Drawing.Size(118, 20)
        Me.Dtpick1.TabIndex = 0
        '
        'FrmCrRptLevSumary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1019, 123)
        Me.Controls.Add(Me.Dtpick1)
        Me.Controls.Add(Me.BtnLww)
        Me.Controls.Add(Me.CrVewLww)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Combofromid)
        Me.Controls.Add(Me.Lblempid)
        Me.Controls.Add(Me.Combename)
        Me.Controls.Add(Me.Combcatgry)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Lblempnm)
        Me.Controls.Add(Me.Labfrm)
        Me.Controls.Add(Me.Labto)
        Me.Controls.Add(Me.Labtm)
        Me.Controls.Add(Me.Dtpick2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCrRptLevSumary"
        Me.Text = "Register of leaves with wages"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Labtm As System.Windows.Forms.Label
    Friend WithEvents Dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Labto As System.Windows.Forms.Label
    Friend WithEvents Labfrm As System.Windows.Forms.Label
    Friend WithEvents Lblempnm As System.Windows.Forms.Label
    Friend WithEvents Combcatgry As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Combofromid As System.Windows.Forms.ComboBox
    Friend WithEvents Lblempid As System.Windows.Forms.Label
    Friend WithEvents Combename As System.Windows.Forms.ComboBox
    Friend WithEvents CrVewLww As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptLwwRegstr1 As fINACCT.CrRptLwwRegstr
    Friend WithEvents BtnLww As System.Windows.Forms.Button
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
End Class
