<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptBoMCostingChild
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
        Me.Dtp1 = New System.Windows.Forms.DateTimePicker
        Me.Dtp2 = New System.Windows.Forms.DateTimePicker
        Me.CrRptVewBomCost = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptBOMCosting1 = New FinAcct.CrRptBOMCosting
        Me.SuspendLayout()
        '
        'Dtp1
        '
        Me.Dtp1.Enabled = False
        Me.Dtp1.Location = New System.Drawing.Point(493, 0)
        Me.Dtp1.Name = "Dtp1"
        Me.Dtp1.Size = New System.Drawing.Size(200, 20)
        Me.Dtp1.TabIndex = 1
        Me.Dtp1.Visible = False
        '
        'Dtp2
        '
        Me.Dtp2.Enabled = False
        Me.Dtp2.Location = New System.Drawing.Point(493, 22)
        Me.Dtp2.Name = "Dtp2"
        Me.Dtp2.Size = New System.Drawing.Size(200, 20)
        Me.Dtp2.TabIndex = 2
        Me.Dtp2.Visible = False
        '
        'CrRptVewBomCost
        '
        Me.CrRptVewBomCost.ActiveViewIndex = 0
        Me.CrRptVewBomCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewBomCost.DisplayGroupTree = False
        Me.CrRptVewBomCost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrRptVewBomCost.Location = New System.Drawing.Point(0, 0)
        Me.CrRptVewBomCost.Name = "CrRptVewBomCost"
        Me.CrRptVewBomCost.ReportSource = Me.CrRptBOMCosting1
        Me.CrRptVewBomCost.ShowRefreshButton = False
        Me.CrRptVewBomCost.Size = New System.Drawing.Size(944, 624)
        Me.CrRptVewBomCost.TabIndex = 0
        '
        'FrmCrRptBoMCostingChild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(944, 624)
        Me.Controls.Add(Me.Dtp2)
        Me.Controls.Add(Me.Dtp1)
        Me.Controls.Add(Me.CrRptVewBomCost)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCrRptBoMCostingChild"
        Me.Text = "Bill Of Material Costing (BOM Costing)"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrRptVewBomCost As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptBOMCosting1 As FinAcct.CrRptBOMCosting
    Friend WithEvents Dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp2 As System.Windows.Forms.DateTimePicker
End Class
