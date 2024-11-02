Imports System.Data
Imports System.Data.SqlClient

Public Class FrmItmConfig
    Dim ConvrtVal_Flag As Boolean
    Dim Itmconfig_cmd As SqlCommand
    Dim ItmConfig_rdr As SqlDataReader
    Dim ad As SqlDataAdapter
    Dim IndxConfig As Integer = 0
    Dim sql As inv_sql
    Dim dgr As DataGridViewRow
    Dim cel As DataGridViewTextBoxCell
    Dim com As DataGridViewComboBoxCell
    Private Sub FrmItmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 10
        Me.Top = 0
        ConvrtVal_Flag = True
        sql = New inv_sql
    End Sub
    Private Sub Btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub Chk_Numericval()
        Dim Ntxt As Control

        For Each Ntxt In Me.TableLayoutPanel1.Controls
            If TypeOf Ntxt Is TextBox Then
                If Ntxt.Tag = "Txt1" Then
                    If Ntxt.Text = "" Then
                        Ntxt.BackColor = Color.PapayaWhip
                        IndxConfig += 1
                        Ntxt.Focus()
                        Exit Sub
                    Else
                        Ntxt.BackColor = Color.White

                    End If
                End If
                If Ntxt.Tag <> "Txt1" Then
                    If IsNumeric(Ntxt.Text) = False Then
                        Ntxt.BackColor = Color.PapayaWhip
                        IndxConfig += 1
                        Label11.Visible = True
                        Label9.Visible = True
                        Label11.Text = "Invalid value: it should be only postive numeric."
                        Ntxt.Focus()
                    Else
                        Ntxt.BackColor = Color.White
                        Label11.Visible = False
                        Label9.Visible = False
                        If ConvrtVal_Flag = True Then
                            If Ntxt.Tag = "Txt2" Or Ntxt.Tag = "Txt3" Then
                                Exit Sub
                            Else
                                Convert_Numericval(Ntxt)
                            End If
                        Else
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            ConvrtVal_Flag = False
            Chk_Numericval()
            If IndxConfig <> 0 Then
                IndxConfig = 0
                Exit Sub
            Else
                Save_Recd()
            End If
        Else
            Try
                Me.dg.EndEdit()
                If validate_input() Then
                    MsgBox("Invalid input! a record with the same value already exisit, try another value", MsgBoxStyle.Critical)
                    Create_fill_datagrid()
                    Return
                Else
                    Edit_Recd()
                End If
            Catch ez As Exception
                MessageBox.Show(ez.Message)
            End Try

        End If



    End Sub

    Private Sub Rbinch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbinch.CheckedChanged
        If Rbinch.Checked = True Then
            Chk_Numericval()
        End If
    End Sub

    Private Sub Rbcm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbcm.CheckedChanged
        If ConvrtVal_Flag = True Then
            If Rbcm.Checked = True Then
                ConvrtVal_Flag = True
                Chk_Numericval()
            End If
        End If
    End Sub

    Private Sub Convert_Numericval(ByVal Txtbox As TextBox)
        Dim Rbbtn As RadioButton
        Dim Valtoconvrt As Double = CDbl(0.0)
        For Each Rbbtn In Me.GroupBox1.Controls
            If TypeOf Rbbtn Is RadioButton Then
                If Rbbtn.Tag = "rb1" Then
                    If Rbbtn.Checked = True Then
                        Valtoconvrt = CDbl(Txtbox.Text)
                        Txtbox.Text = FormatNumber((Valtoconvrt * 2.54), 4)
                    End If
                ElseIf Rbbtn.Tag = "rb2" Then
                    If Rbbtn.Checked = True Then
                        Valtoconvrt = CDbl(Txtbox.Text)
                        Txtbox.Text = FormatNumber((Valtoconvrt / 2.54), 4)
                    End If
                End If
            End If
        Next

    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        TxtCitmname.Focus()
    End Sub

    Private Sub Save_Recd()
        Try
            If Trim(BtnSave.Text) = "&Save" Then
                Itmconfig_cmd = New SqlCommand("finact_itmconfig_insert", FinActConn)
                Itmconfig_cmd.CommandType = CommandType.StoredProcedure
            End If

            Itmconfig_cmd.Parameters.AddWithValue("@iname", TxtCitmname.Text)
            If Rbcm.Checked = True Then
                Itmconfig_cmd.Parameters.AddWithValue("@istype", "Inch")
            ElseIf (Rbinch.Checked = True) Then
                Itmconfig_cmd.Parameters.AddWithValue("@istype", "Cm")

            End If
            Itmconfig_cmd.Parameters.AddWithValue("@ich", TxtChgt.Text)
            Itmconfig_cmd.Parameters.AddWithValue("@icw", TxtCwtdth.Text)
            Itmconfig_cmd.Parameters.AddWithValue("@icd", TxtCdia.Text)
            Itmconfig_cmd.Parameters.AddWithValue("@icl", TxtClgnth.Text)
            Itmconfig_cmd.Parameters.AddWithValue("@icpikg", TxtCpcsinkg.Text)
            Itmconfig_cmd.Parameters.AddWithValue("@icwtp", TxtCwtinpc.Text)
            Itmconfig_cmd.Parameters.AddWithValue("@icclr", Cmbxcolor.Text)
            Itmconfig_cmd.Parameters.AddWithValue("@icgrad", Cmbxgrade.Text)
            Itmconfig_cmd.Parameters.AddWithValue("@icmat", Cmbxmaterl.Text)
            Itmconfig_cmd.ExecuteNonQuery()
            MsgBox("Current record has been saved", MsgBoxStyle.Information, Me.Text & " " & "Save_Recd()")
            ClearValue()
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MsgBox("Invalid input! system found a record exisited with same value, Try another value", MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            End If
            TxtCitmname.Focus()
            TxtCitmname.SelectAll()
        Finally
            Itmconfig_cmd.Dispose()
        End Try


    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click

        If BtnFind.Text = "&Find" Then
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 20


            'If dg.i > 0 Then
            Me.TableLayoutPanel1.Visible = False
            Me.SplitContainer1.SplitterDistance = 157
            Me.SplitContainer1.IsSplitterFixed = True
            Create_fill_datagrid()
            BtnSave.Text = "&Update"
            BtnFind.Text = "&Delete"
           

        Else

            If MessageBox.Show("Are you sure to delete?", "Item configuration", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Return
            End If
            Try
                If dg.SelectedRows.Count > 0 Then
                    Dim i As Integer = 0

                    For i = 0 To dg.SelectedRows.Count - 1
                        Itmconfig_cmd = New SqlCommand("Delete from finact_itmconfig where itmcid=@id", FinActConn)
                        Itmconfig_cmd.Parameters.AddWithValue("@id", Me.dg.SelectedRows(i).Cells(0).Value)
                        Itmconfig_cmd.ExecuteNonQuery()
                    Next
                    MsgBox("deleted successfully")
                    Create_fill_datagrid()
                Else
                    MsgBox("System could not found any selected item to delete, Make it sure atleast one item should be selected.", MsgBoxStyle.Information, Me.Text)
                End If

            Catch ex As SqlException
                If ex.Number.Equals(8178) = True Then
                    MsgBox("System could not found any selected item to delete, Make it sure atleast one item should be selected.", MsgBoxStyle.Information, Me.Text)
                Else
                    MessageBox.Show(ex.Message)
                End If

            Finally
                If dg.SelectedRows.Count > 0 Then
                    Itmconfig_cmd.Dispose()
                End If
            End Try
        End If
        


    End Sub
    Private Sub Create_fill_datagrid()
        Try

            dg.Columns.Clear()
            dg.Rows.Clear()
            dg.Size = New Drawing.Size(Me.Width - Me.SplitContainer1.SplitterDistance - 30, 400)
            dg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            dg.ForeColor = Color.Navy
            dg.Columns.Add("iid", "Id")
            dg.Columns.Add("iname", "Name")
            dg.Columns(1).DefaultCellStyle.BackColor = Color.Cyan
            dg.Columns.Add("istype", "Size Type")
            dg.Columns.Add("ich", "Height")
            dg.Columns.Add("icw", "Width")
            dg.Columns.Add("icd", "Dia")
            dg.Columns.Add("icl", "Length")
            dg.Columns.Add("icpikg", "Pieces in Kg.")
            dg.Columns.Add("icwtp", "Weight of Pieces")
            dg.Columns.Add("icclr", "Color")
            dg.Columns.Add("icgrad", "Grade")
            dg.Columns.Add("icmat", "Material")
            dg.ColumnHeadersHeight = 40
            dg.BorderStyle = BorderStyle.FixedSingle
            dg.BackgroundColor = Color.Snow
            Me.SplitContainer1.Panel2.Controls.Add(dg)
            dg.Visible = True
            dg.Left = 0
            dg.Columns(0).Visible = False
            dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red

            Dim pn1(0), pv1(0) As String ''Arrays for procedure argu name n value
            pn1(0) = "@tblname"
            pv1(0) = "Finact_ItmConfig"
            sql.get_data("finact_select_all", pn1, pv1, "size_m")
           

            Dim mk As Integer
            For mk = 0 To sql.ds.Tables("size_m").Rows.Count - 1
                dgr = New DataGridViewRow()
                'for fetching id
                cel = New DataGridViewTextBoxCell()
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(0).ToString()
                dgr.Cells.Add(cel)

                ' for fetching itemname
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(1).ToString()
                dgr.Cells.Add(cel)

                ' for fetching size type
                com = New DataGridViewComboBoxCell
                com.Items.Add("Inch")
                com.Items.Add("Cm")
                com.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(2).ToString()
                dgr.Cells.Add(com)

                ' for fetching item height
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(3).ToString()
                dgr.Cells.Add(cel)

                ' for fetching item width
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(4).ToString()
                dgr.Cells.Add(cel)
                ' for fetching item dia
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(5).ToString()
                dgr.Cells.Add(cel)

                ' for fetching item length
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(6).ToString()
                dgr.Cells.Add(cel)

                ' for fetching Piece in a kg.
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(7).ToString()
                dgr.Cells.Add(cel)

                ' for fetching  Weight of 100 pieces
                cel = New DataGridViewTextBoxCell
                cel.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(8).ToString()
                dgr.Cells.Add(cel)

                ' for fetching Color
                com = New DataGridViewComboBoxCell
                com.Items.Add("Red")
                com.Items.Add("Black")
                com.Items.Add("Blue")
                com.Items.Add("Yellow")
                com.Items.Add("Green")
                com.Items.Add("Pink")
                com.Items.Add("Magenta")
                com.Items.Add("White")
                com.Items.Add("Grey")
                'com.DisplayMember = sql.ds.Tables("size_m").Rows(mk).ItemArray(9).ToString()
                com.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(9).ToString()
                'cel.Value = Format(Convert.ToDateTime(cel.Value), "dd/MM/yyyy")
                dgr.Cells.Add(com)

                ' for fetching Grade
                com = New DataGridViewComboBoxCell
                com.Items.Add("Grade 1")
                com.Items.Add("Grade 2")
                com.Items.Add("Grade 3")
                com.Items.Add("Grade 4")
                com.Items.Add("Grade 5")
                com.Items.Add("Grade 6")
                com.Items.Add("Grade 7")
                com.Items.Add("Grade 8")
                com.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(10).ToString()
                dgr.Cells.Add(com)

                ' for fetching material
                com = New DataGridViewComboBoxCell
                com.Items.Add("Fist Quality")
                com.Items.Add("Second Quality")
                com.Items.Add("Third Quality")
                com.Items.Add("Scrap Quality")
                com.Value = sql.ds.Tables("size_m").Rows(mk).ItemArray(11).ToString()
                dgr.Cells.Add(com)
                dg.Rows.Add(dgr)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.cnn.Close()
            sql.ds.Dispose()

        End Try
    End Sub

   

    Private Sub Btnclse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclse.Click
        Me.Close()

    End Sub

    Private Sub btndele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndele.Click
        If BtnFind.Text = "&Delete" Then
            dg.Visible = False
            Me.TableLayoutPanel1.Visible = True
            Me.SplitContainer1.SplitterDistance = 157
            Me.SplitContainer1.IsSplitterFixed = False
            Me.Width = 745
            BtnSave.Text = "&Save"
            BtnFind.Text = "&Find"
        Else
            ClearValue()
        End If

    End Sub
#Region "Clear"
    Private Sub ClearValue()
        Dim Contrl As Control
        For Each Contrl In Me.TableLayoutPanel1.Controls
            If TypeOf Contrl Is TextBox Then
                Contrl.Text = ""
            ElseIf TypeOf Contrl Is ComboBox Then
                Contrl.Text = ""
            End If
        Next

    End Sub
#End Region
#Region "Validate"
    Private Function validate_input() As Boolean
        Dim i, j As Integer
        For i = 0 To Me.dg.Rows.Count - 1
            For j = i + 1 To Me.dg.Rows.Count - 1
                If Me.dg.Rows(i).Cells(1).Value = Me.dg.Rows(j).Cells(1).Value Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function
#End Region
    Dim cont As Integer
    Dim flag As Integer = 0
    Dim str As String = ""
   
#Region "Editarecord"
    Private Sub Edit_Recd()
        Try
            Dim i As Integer = 0
            For i = 0 To dg.Rows.Count - 2
                ''If Trim(BtnSave.Text) = "&Update" Then
                Itmconfig_cmd = New SqlCommand("finact_itmconfig_update", FinActConn)
                Itmconfig_cmd.CommandType = CommandType.StoredProcedure
                Itmconfig_cmd.Parameters.AddWithValue("@iId", Me.dg.Rows(i).Cells(0).Value)


                Itmconfig_cmd.Parameters.AddWithValue("@iname", Me.dg.Rows(i).Cells(1).Value)
                If Me.dg.Rows(i).Cells(2).Value = "Inch" Then
                    Itmconfig_cmd.Parameters.AddWithValue("@istype", "Inch")
                ElseIf Me.dg.Rows(i).Cells(2).Value = "Cm" Then
                    Itmconfig_cmd.Parameters.AddWithValue("@istype", "Cm")

                End If
                Itmconfig_cmd.Parameters.AddWithValue("@ich", Me.dg.Rows(i).Cells(3).Value)
                Itmconfig_cmd.Parameters.AddWithValue("@icw", Me.dg.Rows(i).Cells(4).Value)
                Itmconfig_cmd.Parameters.AddWithValue("@icd", Me.dg.Rows(i).Cells(5).Value)
                Itmconfig_cmd.Parameters.AddWithValue("@icl", Me.dg.Rows(i).Cells(6).Value)
                Itmconfig_cmd.Parameters.AddWithValue("@icpikg", Me.dg.Rows(i).Cells(7).Value)
                Itmconfig_cmd.Parameters.AddWithValue("@icwtp", Me.dg.Rows(i).Cells(8).Value)
                Itmconfig_cmd.Parameters.AddWithValue("@icclr", Me.dg.Rows(i).Cells(9).Value)
                Itmconfig_cmd.Parameters.AddWithValue("@icgrad", Me.dg.Rows(i).Cells(10).Value)
                Itmconfig_cmd.Parameters.AddWithValue("@icmat", Me.dg.Rows(i).Cells(11).Value)
                Itmconfig_cmd.ExecuteNonQuery()
            Next
            MsgBox("Current record has been saved", MsgBoxStyle.Information, Me.Text & " " & "Save_Recd()")
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MsgBox("Invalid input! system found a record exisited with same value, Try another value", MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            End If
            TxtCitmname.Focus()
            TxtCitmname.SelectAll()
        Finally
            Itmconfig_cmd.Dispose()
        End Try


    End Sub
#End Region

    Private Sub Dg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dg.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Return
        End If
        For cont = 0 To Me.dg.Rows.Count - 1
            If Me.dg.Rows(cont).Cells(1).Value().ToLower.StartsWith(e.KeyChar.ToString.ToLower) Then
                If str <> e.KeyChar.ToString.ToLower And flag = 1 Then
                    flag = 0
                    str = ""
                End If
                If Me.dg.Rows(cont).Selected = False And flag = 0 Then
                    Me.dg.Rows(cont).Selected = True
                    If Me.dg.SelectedRows(0).Index + 1 < Me.dg.Rows.Count Then
                        If Me.dg.Rows(cont + 1).Cells(1).Value().ToLower.StartsWith(e.KeyChar.ToString.ToLower) Then
                            flag = 1
                            str = e.KeyChar.ToString.ToLower
                        Else
                            flag = 0
                            str = ""
                        End If
                    End If
                    Me.dg.FirstDisplayedScrollingRowIndex = Me.dg.SelectedRows(0).Index
                    Return
                End If
                If flag = 1 Then
                    If Me.dg.SelectedRows(0).Index + 1 < Me.dg.Rows.Count Then
                        If Me.dg.SelectedRows(0).Index + 1 = Me.dg.Rows.Count - 1 And Not Me.dg.Rows(Me.dg.SelectedRows(0).Index + 1).Cells(1).Value().ToLower.StartsWith(e.KeyChar.ToString.ToLower) Then
                            flag = 0
                            str = ""
                            cont = 0
                            Continue For
                        End If
                        Me.dg.Rows(Me.dg.SelectedRows(0).Index + 1).Selected = True
                    End If
                    If Me.dg.SelectedRows(0).Index + 1 < Me.dg.Rows.Count - 1 Then
                        If Me.dg.Rows(Me.dg.SelectedRows(0).Index + 1).Cells(1).Value().ToLower.StartsWith(e.KeyChar.ToString.ToLower) Then
                            flag = 1
                            str = e.KeyChar.ToString.ToLower
                        Else
                            flag = 0
                            str = ""
                        End If
                    ElseIf Me.dg.SelectedRows(0).Index = Me.dg.Rows.Count - 1 Then
                        flag = 0
                        str = ""
                    Else
                        flag = 1
                        str = e.KeyChar.ToString.ToLower
                    End If
                    Me.dg.FirstDisplayedScrollingRowIndex = Me.dg.SelectedRows(0).Index
                    Return
                End If
            End If
        Next
    End Sub


    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        If BtnSave.Text = "&Save" Then
            BtnSave_Click(sender, e)
        End If

    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        If BtnFind.Text = "&Delete" Then
            BtnFind_Click(sender, e)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

  
End Class