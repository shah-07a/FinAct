<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWelcomeSplashScreen
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
        Me.Btnexit = New System.Windows.Forms.Button
        Me.CrRptVewWelcome = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptWelcome1 = New FinAcct.CrRptWelcome
        Me.SuspendLayout()
        '
        'Btnexit
        '
        Me.Btnexit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btnexit.BackColor = System.Drawing.SystemColors.Control
        Me.Btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnexit.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Btnexit.Location = New System.Drawing.Point(810, 3)
        Me.Btnexit.Name = "Btnexit"
        Me.Btnexit.Size = New System.Drawing.Size(19, 23)
        Me.Btnexit.TabIndex = 2
        Me.Btnexit.Text = "X"
        Me.Btnexit.UseVisualStyleBackColor = False
        '
        'CrRptVewWelcome
        '
        Me.CrRptVewWelcome.ActiveViewIndex = 0
        Me.CrRptVewWelcome.AutoSize = True
        Me.CrRptVewWelcome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrRptVewWelcome.DisplayGroupTree = False
        Me.CrRptVewWelcome.DisplayStatusBar = False
        Me.CrRptVewWelcome.DisplayToolbar = False
        Me.CrRptVewWelcome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrRptVewWelcome.Location = New System.Drawing.Point(0, 0)
        Me.CrRptVewWelcome.Name = "CrRptVewWelcome"
        Me.CrRptVewWelcome.ReportSource = Me.CrRptWelcome1
        Me.CrRptVewWelcome.ShowGroupTreeButton = False
        Me.CrRptVewWelcome.ShowPageNavigateButtons = False
        Me.CrRptVewWelcome.ShowRefreshButton = False
        Me.CrRptVewWelcome.Size = New System.Drawing.Size(835, 396)
        Me.CrRptVewWelcome.TabIndex = 1
        Me.CrRptVewWelcome.UseWaitCursor = True
        '
        'FrmWelcomeSplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(835, 396)
        Me.ControlBox = False
        Me.Controls.Add(Me.Btnexit)
        Me.Controls.Add(Me.CrRptVewWelcome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmWelcomeSplashScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrRptVewWelcome As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptWelcome1 As FinAcct.CrRptWelcome
    Friend WithEvents Btnexit As System.Windows.Forms.Button

End Class
