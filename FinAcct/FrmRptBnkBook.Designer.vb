<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptBnkBook
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Cmbxbb = New System.Windows.Forms.ComboBox
        Me.ChkbbAll = New System.Windows.Forms.CheckBox
        Me.ChkRptbb = New System.Windows.Forms.CheckBox
        Me.BtnRptVewbb = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpbb2 = New System.Windows.Forms.DateTimePicker
        Me.Dtpbb1 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewBB = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptBnkBook1 = New FinAcct.CrRptBnkBook
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Cmbxbb)
        Me.Panel1.Controls.Add(Me.ChkbbAll)
        Me.Panel1.Controls.Add(Me.ChkRptbb)
        Me.Panel1.Controls.Add(Me.BtnRptVewbb)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpbb2)
        Me.Panel1.Controls.Add(Me.Dtpbb1)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1015, 59)
        Me.Panel1.TabIndex = 0
        '
        'Cmbxbb
        '
        Me.Cmbxbb.FormattingEnabled = True
        Me.Cmbxbb.Location = New System.Drawing.Point(470, 18)
        Me.Cmbxbb.Name = "Cmbxbb"
        Me.Cmbxbb.Size = New System.Drawing.Size(387, 21)
        Me.Cmbxbb.TabIndex = 5
        '
        'ChkbbAll
        '
        Me.ChkbbAll.AutoSize = True
        Me.ChkbbAll.Checked = True
        Me.ChkbbAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkbbAll.Location = New System.Drawing.Point(424, 20)
        Me.ChkbbAll.Name = "ChkbbAll"
        Me.ChkbbAll.Size = New System.Drawing.Size(40, 17)
        Me.ChkbbAll.TabIndex = 4
        Me.ChkbbAll.Text = "All"
        Me.ChkbbAll.UseVisualStyleBackColor = True
        '
        'ChkRptbb
        '
        Me.ChkRptbb.AutoSize = True
        Me.ChkRptbb.Checked = True
        Me.ChkRptbb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRptbb.Location = New System.Drawing.Point(9, 20)
        Me.ChkRptbb.Name = "ChkRptbb"
        Me.ChkRptbb.Size = New System.Drawing.Size(211, 17)
        Me.ChkRptbb.TabIndex = 1
        Me.ChkRptbb.Text = "Company Information Required "
        Me.ChkRptbb.UseVisualStyleBackColor = True
        '
        'BtnRptVewbb
        '
        Me.BtnRptVewbb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRptVewbb.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnRptVewbb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRptVewbb.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRptVewbb.Location = New System.Drawing.Point(863, 12)
        Me.BtnRptVewbb.Name = "BtnRptVewbb"
        Me.BtnRptVewbb.Size = New System.Drawing.Size(143, 33)
        Me.BtnRptVewbb.TabIndex = 6
        Me.BtnRptVewbb.Text = "Report View"
        Me.BtnRptVewbb.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(251, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'Dtpbb2
        '
        Me.Dtpbb2.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbb2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbb2.Location = New System.Drawing.Point(292, 32)
        Me.Dtpbb2.Name = "Dtpbb2"
        Me.Dtpbb2.Size = New System.Drawing.Size(114, 21)
        Me.Dtpbb2.TabIndex = 3
        '
        'Dtpbb1
        '
        Me.Dtpbb1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbb1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbb1.Location = New System.Drawing.Point(293, 3)
        Me.Dtpbb1.Name = "Dtpbb1"
        Me.Dtpbb1.Size = New System.Drawing.Size(114, 21)
        Me.Dtpbb1.TabIndex = 2
        '
        'CrRptVewBB
        '
        Me.CrRptVewBB.ActiveViewIndex = 0
        Me.CrRptVewBB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrRptVewBB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewBB.Location = New System.Drawing.Point(0, 66)
        Me.CrRptVewBB.Name = "CrRptVewBB"
        Me.CrRptVewBB.ReportSource = Me.CrRptBnkBook1
        Me.CrRptVewBB.Size = New System.Drawing.Size(1017, 0)
        Me.CrRptVewBB.TabIndex = 0
        '
        'FrmRptBnkBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1017, 62)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrRptVewBB)
        Me.Name = "FrmRptBnkBook"
        Me.Text = "Report Bank Book"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewBB As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptBnkBook1 As FinAcct.CrRptBnkBook
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ChkRptbb As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRptVewbb As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpbb2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpbb1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkbbAll As System.Windows.Forms.CheckBox
    Friend WithEvents Cmbxbb As System.Windows.Forms.ComboBox
End Class
