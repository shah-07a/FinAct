<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEPFfrm5
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
        Me.txtepfgno = New System.Windows.Forms.TextBox
        Me.BtnEPF5 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.CrVewEpfFrm5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtepfgno)
        Me.Panel1.Controls.Add(Me.BtnEPF5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick2)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1004, 39)
        Me.Panel1.TabIndex = 0
        '
        'txtepfgno
        '
        Me.txtepfgno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtepfgno.Location = New System.Drawing.Point(500, 6)
        Me.txtepfgno.MaxLength = 5
        Me.txtepfgno.Name = "txtepfgno"
        Me.txtepfgno.Size = New System.Drawing.Size(130, 20)
        Me.txtepfgno.TabIndex = 3
        '
        'BtnEPF5
        '
        Me.BtnEPF5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEPF5.Location = New System.Drawing.Point(655, 6)
        Me.BtnEPF5.Name = "BtnEPF5"
        Me.BtnEPF5.Size = New System.Drawing.Size(344, 23)
        Me.BtnEPF5.TabIndex = 4
        Me.BtnEPF5.Text = "View Report"
        Me.BtnEPF5.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 18)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Month :-"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(360, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 18)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Account Group No. :-"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Date :-"
        '
        'Dtpick2
        '
        Me.Dtpick2.CustomFormat = "MMMM-yyyy"
        Me.Dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick2.Location = New System.Drawing.Point(62, 6)
        Me.Dtpick2.Name = "Dtpick2"
        Me.Dtpick2.Size = New System.Drawing.Size(114, 20)
        Me.Dtpick2.TabIndex = 1
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(239, 6)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.Size = New System.Drawing.Size(114, 20)
        Me.Dtpick1.TabIndex = 2
        '
        'CrVewEpfFrm5
        '
        Me.CrVewEpfFrm5.ActiveViewIndex = -1
        Me.CrVewEpfFrm5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEpfFrm5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEpfFrm5.DisplayGroupTree = False
        Me.CrVewEpfFrm5.Location = New System.Drawing.Point(2, 46)
        Me.CrVewEpfFrm5.Name = "CrVewEpfFrm5"
        Me.CrVewEpfFrm5.SelectionFormula = ""
        Me.CrVewEpfFrm5.ShowGroupTreeButton = False
        Me.CrVewEpfFrm5.ShowRefreshButton = False
        Me.CrVewEpfFrm5.Size = New System.Drawing.Size(1004, 0)
        Me.CrVewEpfFrm5.TabIndex = 4
        Me.CrVewEpfFrm5.ViewTimeSelectionFormula = ""
        '
        'FrmCrRptEPFfrm5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 44)
        Me.Controls.Add(Me.CrVewEpfFrm5)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEPFfrm5"
        Me.Text = "FrmCrRptEPFfrm5"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnEPF5 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrVewEpfFrm5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtepfgno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
