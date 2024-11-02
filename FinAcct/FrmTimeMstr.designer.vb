<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTimeMstr
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
        Me.Lblbrk = New System.Windows.Forms.Label
        Me.Lblbrkto = New System.Windows.Forms.Label
        Me.Lblsft = New System.Windows.Forms.Label
        Me.Lblsrt = New System.Windows.Forms.Label
        Me.Lblend = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Dtpkrbrkto = New System.Windows.Forms.DateTimePicker
        Me.Combmin = New System.Windows.Forms.ComboBox
        Me.Dtpkrbrk = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dtpkrendtm = New System.Windows.Forms.DateTimePicker
        Me.Dtpkrstime = New System.Windows.Forms.DateTimePicker
        Me.Combsft = New System.Windows.Forms.ComboBox
        Me.Combid = New System.Windows.Forms.ComboBox
        Me.Lblempid = New System.Windows.Forms.Label
        Me.Btnadd = New System.Windows.Forms.Button
        Me.Btnfnd = New System.Windows.Forms.Button
        Me.Btndel = New System.Windows.Forms.Button
        Me.Btnclose = New System.Windows.Forms.Button
        Me.txtconid = New System.Windows.Forms.TextBox
        Me.Labenter = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lblbrk
        '
        Me.Lblbrk.AutoSize = True
        Me.Lblbrk.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbrk.Location = New System.Drawing.Point(3, 82)
        Me.Lblbrk.Name = "Lblbrk"
        Me.Lblbrk.Size = New System.Drawing.Size(78, 14)
        Me.Lblbrk.TabIndex = 0
        Me.Lblbrk.Text = "Break From"
        '
        'Lblbrkto
        '
        Me.Lblbrkto.AutoSize = True
        Me.Lblbrkto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbrkto.Location = New System.Drawing.Point(269, 82)
        Me.Lblbrkto.Name = "Lblbrkto"
        Me.Lblbrkto.Size = New System.Drawing.Size(58, 14)
        Me.Lblbrkto.TabIndex = 1
        Me.Lblbrkto.Text = "BreakTo"
        '
        'Lblsft
        '
        Me.Lblsft.AutoSize = True
        Me.Lblsft.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblsft.Location = New System.Drawing.Point(3, 14)
        Me.Lblsft.Name = "Lblsft"
        Me.Lblsft.Size = New System.Drawing.Size(44, 14)
        Me.Lblsft.TabIndex = 2
        Me.Lblsft.Text = "SiftNo"
        '
        'Lblsrt
        '
        Me.Lblsrt.AutoSize = True
        Me.Lblsrt.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblsrt.Location = New System.Drawing.Point(3, 51)
        Me.Lblsrt.Name = "Lblsrt"
        Me.Lblsrt.Size = New System.Drawing.Size(71, 14)
        Me.Lblsrt.TabIndex = 3
        Me.Lblsrt.Text = "Start Time"
        '
        'Lblend
        '
        Me.Lblend.AutoSize = True
        Me.Lblend.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblend.Location = New System.Drawing.Point(269, 51)
        Me.Lblend.Name = "Lblend"
        Me.Lblend.Size = New System.Drawing.Size(62, 14)
        Me.Lblend.TabIndex = 4
        Me.Lblend.Text = "End time"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Dtpkrbrkto)
        Me.Panel1.Controls.Add(Me.Combmin)
        Me.Panel1.Controls.Add(Me.Dtpkrbrk)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Dtpkrendtm)
        Me.Panel1.Controls.Add(Me.Dtpkrstime)
        Me.Panel1.Controls.Add(Me.Combsft)
        Me.Panel1.Controls.Add(Me.Lblsft)
        Me.Panel1.Controls.Add(Me.Lblbrkto)
        Me.Panel1.Controls.Add(Me.Lblend)
        Me.Panel1.Controls.Add(Me.Lblbrk)
        Me.Panel1.Controls.Add(Me.Lblsrt)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(470, 156)
        Me.Panel1.TabIndex = 0
        '
        'Dtpkrbrkto
        '
        Me.Dtpkrbrkto.CustomFormat = "HH:mm:ss"
        Me.Dtpkrbrkto.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.Dtpkrbrkto.Location = New System.Drawing.Point(338, 82)
        Me.Dtpkrbrkto.Name = "Dtpkrbrkto"
        Me.Dtpkrbrkto.ShowUpDown = True
        Me.Dtpkrbrkto.Size = New System.Drawing.Size(113, 22)
        Me.Dtpkrbrkto.TabIndex = 4
        '
        'Combmin
        '
        Me.Combmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combmin.FormattingEnabled = True
        Me.Combmin.Items.AddRange(New Object() {"0", "15", "30", "45", "60"})
        Me.Combmin.Location = New System.Drawing.Point(149, 116)
        Me.Combmin.Name = "Combmin"
        Me.Combmin.Size = New System.Drawing.Size(83, 22)
        Me.Combmin.TabIndex = 5
        '
        'Dtpkrbrk
        '
        Me.Dtpkrbrk.CustomFormat = "HH:mm:ss"
        Me.Dtpkrbrk.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.Dtpkrbrk.Location = New System.Drawing.Point(149, 82)
        Me.Dtpkrbrk.Name = "Dtpkrbrk"
        Me.Dtpkrbrk.ShowUpDown = True
        Me.Dtpkrbrk.Size = New System.Drawing.Size(112, 22)
        Me.Dtpkrbrk.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 28)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Count Overtime After" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   (in minutes)"
        '
        'Dtpkrendtm
        '
        Me.Dtpkrendtm.CustomFormat = "HH:mm:ss"
        Me.Dtpkrendtm.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.Dtpkrendtm.Location = New System.Drawing.Point(338, 48)
        Me.Dtpkrendtm.Name = "Dtpkrendtm"
        Me.Dtpkrendtm.ShowUpDown = True
        Me.Dtpkrendtm.Size = New System.Drawing.Size(113, 22)
        Me.Dtpkrendtm.TabIndex = 2
        '
        'Dtpkrstime
        '
        Me.Dtpkrstime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpkrstime.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder
        Me.Dtpkrstime.CustomFormat = "HH:mm:ss"
        Me.Dtpkrstime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.Dtpkrstime.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Dtpkrstime.Location = New System.Drawing.Point(149, 48)
        Me.Dtpkrstime.Name = "Dtpkrstime"
        Me.Dtpkrstime.ShowUpDown = True
        Me.Dtpkrstime.Size = New System.Drawing.Size(113, 22)
        Me.Dtpkrstime.TabIndex = 1
        Me.Dtpkrstime.Value = New Date(2008, 2, 29, 15, 0, 0, 0)
        '
        'Combsft
        '
        Me.Combsft.DropDownHeight = 50
        Me.Combsft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combsft.FormattingEnabled = True
        Me.Combsft.IntegralHeight = False
        Me.Combsft.Items.AddRange(New Object() {"1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "13th", "14th", "15th", "16th", "17th", "18th", "19th", "20th", "21st", "22nd", "23rd", "24th"})
        Me.Combsft.Location = New System.Drawing.Point(149, 14)
        Me.Combsft.Name = "Combsft"
        Me.Combsft.Size = New System.Drawing.Size(74, 22)
        Me.Combsft.TabIndex = 0
        '
        'Combid
        '
        Me.Combid.DropDownHeight = 95
        Me.Combid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combid.DropDownWidth = 60
        Me.Combid.IntegralHeight = False
        Me.Combid.Location = New System.Drawing.Point(61, 177)
        Me.Combid.Name = "Combid"
        Me.Combid.Size = New System.Drawing.Size(108, 21)
        Me.Combid.TabIndex = 6
        '
        'Lblempid
        '
        Me.Lblempid.AutoSize = True
        Me.Lblempid.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblempid.Location = New System.Drawing.Point(6, 181)
        Me.Lblempid.Name = "Lblempid"
        Me.Lblempid.Size = New System.Drawing.Size(48, 14)
        Me.Lblempid.TabIndex = 11
        Me.Lblempid.Text = "Sift No"
        '
        'Btnadd
        '
        Me.Btnadd.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btnadd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnadd.Location = New System.Drawing.Point(4, 206)
        Me.Btnadd.Name = "Btnadd"
        Me.Btnadd.Size = New System.Drawing.Size(104, 26)
        Me.Btnadd.TabIndex = 8
        Me.Btnadd.Text = "&Add"
        Me.Btnadd.UseVisualStyleBackColor = True
        '
        'Btnfnd
        '
        Me.Btnfnd.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Btnfnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btnfnd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnfnd.Location = New System.Drawing.Point(114, 207)
        Me.Btnfnd.Name = "Btnfnd"
        Me.Btnfnd.Size = New System.Drawing.Size(104, 26)
        Me.Btnfnd.TabIndex = 9
        Me.Btnfnd.Text = "&Find"
        Me.Btnfnd.UseVisualStyleBackColor = True
        '
        'Btndel
        '
        Me.Btndel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Btndel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btndel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btndel.Location = New System.Drawing.Point(224, 206)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(104, 26)
        Me.Btndel.TabIndex = 10
        Me.Btndel.Text = "&Delete"
        Me.Btndel.UseVisualStyleBackColor = True
        '
        'Btnclose
        '
        Me.Btnclose.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btnclose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnclose.Location = New System.Drawing.Point(334, 206)
        Me.Btnclose.Name = "Btnclose"
        Me.Btnclose.Size = New System.Drawing.Size(104, 26)
        Me.Btnclose.TabIndex = 11
        Me.Btnclose.Text = "&Close"
        Me.Btnclose.UseVisualStyleBackColor = True
        '
        'txtconid
        '
        Me.txtconid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtconid.Location = New System.Drawing.Point(22, 241)
        Me.txtconid.Name = "txtconid"
        Me.txtconid.Size = New System.Drawing.Size(57, 20)
        Me.txtconid.TabIndex = 13
        Me.txtconid.Visible = False
        '
        'Labenter
        '
        Me.Labenter.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Labenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Labenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labenter.ForeColor = System.Drawing.Color.Navy
        Me.Labenter.Location = New System.Drawing.Point(183, 179)
        Me.Labenter.Name = "Labenter"
        Me.Labenter.Size = New System.Drawing.Size(151, 21)
        Me.Labenter.TabIndex = 68
        Me.Labenter.Text = " Press  enter  key to continue"
        Me.Labenter.Visible = False
        '
        'FrmTimeMstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(475, 241)
        Me.Controls.Add(Me.Labenter)
        Me.Controls.Add(Me.txtconid)
        Me.Controls.Add(Me.Btnclose)
        Me.Controls.Add(Me.Btndel)
        Me.Controls.Add(Me.Btnfnd)
        Me.Controls.Add(Me.Btnadd)
        Me.Controls.Add(Me.Combid)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Lblempid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTimeMstr"
        Me.Text = "TimeMaster"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lblbrk As System.Windows.Forms.Label
    Friend WithEvents Lblbrkto As System.Windows.Forms.Label
    Friend WithEvents Lblsft As System.Windows.Forms.Label
    Friend WithEvents Lblsrt As System.Windows.Forms.Label
    Friend WithEvents Lblend As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Dtpkrbrkto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpkrbrk As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpkrendtm As System.Windows.Forms.DateTimePicker
    Friend WithEvents Combsft As System.Windows.Forms.ComboBox
    Friend WithEvents Btnadd As System.Windows.Forms.Button
    Friend WithEvents Btnfnd As System.Windows.Forms.Button
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents Btnclose As System.Windows.Forms.Button
    Friend WithEvents Combid As System.Windows.Forms.ComboBox
    Friend WithEvents Lblempid As System.Windows.Forms.Label
    Friend WithEvents Dtpkrstime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Combmin As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtconid As System.Windows.Forms.TextBox
    Friend WithEvents Labenter As System.Windows.Forms.Label
End Class
