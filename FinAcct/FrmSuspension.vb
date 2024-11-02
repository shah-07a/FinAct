Imports System.Data
Imports System.Data.SqlClient

Public Class FrmSuspension
    Dim Emp_Suspend_Cmd As SqlCommand
    Dim Emp_Suspend_rdr As SqlDataReader
    Dim Emp_Suspend_adaptr As SqlDataAdapter
    Dim ds As DataSet
    Dim Compny_Strtdt As Date
    Dim add_flag As Boolean
    Dim cnfrmmsg As String
    Dim Fnd_Empid As Integer
    Dim cnt_recrds As Integer
    Dim Fromdt As String
    Dim Todt As string



    Private Sub FrmSuspension_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        fetch_Strtdt()
        DtpkrDt.MinDate = Compny_Strtdt
        Me.Size = New System.Drawing.Point(541, 356)
        PnlSuspnd.Size = New System.Drawing.Point(515, 264)
        DtpkrDt.Text = Today
        DtpkrDt.Focus()
        Fetch_Empname()


    End Sub


    Private Sub fetch_Strtdt()
        Try
            Emp_Suspend_Cmd = New SqlCommand("Select costrtdt from Finactcogatemstr  ", FinActConn)
            Emp_Suspend_rdr = Emp_Suspend_Cmd.ExecuteReader
            Emp_Suspend_rdr.Read()
            If Emp_Suspend_rdr.HasRows = True Then
                Compny_Strtdt = Emp_Suspend_rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Suspend_rdr.Close()
            Emp_Suspend_Cmd = Nothing
        End Try
    End Sub


    Private Sub Fetch_Empname()
        Try
            Emp_Suspend_Cmd = New SqlCommand("Select empname,empid from  FinactEmpmstr where empcateg='Working'", FinActConn)
            Emp_Suspend_adaptr = New SqlDataAdapter(Emp_Suspend_Cmd)
            ds = New DataSet(Emp_Suspend_Cmd.CommandText)
            Emp_Suspend_adaptr.Fill(ds)
            CmbxEmp.DataSource = ds.Tables(0)
            Me.CmbxEmp.ValueMember = "empid"
            Me.CmbxEmp.DisplayMember = "empname"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Emp_Suspend_Cmd = Nothing
        End Try

    End Sub


    Private Sub BtnCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCls.Click

        cnfrmmsg = MsgBox("Are you sure to exit?", MsgBoxStyle.YesNo, "Close")
        If cnfrmmsg = vbYes Then
            Me.Close()

        End If
    End Sub

    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        Clrvalue()
        Me.Size = New System.Drawing.Point(541, 356)
        PnlSuspnd.Size = New System.Drawing.Point(515, 264)
        DtpkrDt.Enabled = True
        CmbxEmp.Enabled = True
        LstSuspnd.Visible = False
        BtnSave.Text = "&Save"
        BtnFnd.Text = "&Find"
        DtpkrDt.Focus()
    End Sub

    Private Sub Clrvalue()
        DtpkrDt.Text = Today
        If CmbxEmp.Items.Count > 0 Then
            CmbxEmp.SelectedIndex = 0
        End If
        DtpkrFrm.Text = Today
        DtpkrTo.Text = Today
        TxtResn.Text = ""
        LblEmpid.Text = ""

    End Sub

    Private Sub DtpkrDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrDt.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            CmbxEmp.Focus()

        End If
    End Sub

    Private Sub CmbxEmp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmp.GotFocus
        If CmbxEmp.Items.Count > 0 Then
            If CmbxEmp.Text = "" Then
                CmbxEmp.SelectedIndex = 0
            End If
            CmbxEmp.DroppedDown = True
        End If
    End Sub


    Private Sub CmbxEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEmp.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            LblEmpid.Text = CmbxEmp.SelectedValue
            Chek_recrd()
            If cnt_recrds = 0 Then
                DtpkrFrm.Focus()
            ElseIf cnt_recrds > 0 Then
                Recrd_Detail()
                MsgBox("'" & (CmbxEmp.Text) & "' has already been given Suspension from '" & (Fromdt) & "' to '" & (Todt) & "'", MsgBoxStyle.Exclamation, "Suspension")
                DtpkrDt.Focus()
            End If


        End If
    End Sub


    Private Sub DtpkrFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrFrm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            DtpkrTo.Focus()

        End If
    End Sub


    Private Sub DtpkrTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpkrTo.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            TxtResn.Focus()

        End If
    End Sub

    Private Sub TxtRsn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtResn.KeyDown
        If e.KeyCode = Keys.Tab Then
            BtnSave.Focus()

        End If
    End Sub



    Private Sub CmbxEmp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmp.Leave
        LblEmpid.Text = CmbxEmp.SelectedValue
    End Sub


    Private Sub Suspend_Saverec()

        Try
            If add_flag = True Then
                Emp_Suspend_Cmd = New SqlCommand("Finact_Insert_EmpSuspend", FinActConn)
                Emp_Suspend_Cmd.CommandType = CommandType.StoredProcedure
                Emp_Suspend_Cmd.Parameters.AddWithValue("@SuspDt", DtpkrDt.Value.Date)
                Emp_Suspend_Cmd.Parameters.AddWithValue("@SuspEmpid", LblEmpid.Text)
                Emp_Suspend_Cmd.Parameters.AddWithValue("@Suspadusrid", Current_UsrId)
                Emp_Suspend_Cmd.Parameters.AddWithValue("@Suspaddt", Now)
                Emp_Suspend_Cmd.Parameters.AddWithValue("@Suspdelstatus", 0)
            ElseIf add_flag = False Then
                Emp_Suspend_Cmd = New SqlCommand("Finact_Edit_EmpSuspend", FinActConn)
                Emp_Suspend_Cmd.CommandType = CommandType.StoredProcedure
                Emp_Suspend_Cmd.Parameters.AddWithValue("@SuspEmpid", LblEmpid.Text)
                Emp_Suspend_Cmd.Parameters.AddWithValue("@Suspedtusrid", Current_UsrId)
                Emp_Suspend_Cmd.Parameters.AddWithValue("@Suspedtdt", Now)

            End If
            Emp_Suspend_Cmd.Parameters.AddWithValue("@SuspFrmdt", DtpkrFrm.Value.Date)
            Emp_Suspend_Cmd.Parameters.AddWithValue("@SuspTodt", DtpkrTo.Value.Date)
            Emp_Suspend_Cmd.Parameters.AddWithValue("@SuspRsn", TxtResn.Text)

            Emp_Suspend_Cmd.ExecuteNonQuery()
            If add_flag = True Then
                MsgBox("Record has been Saved Successfully.", MsgBoxStyle.Information, "Save")
            ElseIf add_flag = False Then
                MsgBox("Record has been Updated Successfully.", MsgBoxStyle.Information, "Edit")

            End If

            Clrvalue()

            DtpkrDt.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Suspend_Cmd = Nothing
        End Try

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            add_flag = True
            Suspend_Saverec()

        ElseIf BtnSave.Text = "&Edit" Then
            add_flag = False
            Suspend_Saverec()
            BtnSave.Text = "&Save"
            BtnFnd.Text = "&Find"

        End If
    End Sub

    Private Sub Fnd_Recrds()
        Dim Lstvew As ListViewItem
        LstSuspnd.Items.Clear()
        Try
            Emp_Suspend_Cmd = New SqlCommand("Select SuspDt,SuspEmpid,SuspFrmDt,SuspToDt,SuspRsn,FinactEmpmstr.empname from FinactEmp_Suspension inner join FinactEmpmstr on FinactEmp_Suspension.SuspEmpid=FinactEmpmstr.empid where Suspdelstatus=0 ", FinActConn)
            Emp_Suspend_rdr = Emp_Suspend_Cmd.ExecuteReader
            While Emp_Suspend_rdr.Read()
                If Emp_Suspend_rdr.HasRows = True Then
                    Lstvew = LstSuspnd.Items.Add(Format(Emp_Suspend_rdr(0), "dd/MM/yyyy"))
                    Lstvew.SubItems.Add(Emp_Suspend_rdr(1))
                    Fnd_Empid = Emp_Suspend_rdr(1)
                    Lstvew.SubItems.Add(Format(Emp_Suspend_rdr(2), "dd/MM/yyyy"))
                    Lstvew.SubItems.Add(Format(Emp_Suspend_rdr(3), "dd/MM/yyyy"))
                    Lstvew.SubItems.Add(Emp_Suspend_rdr(4))
                    Lstvew.SubItems.Add(Emp_Suspend_rdr(5))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Emp_Suspend_rdr.HasRows = False Then
                MsgBox("System has found no record.", MsgBoxStyle.Information, "Find")
                DtpkrDt.Focus()
            Else
                BtnSave.Text = "&Edit"
                BtnFnd.Text = "&Delete"
                Me.Size = New System.Drawing.Point(588, 585)
                PnlSuspnd.Size = New System.Drawing.Point(559, 264)
                LstSuspnd.Visible = True

            End If
            Emp_Suspend_rdr.Close()
            Emp_Suspend_Cmd = Nothing
        End Try


    End Sub


    Private Sub BtnFnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFnd.Click
        If BtnFnd.Text = "&Find" Then
          
            Fnd_Recrds()
        ElseIf BtnFnd.Text = "&Delete" Then
            ''Me.Size = New System.Drawing.Point(541, 356)
            ''PnlSuspnd.Size = New System.Drawing.Point(515, 264)
            ''LstSuspnd.Visible = False
            cnfrmmsg = MsgBox("Are you sure to delete record?", MsgBoxStyle.YesNo, "Delete")
            If cnfrmmsg = vbYes Then
                Try
                    Emp_Suspend_Cmd = New SqlCommand("Finact_Delete_EmpSuspend", FinActConn)
                    Emp_Suspend_Cmd.CommandType = CommandType.StoredProcedure
                    Emp_Suspend_Cmd.Parameters.AddWithValue("@SuspEmpid", Fnd_Empid)
                    Emp_Suspend_Cmd.Parameters.AddWithValue("@Suspdelusrid", Current_UsrId)
                    Emp_Suspend_Cmd.Parameters.AddWithValue("@Suspdeldt", Now)
                    Emp_Suspend_Cmd.Parameters.AddWithValue("@Suspdelstatus", 1)
                    Emp_Suspend_Cmd.ExecuteNonQuery()
                    MsgBox("Record has been Deleted Successfully.", MsgBoxStyle.Information, "Delete")
                    Clrvalue()
                    BtnSave.Text = "&Save"
                    BtnFnd.Text = "&Find"
                    DtpkrDt.Enabled = True
                    CmbxEmp.Enabled = True
                    DtpkrDt.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Emp_Suspend_Cmd = Nothing
                End Try

            End If

        End If
    End Sub

    Private Sub LstSuspnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstSuspnd.DoubleClick

        Dim indx As Integer
        indx = LstSuspnd.SelectedItems(0).Index
        DtpkrDt.Text = ConvertDate(LstSuspnd.Items(indx).SubItems(0).Text)
        LblEmpid.Text = LstSuspnd.Items(indx).SubItems(1).Text
        DtpkrFrm.Text = ConvertDate(LstSuspnd.Items(indx).SubItems(2).Text)
        DtpkrTo.Text = ConvertDate(LstSuspnd.Items(indx).SubItems(3).Text)
        TxtResn.Text = LstSuspnd.Items(indx).SubItems(4).Text
        CmbxEmp.Text = LstSuspnd.Items(indx).SubItems(5).Text
        Me.Size = New System.Drawing.Point(541, 356)
        PnlSuspnd.Size = New System.Drawing.Point(515, 264)
        DtpkrDt.Enabled = False
        CmbxEmp.Enabled = False
        LstSuspnd.Visible = False
        DtpkrFrm.Focus()
    End Sub


    Private Sub Chek_recrd()
        Try
            Emp_Suspend_Cmd = New SqlCommand("Select count(SuspId) from FinactEmp_Suspension where SuspEmpid='" & (LblEmpid.Text) & "'  ", FinActConn)
            Emp_Suspend_rdr = Emp_Suspend_Cmd.ExecuteReader
            Emp_Suspend_rdr.Read()
            If Emp_Suspend_rdr.HasRows = True Then
                cnt_recrds = Emp_Suspend_rdr(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Suspend_rdr.Close()
            Emp_Suspend_Cmd = Nothing
        End Try
    End Sub

    Private Sub Recrd_Detail()

        Try
            Emp_Suspend_Cmd = New SqlCommand("Select SuspFrmDt,SuspToDt from FinactEmp_Suspension where Suspdelstatus=0 and SuspEmpid='" & (LblEmpid.Text) & "'", FinActConn)
            Emp_Suspend_rdr = Emp_Suspend_Cmd.ExecuteReader
            While Emp_Suspend_rdr.Read()
                If Emp_Suspend_rdr.HasRows = True Then
                    Fromdt = Format(Emp_Suspend_rdr(0), "dd/MM/yyyy")

                    Todt = Format(Emp_Suspend_rdr(1), "dd/MM/yyyy")

                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Emp_Suspend_rdr.Close()
            Emp_Suspend_Cmd = Nothing
        End Try

    End Sub

    Public Shared Function ConvertDate(ByVal strtdate As String) As Date
        Return DateTime.ParseExact(strtdate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
    End Function

   
    Private Sub CmbxEmp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxEmp.SelectedIndexChanged

    End Sub

    Private Sub TxtResn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtResn.KeyDown

    End Sub

    Private Sub TxtResn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtResn.TextChanged

    End Sub

    Private Sub DtpkrTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpkrTo.ValueChanged

    End Sub
End Class