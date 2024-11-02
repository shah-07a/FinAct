Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrRptEsiForm1
    Dim EsiF1_Cmd As SqlCommand
    Dim EsiF1_Adptr As SqlDataAdapter
    Dim EsiF1_Rdr As SqlDataReader
    Dim EsiF1_Cmd2 As SqlCommand
    Dim EsiF1_Rdr2 As SqlDataReader
    Dim EsiF1_Cmd1 As SqlCommand
    Dim EsiF1_Rdr1 As SqlDataReader
    Dim EsiF1_Ds As DataSet
    Dim EmpCode As String = ""
    Dim CrRptEsiFrm1 As New CrRptFrm1

    Private Sub BtnEsi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEsi.Click
        Try
            Me.Height = 700
            temp_tblEsiinfoF1_Del()
            CreatTemp_EsiInfoF1_tbl()
            Fetch_InfoCrRptEsiNo()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fetch_InfoCrRptEsiNo()
        Try
            EsiF1_Cmd = New SqlCommand("Select * from temp_esiinfof1", FinActConn)
            Dim dsEsino As New DataSet(EsiF1_Cmd.CommandText)
            EsiF1_Adptr = New SqlDataAdapter(EsiF1_Cmd)
            EsiF1_Adptr.Fill(dsEsino)
            CrRptEsiFrm1.SetDataSource(dsEsino.Tables(0))
            CrVewEsiF1.ReportSource = CrRptEsiFrm1
            dsEsino.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF1_Cmd = Nothing

            EsiF1_Adptr.Dispose()
           

        End Try
    End Sub
    Private Sub CreatTemp_EsiInfoF1_tbl()
        Dim esirecno As Integer = 1
        Dim esiempstatus As String = ""
        Try
            EsiF1_Cmd = New SqlCommand("Temp_EmpEsiInfof1_Select", FinActConn)
            EsiF1_Cmd.CommandType = CommandType.StoredProcedure
            EsiF1_Cmd.Parameters.AddWithValue("@Empcode", Trim(EmpCode))
            EsiF1_Rdr = EsiF1_Cmd.ExecuteReader
            While EsiF1_Rdr.Read
                If EsiF1_Rdr.HasRows = True Then
                    EsiF1_Cmd1 = New SqlCommand("Temp_EsiInfoF1_Insert", FinActConn1)
                    EsiF1_Cmd1.CommandType = CommandType.StoredProcedure
                    EsiF1_Cmd1.Parameters.AddWithValue("@eid", EsiF1_Rdr("empid"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@ename", EsiF1_Rdr("empname"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@edob", EsiF1_Rdr("empdobdt"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@efname", EsiF1_Rdr("empfather"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@esex", EsiF1_Rdr("empsex"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@eadrs", EsiF1_Rdr("empadrs1"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@eadrs1", EsiF1_Rdr("empadrs2") & "'" & EsiF1_Rdr("empadrs3"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@eadrs2", EsiF1_Rdr("cscctyname") & "," & EsiF1_Rdr("cscstatename") & "," & EsiF1_Rdr("csccontry"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@emarital", EsiF1_Rdr("empmarital"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@ejndt", EsiF1_Rdr("empjndt"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@estatus", EsiF1_Rdr("empcateg"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@einsno", EsiF1_Rdr("empesicno"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@edespn", EsiF1_Rdr("empdispensry"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@edpt", EsiF1_Rdr("deptname"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@enomi", EsiF1_Rdr("empnominame"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@enomifh", EsiF1_Rdr("empnomifhname"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@enomirel", EsiF1_Rdr("empnomireltn"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@enomiadrs", EsiF1_Rdr("empnomiadrs"))
                    EsiF1_Cmd1.Parameters.AddWithValue("@enomiadrs1", EsiF1_Rdr("empnomiadrs1"))

                    Try
                        EsiF1_Cmd2 = New SqlCommand("Temp_EmpEsiInfoF1_part3_Select", FinActConn2)
                        EsiF1_Cmd2.CommandType = CommandType.StoredProcedure
                        EsiF1_Cmd2.Parameters.AddWithValue("@Empcode", Trim(EmpCode))
                        EsiF1_Rdr1 = EsiF1_Cmd2.ExecuteReader
                        While EsiF1_Rdr1.Read
                            EsiF1_Cmd1.Parameters.AddWithValue("@ewrk", EsiF1_Rdr1("deptname"))
                        End While
                    Catch ex1 As Exception
                        MsgBox(ex1.Message)
                    Finally
                        EsiF1_Cmd2.Dispose()
                        EsiF1_Rdr1.Close()
                    End Try
                    Try
                        EsiF1_Cmd2 = New SqlCommand("Temp_EmpEsiInfoF1_part2_Select", FinActConn2)
                        EsiF1_Cmd2.CommandType = CommandType.StoredProcedure
                        EsiF1_Cmd2.Parameters.AddWithValue("@Empcode", Trim(EmpCode))
                        EsiF1_Rdr1 = EsiF1_Cmd2.ExecuteReader
                        While EsiF1_Rdr1.Read
                            EsiF1_Cmd1.Parameters.AddWithValue("@enomiadrs2", EsiF1_Rdr1("city") & "," & EsiF1_Rdr1("state") & "," & EsiF1_Rdr1("country"))
                        End While
                    Catch ex1 As Exception
                        MsgBox(ex1.Message)
                    Finally
                        EsiF1_Cmd2.Dispose()
                        EsiF1_Rdr1.Close()
                    End Try

                    EsiF1_Cmd1.ExecuteNonQuery()
                End If
            End While
            EsiF1_Cmd1.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF1_Cmd.Dispose()
            EsiF1_Rdr.Close()

            Try
                EsiF1_Cmd2 = New SqlCommand("Temp_EmpEsiInfoF1_part3", FinActConn2)
                EsiF1_Cmd2.CommandType = CommandType.StoredProcedure
                EsiF1_Cmd2.Parameters.AddWithValue("@Empcode", Trim(EmpCode))
                EsiF1_Rdr1 = EsiF1_Cmd2.ExecuteReader
                Dim EsiSno As Integer = 1
                While EsiF1_Rdr1.Read
                    If EsiF1_Rdr1.HasRows = True Then
                        EsiF1_Cmd1 = New SqlCommand("Temp_EmpEsiInfoF1_part2_Insert", FinActConn1)
                        EsiF1_Cmd1.CommandType = CommandType.StoredProcedure
                        EsiF1_Cmd1.Parameters.AddWithValue("@EsiSno", EsiSno)
                        EsiF1_Cmd1.Parameters.AddWithValue("@EsiMembr", EsiF1_Rdr1("empfmlymembr"))
                        EsiF1_Cmd1.Parameters.AddWithValue("@EsiMembrDob", EsiF1_Rdr1("empfmlymembrdob"))
                        EsiF1_Cmd1.Parameters.AddWithValue("@EsiRelatn", EsiF1_Rdr1("empfmlyrelatn"))
                        EsiF1_Cmd1.Parameters.AddWithValue("@EsiMembrStatus", ("Yes"))
                        EsiF1_Cmd1.ExecuteNonQuery()
                        EsiSno += 1
                    End If
                End While
                EsiF1_Cmd1.Dispose()
            Catch ex1 As Exception
                MsgBox(ex1.Message)
            Finally
                EsiF1_Cmd2.Dispose()
                EsiF1_Rdr1.Close()
            End Try


        End Try

    End Sub

    Private Sub temp_tblEsiinfoF1_Del()
        Try
            EsiF1_Cmd = New SqlCommand("delete from Temp_EsiInfoF1 ", FinActConn)
            EsiF1_Cmd.ExecuteNonQuery()
            EsiF1_Cmd.Dispose()
            EsiF1_Cmd = New SqlCommand("delete from Temp_EsiInfoF1_part2 ", FinActConn)
            EsiF1_Cmd.ExecuteNonQuery()
            EsiF1_Cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EsiF1_Cmd.Dispose()
        End Try
    End Sub


    Private Sub FrmCrRptEsiForm1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Width = 1025
            Me.Height = 85

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxEmpname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmpname.GotFocus
        Try
            EsiF1_Cmd = New SqlCommand("Select distinct(empid),empname from Finactempmstr" _
            & " inner join finactemppfesi on finactempmstr.empid=finactemppfesi.emppfconcrnid and finactemppfesi.empesiapli=1 order by empname", FinActConn)
            EsiF1_Adptr = New SqlDataAdapter(EsiF1_Cmd)
            EsiF1_Ds = New DataSet
            EsiF1_Adptr.Fill(EsiF1_Ds, "TempTbl")
            CmbxEmpname.DataSource = EsiF1_Ds.Tables("TempTbl")
            CmbxEmpname.DisplayMember = "empname"
            CmbxEmpname.ValueMember = "empid"
            EsiF1_Adptr.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub ALLCONTROLS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxEmpname.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If CmbxEmpname.SelectedIndex = -1 Then
                    CmbxEmpname.Focus()
                    BtnEsi.Enabled = False
                Else
                    BtnEsi.Enabled = True
                    BtnEsi.Focus()

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxEmpname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxEmpname.Leave
        If CmbxEmpname.SelectedIndex <> -1 Then
            EmpCode = CStr(CmbxEmpname.SelectedValue)
            BtnEsi.Enabled = True
            BtnEsi.Focus()
        Else
            MsgBox("Invalid action!select an item to proceed", MsgBoxStyle.Critical, Me.Text)
            CmbxEmpname.Focus()
            BtnEsi.Enabled = False

        End If
    End Sub

End Class