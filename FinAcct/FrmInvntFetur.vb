Public Class FrmInvntFetur
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents CmbxEnblChq As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CmbxChqprnt As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents CmbxMbc As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents CmbxAlowInv As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents CmbxPurInv As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents CmbxDrCrnote As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents CmbxCrnote As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents CmbxDrnote As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents CmbxPyrol As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbxCostCntr As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbxActInvt As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbxMMG As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxMSC As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxMBwdtl As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxExDt As System.Windows.Forms.ComboBox
    Friend WithEvents cmbxValZero As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.CmbxEnblChq = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.CmbxChqprnt = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.CmbxMbc = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.CmbxAlowInv = New System.Windows.Forms.ComboBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.CmbxPurInv = New System.Windows.Forms.ComboBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.CmbxDrCrnote = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.CmbxCrnote = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.CmbxDrnote = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.CmbxPyrol = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbxCostCntr = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.CmbxMMG = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbxMSC = New System.Windows.Forms.ComboBox
        Me.CmbxMBwdtl = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.CmbxExDt = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cmbxActInvt = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbxValZero = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(9, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 445)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox2.Controls.Add(Me.Panel6)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Panel7)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Panel8)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(376, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(362, 410)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.CmbxEnblChq)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Controls.Add(Me.CmbxChqprnt)
        Me.Panel6.Controls.Add(Me.Label17)
        Me.Panel6.Location = New System.Drawing.Point(11, 336)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(341, 64)
        Me.Panel6.TabIndex = 5
        '
        'CmbxEnblChq
        '
        Me.CmbxEnblChq.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxEnblChq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxEnblChq.ForeColor = System.Drawing.Color.Navy
        Me.CmbxEnblChq.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxEnblChq.Location = New System.Drawing.Point(272, 6)
        Me.CmbxEnblChq.Name = "CmbxEnblChq"
        Me.CmbxEnblChq.Size = New System.Drawing.Size(64, 23)
        Me.CmbxEnblChq.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(8, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(264, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Use Tracking Number (Delivery/Receipt Notes) :-"
        '
        'CmbxChqprnt
        '
        Me.CmbxChqprnt.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxChqprnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxChqprnt.ForeColor = System.Drawing.Color.Navy
        Me.CmbxChqprnt.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxChqprnt.Location = New System.Drawing.Point(272, 32)
        Me.CmbxChqprnt.Name = "CmbxChqprnt"
        Me.CmbxChqprnt.Size = New System.Drawing.Size(64, 23)
        Me.CmbxChqprnt.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(8, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(224, 16)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Use Rejection Inward/Outward Notes  :-"
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(9, 320)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(183, 16)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Additional Inventory/Vouchers :- "
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.CmbxMbc)
        Me.Panel7.Controls.Add(Me.Label21)
        Me.Panel7.Location = New System.Drawing.Point(11, 255)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(341, 40)
        Me.Panel7.TabIndex = 3
        '
        'CmbxMbc
        '
        Me.CmbxMbc.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxMbc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxMbc.ForeColor = System.Drawing.Color.Navy
        Me.CmbxMbc.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxMbc.Location = New System.Drawing.Point(272, 6)
        Me.CmbxMbc.Name = "CmbxMbc"
        Me.CmbxMbc.Size = New System.Drawing.Size(64, 23)
        Me.CmbxMbc.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(8, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(208, 16)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Track Additional Cost  of Purchase  :-"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(9, 239)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(151, 16)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Purchase  Management  :-"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.CmbxAlowInv)
        Me.Panel8.Controls.Add(Me.Label26)
        Me.Panel8.Controls.Add(Me.Label27)
        Me.Panel8.Controls.Add(Me.CmbxPurInv)
        Me.Panel8.Controls.Add(Me.Label29)
        Me.Panel8.Controls.Add(Me.CmbxDrCrnote)
        Me.Panel8.Controls.Add(Me.Label30)
        Me.Panel8.Controls.Add(Me.CmbxCrnote)
        Me.Panel8.Controls.Add(Me.Label31)
        Me.Panel8.Controls.Add(Me.CmbxDrnote)
        Me.Panel8.Controls.Add(Me.Label11)
        Me.Panel8.Controls.Add(Me.ComboBox1)
        Me.Panel8.Location = New System.Drawing.Point(10, 38)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(342, 170)
        Me.Panel8.TabIndex = 1
        '
        'CmbxAlowInv
        '
        Me.CmbxAlowInv.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxAlowInv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxAlowInv.ForeColor = System.Drawing.Color.Navy
        Me.CmbxAlowInv.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxAlowInv.Location = New System.Drawing.Point(264, 6)
        Me.CmbxAlowInv.Name = "CmbxAlowInv"
        Me.CmbxAlowInv.Size = New System.Drawing.Size(72, 23)
        Me.CmbxAlowInv.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(8, 8)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(104, 16)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Allow Invoicing  :-"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label27.Location = New System.Drawing.Point(56, 33)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(208, 16)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Enter Purchases In Invoice Format  :-"
        '
        'CmbxPurInv
        '
        Me.CmbxPurInv.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxPurInv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxPurInv.ForeColor = System.Drawing.Color.Navy
        Me.CmbxPurInv.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxPurInv.Location = New System.Drawing.Point(264, 32)
        Me.CmbxPurInv.Name = "CmbxPurInv"
        Me.CmbxPurInv.Size = New System.Drawing.Size(72, 23)
        Me.CmbxPurInv.TabIndex = 1
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(8, 59)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(144, 16)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Use Debit/Credit Notes :- "
        '
        'CmbxDrCrnote
        '
        Me.CmbxDrCrnote.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxDrCrnote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDrCrnote.ForeColor = System.Drawing.Color.Navy
        Me.CmbxDrCrnote.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxDrCrnote.Location = New System.Drawing.Point(264, 58)
        Me.CmbxDrCrnote.Name = "CmbxDrCrnote"
        Me.CmbxDrCrnote.Size = New System.Drawing.Size(72, 23)
        Me.CmbxDrCrnote.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label30.Location = New System.Drawing.Point(56, 84)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(200, 16)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Use Invoice Mode for Credit Note :- "
        '
        'CmbxCrnote
        '
        Me.CmbxCrnote.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxCrnote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCrnote.ForeColor = System.Drawing.Color.Navy
        Me.CmbxCrnote.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxCrnote.Location = New System.Drawing.Point(264, 84)
        Me.CmbxCrnote.Name = "CmbxCrnote"
        Me.CmbxCrnote.Size = New System.Drawing.Size(72, 23)
        Me.CmbxCrnote.TabIndex = 1
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label31.Location = New System.Drawing.Point(56, 111)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(192, 16)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "Use Invoice Mode for Debit Note :- "
        '
        'CmbxDrnote
        '
        Me.CmbxDrnote.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxDrnote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDrnote.ForeColor = System.Drawing.Color.Navy
        Me.CmbxDrnote.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxDrnote.Location = New System.Drawing.Point(264, 111)
        Me.CmbxDrnote.Name = "CmbxDrnote"
        Me.CmbxDrnote.Size = New System.Drawing.Size(72, 23)
        Me.CmbxDrnote.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(232, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Seperate Discount Column On Invoices  :- "
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.ForeColor = System.Drawing.Color.Navy
        Me.ComboBox1.Items.AddRange(New Object() {"Yes", "No"})
        Me.ComboBox1.Location = New System.Drawing.Point(264, 137)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(72, 23)
        Me.ComboBox1.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(8, 24)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 16)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "Invoicing :- "
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 410)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inventory Features"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.ComboBox2)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Location = New System.Drawing.Point(12, 360)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(341, 40)
        Me.Panel5.TabIndex = 9
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.ForeColor = System.Drawing.Color.Navy
        Me.ComboBox2.Items.AddRange(New Object() {"Yes", "No"})
        Me.ComboBox2.Location = New System.Drawing.Point(272, 6)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(64, 23)
        Me.ComboBox2.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(8, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(160, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Use Multiple Price Levels :-"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(10, 344)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(151, 16)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Sale  Management  :-"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.CmbxPyrol)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.CmbxCostCntr)
        Me.Panel4.Location = New System.Drawing.Point(11, 272)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(341, 64)
        Me.Panel4.TabIndex = 5
        '
        'CmbxPyrol
        '
        Me.CmbxPyrol.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxPyrol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxPyrol.ForeColor = System.Drawing.Color.Navy
        Me.CmbxPyrol.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxPyrol.Location = New System.Drawing.Point(264, 6)
        Me.CmbxPyrol.Name = "CmbxPyrol"
        Me.CmbxPyrol.Size = New System.Drawing.Size(72, 23)
        Me.CmbxPyrol.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(208, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Allow Purchase Order Processing  :-"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(8, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(184, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Allow Sales Order Processing  :-"
        '
        'CmbxCostCntr
        '
        Me.CmbxCostCntr.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxCostCntr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCostCntr.ForeColor = System.Drawing.Color.Navy
        Me.CmbxCostCntr.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxCostCntr.Location = New System.Drawing.Point(264, 32)
        Me.CmbxCostCntr.Name = "CmbxCostCntr"
        Me.CmbxCostCntr.Size = New System.Drawing.Size(72, 23)
        Me.CmbxCostCntr.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(9, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Order Processing  :- "
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.CmbxMMG)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.CmbxMSC)
        Me.Panel3.Controls.Add(Me.CmbxMBwdtl)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.CmbxExDt)
        Me.Panel3.Location = New System.Drawing.Point(11, 128)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(341, 120)
        Me.Panel3.TabIndex = 3
        '
        'CmbxMMG
        '
        Me.CmbxMMG.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxMMG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxMMG.ForeColor = System.Drawing.Color.Navy
        Me.CmbxMMG.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxMMG.Location = New System.Drawing.Point(264, 6)
        Me.CmbxMMG.Name = "CmbxMMG"
        Me.CmbxMMG.Size = New System.Drawing.Size(72, 23)
        Me.CmbxMMG.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Maintain Multiple Godowns  :-"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Maintain Stock Categories  :-"
        '
        'CmbxMSC
        '
        Me.CmbxMSC.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxMSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxMSC.ForeColor = System.Drawing.Color.Navy
        Me.CmbxMSC.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxMSC.Location = New System.Drawing.Point(264, 32)
        Me.CmbxMSC.Name = "CmbxMSC"
        Me.CmbxMSC.Size = New System.Drawing.Size(72, 23)
        Me.CmbxMSC.TabIndex = 1
        '
        'CmbxMBwdtl
        '
        Me.CmbxMBwdtl.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxMBwdtl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxMBwdtl.ForeColor = System.Drawing.Color.Navy
        Me.CmbxMBwdtl.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxMBwdtl.Location = New System.Drawing.Point(264, 58)
        Me.CmbxMBwdtl.Name = "CmbxMBwdtl"
        Me.CmbxMBwdtl.Size = New System.Drawing.Size(72, 23)
        Me.CmbxMBwdtl.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Maintain Batch Wise Details :-"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(56, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Set Expiry Dates for Batches :-"
        '
        'CmbxExDt
        '
        Me.CmbxExDt.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxExDt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxExDt.ForeColor = System.Drawing.Color.Navy
        Me.CmbxExDt.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxExDt.Location = New System.Drawing.Point(264, 84)
        Me.CmbxExDt.Name = "CmbxExDt"
        Me.CmbxExDt.Size = New System.Drawing.Size(72, 23)
        Me.CmbxExDt.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(9, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Storage && Classification :- "
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmbxActInvt)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cmbxValZero)
        Me.Panel2.Location = New System.Drawing.Point(10, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(342, 66)
        Me.Panel2.TabIndex = 1
        '
        'cmbxActInvt
        '
        Me.cmbxActInvt.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmbxActInvt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxActInvt.ForeColor = System.Drawing.Color.Navy
        Me.cmbxActInvt.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbxActInvt.Location = New System.Drawing.Point(264, 6)
        Me.cmbxActInvt.Name = "cmbxActInvt"
        Me.cmbxActInvt.Size = New System.Drawing.Size(72, 23)
        Me.cmbxActInvt.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Integrate Accounts and Inventory :-"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Allow Zero Valued Enteries :-"
        '
        'cmbxValZero
        '
        Me.cmbxValZero.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmbxValZero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxValZero.ForeColor = System.Drawing.Color.Navy
        Me.cmbxValZero.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbxValZero.Location = New System.Drawing.Point(264, 32)
        Me.cmbxValZero.Name = "cmbxValZero"
        Me.cmbxValZero.Size = New System.Drawing.Size(72, 23)
        Me.cmbxValZero.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "General :- "
        '
        'FrmInvntFetur
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(778, 461)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmInvntFetur"
        Me.Text = "Inventory Features"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmInvntFetur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

    End Sub
End Class
