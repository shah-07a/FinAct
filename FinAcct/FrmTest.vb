Imports System.Data.SqlClient
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Management
Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO
Imports System.Deployment
Imports System.Collections.Generic
Imports NetFwTypeLib

    Public Class FrmTest
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader


        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            ' Dim strDate1 As String = Trim(TextBox1.Text)
            ' Dim d As Date = New Date(2000 + strDate1.Substring(0, 1), strDate1.Substring(1, 2), strDate1.Substring(3, 2))
            Get_systemInfo()
            DateTimePicker1.Value = ConvertDate(TextBox1.Text)
        End Sub

        Public Shared Function ConvertDate(ByVal strdate As String) As Date
            'If strdate.Length = 9 Then strdate = "0" + strdate
            'If strdate.Length <> 6 Then Throw New FormatException("Invalid date format")
            'Return DateTime.Parse(strdate).Date 'System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
            Return DateTime.ParseExact(strdate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
        End Function

        Private Sub FrmTest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cmd = New SqlCommand("select empjndt from finactempmstr", FinActConn)
            rdr = cmd.ExecuteReader
            rdr.Read()
            TextBox1.Text = "" 'Format(rdr(0), "dd/MM/yyyy")
            cmd.Dispose()
            rdr.Close()



        End Sub
        Private Sub Get_systemInfo()
            '
            ' Requires setting a reference to System.Management.dll
            '
            'Try
            Dim strMACAddress As String = ""
            '
            ' Create the query, in SQL syntax, to retrieve the properties from
            ' the active Network Adapter.
            '
            Dim strQuery As String
            strQuery = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True"

            '
            ' Create a ManagementObjectSearcher object passing in the query to run.
            '
            Dim query As ManagementObjectSearcher = New ManagementObjectSearcher(strQuery)

            '
            ' Create a ManagementObjectCollection assigning it the results of the query.
            '
            Dim queryCollection As ManagementObjectCollection = query.Get()

            '
            ' Loop through the results extracting the MAC Address.
            '
            Dim mo As ManagementObject

            For Each mo In queryCollection
                strMACAddress = mo("MacAddress").ToString().Replace(":", "")
                MsgBox(strMACAddress)
                Exit For
            Next



            'Catch ex As Exception
            'Return ""
            ' End Try


            'Similarly, you can get a wealth of information about your hard drives using WMI by changing the query to retrieve information from the Win32_PhysicalMedia provider. 





            ''Dim strSN As String = ""
            ''Dim strQuery As String = "SELECT * FROM Win32_PhysicalMedia"
            ''Dim query As ManagementObjectSearcher = New ManagementObjectSearcher(strQuery)
            ''Dim queryCollection As ManagementObjectCollection = query.Get()
            ''Dim mo As ManagementObject
            ''mo = New ManagementObject
            ''For Each mo In queryCollection
            ''    MsgBox(mo("SerialNumber").ToString())
            ''Next


            Dim theManagementScope As New ManagementScope("\\" & Environment.MachineName & "\root\CIMv2")
            Dim theQuery As New ObjectQuery("SELECT SerialNumber FROM Win32_PhysicalMedia")
            Dim theSearcher As New ManagementObjectSearcher(theManagementScope, theQuery)
            Dim theResults As ManagementObjectCollection = theSearcher.Get()

            For Each currentResult As ManagementObject In theResults
                '  MessageBox.Show(currentResult("SerialNumber").ToString())
            Next



            'CPU
            'Dim theManagementScope As New ManagementScope("\\" & Environment.MachineName & "\root\CIMv2")
            'Dim theQuery As New ObjectQuery("SELECT ProcessorID FROM Win32_Processor")
            'Dim theSearcher As New ManagementObjectSearcher(theManagementScope, theQuery)
            'Dim theResults As ManagementObjectCollection = theSearcher.Get()

            'For Each currentResult As ManagementObject In theResults
            '    MessageBox.Show(currentResult("ProcessorID").ToString())
            'Next


        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

            ' showMain()

            If Val(TextBox2.Text) > 0 Then
                Label1.Text = RupeesToWord(Val(TextBox2.Text))
            Else
                MessageBox.Show("Please enter any amount")
            End If


        End Sub

        Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

        End Sub

        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
            Try

                My.Computer.FileSystem.WriteAllText("E:\rmTest.txt", "Rafiq,Mohammed@,shah#786,$Time%India", True)
            Catch ex As Exception

            End Try
        End Sub

        Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
            Try
                Dim filename As String = "E:\rmTest.txt"
                Dim fields As String()
                Dim delimiter As String = ","
                Dim i As Integer = 0
                Using parser As New TextFieldParser(filename)
                    parser.SetDelimiters(delimiter)
                    While Not parser.EndOfData
                        ' Read in the fields for the current line
                        fields = parser.ReadFields()
                        ' Add code here to use data in fields variable.
                        Me.TextBox3.Text = fields(0).ToString
                        Me.TextBox4.Text = fields(1).ToString
                        Me.TextBox5.Text = fields(2).ToString
                        Me.TextBox6.Text = fields(3).ToString
                        Me.TextBox7.Text = fields(4).ToString
                        Me.TextBox8.Text = fields(5).ToString


                    End While
                End Using

            Catch ex As Exception

            End Try
        End Sub

        Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
            Try
                calcSum(1, 3, 4, 5)
            Catch ex As Exception

            End Try
        End Sub
        Public Function calcSum(ByVal ParamArray args() As Double) As Double
            calcSum = 0
            If args.Length <= 0 Then Exit Function
            For i As Integer = 0 To UBound(args, 1)
                calcSum += args(i)
            Next i
        End Function



        Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
            Try
                Dim xxStr As String = "Create  procedure [dbo].[test9]" _
                & " as declare @deptname varchar(170) declare @desiname varchar(170) declare @empname varchar(170)" _
                & " Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname" _
                & " from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid" _
                & " Select FinactEmpmstr.empid,FinactEmpmstr.empname,finactDept.deptname" _
                & " from FinactEmpmstr inner join finactDept on FinactEmpmstr.empdeptid=finactDept.deptid"
                cmd = New SqlCommand(xxStr, FinActConn)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try


        End Sub

        Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
            Try
                Dim xF As String = Mid(Me.TextBox3.Text.Trim, 1, 1)
                Dim xI As Integer = 0
                For Each xCh As Char In Me.TextBox3.Text.Trim
                    xI += 1
                    If xCh = " " Then
                        xF += Mid(Me.TextBox3.Text.Trim, xI + 1, 1)
                    End If
                Next
                Me.TextBox4.Text = xF.ToUpper
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
            Try
            '            Dim fw As moah.winxpspwfirewall = New moah.winxpspwfirewall
            '            Dim fw As Moah.WinXPSP2FireWall = New Moah.WinXPSP2FireWall()
            'fw.Initialize();

            'string strApplication = System.Environment.CurrentDirectory + 
            '                        "\\WindowsFirewall.exe";
            'fw.AddApplication(strApplication, "FireWallTest");
            'fw.RemoveApplication(strApplication);

            'fw.AddPort(4321, NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP, 
            '           "FireWallPortTest");
            'fw.RemovePort(4321, NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);

            Catch ex As Exception

            End Try
        End Sub
    End Class
