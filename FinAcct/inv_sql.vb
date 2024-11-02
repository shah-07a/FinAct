
Imports System.Data

Public Class inv_sql
    Public cnn As Data.SqlClient.SqlConnection
    'Public Conn As SqlClient.SqlConnection
    Public cmd As Data.SqlClient.SqlCommand
    Public adp As Data.SqlClient.SqlDataAdapter
    Public ds As Data.DataSet
    Dim MyDateTime As DateTime

    'from MdIVariable
    
    Public Sub New()
        '==Following Connection String for Attached file.
        '' cnn = New Data.SqlClient.SqlConnection("integrated security=SSPI;data source=.\SQLEXPRESS;persist security info=False;initial catalog=Finact07") 'connection string for Ms-Sql Express
        ' cnn = New Data.SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Finact07.MDF;Integrated Security=True;User Instance=True;")
        '==Following Connection String for Login Qifar@time1
        ''cnn = New Data.SqlClient.SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1029;Uid=Qifar@Time1;Pwd=mohd@786rafiqhcl;database=FinAct07") ' connection string for Ms-Sql Express
        '==Following Connection String for Login Qifar@Time2
        ''  cnn = New Data.SqlClient.SqlConnection("Server=qifar-2880-b-1\SQLEXPRESS,1030;Uid=Qifar@Time2;Pwd=qifar@time2user;database=FinAct07") ' connection string for Ms-Sql Express
        '==Following Connection String for Login in Time Rubber  Qifar@Time2
        '' cnn = New Data.SqlClient.SqlConnection("Server=Server\SQLEXPRESS,1085;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
        ''cnn = New Data.SqlClient.SqlConnection("Server=.\SQLEXPRESS;Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
        cnn = New Data.SqlClient.SqlConnection("Server=" & (SqlServerName) & ";Uid=Qifar@Time2;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
        'cnn = New Data.SqlClient.SqlConnection("Server=.\SQLEXPRESS;Uid=Qifar@Time1;Pwd=qifar@time2user;database=MsSql08_FinAct07") ' connection string for Ms-Sql Express
        '==Following Connection String for Login KBL Sales
        '--------------------------------------------------------------
        '' cnn = New Data.SqlClient.SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@SqlKBL;Pwd=qifar@time2user;database=MsSql08_FinAct_KblSales09") ' connection string for Ms-Sql Express

        '=============
        'VISTA COMPETIBLE CONNECTION
        '---------------------------
        'HOME
        ''cnn = New Data.SqlClient.SqlConnection("Server=Qifar_Info_786\SQLEXPRESS,1030;Uid=Qifar@Time1;Pwd=qifar@time2user;database='" & (Db_FinAct) & "'") ' connection string for Ms-Sql Express
        '---------
    End Sub
    Sub connect()
        Try
            If cnn.State <> ConnectionState.Open Then
                cnn.Open()
            End If
        Catch
            MsgBox("Can not connect to database")
        End Try
    End Sub

    Private Sub command(ByVal str As String, ByVal paran() As String, ByVal parav() As String)
        connect()
        cmd = New Data.SqlClient.SqlCommand(str, cnn)
        cmd.CommandType = CommandType.StoredProcedure
        Dim u As Integer
        For u = 0 To paran.Length - 1
            If (parav(u) = Nothing) Then
                parav(u) = ""
            End If
           
            If parav(u).EndsWith("$datee") Then
                MyDateTime = New DateTime()
                Dim s As String = parav(u).Replace("$datee", "").Trim
                MyDateTime = DateTime.ParseExact(s, "dd/MM/yyyy", Nothing)
                cmd.Parameters.Add(New Data.SqlClient.SqlParameter(paran(u), SqlDbType.SmallDateTime))
                cmd.Parameters(u).Value = MyDateTime
            Else
                cmd.Parameters.Add(New Data.SqlClient.SqlParameter(paran(u), SqlDbType.Text))
                cmd.Parameters(u).Value = parav(u)
            End If
        Next
    End Sub
    Public Function Exe_querry(ByVal str As String, ByVal paran() As String, ByVal parav() As String) As Boolean
        Try
            command(str, paran, parav)
            cmd.ExecuteNonQuery()
            cnn.Close()
            Return True
        Catch ex As Exception
            Try
                cnn.Close()
            Catch
            End Try
            MsgBox(ex.Message())
            primary_flag = True
            Return False
        End Try
    End Function
    Public Sub get_data(ByVal str As String, ByVal paran() As String, ByVal parav() As String, ByVal temp As String)
        Try
            command(str, paran, parav)
            adp = New Data.SqlClient.SqlDataAdapter(cmd)
            ds = New Data.DataSet()
            adp.Fill(ds, temp)
            cnn.Close()
        Catch ex As Exception
            Try
                cnn.Close()
            Catch
            End Try
            MsgBox(ex.Message())
        End Try
    End Sub

End Class


