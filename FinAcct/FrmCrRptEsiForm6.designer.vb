<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEsiForm6
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
        Me.BtnBonus = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.CrVewEsiF6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptEsiform61 = New FinAcct.CrRptEsiform6
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnBonus)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.dtpick2)
        Me.Panel1.Location = New System.Drawing.Point(0, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 41)
        Me.Panel1.TabIndex = 0
        '
        'BtnBonus
        '
        Me.BtnBonus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBonus.Location = New System.Drawing.Point(792, 9)
        Me.BtnBonus.Name = "BtnBonus"
        Me.BtnBonus.Size = New System.Drawing.Size(208, 23)
        Me.BtnBonus.TabIndex = 3
        Me.BtnBonus.Text = "View Report"
        Me.BtnBonus.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(327, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 18)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "To Month"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "From Month"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "MMMM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(106, 9)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(131, 20)
        Me.Dtpick1.TabIndex = 1
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "MMMM/yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(413, 9)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.ShowUpDown = True
        Me.dtpick2.Size = New System.Drawing.Size(131, 20)
        Me.dtpick2.TabIndex = 2
        '
        'CrVewEsiF6
        '
        Me.CrVewEsiF6.ActiveViewIndex = 0
        Me.CrVewEsiF6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEsiF6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEsiF6.Location = New System.Drawing.Point(0, 49)
        Me.CrVewEsiF6.Name = "CrVewEsiF6"
        Me.CrVewEsiF6.ReportSource = Me.CrRptEsiform61
        Me.CrVewEsiF6.Size = New System.Drawing.Size(1008, 0)
        Me.CrVewEsiF6.TabIndex = 2
        '
        'FrmCrRptEsiForm6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 46)
        Me.Controls.Add(Me.CrVewEsiF6)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEsiForm6"
        Me.Text = "Employee's State Insurance Form No. 6"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnBonus As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrVewEsiF6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptEsiform61 As fINACCT.CrRptEsiform6
End Class
