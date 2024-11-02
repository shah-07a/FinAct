Public Class FrmSetVat
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbxStates As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtpkrVatApp As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpkrVatApp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbxDealType As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DtpkrVatApp = New System.Windows.Forms.DateTimePicker
        Me.CmbxStates = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbxDealType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DtpkrVatApp1 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DtpkrVatApp)
        Me.Panel1.Controls.Add(Me.CmbxStates)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CmbxDealType)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.DtpkrVatApp1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(9, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 224)
        Me.Panel1.TabIndex = 0
        '
        'DtpkrVatApp
        '
        Me.DtpkrVatApp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpkrVatApp.Location = New System.Drawing.Point(208, 128)
        Me.DtpkrVatApp.Name = "DtpkrVatApp"
        Me.DtpkrVatApp.Size = New System.Drawing.Size(104, 20)
        Me.DtpkrVatApp.TabIndex = 2
        '
        'CmbxStates
        '
        Me.CmbxStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxStates.Location = New System.Drawing.Point(120, 24)
        Me.CmbxStates.Name = "CmbxStates"
        Me.CmbxStates.Size = New System.Drawing.Size(192, 21)
        Me.CmbxStates.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 20)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "State :-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Type of Dealer :-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbxDealType
        '
        Me.CmbxDealType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxDealType.Items.AddRange(New Object() {"Regular " & Global.Microsoft.VisualBasic.ChrW(9), "Composition", "Composition to Regular"})
        Me.CmbxDealType.Location = New System.Drawing.Point(120, 72)
        Me.CmbxDealType.Name = "CmbxDealType"
        Me.CmbxDealType.Size = New System.Drawing.Size(192, 21)
        Me.CmbxDealType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Regular VAT Application From :-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtpkrVatApp1
        '
        Me.DtpkrVatApp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpkrVatApp1.Location = New System.Drawing.Point(208, 168)
        Me.DtpkrVatApp1.Name = "DtpkrVatApp1"
        Me.DtpkrVatApp1.Size = New System.Drawing.Size(104, 20)
        Me.DtpkrVatApp1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 32)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Composition Scheme Application From :-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmSetVat
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(344, 240)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmSetVat"
        Me.ShowInTaskbar = False
        Me.Text = "Value added Tax (VAT)"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmSetVat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 426
        Me.Top = 50

    End Sub

    Private Sub DtpkrVatApp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrVatApp1.ValueChanged

    End Sub

    Private Sub DtpkrVatApp1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpkrVatApp1.Leave
        FrmSetVat.ActiveForm.Close()
    End Sub
End Class
