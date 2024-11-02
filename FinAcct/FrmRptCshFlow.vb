Imports System.Data.SqlClient
Public Class FrmRptCshFlow
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim rdr As SqlDataReader
    Dim rdr1 As SqlDataReader
    Dim cmd2 As SqlCommand
    Dim rdr2 As SqlDataReader

    Private Sub FrmRptCshFlow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cmd = New SqlCommand("Delete from FINACT_TEMP_cbook", FinActConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            ''FrmMainMdi.MenuItem78.Enabled = True

        End Try
    End Sub
    Private Sub FrmRptCshFlow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 10
        FillTempTable_CshFlow()
        ''FrmMainMdi.MenuItem78.Enabled = False

    End Sub
    Private Sub FillTempTable_CshFlow()
        Dim DrCrType As String = ""
        Dim Bokidx As Integer = 0
        Dim Bookname As String = ""
        Dim BokTranMode As String

        'Opening Balance
        cmd = New SqlCommand("SELECT SPLRID,Splrname,SPLROPNBAL,SPLRBALTYPE  FROM FINACTSPLRMSTR WHERE FINACTSPLRMSTR.SPLROPNBAL>0 and finactsplrmstr.splrdelstatus=1 and finactsplrmstr.splrtype ='" & ("Cash Book") & "' ", FinActConn)
        Try
            rdr = cmd.ExecuteReader
            While rdr.Read
                If rdr.HasRows = True Then
                    DrCrType = Trim(rdr("splrbaltype"))
                    cmd1 = New SqlCommand("INSERT INTO FINACT_TEMP_cbook (COLcustid,COLName,COLdetails,COLdr,colcr)valueS(@custid,@name,@details,@dr,@cr) ", FinActConn1)
                    If DrCrType = "Debit" Then

                        cmd1.Parameters.AddWithValue("@custid", rdr("splrid"))
                        cmd1.Parameters.AddWithValue("@name", rdr("splrname"))
                        cmd1.Parameters.AddWithValue("@details", "Opening Balance")
                        cmd1.Parameters.AddWithValue("@dr", rdr("splropnbal"))
                        cmd1.Parameters.AddWithValue("@cr", 0)

                    ElseIf DrCrType = "Credit" Then
                        cmd1.Parameters.AddWithValue("@custid", rdr("splrid"))
                        cmd1.Parameters.AddWithValue("@name", rdr("splrname"))
                        cmd1.Parameters.AddWithValue("@details", "Opening Balance")
                        cmd1.Parameters.AddWithValue("@dr", 0)
                        cmd1.Parameters.AddWithValue("@cr", rdr("splropnbal"))
                    End If
                    cmd1.ExecuteNonQuery()
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            cmd1 = Nothing
            rdr.Close()
        End Try


        'Cash and Bank Enteries
        cmd = New SqlCommand("SELECT cbtrandt,cbtrancustid,cbtranbokname,cbtranamtdrcr,cbtrantype,cbtranmode,cbtrannratn,splrname FROM FINACTcshbnk inner join finactsplrmstr on cbtrancustid=splrid  WHERE cbtranmode in ('Csh','CshCsh','CshBnk','BnkCsh')  and cbtranamtdrcr>0 and cbtrandelstatus=1", FinActConn)
        rdr = cmd.ExecuteReader
        Try
            While rdr.Read
                If rdr.HasRows = True Then
                    DrCrType = Trim(rdr("cbtrantype"))
                    BokTranMode = Trim(rdr("cbtranmode"))
                    Bokidx = Trim(rdr("cbtranbokname"))
                    If DrCrType = "Debit" Then
                        cmd1 = New SqlCommand("INSERT INTO FINACT_TEMP_cbook(coltdate,COLcustid,COLname,COLdetails,COLdr,colcr)valueS(@tdate,@custid,@name,@details,@dr,@cr) ", FinActConn1)
                        cmd1.Parameters.AddWithValue("@tdate", rdr("cbtrandt"))
                        cmd1.Parameters.AddWithValue("@custid", rdr("cbtrancustid"))
                        cmd1.Parameters.AddWithValue("@name", rdr("splrname"))
                        cmd1.Parameters.AddWithValue("@details", rdr("cbtrannratn"))
                        cmd1.Parameters.AddWithValue("@dr", 0)
                        cmd1.Parameters.AddWithValue("@cr", rdr("cbtranamtdrcr"))
                        cmd1.ExecuteNonQuery()
                    ElseIf DrCrType = "Credit" Then
                        'insert for Bank /Cash Book
                        cmd1 = New SqlCommand("INSERT INTO FINACT_TEMP_cbook(coltdate,COLcustid,COLname,COLdetails,COLdr,colcr)valueS(@tdate,@custid,@name,@details,@dr,@cr) ", FinActConn1)
                        cmd1.Parameters.AddWithValue("@tdate", rdr("cbtrandt"))
                        cmd1.Parameters.AddWithValue("@custid", rdr("cbtrancustid"))
                        cmd1.Parameters.AddWithValue("@name", rdr("splrname"))
                        cmd1.Parameters.AddWithValue("@details", rdr("cbtrannratn"))
                        cmd1.Parameters.AddWithValue("@dr", rdr("cbtranamtdrcr"))
                        cmd1.Parameters.AddWithValue("@cr", 0)
                        cmd1.ExecuteNonQuery()

                        ''XXX-CshBnk means we are going to Credit amount to cash book and  Debit to BankBook
                    ElseIf DrCrType = "Contra" And BokTranMode = "CshBnk" Then
                        'insert Cash Book Contra
                        cmd1 = New SqlCommand("INSERT INTO FINACT_TEMP_cbook(coltdate,COLcustid,COLname,COLdetails,COLdr,colcr)valueS(@tdate,@custid,@name,@details,@dr,@cr) ", FinActConn1)
                        cmd1.Parameters.AddWithValue("@tdate", rdr("cbtrandt"))
                        cmd1.Parameters.AddWithValue("@custid", Bokidx)
                        cmd2 = New SqlCommand("SELECT splrname  FROM  finactsplrmstr   WHERE splrid='" & (Bokidx) & "' and splrdelstatus=1", FinActConn2)
                        rdr2 = cmd2.ExecuteReader
                        rdr2.Read()
                        If rdr2.HasRows = True Then
                            Bookname = Trim(rdr2(0))
                        End If
                        rdr2.Close()
                        cmd2 = Nothing
                        cmd1.Parameters.AddWithValue("@name", Bookname)
                        cmd1.Parameters.AddWithValue("@details", rdr("cbtrannratn"))
                        cmd1.Parameters.AddWithValue("@dr", rdr("cbtranamtdrcr"))
                        cmd1.Parameters.AddWithValue("@cr", 0)
                        cmd1.ExecuteNonQuery()

                        '' XXX-CshBnk means we are going to Credit amount to Bank Book and  Debit to Cash Book
                    ElseIf DrCrType = "Contra" And BokTranMode = "BnkCsh" Then
                        cmd1 = New SqlCommand("INSERT INTO FINACT_TEMP_cbook(coltdate,COLcustid,COLname,COLdetails,COLdr,colcr)valueS(@tdate,@custid,@name,@details,@dr,@cr) ", FinActConn1)
                        cmd1.Parameters.AddWithValue("@tdate", rdr("cbtrandt"))
                        cmd1.Parameters.AddWithValue("@custid", rdr("cbtrancustid"))
                        cmd1.Parameters.AddWithValue("@name", rdr("splrname"))
                        cmd1.Parameters.AddWithValue("@details", rdr("cbtrannratn"))
                        cmd1.Parameters.AddWithValue("@dr", 0)
                        cmd1.Parameters.AddWithValue("@cr", rdr("cbtranamtdrcr"))
                        cmd1.ExecuteNonQuery()
                        ''XXX-CshCsh means we are going to Credit amount to Cash Book and  Debit to Cash Book
                    ElseIf DrCrType = "Contra" And BokTranMode = "CshCsh" Then
                        cmd1 = New SqlCommand("INSERT INTO FINACT_TEMP_cbook(coltdate,COLcustid,COLname,COLdetails,COLdr,colcr)valueS(@tdate,@custid,@name,@details,@dr,@cr) ", FinActConn1)
                        cmd1.Parameters.AddWithValue("@tdate", rdr("cbtrandt"))
                        cmd1.Parameters.AddWithValue("@custid", Bokidx)
                        cmd2 = New SqlCommand("SELECT splrname  FROM  finactsplrmstr   WHERE splrid='" & (Bokidx) & "' and splrdelstatus=1", FinActConn2)
                        rdr2 = cmd2.ExecuteReader
                        rdr2.Read()
                        If rdr2.HasRows = True Then
                            Bookname = Trim(rdr2(0))
                        End If
                        rdr2.Close()
                        cmd2 = Nothing
                        cmd1.Parameters.AddWithValue("@name", Bookname)
                        cmd1.Parameters.AddWithValue("@details", rdr("cbtrannratn"))
                        cmd1.Parameters.AddWithValue("@dr", rdr("cbtranamtdrcr"))
                        cmd1.Parameters.AddWithValue("@cr", 0)
                        cmd1.ExecuteNonQuery()
                        cmd1 = New SqlCommand("INSERT INTO FINACT_TEMP_cbook(coltdate,COLcustid,COLname,COLdetails,COLdr,colcr)valueS(@tdate,@custid,@name,@details,@dr,@cr) ", FinActConn1)
                        cmd1.Parameters.AddWithValue("@tdate", rdr("cbtrandt"))
                        cmd1.Parameters.AddWithValue("@custid", Bokidx)
                        cmd2 = New SqlCommand("SELECT splrname  FROM  finactsplrmstr   WHERE splrid='" & (Bokidx) & "' and splrdelstatus=1", FinActConn2)
                        rdr2 = cmd2.ExecuteReader
                        rdr2.Read()
                        If rdr2.HasRows = True Then
                            Bookname = Trim(rdr2(0))
                        End If
                        rdr2.Close()
                        cmd2 = Nothing
                        cmd1.Parameters.AddWithValue("@name", Bookname)
                        cmd1.Parameters.AddWithValue("@details", rdr("cbtrannratn"))
                        cmd1.Parameters.AddWithValue("@dr", 0)
                        cmd1.Parameters.AddWithValue("@cr", rdr("cbtranamtdrcr"))
                        cmd1.ExecuteNonQuery()

                    End If

                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing
            cmd1 = Nothing
            rdr.Close()
        End Try


    End Sub
End Class