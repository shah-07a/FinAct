Public Class FrmFlloExcise
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtFeRegn As System.Windows.Forms.TextBox
    Friend WithEvents TxtRange As System.Windows.Forms.TextBox
    Friend WithEvents TxtFeCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtFeName As System.Windows.Forms.TextBox
    Friend WithEvents TxtFeAdrs As System.Windows.Forms.TextBox
    Friend WithEvents TxtFeAdrs1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtFeDivAdrs As System.Windows.Forms.TextBox
    Friend WithEvents TxtFeDivcode As System.Windows.Forms.TextBox
    Friend WithEvents TxtFeDivAdrs1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtFeDiv As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TxtFeRegn = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtRange = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtFeCode = New System.Windows.Forms.TextBox
        Me.TxtFeName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtFeAdrs = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtFeAdrs1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtFeDivAdrs = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtFeDivcode = New System.Windows.Forms.TextBox
        Me.TxtFeDivAdrs1 = New System.Windows.Forms.TextBox
        Me.TxtFeDiv = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtFeRegn)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtRange)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtFeCode)
        Me.Panel1.Controls.Add(Me.TxtFeName)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtFeAdrs)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TxtFeAdrs1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TxtFeDivAdrs)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TxtFeDivcode)
        Me.Panel1.Controls.Add(Me.TxtFeDivAdrs1)
        Me.Panel1.Controls.Add(Me.TxtFeDiv)
        Me.Panel1.Location = New System.Drawing.Point(9, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 320)
        Me.Panel1.TabIndex = 0
        '
        'TxtFeRegn
        '
        Me.TxtFeRegn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFeRegn.Location = New System.Drawing.Point(152, 16)
        Me.TxtFeRegn.Name = "TxtFeRegn"
        Me.TxtFeRegn.Size = New System.Drawing.Size(168, 20)
        Me.TxtFeRegn.TabIndex = 0
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
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Range :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Code :-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtRange
        '
        Me.TxtRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRange.Location = New System.Drawing.Point(80, 56)
        Me.TxtRange.Name = "TxtRange"
        Me.TxtRange.Size = New System.Drawing.Size(192, 20)
        Me.TxtRange.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Name :-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFeCode
        '
        Me.TxtFeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFeCode.Location = New System.Drawing.Point(80, 88)
        Me.TxtFeCode.Name = "TxtFeCode"
        Me.TxtFeCode.Size = New System.Drawing.Size(240, 20)
        Me.TxtFeCode.TabIndex = 2
        '
        'TxtFeName
        '
        Me.TxtFeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFeName.Location = New System.Drawing.Point(80, 120)
        Me.TxtFeName.Name = "TxtFeName"
        Me.TxtFeName.Size = New System.Drawing.Size(240, 20)
        Me.TxtFeName.TabIndex = 3
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
        Me.Label5.Text = "Address :-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFeAdrs
        '
        Me.TxtFeAdrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFeAdrs.Location = New System.Drawing.Point(80, 152)
        Me.TxtFeAdrs.Name = "TxtFeAdrs"
        Me.TxtFeAdrs.Size = New System.Drawing.Size(240, 20)
        Me.TxtFeAdrs.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Division :-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFeAdrs1
        '
        Me.TxtFeAdrs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFeAdrs1.Location = New System.Drawing.Point(80, 173)
        Me.TxtFeAdrs1.Name = "TxtFeAdrs1"
        Me.TxtFeAdrs1.Size = New System.Drawing.Size(240, 20)
        Me.TxtFeAdrs1.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 20)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Code :-"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFeDivAdrs
        '
        Me.TxtFeDivAdrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFeDivAdrs.Location = New System.Drawing.Point(80, 264)
        Me.TxtFeDivAdrs.Name = "TxtFeDivAdrs"
        Me.TxtFeDivAdrs.Size = New System.Drawing.Size(240, 20)
        Me.TxtFeDivAdrs.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 20)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Address :-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFeDivcode
        '
        Me.TxtFeDivcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFeDivcode.Location = New System.Drawing.Point(80, 232)
        Me.TxtFeDivcode.Name = "TxtFeDivcode"
        Me.TxtFeDivcode.Size = New System.Drawing.Size(184, 20)
        Me.TxtFeDivcode.TabIndex = 7
        '
        'TxtFeDivAdrs1
        '
        Me.TxtFeDivAdrs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFeDivAdrs1.Location = New System.Drawing.Point(80, 288)
        Me.TxtFeDivAdrs1.Name = "TxtFeDivAdrs1"
        Me.TxtFeDivAdrs1.Size = New System.Drawing.Size(240, 20)
        Me.TxtFeDivAdrs1.TabIndex = 9
        '
        'TxtFeDiv
        '
        Me.TxtFeDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFeDiv.Location = New System.Drawing.Point(80, 200)
        Me.TxtFeDiv.Name = "TxtFeDiv"
        Me.TxtFeDiv.Size = New System.Drawing.Size(184, 20)
        Me.TxtFeDiv.TabIndex = 6
        '
        'FrmFlloExcise
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(346, 336)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmFlloExcise"
        Me.ShowInTaskbar = False
        Me.Text = "Follow Excise Rules For Invoicing"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TxtDivAdrs1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFeDivAdrs1.Leave
        FrmFlloExcise.ActiveForm.Hide()
    End Sub

    Private Sub FrmFlloExcise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 426
        Me.Top = 50
    End Sub
End Class
