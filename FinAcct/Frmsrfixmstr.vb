Imports System.Data
Imports System.Data.SqlClient


Public Class Frmsrfixmstr
    Inherits System.Windows.Forms.Form
    Dim indx As Integer
    Dim CoCsCCmd As SqlCommand
    Dim DtaRdr As SqlDataReader
    Dim EdtRecrdNo As Integer
    Dim EdtFlag As Boolean
    Dim AddWithValueFlag As Boolean

    Private Sub Frmsrfixmstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0
        Me.Width = 290
        Me.Height = 146
        Me.SplitContainer1.SplitterDistance = 70
        CheckAcess_Btn_frm(BtnAddWithValue, BtnFind)
        EdtFlag = False
        AddWithValueFlag = True
    End Sub
    Private Sub ChekEmpty()
        With TxtSrfix
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
        TxtSrfix.Text = ""
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Or BtnSave.Text = "&Update" Then
            AddWithValueFlag = True
            EdtFlag = False

            ChekEmpty()
            If indx <> 0 Then
                'BtnSave.Enabled = False
                indx = 0
                MsgBox("Blank Field not allowed", MsgBoxStyle.Information, "Blank Field")
                Exit Sub
            Else
                'BtnSave.Enabled = True
            End If
            Dim SveCnfrm As String
            SveCnfrm = MsgBox("Are you sure to Save this record?", MsgBoxStyle.YesNo, "Save")
            If SveCnfrm = vbYes Then
                If AddWithValueFlag = True Then
                    CoCsCCmd = New SqlCommand("Insert Into finact_srfixmstr (srfixname,adusrid,addt,delstatus)values(@name,@adur,@addt,@delsta)", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@Name", Trim(TxtSrfix.Text))
                    CoCsCCmd.Parameters.AddWithValue("@adur", Current_UsrId)
                    CoCsCCmd.Parameters.AddWithValue("@addt", Now)
                    CoCsCCmd.Parameters.AddWithValue("@delsta", 1)
                ElseIf EdtFlag = True Then
                    CoCsCCmd = New SqlCommand("update finact_srfixmstr set(srfixname=@srfixName,edtusrid=@edur,edtdt=@eddt,delstatus=@delsta)", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@Name", Trim(TxtSrfix.Text))
                    CoCsCCmd.Parameters.AddWithValue("@edur", Current_UsrId)
                    CoCsCCmd.Parameters.AddWithValue("@eddt", Now)
                    CoCsCCmd.Parameters.AddWithValue("@delsta", 1)
                End If

                Try
                    If FrmShow_flag(0) = True Then
                        Surfix4Cmbx(0) = Trim(TxtSrfix.Text)
                    End If

                    CoCsCCmd.ExecuteNonQuery()
                    MsgBox("Current Record has been Saved Successfully.", MsgBoxStyle.Information)
                    ClrValue()
                    TxtSrfix.Focus()
                    ' BtnAddWithValue.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    'MsgBox("Violation of Primary key" + Chr(10) + "City Name already exist, you can not insert Duplicate record." + Chr(13) + "This Record has been terminated.", MsgBoxStyle.Critical, "City Name Alread Exist!")
                    TxtSrfix.SelectAll()
                    TxtSrfix.Focus()
                    Exit Try
                Finally
                    CoCsCCmd = Nothing
                End Try
               

            End If
        End If
    End Sub

    Private Sub BtnAddWithValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddWithValue.Click
        ClrValue()
        TxtSrfix.Focus()
        AddWithValueFlag = True
        EdtFlag = False
        If LstVewFnd.Visible = True Then
            LstVewFnd.Visible = False
            Me.TableLayoutPanel1.Visible = True
            Me.Height = 146
            Me.Width = 290
            Me.SplitContainer1.SplitterDistance = 70
            

        End If
        BtnFind.Text = "&Find"
        BtnSave.Text = "&Save"
        If TxtSrfix.BackColor <> Color.White Then
            TxtSrfix.BackColor = Color.White
        End If
        
    End Sub

    Private Sub CheckAcess_Btn_frm(ByVal BtnnAdd As Button, _
         ByVal BtnnFnd As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnAdd.Enabled = True
                'BtnnEdt.Enabled = True
                'BtnnDel.Enabled = True
                BtnnFnd.Enabled = True
            Case "DataEntryMstr"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(208, 104)
                'BtnnEdt.Visible = False
                'BtnnDel.Visible = False
                BtnnFnd.Visible = False
            Case "PayRoll"
                BtnnAdd.Enabled = True
                BtnnAdd.Location = New System.Drawing.Point(208, 104)
                'BtnnEdt.Visible = False
                'BtnnDel.Visible = False
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

        If TxtSrfix.BackColor <> Color.White Then
            TxtSrfix.BackColor = Color.White
        End If
       
    End Sub


    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        If BtnFind.Text = "&Find" Then
            Backcolor_chng()
            LstVewFnd.Clear()
            LstVewFnd.Columns.Add("Name ", LstVewFnd.Width, HorizontalAlignment.Left)
            LstVewFnd.Columns.Add("Id", LstVewFnd.Width \ 3, HorizontalAlignment.Left)
            Dim LstItem As ListViewItem
            Me.Height = 250
            Me.Width = 290
            LstVewFnd.Visible = True
            Me.LstVewFnd.Left = 10
            Me.LstVewFnd.Top = 2
            Me.LstVewFnd.Height = Me.SplitContainer1.Height - 50
            Me.SplitContainer1.SplitterDistance = 174
            Me.TableLayoutPanel1.Visible = False
            CoCsCCmd = New SqlCommand("Select * from finact_srfixmstr order by srfixname ", FinActConn)
            Try
                DtaRdr = CoCsCCmd.ExecuteReader
                Dim x As Integer
                x = 0
                While DtaRdr.Read()
                    LstItem = LstVewFnd.Items.Add(DtaRdr("SplrSurFix"), 1)
                    LstVewFnd.Items(x).SubItems.Add(DtaRdr("srfixid"))
                    x += 1
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
            If TxtSrfix.Text = "" Or EdtRecrdNo < 1 Then
                MsgBox("No record is present to Delete.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If EdtRecrdNo > 0 Then 'TypeOf Cntrl Is TextBox And Cntrl.Text <> "" Then
                Dim delmsgconfrm As String
                delmsgconfrm = MsgBox("Are you sure to Delete this record?", MsgBoxStyle.YesNo)
                If delmsgconfrm = vbYes Then
                    CoCsCCmd = New SqlCommand("Delete  from finact_srfixmstr where srfixid=@srfixid", FinActConn)
                    CoCsCCmd.Parameters.AddWithValue("@srfixid", EdtRecrdNo)
                ElseIf delmsgconfrm = vbNo Then
                    BtnFind.Focus()
                    Exit Sub
                End If

            End If
            Try

                CoCsCCmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Try
            Finally
                CoCsCCmd = Nothing
                MsgBox("Current Record has been Deleted Successfully.", MsgBoxStyle.Information, "Delete")
                ClrValue()
                EdtRecrdNo = 0
                BtnSave.Text = "&Save"
                BtnFind.Text = "&Find"
                TxtSrfix.Focus()
                BtnFind.Text = "&Find"
            End Try
        End If
    End Sub

    Private Sub LstVewFnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVewFnd.DoubleClick
        Try
            TxtSrfix.Text = LstVewFnd.SelectedItems(0).Text
            EdtRecrdNo = LstVewFnd.SelectedItems.Item(0).SubItems.Item(1).Text
            LstVewFnd.Visible = False
            Me.Height = 146
            Me.Width = 290
            Me.SplitContainer1.SplitterDistance = 70
            Me.TableLayoutPanel1.Visible = True
            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LstVewFnd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstVewFnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstVewFnd_DoubleClick(sender, e)
        End If

    End Sub

    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Label1.KeyDown, LstVewFnd.KeyDown, BtnClos.KeyDown, BtnFind.KeyDown, BtnSave.KeyDown, BtnAddWithValue.KeyDown, TxtSrfix.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TxtCty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSrfix.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSrfix_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSrfix.Leave
        Try
            If TxtSrfix.Text = "" Then
                TxtSrfix.BackColor = Color.LemonChiffon
                MsgBox("Blank field not allowed", MsgBoxStyle.Information, "Blank Field")
                TxtSrfix.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtsrfix_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSrfix.TextChanged
        If TxtSrfix.BackColor <> Color.White Then
            TxtSrfix.BackColor = Color.White
        End If
    End Sub

    Private Sub LstVewFnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVewFnd.SelectedIndexChanged

    End Sub
End Class