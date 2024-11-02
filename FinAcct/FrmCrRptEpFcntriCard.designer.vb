<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEpFcntriCard
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
        Me.TxtAcNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnEPFcntri = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.CrvewEpfCntriCard = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptEpfContriCard1 = New FinAcct.CrRptEpfContriCard
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtAcNo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.BtnEPFcntri)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.dtpick2)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1004, 43)
        Me.Panel1.TabIndex = 0
        '
        'TxtAcNo
        '
        Me.TxtAcNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAcNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcNo.Location = New System.Drawing.Point(694, 10)
        Me.TxtAcNo.MaxLength = 6
        Me.TxtAcNo.Name = "TxtAcNo"
        Me.TxtAcNo.Size = New System.Drawing.Size(134, 22)
        Me.TxtAcNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(556, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 18)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Account Group No. :"
        '
        'BtnEPFcntri
        '
        Me.BtnEPFcntri.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEPFcntri.Location = New System.Drawing.Point(885, 10)
        Me.BtnEPFcntri.Name = "BtnEPFcntri"
        Me.BtnEPFcntri.Size = New System.Drawing.Size(114, 23)
        Me.BtnEPFcntri.TabIndex = 4
        Me.BtnEPFcntri.Text = "View Report"
        Me.BtnEPFcntri.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(276, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 18)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "To Month"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "From Month"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "MMMM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(91, 10)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(156, 21)
        Me.Dtpick1.TabIndex = 1
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "MMMM/yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(348, 10)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.ShowUpDown = True
        Me.dtpick2.Size = New System.Drawing.Size(156, 21)
        Me.dtpick2.TabIndex = 2
        '
        'CrvewEpfCntriCard
        '
        Me.CrvewEpfCntriCard.ActiveViewIndex = 0
        Me.CrvewEpfCntriCard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrvewEpfCntriCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrvewEpfCntriCard.DisplayGroupTree = False
        Me.CrvewEpfCntriCard.Location = New System.Drawing.Point(3, 51)
        Me.CrvewEpfCntriCard.Name = "CrvewEpfCntriCard"
        Me.CrvewEpfCntriCard.ReportSource = Me.CrRptEpfContriCard1
        Me.CrvewEpfCntriCard.ShowGroupTreeButton = False
        Me.CrvewEpfCntriCard.ShowRefreshButton = False
        Me.CrvewEpfCntriCard.Size = New System.Drawing.Size(1004, 0)
        Me.CrvewEpfCntriCard.TabIndex = 2
        '
        'FrmCrRptEpFcntriCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 47)
        Me.Controls.Add(Me.CrvewEpfCntriCard)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEpFcntriCard"
        Me.Text = "FrmCrRptEpFcntriCard"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtAcNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnEPFcntri As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrvewEpfCntriCard As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptEpfContriCard1 As fINACCT.CrRptEpfContriCard
End Class
