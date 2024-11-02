Public Class FrmStataxn
    Inherits System.Windows.Forms.Form
    Dim Frmxcise As New FrmXciseInfo
    Dim frmFXcise As New FrmFlloExcise
    Dim FrmVatset As New FrmSetVat
    Dim FrmSetSerTx As New FrmSetServicetx
    Dim frmsettds As New frmsettds
    Dim FrmTcsSet As New FrmSetTCS
    Dim FrmFBtset As New FrmSetFbt




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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbxSetXcise As System.Windows.Forms.ComboBox
    Friend WithEvents cmbxSetxciserule As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxVat As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxSetSerTx As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxTDS As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxSetTcs As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxSetFbt As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtVATCompo As System.Windows.Forms.TextBox
    Friend WithEvents TxtVATRegulr As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.TxtVATCompo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtVATRegulr = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CmbxSetFbt = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.CmbxVat = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbxSetSerTx = New System.Windows.Forms.ComboBox
        Me.CmbxTDS = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.CmbxSetTcs = New System.Windows.Forms.ComboBox
        Me.cmbxSetXcise = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbxSetxciserule = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(9, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(399, 460)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 426)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Statutory && Taxation"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.CmbxSetFbt)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.CmbxVat)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.CmbxSetSerTx)
        Me.Panel2.Controls.Add(Me.CmbxTDS)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.CmbxSetTcs)
        Me.Panel2.Controls.Add(Me.cmbxSetXcise)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cmbxSetxciserule)
        Me.Panel2.Location = New System.Drawing.Point(10, 24)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(342, 392)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TxtVATCompo)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.TxtVATRegulr)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.TextBox2)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Location = New System.Drawing.Point(6, 224)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(328, 144)
        Me.Panel3.TabIndex = 7
        '
        'TxtVATCompo
        '
        Me.TxtVATCompo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVATCompo.Location = New System.Drawing.Point(152, 36)
        Me.TxtVATCompo.Name = "TxtVATCompo"
        Me.TxtVATCompo.Size = New System.Drawing.Size(168, 21)
        Me.TxtVATCompo.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "VAT/TIN (Composition) :-"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Tax Informations"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(8, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 16)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "VAT/TIN (Regular) :-"
        '
        'TxtVATRegulr
        '
        Me.TxtVATRegulr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVATRegulr.Location = New System.Drawing.Point(152, 60)
        Me.TxtVATRegulr.Name = "TxtVATRegulr"
        Me.TxtVATRegulr.Size = New System.Drawing.Size(168, 21)
        Me.TxtVATRegulr.TabIndex = 8
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(152, 84)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(168, 21)
        Me.TextBox1.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 15)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Inter State Sale Tax No.  :-"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(152, 108)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(168, 21)
        Me.TextBox2.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(8, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 15)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "PAN/Income Tax No.  :-"
        '
        'CmbxSetFbt
        '
        Me.CmbxSetFbt.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxSetFbt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxSetFbt.ForeColor = System.Drawing.Color.Navy
        Me.CmbxSetFbt.Items.AddRange(New Object() {"Enabled", "Disabled", ""})
        Me.CmbxSetFbt.Location = New System.Drawing.Point(264, 176)
        Me.CmbxSetFbt.Name = "CmbxSetFbt"
        Me.CmbxSetFbt.Size = New System.Drawing.Size(72, 23)
        Me.CmbxSetFbt.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 176)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(168, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Set Fringe Benefit Tax (FBT) :-"
        '
        'CmbxVat
        '
        Me.CmbxVat.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxVat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxVat.ForeColor = System.Drawing.Color.Navy
        Me.CmbxVat.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.CmbxVat.Location = New System.Drawing.Point(264, 61)
        Me.CmbxVat.Name = "CmbxVat"
        Me.CmbxVat.Size = New System.Drawing.Size(72, 23)
        Me.CmbxVat.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Set Value Added Tax (VAT)  :-"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Set Service Tax  :-"
        '
        'CmbxSetSerTx
        '
        Me.CmbxSetSerTx.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxSetSerTx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxSetSerTx.ForeColor = System.Drawing.Color.Navy
        Me.CmbxSetSerTx.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.CmbxSetSerTx.Location = New System.Drawing.Point(264, 89)
        Me.CmbxSetSerTx.Name = "CmbxSetSerTx"
        Me.CmbxSetSerTx.Size = New System.Drawing.Size(72, 23)
        Me.CmbxSetSerTx.TabIndex = 3
        '
        'CmbxTDS
        '
        Me.CmbxTDS.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxTDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxTDS.ForeColor = System.Drawing.Color.Navy
        Me.CmbxTDS.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.CmbxTDS.Location = New System.Drawing.Point(264, 118)
        Me.CmbxTDS.Name = "CmbxTDS"
        Me.CmbxTDS.Size = New System.Drawing.Size(72, 23)
        Me.CmbxTDS.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(208, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Set Tax Deducted at Source (TDS)  :-"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(208, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Set Tax Collected at Source (TCS)  :-"
        '
        'CmbxSetTcs
        '
        Me.CmbxSetTcs.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.CmbxSetTcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxSetTcs.ForeColor = System.Drawing.Color.Navy
        Me.CmbxSetTcs.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.CmbxSetTcs.Location = New System.Drawing.Point(264, 146)
        Me.CmbxSetTcs.Name = "CmbxSetTcs"
        Me.CmbxSetTcs.Size = New System.Drawing.Size(72, 23)
        Me.CmbxSetTcs.TabIndex = 5
        '
        'cmbxSetXcise
        '
        Me.cmbxSetXcise.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmbxSetXcise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxSetXcise.ForeColor = System.Drawing.Color.Navy
        Me.cmbxSetXcise.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.cmbxSetXcise.Location = New System.Drawing.Point(264, 6)
        Me.cmbxSetXcise.Name = "cmbxSetXcise"
        Me.cmbxSetXcise.Size = New System.Drawing.Size(72, 23)
        Me.cmbxSetXcise.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Set  Excise Informations  :- "
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Set Excise Rules for Invoicing :-"
        '
        'cmbxSetxciserule
        '
        Me.cmbxSetxciserule.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmbxSetxciserule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxSetxciserule.ForeColor = System.Drawing.Color.Navy
        Me.cmbxSetxciserule.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.cmbxSetxciserule.Location = New System.Drawing.Point(264, 33)
        Me.cmbxSetxciserule.Name = "cmbxSetxciserule"
        Me.cmbxSetxciserule.Size = New System.Drawing.Size(72, 23)
        Me.cmbxSetxciserule.TabIndex = 1
        '
        'FrmStataxn
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(418, 480)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmStataxn"
        Me.Text = "Statutory & Taxation"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmStataxn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

    End Sub

    Private Sub cmbxSetXcise_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxSetXcise.SelectedIndexChanged
        If cmbxSetXcise.Text = "Enabled" Then
            Frmxcise.ShowDialog(Me)
        End If
    End Sub

    Private Sub cmbxSetxciserule_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxSetxciserule.SelectedIndexChanged
        If cmbxSetxciserule.Text = "Enabled" Then
            frmFXcise.ShowDialog(Me)
        End If
    End Sub

    Private Sub CmbxVat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxVat.SelectedIndexChanged
        If CmbxVat.Text = "Enabled" Then
            FrmVatset.ShowDialog(Me)
        End If
    End Sub

    Private Sub CmbxSetSerTx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSetSerTx.SelectedIndexChanged
        If CmbxSetSerTx.Text = "Enabled" Then
            FrmSetSerTx.ShowDialog(Me)
        End If
    End Sub

    Private Sub CmbxTDS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxTDS.SelectedIndexChanged
        If CmbxTDS.Text = "Enabled" Then
            frmsettds.ShowDialog(Me)
        End If
    End Sub

    Private Sub CmbxAdvPara_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSetTcs.SelectedIndexChanged
        If CmbxSetTcs.Text = "Enabled" Then
            FrmTcsSet.ShowDialog(Me)
        End If
    End Sub

    Private Sub CmbxSetFbt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSetFbt.SelectedIndexChanged
        If CmbxSetFbt.Text = "Enabled" Then
            FrmFBtset.ShowDialog(Me)
        End If
    End Sub
End Class
