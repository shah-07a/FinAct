<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptVAT16
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
        Me.CrRptVewVAT16 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptVATForm161 = New FinAcct.CrRptVATForm16
        Me.SuspendLayout()
        '
        'CrRptVewVAT16
        '
        Me.CrRptVewVAT16.ActiveViewIndex = 0
        Me.CrRptVewVAT16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewVAT16.DisplayGroupTree = False
        Me.CrRptVewVAT16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrRptVewVAT16.Location = New System.Drawing.Point(0, 0)
        Me.CrRptVewVAT16.Name = "CrRptVewVAT16"
        Me.CrRptVewVAT16.ReportSource = Me.CrRptVATForm161
        Me.CrRptVewVAT16.ShowRefreshButton = False
        Me.CrRptVewVAT16.Size = New System.Drawing.Size(794, 0)
        Me.CrRptVewVAT16.TabIndex = 0
        '
        'FrmCrRptVAT16
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(794, 0)
        Me.Controls.Add(Me.CrRptVewVAT16)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmCrRptVAT16"
        Me.Text = "FrmCrRptVAT16"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewVAT16 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptVATForm161 As FinAcct.CrRptVATForm16
End Class
