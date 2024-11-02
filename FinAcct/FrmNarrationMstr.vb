Imports System.Data.SqlClient
Imports System.Data.DataTable
Imports System.Data
Public Class FrmNarrationMstr
    Inherits System.Windows.Forms.Form
    Dim Indx As Integer
    Dim CatCmd As SqlCommand
    Dim DtaRdr As SqlDataReader
    Dim addFlag As Boolean
    Dim EdtFlag As Boolean
    Dim AllowEdt As Boolean = False
    Dim EdtRecrdNo As Integer
    Dim DelStatus As Integer
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            addFlag = True
            EdtFlag = False
            ChekEmpty()
            If Indx <> 0 Then
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                ' BtnSave.Enabled = False
                Indx = 0
                Exit Sub
            Else
                ' BtnSave.Enabled = True
            End If
            Dim SveCnfrm As String
            SveCnfrm = MsgBox("Are you sure to Save this record?", MsgBoxStyle.YesNo)
            If SveCnfrm = vbYes Then
                If FinActConn.State Then FinActConn.Close()
                FinActConn.Open()
                If addFlag = True Then
                    CatCmd = New SqlCommand("Finact_Narration_Insert", FinActConn)
                    CatCmd.CommandType = CommandType.StoredProcedure
                    CatCmd.Parameters.AddWithValue("@Nrr", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@Nrradusrid", Current_UsrId)
                    CatCmd.Parameters.AddWithValue("@Nrraddt", Now)
                ElseIf EdtFlag = True Then
                    CatCmd = New SqlCommand("Finact_Narration_Update", FinActConn)
                    CatCmd.CommandType = CommandType.StoredProcedure
                    CatCmd.Parameters.AddWithValue("@Nrr", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@Nrrid", EdtRecrdNo)
                    CatCmd.Parameters.AddWithValue("@Nrredtusrid", Current_UsrId)
                    CatCmd.Parameters.AddWithValue("@Nrredtdt", Now)
                End If

                Try
                    CatCmd.ExecuteNonQuery()
                    MsgBox("Record has been Saved Successfully", MsgBoxStyle.Information)
                    ClrValue()
                Catch ex As Exception
                    ' MsgBox("Violation of Primary key" + Chr(10) + "Already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "Branch Name Already Exist!")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Department")
                    TxtDept.SelectAll()
                    TxtDept.Focus()
                    Exit Try
                Finally
                    CatCmd = Nothing
                    TxtDept.Focus()
                    ' Btnadd.Focus()
                End Try
            ElseIf SveCnfrm = vbNo Then
                TxtDept.Focus()
            End If
        ElseIf BtnSave.Text = "&Update" Then
            If AllowEdt = True Then
                TxtDept.Focus()
                addFlag = False
                EdtFlag = True
                ChekEmpty()
                If Indx <> 0 Then
                    MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                    Indx = 0
                    Exit Sub
                Else

                End If

                If EdtFlag = True Then
                    CatCmd = New SqlCommand("Finact_Narration_Update", FinActConn)
                    CatCmd.CommandType = CommandType.StoredProcedure
                    CatCmd.Parameters.AddWithValue("@Nrr", Trim(TxtDept.Text))
                    CatCmd.Parameters.AddWithValue("@Nrrid", EdtRecrdNo)
                    CatCmd.Parameters.AddWithValue("@Nrredtusrid", Current_UsrId)
                    CatCmd.Parameters.AddWithValue("@Nrredtdt", Now)
                End If

                Try
                    CatCmd.ExecuteNonQuery()
                    MsgBox("Record has been Updated Successfully", MsgBoxStyle.Information)
                    ClrValue()
                    BtnSave.Text = "&Save"
                    BtnFind.Text = "&Find"

                Catch ex As Exception
                    MsgBox("Violation of Primary key" + Chr(10) + "Already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "Branch Name Already Exist!")
                    TxtDept.SelectAll()
                    TxtDept.Focus()
                    Exit Try
                Finally
                    CatCmd = Nothing
                    TxtDept.Focus()
                End Try

            Else
                If TxtDept.Text = "" Then
                    MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                    TxtDept.BackColor = Color.LemonChiffon
                    TxtDept.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub FrmdeptMstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Me.Size = New Size(550, 399)
            Me.Top = 0
            Me.Width = 430 'MeWidth / 1.45
            Me.Height = 399 'MeHeight / 3.7

            CheckAcess_Btn_frm(Btnadd, BtnFind)
            addFlag = True
            EdtFlag = False
            Me.TxtDept.Focus()
            Me.TxtDept.SelectAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CheckAcess_Btn_frm(ByVal BtnnAdd As Button, ByVal BtnnFnd As Button)
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
    End Sub
    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        If BtnFind.Text = "&Find" Then
            If TxtDept.BackColor <> Color.White Then
                TxtDept.BackColor = Color.White
            End If
            Me.Width = 765
            Me.Height = 399

            LstVewFnd.Clear()
            LstVewFnd.Columns.Add("Name Of Branch", LstVewFnd.Width, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Id", LstVewFnd.Width \ 1, HorizontalAlignment.Left)
            Dim LstItem As ListViewItem
            LstVewFnd.Visible = True
            CatCmd = New SqlCommand("Select * from finact_narration where Nrrdelstatus=1 order by Narration ", FinActConn)
            Try
                DtaRdr = CatCmd.ExecuteReader
                Dim x As Integer
                x = 0
                While DtaRdr.Read()
                    LstItem = LstVewFnd.Items.Add(DtaRdr("Narration"), 1)
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("Nrrid"))
                    x += 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            Finally
                DtaRdr.Close()
                CatCmd = Nothing
                LstVewFnd.Focus()
                LstVewFnd.Select()
            End Try
            addFlag = False
            EdtFlag = True
            BtnSave.Text = "&Update"
            BtnFind.Text = "&Delete"

        ElseIf BtnFind.Text = "&Delete" Then
            If TxtDept.Text = "" Or EdtRecrdNo < 1 Then
                MsgBox("No record is present to delete", MsgBoxStyle.Information)
                Exit Sub
            End If
            If TxtDept.Text <> "" And EdtRecrdNo > 0 Then
                Select Case MsgBox("Are you sure to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)
                    Case MsgBoxResult.Yes
                        CatCmd = New SqlCommand("Delete from finact_narration where Nrrid=@deptid", FinActConn)
                        CatCmd.Parameters.AddWithValue("@deptid", EdtRecrdNo)
                        Try
                            CatCmd.ExecuteNonQuery()
                            MsgBox("Current Record has been Deleted Successfully", MsgBoxStyle.Information, "Current Record Deleted")
                            BtnSave.Text = "&Save"
                            BtnFind.Text = "&Find"
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Exit Try
                        Finally
                            CatCmd = Nothing
                            TxtDept.Text = ""
                            EdtRecrdNo = 0
                            TxtDept.Focus()
                        End Try
                    Case MsgBoxResult.No
                        BtnFind.Focus()

                End Select

            End If
        End If
    End Sub
    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Dim cnfrmmsg As String
        cnfrmmsg = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmmsg = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub LstVewFnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewFnd.DoubleClick
        Try
            TxtDept.Text = LstVewFnd.SelectedItems(0).Text
            EdtRecrdNo = LstVewFnd.SelectedItems.Item(0).SubItems.Item(1).Text
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 399)
            BtnFind.Enabled = True
            AllowEdt = True
            BtnFind.Focus()
            'TxtDept.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub LstVewFnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewFnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstVewFnd_DoubleClick(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 399)
        End If
    End Sub


    Private Sub TxtDept_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDept.Leave
        BtnSave.Focus()
    End Sub
    Private Sub ChekEmpty()
        With TxtDept
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
    End Sub

    Private Sub ClrValue()
        TxtDept.Text = ""
    End Sub

    Private Sub Btnadd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        ClrValue()
        addFlag = True
        EdtFlag = False
        AllowEdt = False
        TxtDept.Focus()
        If LstVewFnd.Visible = True Then
            LstVewFnd.Visible = False
            Me.Size = New Size(430, 399)
        End If
        BtnSave.Text = "&Save"
        BtnFind.Text = "&Find"
        If TxtDept.BackColor <> Color.White Then
            TxtDept.BackColor = Color.White
        End If

    End Sub

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClos.GotFocus, Btnadd.GotFocus _
    , BtnFind.GotFocus, BtnSave.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GroupBox1.KeyDown, Label1.KeyDown, LstVewFnd.KeyDown, _
    TxtDept.KeyDown, Btnadd.KeyDown, BtnClos.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDept.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub TxtDept_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDept.TextChanged
        If TxtDept.BackColor <> Color.White Then
            TxtDept.BackColor = Color.White
        End If
    End Sub


    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Leave, BtnClos.Leave _
    , BtnFind.Leave, BtnSave.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
End Class