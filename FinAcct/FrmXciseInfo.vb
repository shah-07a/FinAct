Public Class FrmXciseInfo
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'add any initialization after the InitializeComponent() call

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtRegn As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtRncod As System.Windows.Forms.TextBox
    Friend WithEvents TxtRnname As System.Windows.Forms.TextBox
    Friend WithEvents TxtRnAdrs As System.Windows.Forms.TextBox
    Friend WithEvents TxtRnAdrs1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtComm As System.Windows.Forms.TextBox
    Friend WithEvents TxtDivCod As System.Windows.Forms.TextBox
    Friend WithEvents TxtDivAdrs As System.Windows.Forms.TextBox
    Friend WithEvents TxtDivName As System.Windows.Forms.TextBox
    Friend WithEvents TxtDivAdrs1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TxtRegn = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtRncod = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtRnname = New System.Windows.Forms.TextBox
        Me.TxtRnAdrs = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtRnAdrs1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtComm = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtDivAdrs = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtDivName = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtDivAdrs1 = New System.Windows.Forms.TextBox
        Me.TxtDivCod = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtRegn)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtRncod)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtRnname)
        Me.Panel1.Controls.Add(Me.TxtRnAdrs)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtRnAdrs1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TxtComm)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TxtDivAdrs)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TxtDivName)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.TxtDivAdrs1)
        Me.Panel1.Controls.Add(Me.TxtDivCod)
        Me.Panel1.Location = New System.Drawing.Point(11, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 392)
        Me.Panel1.TabIndex = 0
        '
        'TxtRegn
        '
        Me.TxtRegn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRegn.Location = New System.Drawing.Point(152, 16)
        Me.TxtRegn.Name = "TxtRegn"
        Me.TxtRegn.Size = New System.Drawing.Size(168, 20)
        Me.TxtRegn.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ECC/PAN Based Registration/Code No. :- "
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "RANGE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Code :-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtRncod
        '
        Me.TxtRncod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRncod.Location = New System.Drawing.Point(80, 88)
        Me.TxtRncod.Name = "TxtRncod"
        Me.TxtRncod.Size = New System.Drawing.Size(184, 20)
        Me.TxtRncod.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Name :-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtRnname
        '
        Me.TxtRnname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRnname.Location = New System.Drawing.Point(80, 120)
        Me.TxtRnname.Name = "TxtRnname"
        Me.TxtRnname.Size = New System.Drawing.Size(240, 20)
        Me.TxtRnname.TabIndex = 2
        '
        'TxtRnAdrs
        '
        Me.TxtRnAdrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRnAdrs.Location = New System.Drawing.Point(80, 152)
        Me.TxtRnAdrs.Name = "TxtRnAdrs"
        Me.TxtRnAdrs.Size = New System.Drawing.Size(240, 20)
        Me.TxtRnAdrs.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "address :-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtRnAdrs1
        '
        Me.TxtRnAdrs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRnAdrs1.Location = New System.Drawing.Point(80, 173)
        Me.TxtRnAdrs1.Name = "TxtRnAdrs1"
        Me.TxtRnAdrs1.Size = New System.Drawing.Size(240, 20)
        Me.TxtRnAdrs1.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(8, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "DIVISION"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 20)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "COMMISSIONERATE :-"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtComm
        '
        Me.TxtComm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtComm.Location = New System.Drawing.Point(160, 208)
        Me.TxtComm.Name = "TxtComm"
        Me.TxtComm.Size = New System.Drawing.Size(160, 20)
        Me.TxtComm.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 272)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 20)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Code :-"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDivAdrs
        '
        Me.TxtDivAdrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDivAdrs.Location = New System.Drawing.Point(80, 336)
        Me.TxtDivAdrs.Name = "TxtDivAdrs"
        Me.TxtDivAdrs.Size = New System.Drawing.Size(240, 20)
        Me.TxtDivAdrs.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 20)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "address :-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDivName
        '
        Me.TxtDivName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDivName.Location = New System.Drawing.Point(80, 304)
        Me.TxtDivName.Name = "TxtDivName"
        Me.TxtDivName.Size = New System.Drawing.Size(240, 20)
        Me.TxtDivName.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(8, 304)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 20)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Name :-"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDivAdrs1
        '
        Me.TxtDivAdrs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDivAdrs1.Location = New System.Drawing.Point(80, 357)
        Me.TxtDivAdrs1.Name = "TxtDivAdrs1"
        Me.TxtDivAdrs1.Size = New System.Drawing.Size(240, 20)
        Me.TxtDivAdrs1.TabIndex = 9
        '
        'TxtDivCod
        '
        Me.TxtDivCod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDivCod.Location = New System.Drawing.Point(80, 272)
        Me.TxtDivCod.Name = "TxtDivCod"
        Me.TxtDivCod.Size = New System.Drawing.Size(184, 20)
        Me.TxtDivCod.TabIndex = 6
        '
        'FrmXciseInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(346, 408)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmXciseInfo"
        Me.ShowInTaskbar = False
        Me.Text = "Company's Excise Informations"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmXciseInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 426
        Me.Top = 50
    End Sub
    Private Sub TxtDivAdrs1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDivAdrs1.Leave
        FrmXciseInfo.ActiveForm.Hide()
    End Sub

   
End Class
