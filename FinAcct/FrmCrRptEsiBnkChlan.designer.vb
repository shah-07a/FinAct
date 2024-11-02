<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEsiBnkChlan
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
        Me.Dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.TxtNratn = New System.Windows.Forms.TextBox
        Me.cmbxbnkname = New System.Windows.Forms.ComboBox
        Me.Cmbxempname = New System.Windows.Forms.ComboBox
        Me.Cmbxtypw = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.BtnEsibnk = New System.Windows.Forms.Button
        Me.CrVewEsiBnk = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptFrmESIC1 = New FinAcct.CrRptFrmESIC
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Dtpick2)
        Me.Panel1.Controls.Add(Me.TxtNratn)
        Me.Panel1.Controls.Add(Me.cmbxbnkname)
        Me.Panel1.Controls.Add(Me.Cmbxempname)
        Me.Panel1.Controls.Add(Me.Cmbxtypw)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.BtnEsibnk)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1007, 102)
        Me.Panel1.TabIndex = 0
        '
        'Dtpick2
        '
        Me.Dtpick2.CustomFormat = "dd/MM/yyyy"
        Me.Dtpick2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick2.Location = New System.Drawing.Point(125, 38)
        Me.Dtpick2.Name = "Dtpick2"
        Me.Dtpick2.Size = New System.Drawing.Size(133, 21)
        Me.Dtpick2.TabIndex = 2
        '
        'TxtNratn
        '
        Me.TxtNratn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNratn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNratn.Location = New System.Drawing.Point(380, 8)
        Me.TxtNratn.Name = "TxtNratn"
        Me.TxtNratn.Size = New System.Drawing.Size(622, 20)
        Me.TxtNratn.TabIndex = 4
        '
        'cmbxbnkname
        '
        Me.cmbxbnkname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxbnkname.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxbnkname.FormattingEnabled = True
        Me.cmbxbnkname.Items.AddRange(New Object() {"Bank Of India", "Bank Of Punjab", "Canara Bank ", "Central Bank of India", "Dena Bank", "HDFC Bank", "ICICI Bank ", "IDBI Bank", "Ind-Suind Bank", "Oriental Bank Of Commerce", "Punjab & Sind Bank", "Punjab National Bank", "State Bank Of Bikaner", "State Bank Of India", "State Bank Of J&K", "State Bank Of Patiala", "State Bank Of Rajasthan"})
        Me.cmbxbnkname.Location = New System.Drawing.Point(380, 66)
        Me.cmbxbnkname.Name = "cmbxbnkname"
        Me.cmbxbnkname.Size = New System.Drawing.Size(349, 21)
        Me.cmbxbnkname.Sorted = True
        Me.cmbxbnkname.TabIndex = 6
        '
        'Cmbxempname
        '
        Me.Cmbxempname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxempname.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxempname.FormattingEnabled = True
        Me.Cmbxempname.Items.AddRange(New Object() {"By Cheque", "By Cash"})
        Me.Cmbxempname.Location = New System.Drawing.Point(380, 38)
        Me.Cmbxempname.Name = "Cmbxempname"
        Me.Cmbxempname.Size = New System.Drawing.Size(349, 21)
        Me.Cmbxempname.TabIndex = 5
        '
        'Cmbxtypw
        '
        Me.Cmbxtypw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbxtypw.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbxtypw.FormattingEnabled = True
        Me.Cmbxtypw.Items.AddRange(New Object() {"By Cheque", "By Cash"})
        Me.Cmbxtypw.Location = New System.Drawing.Point(125, 8)
        Me.Cmbxtypw.Name = "Cmbxtypw"
        Me.Cmbxtypw.Size = New System.Drawing.Size(133, 21)
        Me.Cmbxtypw.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(281, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 18)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Bank Name"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 18)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Cheque Date"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(281, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 18)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Deposit By"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(281, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 18)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Narration"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 18)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Payment Type"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 32)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Payment for the month"
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "MMMM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(125, 66)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.ShowUpDown = True
        Me.Dtpick1.Size = New System.Drawing.Size(133, 20)
        Me.Dtpick1.TabIndex = 3
        '
        'BtnEsibnk
        '
        Me.BtnEsibnk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEsibnk.Enabled = False
        Me.BtnEsibnk.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEsibnk.Location = New System.Drawing.Point(835, 66)
        Me.BtnEsibnk.Name = "BtnEsibnk"
        Me.BtnEsibnk.Size = New System.Drawing.Size(167, 23)
        Me.BtnEsibnk.TabIndex = 7
        Me.BtnEsibnk.Text = "View Report"
        Me.BtnEsibnk.UseVisualStyleBackColor = True
        '
        'CrVewEsiBnk
        '
        Me.CrVewEsiBnk.ActiveViewIndex = 0
        Me.CrVewEsiBnk.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEsiBnk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEsiBnk.DisplayGroupTree = False
        Me.CrVewEsiBnk.Enabled = False
        Me.CrVewEsiBnk.Location = New System.Drawing.Point(3, 110)
        Me.CrVewEsiBnk.Name = "CrVewEsiBnk"
        Me.CrVewEsiBnk.ReportSource = Me.CrRptFrmESIC1
        Me.CrVewEsiBnk.Size = New System.Drawing.Size(1006, 0)
        Me.CrVewEsiBnk.TabIndex = 9
        '
        'FrmCrRptEsiBnkChlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 107)
        Me.Controls.Add(Me.CrVewEsiBnk)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEsiBnkChlan"
        Me.Text = "FrmCrRptEsiBnkChlan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnEsibnk As System.Windows.Forms.Button
    Friend WithEvents CrVewEsiBnk As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptFrmESIC1 As fINACCT.CrRptFrmESIC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNratn As System.Windows.Forms.TextBox
    Friend WithEvents Cmbxtypw As System.Windows.Forms.ComboBox
    Friend WithEvents Dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmbxempname As System.Windows.Forms.ComboBox
    Friend WithEvents cmbxbnkname As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
