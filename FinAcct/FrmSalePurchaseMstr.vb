Imports System.Data
Imports System.Data.SqlClient

Public Class FrmSalePurchaseMstr
    Inherits System.Windows.Forms.Form
    Dim indx As Integer
    Dim CoCsCCmd As SqlCommand
    Dim DtaRdr As SqlDataReader
    Dim EdtRecrdNo As Integer
    Dim EdtFlag As Boolean
    Friend WithEvents CmbxType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Dim AddWithValueFlag As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'AddWithValue any initialization after the InitializeComponent() call

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCty As System.Windows.Forms.TextBox
    Friend WithEvents BtnCncl As System.Windows.Forms.Button
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents LstVewFnd As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSalePurchaseMstr))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCty = New System.Windows.Forms.TextBox
        Me.BtnCncl = New System.Windows.Forms.Button
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.LstVewFnd = New System.Windows.Forms.ListView
        Me.CmbxType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:-"
        '
        'TxtCty
        '
        Me.TxtCty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCty.Location = New System.Drawing.Point(63, 8)
        Me.TxtCty.MaxLength = 30
        Me.TxtCty.Name = "TxtCty"
        Me.TxtCty.Size = New System.Drawing.Size(321, 20)
        Me.TxtCty.TabIndex = 0
        '
        'BtnCncl
        '
        Me.BtnCncl.BackColor = System.Drawing.Color.Transparent
        Me.BtnCncl.BackgroundImage = CType(resources.GetObject("BtnCncl.BackgroundImage"), System.Drawing.Image)
        Me.BtnCncl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCncl.FlatAppearance.BorderSize = 0
        Me.BtnCncl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnCncl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCncl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCncl.ForeColor = System.Drawing.Color.Navy
        Me.BtnCncl.Location = New System.Drawing.Point(199, 330)
        Me.BtnCncl.Name = "BtnCncl"
        Me.BtnCncl.Size = New System.Drawing.Size(90, 30)
        Me.BtnCncl.TabIndex = 5
        Me.BtnCncl.Text = "&Cancel"
        Me.BtnCncl.UseVisualStyleBackColor = False
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.FlatAppearance.BorderSize = 0
        Me.BtnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.ForeColor = System.Drawing.Color.Navy
        Me.BtnFind.Location = New System.Drawing.Point(103, 330)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(90, 30)
        Me.BtnFind.TabIndex = 4
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Navy
        Me.BtnSave.Location = New System.Drawing.Point(7, 330)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(90, 30)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.BackColor = System.Drawing.Color.Transparent
        Me.BtnClos.BackgroundImage = CType(resources.GetObject("BtnClos.BackgroundImage"), System.Drawing.Image)
        Me.BtnClos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClos.FlatAppearance.BorderSize = 0
        Me.BtnClos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnClos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClos.ForeColor = System.Drawing.Color.Navy
        Me.BtnClos.Location = New System.Drawing.Point(295, 330)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(90, 30)
        Me.BtnClos.TabIndex = 6
        Me.BtnClos.Text = "C&lose"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'LstVewFnd
        '
        Me.LstVewFnd.AllowDrop = True
        Me.LstVewFnd.BackColor = System.Drawing.Color.LightCyan
        Me.LstVewFnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVewFnd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVewFnd.ForeColor = System.Drawing.Color.Navy
        Me.LstVewFnd.GridLines = True
        Me.LstVewFnd.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstVewFnd.HoverSelection = True
        Me.LstVewFnd.Location = New System.Drawing.Point(400, 8)
        Me.LstVewFnd.MultiSelect = False
        Me.LstVewFnd.Name = "LstVewFnd"
        Me.LstVewFnd.Size = New System.Drawing.Size(364, 352)
        Me.LstVewFnd.TabIndex = 2
        Me.LstVewFnd.UseCompatibleStateImageBehavior = False
        Me.LstVewFnd.View = System.Windows.Forms.View.Details
        Me.LstVewFnd.Visible = False
        '
        'CmbxType
        '
        Me.CmbxType.FormattingEnabled = True
        Me.CmbxType.Location = New System.Drawing.Point(63, 158)
        Me.CmbxType.Name = "CmbxType"
        Me.CmbxType.Size = New System.Drawing.Size(321, 21)
        Me.CmbxType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(3, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Type"
        '
        'FrmSalePurchaseMstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Cyan
        Me.ClientSize = New System.Drawing.Size(770, 369)
        Me.Controls.Add(Me.CmbxType)
        Me.Controls.Add(Me.LstVewFnd)
        Me.Controls.Add(Me.BtnCncl)
        Me.Controls.Add(Me.TxtCty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnClos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmSalePurchaseMstr"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Sale/Purchase Type Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub ChekEmpty()
        With TxtCty
            If .Text = "" Then
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                indx = indx + 1
                .Focus()
            Else
                .BackColor = Color.White
                .ForeColor = Color.Black
            End If
        End With
    End Sub

    Private Sub ClrValue()
        TxtCty.Text = ""
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Trim(BtnSave.Text) = "&Save" Then
            AddWithValueFlag = True
            EdtFlag = False
        ElseIf Trim(BtnSave.Text) = "&Update" Then
            AddWithValueFlag = False
            EdtFlag = True
            Me.BtnSave.Text = Trim("&Save")
        End If
        If BtnSave.Text = "&Save" Or BtnSave.Text = "&Update" Then

            ChekEmpty()
            If indx <> 0 Then
                indx = 0
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                Exit Sub
            Else
            End If
            Dim SveCnfrm As String
            SveCnfrm = MsgBox("Are you sure to Save this record?", MsgBoxStyle.YesNo, "Save")
            If SveCnfrm = vbYes Then
                If AddWithValueFlag = True Then
                    CoCsCCmd = New SqlCommand("Insert Into Finact_SalePurchaseType(SalePur_name,SalePurtype,SalePuradusrid,SalePuraddt,SalePurdelstatus,SalePurtype1) values(@pname,@plocid,@pusrid,@paddt,@pdels,@SalePurtype1)", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@pName", Trim(TxtCty.Text))
                    CoCsCCmd.Parameters.AddWithValue("@plocid", Trim(Me.CmbxType.Text))
                    CoCsCCmd.Parameters.AddWithValue("@pusrid", Current_UsrId)
                    CoCsCCmd.Parameters.AddWithValue("@paddt", Now)
                    CoCsCCmd.Parameters.AddWithValue("@pdels", 1)
                    CoCsCCmd.Parameters.AddWithValue("SalePurtype1", xSalePurCatType)
                ElseIf EdtFlag = True Then
                    If EdtRecrdNo = 0 Then
                        MsgBox("Invalid Input!,Select an item from list.", MsgBoxStyle.Critical, "Invalid Input!!!")
                        ClrValue()
                        Me.LstVewFnd.Focus()
                        Exit Sub
                    End If
                    ''CoCsCCmd = New SqlCommand("update Finact_SalePurchaseType set SalePur_name=@pname,SalePurtype=@plocid,SalePuredtusrid=@peusrid,SalePuredtdt=@pedtdt where SalePur_id=@pid", FinActConn)
                    ''CoCsCCmd.Parameters.AddWithValue("@pName", Trim(TxtCty.Text))
                    ''CoCsCCmd.Parameters.AddWithValue("@plocid", Trim(Me.CmbxProcsLoc.Text))
                    ''CoCsCCmd.Parameters.AddWithValue("@pid", EdtRecrdNo)
                    ''CoCsCCmd.Parameters.AddWithValue("@peusrid", Current_UsrId)
                    ''CoCsCCmd.Parameters.AddWithValue("@pedtdt", Now)
                    MsgBox("Invalid input! System permission denied ", MsgBoxStyle.Critical, "Permission Required")
                    Exit Sub
                End If

                Try
                    ' IntHtCmMm(0) = Trim(TxtCty.Text)
                    CoCsCCmd.ExecuteNonQuery()
                    MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information, "Saved!")
                    ClrValue()
                    Me.Width = 405
                    Me.Height = 395
                    If Trim(BtnSave.Text) = "&Update" Then
                        Me.BtnSave.Text = Trim("&Save")
                    End If
                    TxtCty.Focus()
                Catch ex As SqlException
                    If ex.Number = 2627 Then
                        MsgBox("Violation of Primary key" + Chr(10) + "Name is already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "City Name Alread Exist!")
                    Else
                        MsgBox(ex.Message)
                    End If
                    TxtCty.SelectAll()
                    TxtCty.Focus()
                    Exit Try
                Finally
                    CoCsCCmd = Nothing
                End Try
            ElseIf SveCnfrm = vbNo Then
                TxtCty.Focus()
            End If

        End If
    End Sub

    Private Sub BtnAddWithValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        ClrValue()
        TxtCty.Focus()
        AddWithValueFlag = True
        EdtFlag = False
        If LstVewFnd.Visible = True Then
            LstVewFnd.Visible = False
            Me.Height = 395
            Me.Width = 405

        End If
        BtnFind.Text = "&Find"
        BtnSave.Text = "&Save"
        If TxtCty.BackColor <> Color.White Then
            TxtCty.BackColor = Color.White
        End If
    End Sub

    Private Sub FrmCsCMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = xSalePurCatType.Trim & "-" & "TYPE MASTER"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Width = 405
            Me.Height = 395
            If xSalePurCatType.Trim = "SALE" Then
                Me.CmbxType.Items.AddRange(New Object() {"AGAINST H FORM", "EXPORT DIRECT", "INTER STATE", "INTER STATE BRANCH TRANSFER", _
                                                         "INTER STATE DECLARED GOODS", "INTER STATE DECLARED GOODS UN-REGD.", "INTER STATE UN-REGD. DEALER", "INTER STATE TAX FREE", _
                                                         "INTER STATE EXEMPTED", "FROM EXMPT.UNIT SOLD TO OTHER THAN TAXABLE PRSN", _
                                                         "UNDER WORKS CONTRACT", "UNDER WORKS CONTRACT INTERSTATE", "WITHIN STATE", "WITHIN STATE UN-REGD. DEALER", "WITHIN STATE TAX FREE", "WITHIN STATE EXEMPTED"})
            Else
                Me.CmbxType.Items.AddRange(New Object() {"AGAINST H FORM", "BRANCH/PRINCIPALS TRANSFER INTERSTATE", _
                                                         "CAPITAL GOODS", "IMPORT DIRECT", "INTER STATE", "INTER STATE TAX FREE", "INTER STATE EXEMPTED", _
                                                         "OTHER THAN TAXABLE WITHIN STATE", "OTHER THAN TAXABLE INTER STATE", "UNDER SECTION 19(1) AND 20", "UNDER SECTION 13(5)", "UNDER WORKS CONTRACT", _
                                                         "UNDER WORKS CONTRACT INTERSTATE", "WITHIN STATE", "WITHIN STATE TAX FREE", "WITHIN STATE EXEMPTED"})
            End If
         
            CheckAcess_Btn_frm(BtnCncl, BtnFind)
            EdtFlag = False
            AddWithValueFlag = True
            Me.TxtCty.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckAcess_Btn_frm(ByVal BtnnAdd As Button, _
         ByVal BtnnFnd As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnAdd.Enabled = True
                BtnnFnd.Enabled = True
            Case "DataEntryMstr"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(208, 104)
                BtnnFnd.Visible = False
            Case "PayRoll"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(208, 104)
                BtnnFnd.Visible = False
        End Select
    End Sub

    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Dim cnfrmmsg As String
        cnfrmmsg = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmmsg = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub Backcolor_chng()

        If TxtCty.BackColor <> Color.White Then
            TxtCty.BackColor = Color.White
        End If

    End Sub


    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        If BtnFind.Text = "&Find" Then
            Try
                Backcolor_chng()
                LstVewFnd.Clear()
                LstVewFnd.Columns.Add("Name", LstVewFnd.Width, HorizontalAlignment.Left)
                LstVewFnd.Columns.Add("Id", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
                LstVewFnd.Columns.Add("Type", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
                LstVewFnd.Columns.Add("Add User id", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
                LstVewFnd.Columns.Add("Add Date", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
                LstVewFnd.Columns.Add("Edit User id", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
                LstVewFnd.Columns.Add("Edit Date", LstVewFnd.Width \ 3, HorizontalAlignment.Left)

                Dim LstItem As ListViewItem
                Me.Height = 395
                Me.Width = 776
                LstVewFnd.Visible = True
                CoCsCCmd = New SqlCommand("Select * from Finact_SalePurchaseType where salepurtype1='" & Trim(xSalePurCatType) & "' order by SalePur_name ", FinActConn)

                DtaRdr = CoCsCCmd.ExecuteReader
                Dim x As Integer
                x = 0
                While DtaRdr.Read()
                    If DtaRdr.HasRows = True Then
                        LstItem = LstVewFnd.Items.Add(DtaRdr("SalePur_name"), 1)
                        LstVewFnd.Items(x).SubItems.Add(DtaRdr("SalePur_id"))
                        LstVewFnd.Items(x).SubItems.Add(DtaRdr("SalePurtype"))
                        LstVewFnd.Items(x).SubItems.Add(DtaRdr("SalePuradusrid"))
                        LstVewFnd.Items(x).SubItems.Add(DtaRdr("SalePuraddt"))
                        If DtaRdr.IsDBNull(7) = False Then
                            LstVewFnd.Items(x).SubItems.Add(DtaRdr("SalePuredtusrid"))
                            LstVewFnd.Items(x).SubItems.Add(DtaRdr("SalePuredtdt"))
                        Else
                            LstVewFnd.Items(x).SubItems.Add("N.A.")
                            LstVewFnd.Items(x).SubItems.Add("N.A.")
                        End If

                        x += 1
                    End If

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            Finally
                DtaRdr.Close()
                CoCsCCmd = Nothing
                LstVewFnd.Focus()
            End Try
            AddWithValueFlag = False
            EdtFlag = True
            BtnFind.Text = "&Delete"
            BtnSave.Text = "&Update"
        ElseIf BtnFind.Text = "&Delete" Then
            If TxtCty.Text = "" Or EdtRecrdNo < 1 Then
                MsgBox("No record is present to Delete.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If EdtRecrdNo > 0 Then 'TypeOf Cntrl Is TextBox And Cntrl.Text <> "" Then
                Dim delmsgconfrm As String
                Try
                    delmsgconfrm = MsgBox("Are you sure to Delete this record?", MsgBoxStyle.YesNo)
                    If delmsgconfrm = vbYes Then
                        If EdtRecrdNo <> 1 Then
                            ''CoCsCCmd = New SqlCommand("Delete  from Finact_SalePurchaseType where SalePur_id=@pid", FinActConn)
                            ''CoCsCCmd.Parameters.AddWithValue("@pid", EdtRecrdNo)
                            ''CoCsCCmd.ExecuteNonQuery()
                            MsgBox("Invalid Input! System permission denied.", MsgBoxStyle.Critical, "Permission Required")

                            ''CoCsCCmd.Dispose()
                            ''MsgBox("Current Record has been Deleted Successfully.", MsgBoxStyle.Information, "Delete")
                            ClrValue()
                            EdtRecrdNo = 0
                            BtnSave.Text = "&Save"
                            BtnFind.Text = "&Find"
                            TxtCty.Focus()
                            BtnFind.Text = "&Find"

                        ElseIf EdtRecrdNo = 1 Then
                            MsgBox("Invalid! current record is a system reserved record", MsgBoxStyle.Critical, "System Reserved!!")
                        End If
                    ElseIf delmsgconfrm = vbNo Then
                        BtnFind.Focus()
                        Exit Sub
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)

                Finally
                End Try
            End If
        End If
    End Sub

    Private Sub LstVewFnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewFnd.DoubleClick
        Try
            TxtCty.Text = LstVewFnd.SelectedItems(0).Text
            EdtRecrdNo = LstVewFnd.SelectedItems.Item(0).SubItems.Item(1).Text
            Me.CmbxType.Text = LstVewFnd.SelectedItems.Item(0).SubItems.Item(2).Text
            'TxtContry.Text = LstVewFnd.SelectedItems.Item(0).SubItems.Item(3).Text
            LstVewFnd.Visible = False
            Me.Height = 395
            Me.Width = 405
            ' BtnSave.Text = "&Update"
            'Btnedt.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LstVewFnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewFnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstVewFnd_DoubleClick(sender, e)
        End If

    End Sub

    Private Sub Btnall_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.GotFocus, BtnClos.GotFocus, BtnFind.GotFocus, BtnCncl.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Label1.KeyDown, LstVewFnd.KeyDown, BtnClos.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown, BtnCncl.KeyDown, TxtCty.KeyDown, Label2.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TxtCty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCty.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCty.Leave
        Try
            If TxtCty.Text = "" Then
                TxtCty.BackColor = Color.LemonChiffon
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Field")
                TxtCty.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCty.TextChanged
        If TxtCty.BackColor <> Color.White Then
            TxtCty.BackColor = Color.White
        End If
    End Sub

    Private Sub CmbxProcsLoc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType.GotFocus
        Try
            CmbxType.DroppedDown = True

            If CmbxType.Items.Count > 0 And CmbxType.SelectedIndex = -1 Then
                CmbxType.SelectedIndex = 0
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnall_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClos.Leave, BtnCncl.Leave, BtnFind.Leave, BtnSave.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxType.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxType_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CmbxType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxType.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxType) = True Then
                Me.BtnSave.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstVewFnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVewFnd.SelectedIndexChanged

    End Sub
End Class
