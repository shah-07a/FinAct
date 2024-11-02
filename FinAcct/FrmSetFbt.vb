Public Class FrmSetFbt
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbxIssur As System.Windows.Forms.ComboBox
    Friend WithEvents TxtPanFbt As System.Windows.Forms.TextBox
    Friend WithEvents CmbxAsesetype As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxAseseCat As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CmbxIssur = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPanFbt = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbxAsesetype = New System.Windows.Forms.ComboBox
        Me.CmbxAseseCat = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmbxIssur)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtPanFbt)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.CmbxAsesetype)
        Me.Panel1.Controls.Add(Me.CmbxAseseCat)
        Me.Panel1.Location = New System.Drawing.Point(9, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 160)
        Me.Panel1.TabIndex = 0
        '
        'CmbxIssur
        '
        Me.CmbxIssur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxIssur.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxIssur.Location = New System.Drawing.Point(168, 96)
        Me.CmbxIssur.Name = "CmbxIssur"
        Me.CmbxIssur.Size = New System.Drawing.Size(72, 21)
        Me.CmbxIssur.TabIndex = 2
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
        Me.Label1.Text = "FBT Assessee's  Details "
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
        Me.Label2.Size = New System.Drawing.Size(152, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "PAN/Income Tax No.  :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Assessee Type  :-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPanFbt
        '
        Me.TxtPanFbt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPanFbt.Location = New System.Drawing.Point(168, 32)
        Me.TxtPanFbt.Name = "TxtPanFbt"
        Me.TxtPanFbt.Size = New System.Drawing.Size(152, 20)
        Me.TxtPanFbt.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Is Surcharge Applicable :-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Assessee Category :-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxAsesetype
        '
        Me.CmbxAsesetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxAsesetype.Items.AddRange(New Object() {"Artificial Juridical Person", "Association of Person", "Body of Individuals", "Firms/Domestic Companies", "Local Authority", "Non-Domestic Companies"})
        Me.CmbxAsesetype.Location = New System.Drawing.Point(168, 64)
        Me.CmbxAsesetype.Name = "CmbxAsesetype"
        Me.CmbxAsesetype.Size = New System.Drawing.Size(152, 21)
        Me.CmbxAsesetype.TabIndex = 1
        '
        'CmbxAseseCat
        '
        Me.CmbxAseseCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxAseseCat.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxAseseCat.Location = New System.Drawing.Point(168, 128)
        Me.CmbxAseseCat.Name = "CmbxAseseCat"
        Me.CmbxAseseCat.Size = New System.Drawing.Size(152, 21)
        Me.CmbxAseseCat.TabIndex = 3
        '
        'FrmSetFbt
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(346, 176)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmSetFbt"
        Me.ShowInTaskbar = False
        Me.Text = "Company Fringe Benefit Tax (FBT)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmSetFbt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 428
        Me.Top = 28
    End Sub

    Private Sub CmbxAseseCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxAseseCat.SelectedIndexChanged
        FrmSetFbt.ActiveForm.Close()
    End Sub
End Class
