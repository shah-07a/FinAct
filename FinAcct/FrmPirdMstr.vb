Imports System.Data.SqlClient
Imports System.Data.DataTable
Imports System.Data


Public Class FrmPirdMstr
    Inherits System.Windows.Forms.Form

    Dim Indx As Integer
    Dim PerdCmd As SqlCommand
    Dim PerdRdr As SqlDataReader
    Friend WithEvents DtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbxFind As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label


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
    Friend WithEvents Btnadd As System.Windows.Forms.Button
    Friend WithEvents TxtPird As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPirdMstr))
        Me.Btnadd = New System.Windows.Forms.Button
        Me.TxtPird = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.DtpFrom = New System.Windows.Forms.DateTimePicker
        Me.DtpTo = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbxFind = New System.Windows.Forms.ComboBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Btnadd
        '
        Me.Btnadd.BackColor = System.Drawing.Color.Transparent
        Me.Btnadd.BackgroundImage = CType(resources.GetObject("Btnadd.BackgroundImage"), System.Drawing.Image)
        Me.Btnadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnadd.FlatAppearance.BorderSize = 0
        Me.Btnadd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.Btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnadd.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnadd.ForeColor = System.Drawing.Color.Navy
        Me.Btnadd.Location = New System.Drawing.Point(264, 337)
        Me.Btnadd.Name = "Btnadd"
        Me.Btnadd.Size = New System.Drawing.Size(100, 33)
        Me.Btnadd.TabIndex = 6
        Me.Btnadd.Text = "&Cancel"
        Me.Btnadd.UseVisualStyleBackColor = False
        '
        'TxtPird
        '
        Me.TxtPird.BackColor = System.Drawing.Color.White
        Me.TxtPird.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPird.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPird.Location = New System.Drawing.Point(132, 23)
        Me.TxtPird.MaxLength = 50
        Me.TxtPird.Name = "TxtPird"
        Me.TxtPird.Size = New System.Drawing.Size(347, 23)
        Me.TxtPird.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(31, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "NAME: "
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFind.FlatAppearance.BorderSize = 0
        Me.BtnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.ForeColor = System.Drawing.Color.Navy
        Me.BtnFind.Location = New System.Drawing.Point(149, 337)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(100, 33)
        Me.BtnFind.TabIndex = 5
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Navy
        Me.BtnSave.Location = New System.Drawing.Point(34, 337)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(100, 33)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.BackColor = System.Drawing.Color.Transparent
        Me.BtnClos.BackgroundImage = CType(resources.GetObject("BtnClos.BackgroundImage"), System.Drawing.Image)
        Me.BtnClos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClos.FlatAppearance.BorderSize = 0
        Me.BtnClos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.BtnClos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClos.ForeColor = System.Drawing.Color.Navy
        Me.BtnClos.Location = New System.Drawing.Point(379, 337)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(100, 33)
        Me.BtnClos.TabIndex = 7
        Me.BtnClos.Text = "&Close"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'DtpFrom
        '
        Me.DtpFrom.CustomFormat = "dd/MM/yyyy"
        Me.DtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFrom.Location = New System.Drawing.Point(132, 129)
        Me.DtpFrom.Name = "DtpFrom"
        Me.DtpFrom.Size = New System.Drawing.Size(147, 23)
        Me.DtpFrom.TabIndex = 2
        '
        'DtpTo
        '
        Me.DtpTo.CustomFormat = "dd/MM/yyyy"
        Me.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpTo.Location = New System.Drawing.Point(132, 229)
        Me.DtpTo.Name = "DtpTo"
        Me.DtpTo.Size = New System.Drawing.Size(147, 23)
        Me.DtpTo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(31, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "FROM DATE: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(31, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "TO DATE: "
        '
        'CmbxFind
        '
        Me.CmbxFind.Enabled = False
        Me.CmbxFind.FormattingEnabled = True
        Me.CmbxFind.Location = New System.Drawing.Point(132, 61)
        Me.CmbxFind.Name = "CmbxFind"
        Me.CmbxFind.Size = New System.Drawing.Size(347, 24)
        Me.CmbxFind.TabIndex = 1
        Me.CmbxFind.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"MONTH", "QUARTER", "HALF YEAR", "YEAR"})
        Me.ComboBox1.Location = New System.Drawing.Point(132, 277)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox1.TabIndex = 16
        Me.ComboBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(31, 277)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "TYPE"
        Me.Label4.Visible = False
        '
        'FrmPirdMstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.BackgroundImage = Global.FinAcct.My.Resources.Resources.METALR1A
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(514, 376)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.CmbxFind)
        Me.Controls.Add(Me.DtpTo)
        Me.Controls.Add(Me.DtpFrom)
        Me.Controls.Add(Me.TxtPird)
        Me.Controls.Add(Me.Btnadd)
        Me.Controls.Add(Me.BtnClos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.BtnSave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmPirdMstr"
        Me.Text = "PERIOD MASTER"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Me.TxtPird.Text.Trim = "" Then
                Indx = 1
            Else
                Indx = 0
            End If
            If Indx <> 0 Then
                MsgBox("Blank field not allowed", MsgBoxStyle.Critical, "Blank Field")
                Indx = 0
                Exit Sub
            End If
            If Me.DtpFrom.Value >= Me.DtpTo.Value Then
                MsgBox("Invalid Input", MsgBoxStyle.Critical, "Invalid dates")
                Me.DtpTo.Focus()
                Exit Sub
            End If
            If BtnSave.Text = "&Save" Then
                If MessageBox.Show("Are you sure to save current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    If FinActConn.State Then FinActConn.Close()
                    FinActConn.Open()
                    PerdCmd = New SqlCommand("Finact_PerdMstr_Insert", FinActConn)
                    PerdCmd.CommandType = CommandType.StoredProcedure
                    PerdCmd.Parameters.AddWithValue("@PerdName", Trim(Me.TxtPird.Text))
                    PerdCmd.Parameters.AddWithValue("@PerdFdt", Me.DtpFrom.Value.Date)
                    PerdCmd.Parameters.AddWithValue("@PerdTdt", Me.DtpTo.Value.Date)
                    PerdCmd.Parameters.AddWithValue("@PerdAdusrid", Current_UsrId)
                    PerdCmd.Parameters.AddWithValue("@PerdAddt", Now)
                    PerdCmd.ExecuteNonQuery()
                    PerdCmd.Dispose()
                    MsgBox("Current record has been successfully saved", MsgBoxStyle.Information, Me.Text)
                    ClrValue()
                    Me.TxtPird.Focus()
                Else
                    Return
                End If
            ElseIf BtnSave.Text = "&Update" Then
                If MessageBox.Show("Are you sure to update current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    If FinActConn.State Then FinActConn.Close()
                    FinActConn.Open()
                    PerdCmd = New SqlCommand("Finact_PerdMstr_Update", FinActConn)
                    PerdCmd.CommandType = CommandType.StoredProcedure
                    PerdCmd.Parameters.AddWithValue("@PerdId", CInt(Me.CmbxFind.SelectedValue))
                    PerdCmd.Parameters.AddWithValue("@PerdName", Trim(Me.TxtPird.Text))
                    PerdCmd.Parameters.AddWithValue("@PerdFdt", Me.DtpFrom.Value.Date)
                    PerdCmd.Parameters.AddWithValue("@PerdTdt", Me.DtpTo.Value.Date)
                    PerdCmd.Parameters.AddWithValue("@PerdEdtusrid", Current_UsrId)
                    PerdCmd.Parameters.AddWithValue("@PerdEdtdt", Now)
                    PerdCmd.ExecuteNonQuery()
                    PerdCmd.Dispose()

                    MsgBox("Current record has been successfully updated", MsgBoxStyle.Information, Me.Text)
                   xCnclBtn()
                    ClrValue()
                    Me.TxtPird.Focus()
                Else
                    Return
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub xCnclBtn()
        Try
            Me.CmbxFind.Location = New System.Drawing.Point(127, 35)
            Me.TxtPird.Visible = True
            Me.TxtPird.Enabled = True
            Me.CmbxFind.Enabled = False
            Me.CmbxFind.Visible = False
            Me.BtnSave.Enabled = True
            Me.BtnSave.Text = "&Save"
            Me.BtnFind.Text = "&Find"

        Catch ex As Exception

        End Try
    End Sub
    Private Sub xCnclBtn1()
        Try
            Me.CmbxFind.Location = New System.Drawing.Point(127, 35)
            Me.TxtPird.Visible = True
            Me.TxtPird.Enabled = True
            Me.CmbxFind.Enabled = False
            Me.CmbxFind.Visible = False
            Me.BtnSave.Enabled = True
         
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmdeptMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Width = 520 'MeWidth / 1.45
            Me.Height = 402 'MeHeight / 3.7
            CheckAcess_Btn_frm(Btnadd, BtnFind)
            Me.TxtPird.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckAcess_Btn_frm(ByVal BtnnAdd As Button, ByVal BtnnFnd As Button)
        Try
            Select Case Trim(AcessRight)
                Case "OwnrFull"
                    BtnnAdd.Enabled = True
                    BtnnFnd.Enabled = True
                Case "DataEntryMstr"
                    BtnnAdd.Enabled = True
                    BtnnAdd.Location = New System.Drawing.Point(204, 68)
                    BtnnFnd.Visible = False
                Case "PayRoll"
                    BtnnAdd.Enabled = True
                    BtnnAdd.Location = New System.Drawing.Point(204, 68)
                    BtnnFnd.Visible = False
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Try
            If BtnFind.Text = "&Find" Then
                Fill_Combobox("Perdid", "PerdName", "Finact_PerdMstr", "PerdDelStatus", CInt(1), Me.CmbxFind)
                Me.CmbxFind.Location = New System.Drawing.Point(132, 23)
                Me.TxtPird.Visible = False
                Me.TxtPird.Enabled = False
                Me.CmbxFind.Enabled = True
                Me.CmbxFind.Visible = True
                BtnFind.Text = "&Delete"
                BtnSave.Text = "&Update"
                Me.BtnSave.Enabled = False
                Me.CmbxFind.Focus()
            ElseIf BtnFind.Text = "&Delete" Then
                xCnclBtn()
                ClrValue()
                MsgBox("Access Denied!", MsgBoxStyle.Critical, Me.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Try
            Dim cnfrmmsg As String
            cnfrmmsg = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
            If cnfrmmsg = vbYes Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChekEmpty()
        Try

            With TxtPird
                If .Text = "" Then
                    .BackColor = Color.LemonChiffon
                    .ForeColor = Color.Black
                    Indx = Indx + 1
                    .Focus()
                Else
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End If
            End With

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClrValue()
        Try
            TxtPird.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnadd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        Try
            xCnclBtn()
            ClrValue()
            TxtPird.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.GotFocus, Btnadd.GotFocus, BtnClos.GotFocus, BtnFind.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Label1.KeyDown, TxtPird.KeyDown, Btnadd.KeyDown, BtnClos.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown, Label2.KeyDown, Label3.KeyDown, Label4.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Allcontrols_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPird.KeyDown, DtpFrom.KeyDown, DtpTo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtDept_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPird.Leave
        Try
            If Not Len(Trim(Me.TxtPird.Text)) > 0 Then
                Me.TxtPird.Focus()
                Me.TxtPird.SelectAll()
                Me.TxtPird.BackColor = Color.Cyan
            Else
                Me.TxtPird.BackColor = Color.White
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtDept_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPird.TextChanged
        Try
            If TxtPird.BackColor <> Color.White Then
                TxtPird.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Leave, BtnClos.Leave, BtnFind.Leave, BtnSave.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFind_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxFind.GotFocus
        Try
            Me.CmbxFind.DroppedDown = True
            Me.BtnSave.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxFind.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxFind_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFind_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxFind.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxFind) = True Then
                If Me.CmbxFind.SelectedIndex = 0 Then
                    xFillSelRec(Me.CmbxFind.SelectedValue)
                End If
                Me.BtnSave.Enabled = True
                xCnclBtn1()
                Me.TxtPird.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFind_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxFind.SelectedIndexChanged
        Try
            If Me.CmbxFind.SelectedIndex > 0 Then
                xFillSelRec(Me.CmbxFind.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFillSelRec(ByVal xPerdid As Integer)
        Try
            If FinActConn1.State Then FinActConn1.Close()
            FinActConn1.Open()
            PerdCmd = New SqlCommand("Finact_PerdMstr_Select", FinActConn1)
            PerdCmd.CommandType = CommandType.StoredProcedure
            PerdCmd.Parameters.AddWithValue("@PerdId", CInt(xPerdid))
            PerdRdr = PerdCmd.ExecuteReader
            While PerdRdr.Read
                If PerdRdr.IsDBNull(0) = False Then
                    Me.TxtPird.Text = Trim(PerdRdr("PerdName"))
                    Me.DtpFrom.Value = PerdRdr("perdFdt")
                    Me.DtpTo.Value = PerdRdr("PerdTdt")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            PerdCmd.Dispose()
            PerdRdr.Close()
        End Try
    End Sub

    Private Sub DtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpTo.ValueChanged

    End Sub
End Class
