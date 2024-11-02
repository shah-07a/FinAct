Imports System.Data
Imports System.Data.SqlClient
Public Class FrmAlterSelectedItem
    Dim sql As inv_sql
    Dim sql1 As inv_sql
    Dim Itmdgr As DataGridViewRow
    Dim Itmcel As DataGridViewTextBoxCell
    Dim Itmcom As DataGridViewComboBoxCell
    Dim ItmBtn As DataGridViewButtonCell
    Dim updtcom As SqlCommand
    Dim yn As Integer
    Dim C12, C13 As Double
    Dim xItmRateChangeFlag As Boolean = False
    Dim xSelId As Integer = 0
    Dim xChngdRate As Double = 0
    Private Sub FrmAlterSelectedItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            sql = New inv_sql
            sql1 = New inv_sql
            Me.Top = 0
            Me.Left = 0

            Me.Width = Screen.PrimaryScreen.WorkingArea.Width - 20
            Create_fill_ItmDg_Detailed()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Create_fill_ItmDg_Detailed()

        Try
            ItmDg.Columns.Clear()
            ItmDg.Rows.Clear()
            'ItmDg.Size = New Drawing.Size(Me.Width - Me.SplitContainer1.SplitterDistance - 10, Me.Height - (Me.Panel4.Height + 50))
            ItmDg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            ItmDg.ForeColor = Color.Navy
            ItmDg.Columns.Add("iid", "Id") '0
            ItmDg.Columns.Add("icode", "Code") '1
            ItmDg.Columns.Add("in", "Name Of The Item") '2
            ItmDg.Columns(1).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns.Add("Group", "Under Group") '3
            ItmDg.Columns.Add("srno", "Serial No.") '4
            ItmDg.Columns.Add("units", "Units") '5
            ItmDg.Columns.Add("untMearmnt", "Measurement") '6
            ItmDg.Columns.Add("ratecheck", "Purchase Check Rate") '7
            ItmDg.Columns.Add("salr", "Sale Rate") '8
            ItmDg.Columns.Add("reorder", "Reorder Level")
            ItmDg.Columns.Add("max", "Max. Qnty")
            ItmDg.Columns.Add("ht", "Height")
            ItmDg.Columns.Add("wdth", "Width")
            ItmDg.Columns.Add("lnth", "Length")
            ItmDg.Columns.Add("grad", "Grade")
            ItmDg.Columns.Add("matrl", "Material")
            ItmDg.Columns.Add("loc", "Location")
            ItmDg.Columns.Add("opnstok", "Opening Stock")
            ItmDg.Columns.Add("rate", "Rate")
            ItmDg.Columns.Add("per", "Per")
            ItmDg.Columns.Add("value", "Value")
            ItmDg.Columns.Add("excise", "Excise Detail")
            ItmDg.Columns.Add("ITms", "Status")
            ItmDg.Columns.Add("ipath", "Item Image Path")
            ItmDg.Columns.Add("iremrk", "Item Remarks")
            ItmDg.Columns.Add("itype", "Item Type")
            ItmDg.Columns.Add("itype1", "Item Nature")
            ItmDg.Columns.Add("conid", "Concern Item Status")
            ItmDg.Columns.Add("Adusr", "Add User")
            ItmDg.Columns.Add("addt", "Add Date")
            ItmDg.Columns.Add("edtusr", "Edit User")
            ItmDg.Columns.Add("edtdt", "Edit Date")
            ItmDg.Columns.Add("Inbox", "Inner Box")
            ItmDg.Columns.Add("Outbox", "Outer Box")
            ' ItmDg.Columns(18).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(19).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(20).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(25).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(26).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(27).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(28).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(29).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(30).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(31).DefaultCellStyle.BackColor = Color.LightGray
            ItmDg.Columns(29).Width = 250
            ItmDg.Columns(31).Width = 250
            ItmDg.Columns(16).Width = 0
            ItmDg.Columns(16).Visible = False
            ItmDg.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ItmDg.ColumnHeadersHeight = 60
            ItmDg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            ItmDg.BorderStyle = BorderStyle.FixedSingle
            ItmDg.BackgroundColor = Color.Snow
            'Me.SplitContainer1.Panel2.Controls.Add(ItmDg)
            ItmDg.Visible = True
            ItmDg.Left = 0
            ItmDg.Top = 2
            ItmDg.Columns(0).Visible = False
            ItmDg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            Dim pn1(0), pv1(0) As String ''Arrays for procedure argu name n value
            'pn1(0) = "@tblname"
            'pv1(0) = "FinactItmmstr"
            'sql.get_data("finact_select_all", pn1, pv1, "ItmMaster")
            Dim pn11(2), pv11(2) As String ''Arrays for procedure argu name n value
            pn11(0) = "@ta"
            pn11(1) = "@id"
            pn11(2) = "@idval"

            pv11(0) = "FinactItmmstr"
            pv11(1) = "itmid"
            pv11(2) = ItmId_for_Alter


            sql.get_data("select_where", pn11, pv11, "ItmMaster") ' "ItmMaster" stands for ItemMaster

            Dim mk, r As Integer

            For mk = 0 To sql.ds.Tables("ItmMaster").Rows.Count - 1

                Itmdgr = New DataGridViewRow()
                'for fetching id
                Itmcel = New DataGridViewTextBoxCell()
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(0).ToString()
                Itmdgr.Cells.Add(Itmcel)

                ' for fetching code
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(1).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(1).ReadOnly = True


                ' for fetching name
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(2).ToString()
                Itmdgr.Cells.Add(Itmcel)


                'for fetching groupname
                Itmcom = New DataGridViewComboBoxCell()
                ' Dim pn11(2), pv11(2) As String ''Arrays for procedure argu name n value
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finactstokgrupname"
                pv11(1) = "cogrpid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(3).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcom.Items.Add(sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())

                pv11(0) = "finactstokgrupname"
                pv11(1) = "cogrupnam"
                pv11(2) = "PRIMARY"
                sql1.get_data("select_where_Not_like", pn11, pv11, "IMa")

                For r = 0 To sql1.ds.Tables("IMa").Rows.Count - 1
                    If sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString() <> Itmcom.Items(0) Then
                        Itmcom.Items.Add(sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString())
                    End If
                Next
                sql1.ds.Tables("IMa").Dispose()
                Itmcom.Value = Itmcom.Items(0)
                Itmdgr.Cells.Add(Itmcom)

                ' for fetching Sr No.
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(4).ToString()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching Units
                Itmcom = New DataGridViewComboBoxCell()
                Itmcom.Items.Add("Kg")
                Itmcom.Items.Add("Pcs")
                Itmcom.Items.Add("Pair")
                Itmcom.Items.Add("Set")
                Itmcom.Items.Add("Qntl")
                Itmcom.Items.Add("Ton")
                Itmcom.Items.Add("Litre")
                Itmcom.Items.Add("Meter")
                Itmcom.Items.Add("Bag")
                Itmcom.Items.Add("Gross")
                Itmcom.Items.Add("Packet")
                Itmcom.Items.Add("Dozen")
                Itmcom.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(5).ToString()
                Itmdgr.Cells.Add(Itmcom)

                'for fetching unit Measurement
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(6).ToString(), 3)
                Itmdgr.Cells.Add(Itmcel)

                'for fetching ratechecker
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(7).ToString(), 2)
                Itmdgr.Cells.Add(Itmcel)

                'for fetching sale rate
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(8).ToString(), 2)
                Itmdgr.Cells.Add(Itmcel)


                'for fetching Reorder
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(9).ToString()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching Maximum
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(10).ToString()
                Itmdgr.Cells.Add(Itmcel)


                'for fetching item height
                Itmcom = New DataGridViewComboBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmhgtmstr"
                pv11(1) = "itmhtid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(12).ToString()
                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcom.Items.Add(sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                pn1(0) = "@ta"
                pv1(0) = "finact_itmhgtmstr"
                sql1.get_data("select_all", pn1, pv1, "IMa")

                For r = 0 To sql1.ds.Tables("IMa").Rows.Count - 1
                    If sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString() <> Itmcom.Items(0) Then
                        Itmcom.Items.Add(sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString())
                    End If
                Next
                sql1.ds.Tables("IMa").Dispose()
                Itmcom.Value = Itmcom.Items(0)
                Itmdgr.Cells.Add(Itmcom)

                'for fetching item Width
                Itmcom = New DataGridViewComboBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmwdthmstr"
                pv11(1) = "itmwdthid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(13).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcom.Items.Add(sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())

                pn1(0) = "@ta"
                pv1(0) = "finact_itmwdthmstr"
                sql1.get_data("select_all", pn1, pv1, "IMa")

                For r = 0 To sql1.ds.Tables("IMa").Rows.Count - 1
                    If sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString() <> Itmcom.Items(0) Then
                        Itmcom.Items.Add(sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString())
                    End If
                Next
                sql1.ds.Tables("IMa").Dispose()
                Itmcom.Value = Itmcom.Items(0)
                Itmdgr.Cells.Add(Itmcom)

                'for fetching item Length
                Itmcom = New DataGridViewComboBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmlnthmstr"
                pv11(1) = "itmlnthid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(14).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcom.Items.Add(sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                pn1(0) = "@ta"
                pv1(0) = "finact_itmlnthmstr"
                sql1.get_data("select_all", pn1, pv1, "IMa")

                For r = 0 To sql1.ds.Tables("IMa").Rows.Count - 1
                    If sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString() <> Itmcom.Items(0) Then
                        Itmcom.Items.Add(sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString())
                    End If
                Next
                sql1.ds.Tables("IMa").Dispose()
                Itmcom.Value = Itmcom.Items(0)
                Itmdgr.Cells.Add(Itmcom)


                'for fetching item Grade
                Itmcom = New DataGridViewComboBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmgradmstr"
                pv11(1) = "itmgradid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(15).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcom.Items.Add(sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                pn1(0) = "@ta"
                pv1(0) = "finact_itmgradmstr"
                sql1.get_data("select_all", pn1, pv1, "IMa")

                For r = 0 To sql1.ds.Tables("IMa").Rows.Count - 1
                    If sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString() <> Itmcom.Items(0) Then
                        Itmcom.Items.Add(sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString())
                    End If
                Next
                sql1.ds.Tables("IMa").Dispose()
                Itmcom.Value = Itmcom.Items(0)
                Itmdgr.Cells.Add(Itmcom)

                'for fetching item Material
                Itmcom = New DataGridViewComboBoxCell
                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "finact_itmmatrlmstr"
                pv11(1) = "itmgradid"
                pv11(2) = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(16).ToString()

                sql1.get_data("select_where", pn11, pv11, "IM") ' IM stands for ItemMaster
                Itmcom.Items.Add(sql1.ds.Tables("IM").Rows(0).ItemArray(1).ToString())
                pn1(0) = "@ta"
                pv1(0) = "finact_itmmatrlmstr"
                sql1.get_data("select_all", pn1, pv1, "IMa")

                For r = 0 To sql1.ds.Tables("IMa").Rows.Count - 1
                    If sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString() <> Itmcom.Items(0) Then
                        Itmcom.Items.Add(sql1.ds.Tables("IMa").Rows(r).ItemArray(1).ToString())
                    End If
                Next
                sql1.ds.Tables("IMa").Dispose()
                Itmcom.Value = Itmcom.Items(0)
                Itmdgr.Cells.Add(Itmcom)

                'for fetching item location
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = "None"
                Itmdgr.Cells.Add(Itmcel)

                'for fetching OPENING STOCK QNTY
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(11).ToString()
                Itmdgr.Cells.Add(Itmcel)

                'for fetching opnstock rate
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(18).ToString(), 2)
                Itmdgr.Cells.Add(Itmcel)

                'for fetching per type
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = Itmdgr.Cells(5).Value
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(19).ReadOnly = True


                'for fetching stockvalue
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(19).ToString(), 2)
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(20).ReadOnly = True


                'for fetching excise yesno status
                Itmcom = New DataGridViewComboBoxCell
                Itmcom.Items.Add("Yes")
                Itmcom.Items.Add("No")
                Dim ysno As String = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(20).ToString()
                If ysno = 1 Then
                    Itmcom.Value = "Yes"
                Else
                    Itmcom.Value = "No"
                End If
                Itmdgr.Cells.Add(Itmcom)

                'for fetching item status
                Itmcom = New DataGridViewComboBoxCell
                Itmcom.Items.Add("Consumable")
                Itmcom.Items.Add("Non-Consumable")
                Dim a As String = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(21).ToString()
                Itmcom.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(21).ToString()
                Itmdgr.Cells.Add(Itmcom)

                ' for fetching image path
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(23).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(23).ReadOnly = True

                ' for fetching item remarks
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(24).ToString()
                Itmdgr.Cells.Add(Itmcel)



                ' for fetching item type
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(25).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(25).ReadOnly = True

                ' for fetching item nature
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(26).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(26).ReadOnly = True

                ' for fetching item concern id
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("ItmMaster").Rows(mk).ItemArray(27).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(27).ReadOnly = True

                'for fetching add user
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(28).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(28).ReadOnly = True


                'for fetching add date
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(29).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(29).ReadOnly = True


                'for fetching edit user
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(30).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(30).ReadOnly = True

                'for fetching edit date
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = sql.ds.Tables("itmmaster").Rows(mk).ItemArray(31).ToString()
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(31).ReadOnly = True

                'for fetching Inner Box pack
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(35).ToString(), 3)
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(32).ReadOnly = True

                'for fetching Outer Box pack
                Itmcel = New DataGridViewTextBoxCell
                Itmcel.Value = FormatNumber(sql.ds.Tables("itmmaster").Rows(mk).ItemArray(36).ToString(), 3)
                Itmdgr.Cells.Add(Itmcel)
                Itmdgr.Cells(33).ReadOnly = True


                ItmDg.Rows.Add(Itmdgr)

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.cnn.Close()
            sql.ds.Dispose()
            ItmDg.AllowUserToAddRows = False
        End Try
    End Sub


    Private Sub BtnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCncl.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnok.Click
        Try

            If validate_input() = True Then
                Exit Sub
            End If
            If validate_ChekError() = True Then
                MsgBox("Error!! System could not update current record", MsgBoxStyle.Critical, "Error!!!")
                Exit Sub
            End If

            If xItmRateChangeFlag = True Then
                If MessageBox.Show("Rate of current item has been changed. It will also change the rate in all Bill of Materials. Are you sure?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    stitedit()
                    xUpdateEffectedItemRates()
                    Exit Sub
                Else
                    Return
                End If

            End If
            stitedit()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xUpdateEffectedItemRates()
        Try
            If FinActConn.State Then FinActConn.Close()
            FinActConn.Open()
            updtcom = New SqlCommand("Finact_Itm_Bom_Mstr_Rate_Update", FinActConn)
            updtcom.CommandType = CommandType.StoredProcedure
            updtcom.Parameters.AddWithValue("@xSelid", xSelId)
            updtcom.Parameters.AddWithValue("@xChngdRate", CDbl(xChngdRate))

            updtcom.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            updtcom.Dispose()
        End Try
    End Sub
    Private Sub stitedit()
        Dim b As Integer = ItmDg.SelectedRows.Count
        Try
            Dim i As Integer = 0
            Dim pv11(2), pn11(2) As String
            pn11(0) = "@ta"
            pn11(1) = "@id"
            pn11(2) = "@idval"
            If b > 0 Then
                For i = 0 To ItmDg.SelectedRows.Count - 1
                    updtcom = New SqlCommand("Finact_Itmmstr_Update", FinActConn)
                    updtcom.CommandType = CommandType.StoredProcedure
                    Dim cod As String = Me.ItmDg.SelectedRows(i).Cells(1).Value
                    updtcom.Parameters.AddWithValue("@itmcode", Trim(Me.ItmDg.SelectedRows(i).Cells(1).Value))
                    updtcom.Parameters.AddWithValue("@itmname", Me.ItmDg.SelectedRows(i).Cells(2).Value)
                    '===For fetching group id
                    pv11(0) = "finactstokgrupname"
                    pv11(1) = "Cogrupnam"
                    pv11(2) = Trim(Me.ItmDg.SelectedRows(i).Cells(3).Value)
                    sql1.get_data("select_where_like", pn11, pv11, "grupid") ' IM stands for ItemMaster
                    updtcom.Parameters.AddWithValue("@itmcatid", sql1.ds.Tables("grupid").Rows(0).ItemArray(0))

                    '===End of fetching group id
                    Dim xSrno As String = Me.ItmDg.SelectedRows(i).Cells(4).Value
                    If Trim(xSrno) = "" Then
                        xSrno = " "
                    End If
                    updtcom.Parameters.AddWithValue("@itmsrno", xSrno)
                    updtcom.Parameters.AddWithValue("@itmunttype", Me.ItmDg.SelectedRows(i).Cells(5).Value)
                    updtcom.Parameters.AddWithValue("@itmwtetc", Me.ItmDg.SelectedRows(i).Cells(6).Value)
                    updtcom.Parameters.AddWithValue("@itmratechek", (Me.ItmDg.SelectedRows(i).Cells(7).Value))
                    updtcom.Parameters.AddWithValue("@itmsalerate", (Me.ItmDg.SelectedRows(i).Cells(8).Value))
                    updtcom.Parameters.AddWithValue("@itmreorder", CDbl(Me.ItmDg.SelectedRows(i).Cells(9).Value))
                    updtcom.Parameters.AddWithValue("@itmmax", CDbl(Me.ItmDg.SelectedRows(i).Cells(10).Value))
                    updtcom.Parameters.AddWithValue("@itmopnqnty", CDbl(Me.ItmDg.SelectedRows(i).Cells(17).Value))
                    updtcom.Parameters.AddWithValue("@itmopnrate", (Me.ItmDg.SelectedRows(i).Cells(18).Value))

                    '===For fetching height id
                    pv11(0) = "Finact_itmhgtmstr"
                    pv11(1) = "itmhtin"
                    pv11(2) = Me.ItmDg.SelectedRows(i).Cells(11).Value
                    sql1.get_data("select_where_like", pn11, pv11, "IM") ' IM stands for ItemMaster
                    updtcom.Parameters.AddWithValue("@itmht", sql1.ds.Tables("IM").Rows(0).ItemArray(0))
                    '===End of fetching id

                    '===For fetching width id
                    pv11(0) = "Finact_itmwdthmstr"
                    pv11(1) = "itmwdthin"
                    pv11(2) = Me.ItmDg.SelectedRows(i).Cells(12).Value
                    sql1.get_data("select_where_like", pn11, pv11, "IM") ' IM stands for ItemMaster
                    updtcom.Parameters.AddWithValue("@itmwdth", sql1.ds.Tables("IM").Rows(0).ItemArray(0))
                    '===End of fetching id

                    '===For fetching Length id
                    pv11(0) = "Finact_itmlnthmstr"
                    pv11(1) = "itmlnthin"
                    pv11(2) = Me.ItmDg.SelectedRows(i).Cells(13).Value
                    sql1.get_data("select_where_like", pn11, pv11, "IM") ' IM stands for ItemMaster
                    updtcom.Parameters.AddWithValue("@itmlnth", sql1.ds.Tables("IM").Rows(0).ItemArray(0))
                    '===End of fetching id

                    '===For fetching Grade id
                    pv11(0) = "Finact_itmgradmstr"
                    pv11(1) = "itmgradname"
                    pv11(2) = Me.ItmDg.SelectedRows(i).Cells(14).Value
                    sql1.get_data("select_where_like", pn11, pv11, "IM") ' IM stands for ItemMaster
                    updtcom.Parameters.AddWithValue("@itmgrad", sql1.ds.Tables("IM").Rows(0).ItemArray(0))
                    '===End of fetching id

                    '===For fetching Material id
                    pv11(0) = "Finact_itmmatrlmstr"
                    pv11(1) = "itmmatrlname"
                    pv11(2) = Me.ItmDg.SelectedRows(i).Cells(15).Value
                    sql1.get_data("select_where_like", pn11, pv11, "IM") ' IM stands for ItemMaster
                    updtcom.Parameters.AddWithValue("@itmmatrl", sql1.ds.Tables("IM").Rows(0).ItemArray(0))
                    '===End of fetching id

                    '===For fetching Location id
                    '
                    updtcom.Parameters.AddWithValue("@itmloc", 0) ' sql1.ds.Tables("IM").Rows(0).ItemArray(0))
                    '===End of fetching id
                    updtcom.Parameters.AddWithValue("@itmopnval", (Me.ItmDg.SelectedRows(i).Cells(20).Value))

                    If Me.ItmDg.SelectedRows(i).Cells(21).Value = "Yes" Then

                        yn = 1
                    Else
                        yn = 0

                    End If
                    updtcom.Parameters.AddWithValue("@itmexciseinfo", yn)
                    updtcom.Parameters.AddWithValue("@itmstatus", Trim((Me.ItmDg.SelectedRows(i).Cells(22).Value)))
                    updtcom.Parameters.AddWithValue("@itmvatrate", 0) ' txtVat.Text)
                    If Trim((Me.ItmDg.SelectedRows(i).Cells(23).Value)) <> "" Then
                        updtcom.Parameters.AddWithValue("@itmipath", Trim(Me.ItmDg.SelectedRows(i).Cells(23).Value))
                    Else
                        updtcom.Parameters.AddWithValue("@itmipath", "None")
                    End If

                    updtcom.Parameters.AddWithValue("@itmremrk", Trim((Me.ItmDg.SelectedRows(i).Cells(24).Value)))
                    updtcom.Parameters.AddWithValue("@itmtype", Trim((Me.ItmDg.SelectedRows(i).Cells(25).Value)))
                    updtcom.Parameters.AddWithValue("@itmtype1", Trim((Me.ItmDg.SelectedRows(i).Cells(26).Value)))
                    ' updtcom.Parameters.AddWithValue("@itmconcrnid", Trim((Me.ItmDg.SelectedRows(i).Cells(26).Value)))
                    If Trim(Me.ItmDg.SelectedRows(i).Cells(27).Value) = "True" Then
                        updtcom.Parameters.AddWithValue("@itmconcrnid", 1)
                    Else
                        updtcom.Parameters.AddWithValue("@itmconcrnid", 0)
                    End If
                    updtcom.Parameters.AddWithValue("@itmedtusrid", Current_UsrId)
                    updtcom.Parameters.AddWithValue("@itmedtdt", Now)
                    updtcom.Parameters.AddWithValue("@itmdelstatus", 1)
                    updtcom.Parameters.AddWithValue("@itmInrbox", 0)
                    updtcom.Parameters.AddWithValue("@itmOtrbox", 0)
                    updtcom.ExecuteNonQuery()
                Next
                MsgBox("Current record has been updated", MsgBoxStyle.Information, Me.Text & " " & "Item Updated ")
                FrmShow_flag(19) = True
                Me.Close()

            Else
                MsgBox("No record selected for updation.", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")

        Finally
            If b > 0 Then
                updtcom.Dispose()
            End If

        End Try

    End Sub
    Private Function validate_ChekError() As Boolean
        Try
            Dim i, j As Integer
            For i = 0 To Me.ItmDg.SelectedRows.Count - 1
                'Check item name that should not be blank/empty
                For j = i + 1 To Me.ItmDg.Rows(i).Cells.Count - 1
                    If Trim(Me.ItmDg.Rows(i).Cells(j).ErrorText) <> "" Then
                        Return True
                    End If

                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Function
    Private Function validate_input() As Boolean
        Try
            Dim i, j As Integer
            For i = 0 To Me.ItmDg.SelectedRows.Count - 1
                'Check item name that should not be blank/empty
                For j = i + 1 To Me.ItmDg.Rows.Count '- 1
                    If Me.ItmDg.Rows(i).Cells(2).Value = "" Then
                        Me.ItmDg.Rows(i).Cells(2).ErrorText = "Empty not allowed"
                        Return True
                    Else
                        Me.ItmDg.Rows(i).Cells(2).ErrorText = ""
                        'Return False
                    End If

                Next
            Next
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function
    Private Sub ItmDg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItmDg.CellClick
        If Me.ItmDg.CurrentCell.ColumnIndex = 7 Then
            If Trim(Me.ItmDg.CurrentRow.Cells(25).Value) = "Sale" Then
                Me.ItmDg.CurrentRow.Cells(7).ReadOnly = True
            Else
                Me.ItmDg.CurrentRow.Cells(7).ReadOnly = False
            End If
        End If
        If Me.ItmDg.CurrentCell.ColumnIndex = 8 Then
            If Trim(Me.ItmDg.CurrentRow.Cells(25).Value) = "Purchase" Then
                Me.ItmDg.CurrentRow.Cells(8).ReadOnly = True
            Else
                Me.ItmDg.CurrentRow.Cells(8).ReadOnly = False
            End If
        End If
    End Sub

    Private Sub ItmDg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItmDg.CellEndEdit
        If ItmDg.CurrentCell.ColumnIndex = 6 Then
            If Trim(ItmDg.CurrentRow.Cells(6).Value) <> "" Then
                If IsNumeric(ItmDg.CurrentRow.Cells(6).Value) = False Then
                    ItmDg.CurrentRow.Cells(6).ErrorText = "Invalid input! Only valid numericals are allowed"
                Else
                    ItmDg.CurrentRow.Cells(6).ErrorText = ""
                    ItmDg.CurrentRow.Cells(6).Value = FormatNumber(ItmDg.CurrentRow.Cells(6).Value, 2)
                End If
            Else
                ItmDg.CurrentRow.Cells(6).Value = 0.0
                ItmDg.CurrentRow.Cells(6).ErrorText = ""
            End If

        ElseIf ItmDg.CurrentCell.ColumnIndex = 7 Then
            If Trim(ItmDg.CurrentRow.Cells(7).Value) <> "" Then
                If IsNumeric(ItmDg.CurrentRow.Cells(7).Value) = False Then
                    ItmDg.CurrentRow.Cells(7).ErrorText = "Invalid input! Only valid numericals are allowed"
                Else
                    ItmDg.CurrentRow.Cells(7).ErrorText = ""
                    ItmDg.CurrentRow.Cells(7).Value = FormatNumber(ItmDg.CurrentRow.Cells(7).Value, 2)
                End If
            Else
                ItmDg.CurrentRow.Cells(7).Value = 0.0
                ItmDg.CurrentRow.Cells(7).ErrorText = ""
            End If
        ElseIf ItmDg.CurrentCell.ColumnIndex = 8 Then
            If Trim(ItmDg.CurrentRow.Cells(8).Value) <> "" Then
                If IsNumeric(ItmDg.CurrentRow.Cells(8).Value) = False Then
                    ItmDg.CurrentRow.Cells(8).ErrorText = "Invalid input! Only valid numericals are allowed"
                Else
                    ItmDg.CurrentRow.Cells(8).ErrorText = ""
                    ItmDg.CurrentRow.Cells(8).Value = FormatNumber(ItmDg.CurrentRow.Cells(8).Value, 2)
                End If
            Else
                ItmDg.CurrentRow.Cells(8).Value = 0.0
                ItmDg.CurrentRow.Cells(8).ErrorText = ""
            End If

        ElseIf ItmDg.CurrentCell.ColumnIndex = 9 Then
            If Trim(ItmDg.CurrentRow.Cells(9).Value) <> "" Then
                If IsNumeric(ItmDg.CurrentRow.Cells(9).Value) = False Then
                    ItmDg.CurrentRow.Cells(9).ErrorText = "Invalid input! Only valid numericals are allowed"
                Else
                    Dim val1 As Double = ItmDg.CurrentRow.Cells(9).Value
                    Dim val2 As Double = ItmDg.CurrentRow.Cells(10).Value
                    If val1 > val2 Then
                        ItmDg.CurrentRow.Cells(9).ErrorText = "Invalid input!, Maximum quantity should be greater than minimum quantity"
                    Else
                        ItmDg.CurrentRow.Cells(9).ErrorText = ""
                        ItmDg.CurrentRow.Cells(9).Value = FormatNumber(ItmDg.CurrentRow.Cells(9).Value, 3)
                    End If
                End If
            Else
                ItmDg.CurrentRow.Cells(9).ErrorText = "Invalid input!"
            End If

        ElseIf ItmDg.CurrentCell.ColumnIndex = 10 Then
            If Trim(ItmDg.CurrentRow.Cells(10).Value) <> "" Then
                If IsNumeric(ItmDg.CurrentRow.Cells(10).Value) = False Then
                    ItmDg.CurrentRow.Cells(10).ErrorText = "Invalid input! Only valid numericals are allowed"
                Else
                    ItmDg.CurrentRow.Cells(10).ErrorText = ""
                    Dim val1 As Double = ItmDg.CurrentRow.Cells(9).Value
                    Dim val2 As Double = ItmDg.CurrentRow.Cells(10).Value
                    If val1 > val2 Then
                        ItmDg.CurrentRow.Cells(10).ErrorText = "Invalid input"
                    Else
                        ItmDg.CurrentRow.Cells(10).ErrorText = ""
                        ItmDg.CurrentRow.Cells(10).Value = FormatNumber(ItmDg.CurrentRow.Cells(10).Value, 3)
                    End If
                End If
            Else
                ' ItmDg.CurrentRow.Cells(9).Value = 0.0
                ItmDg.CurrentRow.Cells(10).ErrorText = "Invalid input!"
            End If

        ElseIf ItmDg.CurrentCell.ColumnIndex = 17 Then

            If Trim(ItmDg.CurrentRow.Cells(17).Value) <> "" Then
                If IsNumeric(ItmDg.CurrentRow.Cells(17).Value) = False Then
                    ItmDg.CurrentRow.Cells(17).ErrorText = "Invalid input! Only valid numericals are allowed"
                    ItmDg.CurrentRow.Cells(20).Value = 0

                Else
                    ItmDg.CurrentRow.Cells(17).ErrorText = ""
                    ItmDg.CurrentRow.Cells(17).Value = FormatNumber(ItmDg.CurrentRow.Cells(17).Value, 3)
                    C12 = CDbl(ItmDg.CurrentRow.Cells(17).Value)
                End If
            Else
                ItmDg.CurrentRow.Cells(17).Value = 0.0
                ItmDg.CurrentRow.Cells(17).ErrorText = ""
                C12 = CDbl(ItmDg.CurrentRow.Cells(17).Value)
            End If

        ElseIf ItmDg.CurrentCell.ColumnIndex = 18 Then

            If Trim(ItmDg.CurrentRow.Cells(18).Value) <> "" Then
                If IsNumeric(ItmDg.CurrentRow.Cells(18).Value) = False Then
                    ItmDg.CurrentRow.Cells(18).ErrorText = "Invalid input! Only valid numericals are allowed"
                    ItmDg.CurrentRow.Cells(20).Value = 0
                Else
                    ItmDg.CurrentRow.Cells(18).ErrorText = ""
                    ItmDg.CurrentRow.Cells(18).Value = FormatNumber(ItmDg.CurrentRow.Cells(18).Value, 2)
                    C13 = CDbl(ItmDg.CurrentRow.Cells(18).Value)
                    ItmDg.CurrentRow.Cells(20).Value = FormatNumber((C12 * C13), 2)

                End If
            Else
                ItmDg.CurrentRow.Cells(18).Value = 0.0
                ItmDg.CurrentRow.Cells(18).ErrorText = ""
                ItmDg.CurrentRow.Cells(20).Value = FormatNumber((C12 * C13), 2)
            End If

        End If
    End Sub
    Private Sub ItmDg_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItmDg.CellValueChanged
        If ItmDg.CurrentCell.ColumnIndex = 5 Then
            ItmDg.CurrentRow.Cells(19).Value = ItmDg.CurrentCell.Value
        End If
        If e.ColumnIndex = 7 Then
            xItmRateChangeFlag = True
            xSelId = CInt(Me.ItmDg.CurrentRow.Cells(0).Value)
            xChngdRate = CDbl(Me.ItmDg.CurrentRow.Cells(7).Value)
        End If
    End Sub
    Private Sub ItmDg_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ItmDg.DataError
        e.ThrowException = True

    End Sub

   
    Private Sub ItmDg_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ItmDg.RowHeaderMouseClick
        Try
            Me.ItmDg.CurrentCell = Me.ItmDg.Item(1, Me.ItmDg.CurrentCell.RowIndex)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub ItmDg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItmDg.CellContentClick

    End Sub
End Class