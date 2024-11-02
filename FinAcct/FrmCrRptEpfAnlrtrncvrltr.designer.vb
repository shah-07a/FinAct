<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEpfAnlrtrncvrltr
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Dtpick3 = New System.Windows.Forms.DateTimePicker
        Me.TxtSectn = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnEsiGo = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.CrVewEpfAnlRtrncvrltr = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptEpfAnnualRtnCvrLtr1 = New FinAcct.CrRptEpfAnnualRtnCvrLtr
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Dtpick3)
        Me.Panel1.Controls.Add(Me.TxtSectn)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.BtnEsiGo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.dtpick2)
        Me.Panel1.Location = New System.Drawing.Point(3, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1003, 35)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(229, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 18)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "To Month :-"
        '
        'Dtpick3
        '
        Me.Dtpick3.CustomFormat = "MMMM-yyyy"
        Me.Dtpick3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick3.Location = New System.Drawing.Point(311, 6)
        Me.Dtpick3.Name = "Dtpick3"
        Me.Dtpick3.ShowUpDown = True
        Me.Dtpick3.Size = New System.Drawing.Size(114, 20)
        Me.Dtpick3.TabIndex = 2
        '
        'TxtSectn
        '
        Me.TxtSectn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSectn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSectn.Location = New System.Drawing.Point(740, 6)
        Me.TxtSectn.MaxLength = 6
        Me.TxtSectn.Name = "TxtSectn"
        Me.TxtSectn.Size = New System.Drawing.Size(114, 22)
        Me.TxtSectn.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(604, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 18)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Account Section :-"
        '
        'BtnEsiGo
        '
        Me.BtnEsiGo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEsiGo.Location = New System.Drawing.Point(886, 6)
        Me.BtnEsiGo.Name = "BtnEsiGo"
        Me.BtnEsiGo.Size = New System.Drawing.Size(112, 23)
        Me.BtnEsiGo.TabIndex = 5
        Me.BtnEsiGo.Text = "<Go>"
        Me.BtnEsiGo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 18)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "From Month :-"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(428, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 18)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Date :-"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(484, 6)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(114, 20)
        Me.Dtpick1.TabIndex = 3
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "MMMM-yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(108, 6)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.ShowUpDown = True
        Me.dtpick2.Size = New System.Drawing.Size(114, 20)
        Me.dtpick2.TabIndex = 1
        '
        'CrVewEpfAnlRtrncvrltr
        '
        Me.CrVewEpfAnlRtrncvrltr.ActiveViewIndex = 0
        Me.CrVewEpfAnlRtrncvrltr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEpfAnlRtrncvrltr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEpfAnlRtrncvrltr.DisplayGroupTree = False
        Me.CrVewEpfAnlRtrncvrltr.Enabled = False
        Me.CrVewEpfAnlRtrncvrltr.Location = New System.Drawing.Point(3, 42)
        Me.CrVewEpfAnlRtrncvrltr.Name = "CrVewEpfAnlRtrncvrltr"
        Me.CrVewEpfAnlRtrncvrltr.ReportSource = Me.CrRptEpfAnnualRtnCvrLtr1
        Me.CrVewEpfAnlRtrncvrltr.ShowGroupTreeButton = False
        Me.CrVewEpfAnlRtrncvrltr.ShowRefreshButton = False
        Me.CrVewEpfAnlRtrncvrltr.Size = New System.Drawing.Size(1003, 0)
        Me.CrVewEpfAnlRtrncvrltr.TabIndex = 5
        '
        'FrmCrRptEpfAnlrtrncvrltr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 38)
        Me.Controls.Add(Me.CrVewEpfAnlRtrncvrltr)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEpfAnlrtrncvrltr"
        Me.Text = "FrmCrRptEpfAnlrtrncvrltr"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Dtpick3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtSectn As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnEsiGo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrVewEpfAnlRtrncvrltr As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptEpfAnnualRtnCvrLtr1 As fINACCT.CrRptEpfAnnualRtnCvrLtr
End Class
