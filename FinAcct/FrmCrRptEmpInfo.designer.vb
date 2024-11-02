<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptEmpInfo
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
    Dim dt As DataTable
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbxSelcat = New System.Windows.Forms.ComboBox
        Me.CmbxSelval2 = New System.Windows.Forms.ComboBox
        Me.CmbxSelVal = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.FinactDeptBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.HrPrData08DataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DtpDtFrom = New System.Windows.Forms.DateTimePicker
        Me.DtpDtTo = New System.Windows.Forms.DateTimePicker
        Me.CrVewEmpInfo = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptEmpInfo1 = New FinAcct.CrRptEmpInfo
        Me.Panel1.SuspendLayout()
        CType(Me.FinactDeptBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HrPrData08DataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CmbxSelcat)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(993, 35)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Selection Carteria"
        '
        'CmbxSelcat
        '
        Me.CmbxSelcat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbxSelcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxSelcat.FormattingEnabled = True
        Me.CmbxSelcat.Items.AddRange(New Object() {"All", "Employee's Name", "Employee's Id", "Date Of Birth", "Date Of Joining", "Payment Mode", "Department", "Designation", "Category/Grade", "Employment Status", "", ""})
        Me.CmbxSelcat.Location = New System.Drawing.Point(119, 5)
        Me.CmbxSelcat.Name = "CmbxSelcat"
        Me.CmbxSelcat.Size = New System.Drawing.Size(858, 21)
        Me.CmbxSelcat.TabIndex = 1
        '
        'CmbxSelval2
        '
        Me.CmbxSelval2.Location = New System.Drawing.Point(0, 0)
        Me.CmbxSelval2.Name = "CmbxSelval2"
        Me.CmbxSelval2.Size = New System.Drawing.Size(121, 21)
        Me.CmbxSelval2.TabIndex = 0
        '
        'CmbxSelVal
        '
        Me.CmbxSelVal.Location = New System.Drawing.Point(0, 0)
        Me.CmbxSelVal.Name = "CmbxSelVal"
        Me.CmbxSelVal.Size = New System.Drawing.Size(121, 21)
        Me.CmbxSelVal.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 0
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'DtpDtFrom
        '
        Me.DtpDtFrom.Location = New System.Drawing.Point(0, 0)
        Me.DtpDtFrom.Name = "DtpDtFrom"
        Me.DtpDtFrom.Size = New System.Drawing.Size(200, 20)
        Me.DtpDtFrom.TabIndex = 0
        '
        'DtpDtTo
        '
        Me.DtpDtTo.Location = New System.Drawing.Point(0, 0)
        Me.DtpDtTo.Name = "DtpDtTo"
        Me.DtpDtTo.Size = New System.Drawing.Size(200, 20)
        Me.DtpDtTo.TabIndex = 0
        '
        'CrVewEmpInfo
        '
        Me.CrVewEmpInfo.ActiveViewIndex = 0
        Me.CrVewEmpInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewEmpInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewEmpInfo.DisplayGroupTree = False
        Me.CrVewEmpInfo.Location = New System.Drawing.Point(12, 53)
        Me.CrVewEmpInfo.Name = "CrVewEmpInfo"
        Me.CrVewEmpInfo.ReportSource = Me.CrRptEmpInfo1
        Me.CrVewEmpInfo.Size = New System.Drawing.Size(993, 0)
        Me.CrVewEmpInfo.TabIndex = 6
        '
        'FrmCrRptEmpInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1009, 51)
        Me.Controls.Add(Me.CrVewEmpInfo)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCrRptEmpInfo"
        Me.Text = "Detailed Infromations of the emplpyee(s)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FinactDeptBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HrPrData08DataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbxSelcat As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CrVewEmpInfo As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptEmpInfo1 As FinAcct.CrRptEmpInfo
    Friend WithEvents CmbxSelVal As System.Windows.Forms.ComboBox
    ' Friend WithEvents FinactDeptTableAdapter As FinAcct.HrPrData08DataSetTableAdapters.finactDeptTableAdapter
    Friend WithEvents FinactDeptBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents HrPrData08DataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CmbxSelval2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpDtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpDtTo As System.Windows.Forms.DateTimePicker
End Class
