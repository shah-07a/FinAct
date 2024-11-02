Public Class FrmFeatures
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbxActInvt As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbxInExp As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CmbxBilWise As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbxNtrd As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CmbxIntCal As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxAdvPara As System.Windows.Forms.ComboBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents CmbxPyrol As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbxCostCntr As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxCCJ As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbxPCC As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbxPDcc As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
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
    Friend WithEvents CmbxEnblChq As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxChqprnt As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxZero As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxMbc As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxRJov As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.CmbxEnblChq = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.CmbxChqprnt = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.CmbxZero = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.CmbxMbc = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.CmbxRJov = New System.Windows.Forms.ComboBox
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
        Me.Label28 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.CmbxPyrol = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbxCostCntr = New System.Windows.Forms.ComboBox
        Me.CmbxCCJ = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbxPCC = New System.Windows.Forms.ComboBox
        Me.cmbxPDcc = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.CmbxBilWise = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbxNtrd = New System.Windows.Forms.ComboBox
        Me.CmbxIntCal = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.CmbxAdvPara = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cmbxActInvt = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbxInExp = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 464)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Panel6)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Panel7)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Panel8)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(376, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(362, 433)
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
        Me.Panel6.Controls.Add(Me.Label18)
        Me.Panel6.Controls.Add(Me.CmbxZero)
        Me.Panel6.Location = New System.Drawing.Point(11, 296)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(341, 128)
        Me.Panel6.TabIndex = 5
        '
        'CmbxEnblChq
        '
        Me.CmbxEnblChq.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxEnblChq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxEnblChq.ForeColor = System.Drawing.Color.Navy
        Me.CmbxEnblChq.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxEnblChq.Location = New System.Drawing.Point(264, 6)
        Me.CmbxEnblChq.Name = "CmbxEnblChq"
        Me.CmbxEnblChq.Size = New System.Drawing.Size(72, 23)
        Me.CmbxEnblChq.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(8, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Enable Cheque Printing :-"
        '
        'CmbxChqprnt
        '
        Me.CmbxChqprnt.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxChqprnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxChqprnt.ForeColor = System.Drawing.Color.Navy
        Me.CmbxChqprnt.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxChqprnt.Location = New System.Drawing.Point(264, 32)
        Me.CmbxChqprnt.Name = "CmbxChqprnt"
        Me.CmbxChqprnt.Size = New System.Drawing.Size(72, 23)
        Me.CmbxChqprnt.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(8, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(240, 16)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Set Alter Cheque Printing Configurations :-"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(8, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(168, 15)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Allow Zero Valued Enteries :-"
        '
        'CmbxZero
        '
        Me.CmbxZero.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxZero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxZero.ForeColor = System.Drawing.Color.Navy
        Me.CmbxZero.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxZero.Location = New System.Drawing.Point(264, 58)
        Me.CmbxZero.Name = "CmbxZero"
        Me.CmbxZero.Size = New System.Drawing.Size(72, 23)
        Me.CmbxZero.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.LightGreen
        Me.Label20.Location = New System.Drawing.Point(9, 280)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(247, 16)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Cost/Profit Centres Management :- "
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.CmbxMbc)
        Me.Panel7.Controls.Add(Me.Label21)
        Me.Panel7.Controls.Add(Me.Label22)
        Me.Panel7.Controls.Add(Me.CmbxRJov)
        Me.Panel7.Location = New System.Drawing.Point(11, 208)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(341, 64)
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
        Me.Label21.Size = New System.Drawing.Size(176, 16)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Maintain Budget && Controls   :-"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(8, 34)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(264, 16)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Use Reversing Journals && Optional Vouchers  :-"
        '
        'CmbxRJov
        '
        Me.CmbxRJov.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxRJov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxRJov.ForeColor = System.Drawing.Color.Navy
        Me.CmbxRJov.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxRJov.Location = New System.Drawing.Point(272, 32)
        Me.CmbxRJov.Name = "CmbxRJov"
        Me.CmbxRJov.Size = New System.Drawing.Size(64, 23)
        Me.CmbxRJov.TabIndex = 1
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.LightGreen
        Me.Label25.Location = New System.Drawing.Point(9, 192)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(263, 16)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Budgets &&  Scenario Management  :-"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
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
        Me.Panel8.Location = New System.Drawing.Point(10, 38)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(342, 146)
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
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.LightGreen
        Me.Label28.Location = New System.Drawing.Point(8, 24)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(128, 16)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "Invoicing :- "
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Snow
        Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 433)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Accounts Features"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.CmbxPyrol)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.CmbxCostCntr)
        Me.Panel4.Controls.Add(Me.CmbxCCJ)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.CmbxPCC)
        Me.Panel4.Controls.Add(Me.cmbxPDcc)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Location = New System.Drawing.Point(11, 272)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(341, 152)
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
        Me.CmbxPyrol.Size = New System.Drawing.Size(72, 22)
        Me.CmbxPyrol.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Maintain Payroll  :-"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(8, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Maintain Cost Certres  :-"
        '
        'CmbxCostCntr
        '
        Me.CmbxCostCntr.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxCostCntr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCostCntr.ForeColor = System.Drawing.Color.Navy
        Me.CmbxCostCntr.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxCostCntr.Location = New System.Drawing.Point(264, 32)
        Me.CmbxCostCntr.Name = "CmbxCostCntr"
        Me.CmbxCostCntr.Size = New System.Drawing.Size(72, 22)
        Me.CmbxCostCntr.TabIndex = 1
        '
        'CmbxCCJ
        '
        Me.CmbxCCJ.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxCCJ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxCCJ.ForeColor = System.Drawing.Color.Navy
        Me.CmbxCCJ.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxCCJ.Location = New System.Drawing.Point(264, 58)
        Me.CmbxCCJ.Name = "CmbxCCJ"
        Me.CmbxCCJ.Size = New System.Drawing.Size(72, 22)
        Me.CmbxCCJ.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(56, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(200, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Use Cost Centre for Job Costing  :-"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(56, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(208, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "More than one Payroll/Cost Centre  :-"
        '
        'CmbxPCC
        '
        Me.CmbxPCC.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxPCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxPCC.ForeColor = System.Drawing.Color.Navy
        Me.CmbxPCC.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxPCC.Location = New System.Drawing.Point(264, 84)
        Me.CmbxPCC.Name = "CmbxPCC"
        Me.CmbxPCC.Size = New System.Drawing.Size(72, 22)
        Me.CmbxPCC.TabIndex = 1
        '
        'cmbxPDcc
        '
        Me.cmbxPDcc.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmbxPDcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxPDcc.ForeColor = System.Drawing.Color.Navy
        Me.cmbxPDcc.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbxPDcc.Location = New System.Drawing.Point(264, 110)
        Me.cmbxPDcc.Name = "cmbxPDcc"
        Me.cmbxPDcc.Size = New System.Drawing.Size(72, 22)
        Me.cmbxPDcc.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label14.Location = New System.Drawing.Point(56, 110)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(176, 26)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Use Pre-Defined Cost Centre Allocation during Entry  :-"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.LightGreen
        Me.Label13.Location = New System.Drawing.Point(9, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(247, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Cost/Profit Centres Management :- "
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.CmbxBilWise)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.CmbxNtrd)
        Me.Panel3.Controls.Add(Me.CmbxIntCal)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.CmbxAdvPara)
        Me.Panel3.Location = New System.Drawing.Point(11, 128)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(341, 120)
        Me.Panel3.TabIndex = 3
        '
        'CmbxBilWise
        '
        Me.CmbxBilWise.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxBilWise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxBilWise.ForeColor = System.Drawing.Color.Navy
        Me.CmbxBilWise.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxBilWise.Location = New System.Drawing.Point(264, 6)
        Me.CmbxBilWise.Name = "CmbxBilWise"
        Me.CmbxBilWise.Size = New System.Drawing.Size(72, 22)
        Me.CmbxBilWise.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Maintain Bill wise details  :-"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(56, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "For Non-Trading Account also :-"
        '
        'CmbxNtrd
        '
        Me.CmbxNtrd.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxNtrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxNtrd.ForeColor = System.Drawing.Color.Navy
        Me.CmbxNtrd.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxNtrd.Location = New System.Drawing.Point(264, 32)
        Me.CmbxNtrd.Name = "CmbxNtrd"
        Me.CmbxNtrd.Size = New System.Drawing.Size(72, 22)
        Me.CmbxNtrd.TabIndex = 1
        '
        'CmbxIntCal
        '
        Me.CmbxIntCal.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxIntCal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxIntCal.ForeColor = System.Drawing.Color.Navy
        Me.CmbxIntCal.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxIntCal.Location = New System.Drawing.Point(264, 58)
        Me.CmbxIntCal.Name = "CmbxIntCal"
        Me.CmbxIntCal.Size = New System.Drawing.Size(72, 22)
        Me.CmbxIntCal.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Activate Interest Calculation  :-"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(56, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Used Advanced Parameters  :-"
        '
        'CmbxAdvPara
        '
        Me.CmbxAdvPara.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxAdvPara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxAdvPara.ForeColor = System.Drawing.Color.Navy
        Me.CmbxAdvPara.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxAdvPara.Location = New System.Drawing.Point(264, 84)
        Me.CmbxAdvPara.Name = "CmbxAdvPara"
        Me.CmbxAdvPara.Size = New System.Drawing.Size(72, 22)
        Me.CmbxAdvPara.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.LightGreen
        Me.Label6.Location = New System.Drawing.Point(9, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(223, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Outstandings Management  :- "
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmbxActInvt)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cmbxInExp)
        Me.Panel2.Location = New System.Drawing.Point(10, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(342, 71)
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
        Me.cmbxActInvt.Size = New System.Drawing.Size(72, 22)
        Me.cmbxActInvt.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(250, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Integrate Accounts and Inventory :-"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(225, 30)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Income\Expenses Statement Instead of P/L :-"
        '
        'cmbxInExp
        '
        Me.cmbxInExp.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmbxInExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxInExp.ForeColor = System.Drawing.Color.Navy
        Me.cmbxInExp.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbxInExp.Location = New System.Drawing.Point(264, 32)
        Me.cmbxInExp.Name = "cmbxInExp"
        Me.cmbxInExp.Size = New System.Drawing.Size(72, 22)
        Me.cmbxInExp.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LightGreen
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "General :- "
        '
        'FrmFeatures
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.FinAcct.My.Resources.Resources.HOME3_14
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(778, 480)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmFeatures"
        Me.Text = "Accounts Features"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmFeatures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0
    End Sub
End Class
