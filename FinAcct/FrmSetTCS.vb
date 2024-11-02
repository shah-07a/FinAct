Public Class FrmSetTCS
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
    Friend WithEvents CmbxDCtypetcs As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTxnotcs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtITCircletcs As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNameprsontcs As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txtdesigtcs As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CmbxDCtypetcs = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtTxnotcs = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtITCircletcs = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtNameprsontcs = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txtdesigtcs = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmbxDCtypetcs)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtTxnotcs)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtITCircletcs)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtNameprsontcs)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Txtdesigtcs)
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 225)
        Me.Panel1.TabIndex = 0
        '
        'CmbxDCtypetcs
        '
        Me.CmbxDCtypetcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDCtypetcs.Items.AddRange(New Object() {"Government", "Others"})
        Me.CmbxDCtypetcs.Location = New System.Drawing.Point(152, 112)
        Me.CmbxDCtypetcs.Name = "CmbxDCtypetcs"
        Me.CmbxDCtypetcs.Size = New System.Drawing.Size(168, 21)
        Me.CmbxDCtypetcs.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Company Deductor/Collector Details "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tax Assessment Number :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 32)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Income Tax Circle/Ward  (TDS/TCS) :-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtTxnotcs
        '
        Me.TxtTxnotcs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTxnotcs.Location = New System.Drawing.Point(152, 32)
        Me.TxtTxnotcs.Name = "TxtTxnotcs"
        Me.TxtTxnotcs.Size = New System.Drawing.Size(168, 20)
        Me.TxtTxnotcs.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 32)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Deductor/Collector Type :-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtITCircletcs
        '
        Me.TxtITCircletcs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtITCircletcs.Location = New System.Drawing.Point(152, 72)
        Me.TxtITCircletcs.Name = "TxtITCircletcs"
        Me.TxtITCircletcs.Size = New System.Drawing.Size(168, 20)
        Me.TxtITCircletcs.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 32)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Name of the Person Responsible :-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtNameprsontcs
        '
        Me.TxtNameprsontcs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNameprsontcs.Location = New System.Drawing.Point(152, 152)
        Me.TxtNameprsontcs.Name = "TxtNameprsontcs"
        Me.TxtNameprsontcs.Size = New System.Drawing.Size(168, 20)
        Me.TxtNameprsontcs.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Designation  :-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtdesigtcs
        '
        Me.Txtdesigtcs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtdesigtcs.Location = New System.Drawing.Point(152, 192)
        Me.Txtdesigtcs.Name = "Txtdesigtcs"
        Me.Txtdesigtcs.Size = New System.Drawing.Size(168, 20)
        Me.Txtdesigtcs.TabIndex = 4
        '
        'FrmSetTCS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(344, 241)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmSetTCS"
        Me.ShowInTaskbar = False
        Me.Text = "Company Tax Collected at Source Information "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Txtdesigtcs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdesigtcs.TextChanged

    End Sub

    Private Sub Txtdesigtcs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtdesigtcs.Leave
        FrmSetTCS.ActiveForm.Close()
    End Sub

    Private Sub FrmSetTCS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 428
        Me.Top = 50
    End Sub
End Class
