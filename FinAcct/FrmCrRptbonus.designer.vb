<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrRptbonus
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CrVewBonus = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptBonus1 = New FinAcct.CrRptBonus
        Me.dtpick2 = New System.Windows.Forms.DateTimePicker
        Me.Dtpick1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnBonus = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Txtbons = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-87, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 18)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Month/Year"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(222, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 26
        '
        'CrVewBonus
        '
        Me.CrVewBonus.ActiveViewIndex = 0
        Me.CrVewBonus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrVewBonus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrVewBonus.DisplayGroupTree = False
        Me.CrVewBonus.Location = New System.Drawing.Point(3, 53)
        Me.CrVewBonus.Name = "CrVewBonus"
        Me.CrVewBonus.ReportSource = Me.CrRptBonus1
        Me.CrVewBonus.ShowRefreshButton = False
        Me.CrVewBonus.Size = New System.Drawing.Size(1012, 0)
        Me.CrVewBonus.TabIndex = 28
        Me.CrVewBonus.Visible = False
        '
        'dtpick2
        '
        Me.dtpick2.CustomFormat = "dd/MM/yyyy"
        Me.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpick2.Location = New System.Drawing.Point(459, 9)
        Me.dtpick2.Name = "dtpick2"
        Me.dtpick2.Size = New System.Drawing.Size(115, 23)
        Me.dtpick2.TabIndex = 3
        '
        'Dtpick1
        '
        Me.Dtpick1.CustomFormat = "dd/MM/yyyy"
        Me.Dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpick1.Location = New System.Drawing.Point(311, 9)
        Me.Dtpick1.Name = "Dtpick1"
        Me.Dtpick1.Size = New System.Drawing.Size(111, 23)
        Me.Dtpick1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(253, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "From"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(422, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 18)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "To"
        '
        'BtnBonus
        '
        Me.BtnBonus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBonus.BackgroundImage = Global.FinAcct.My.Resources.Resources.btnLarge
        Me.BtnBonus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBonus.Location = New System.Drawing.Point(589, 4)
        Me.BtnBonus.Name = "BtnBonus"
        Me.BtnBonus.Size = New System.Drawing.Size(406, 33)
        Me.BtnBonus.TabIndex = 4
        Me.BtnBonus.Text = "View Report"
        Me.BtnBonus.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Txtbons)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.BtnBonus)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpick1)
        Me.Panel1.Controls.Add(Me.dtpick2)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1012, 43)
        Me.Panel1.TabIndex = 0
        '
        'Txtbons
        '
        Me.Txtbons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtbons.Location = New System.Drawing.Point(138, 7)
        Me.Txtbons.Name = "Txtbons"
        Me.Txtbons.Size = New System.Drawing.Size(100, 23)
        Me.Txtbons.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Accounting year :-"
        '
        'FrmCrRptbonus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1019, 49)
        Me.Controls.Add(Me.CrVewBonus)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmCrRptbonus"
        Me.Text = "Bonus Details "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CrVewBonus As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptBonus1 As FinAcct.CrRptBonus
    Friend WithEvents dtpick2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpick1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnBonus As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Txtbons As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
