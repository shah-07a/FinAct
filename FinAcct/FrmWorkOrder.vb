Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmWorkOrder
    Dim Po_WrkOcmd As SqlCommand
    Dim Po_WrkOrdr As SqlDataReader
    Dim Po_WrkoAdptr As SqlDataAdapter
    Dim Po_WrkoDset As DataSet

    Dim Po_Wrko_SplrId As Integer = 0
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date
    Dim fill_Xcmbx As Boolean = True

    Private Sub FrmWorkOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height / 1.25
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width / 1.25
    End Sub
    Private Sub CreateGridColumns()
        Try
            Po_WrkOcmd = New SqlCommand("Finact_SaleOrder_Select_for_Po_Wrko_Where_id", FinActConn1)
            Po_WrkOcmd.CommandType = CommandType.StoredProcedure
            Po_WrkOcmd.Parameters.AddWithValue("@orderid", CInt(Me.CmbxSaleorderno.SelectedValue))
            Po_WrkOrdr = Po_WrkOcmd.ExecuteReader
            Po_WrkOrdr.Read()
            If Po_WrkOrdr.HasRows = True Then
                '  Me.lblso.Text = Trim(Po_WrkOrdr("Saleordno"))
                If Po_WrkOrdr.IsDBNull(12) = True Then
                    Me.lblsoamt.Text = FormatNumber(0, 2)
                Else
                    Me.lblsoamt.Text = FormatNumber(Po_WrkOrdr("Saleamt"), 2)
                End If
                Date.TryParse(Po_WrkOrdr("Saleorddt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                'Me.dtpordrdt.MinDate = CurrDate
                ' Me.dtpordrdt.Value = CurrDate
                Me.lblsodt.Text = Format(CurrDate.Date, "dd/MM/yyyy")
                'Me.Cmbxstatus.Text = Trim(Po_WrkOrdr("Salestatus"))
                Date.TryParse(Po_WrkOrdr("Saledelvrydt"), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
                Me.lbldelvdt.Text = Format(CurrDate.Date, "dd/MM/yyyy")
                Po_Wrko_SplrId = Trim(Po_WrkOrdr("Salesplrid"))
                Me.lblcust1.Text = Trim(Po_WrkOrdr("splr_name"))
                Me.lblcust2.Text = Trim(Po_WrkOrdr("Splr_city"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Po_WrkOcmd.Dispose()
            Po_WrkOrdr.Close()
            Exit Sub
        Finally
            Po_WrkOcmd.Dispose()
            Po_WrkOrdr.Close()
        End Try

        'Try
        '    Dim DgItms As DataGridView
        '    DgItms = Me.Dgitmems
        '    DgItms.Columns.Clear()
        '    Po_WrkOcmd = New SqlCommand("Finact_SaleOrder_Details_Where_Concrnid", FinActConn1)
        '    Po_WrkOcmd.CommandType = CommandType.StoredProcedure
        '    Po_WrkOcmd.Parameters.AddWithValue("@PordConcrnid", Selected_xOrdr_xId)

        '    TpoAdptr = New Data.SqlClient.SqlDataAdapter(Po_WrkOcmd)
        '    dtaset = New Data.DataSet()
        '    TpoAdptr.Fill(dtaset, "finactSaleorder_details")
        '    DgItms.DataSource = dtaset.Tables("finactSaleorder_details")

        '    ' DgItms.Columns.Add("ColQnty", "Quantity")

        '    DgItms.Columns(0).HeaderText = "Quantity"
        '    DgItms.Columns(0).Name = "ColQnty"
        '    Dim dt As DataGridViewTextBoxColumn = TryCast(DgItms.Columns(0), DataGridViewTextBoxColumn)
        '    dt.MaxInputLength = 10
        '    DgItms.Columns(0).Width = 60
        '    DgItms.Columns(0).DefaultCellStyle.Format = "N3"
        '    DgItms.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    DgItms.Columns(0).DefaultCellStyle.NullValue = Nothing


        '    'DgItms.Columns.Add("ColItemid", "Item Name")
        '    DgItms.Columns(1).HeaderText = "Item Name"
        '    DgItms.Columns(1).Name = "ColItemid"
        '    DgItms.Columns(1).Width = 165
        '    DgItms.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        '    'DgItms.Columns.Add("ColDiscription", "Discription")
        '    DgItms.Columns(2).HeaderText = "Discription"
        '    DgItms.Columns(2).Name = "ColDiscription"
        '    DgItms.Columns(2).Width = 150

        '    ' DgItms.Columns.Add("colCost", "Rate")
        '    DgItms.Columns(3).HeaderText = "Rate"
        '    DgItms.Columns(3).Name = "colCost"
        '    DgItms.Columns(3).Width = 100
        '    DgItms.Columns(3).DefaultCellStyle.Format = "N2"
        '    DgItms.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    DgItms.Columns(3).DefaultCellStyle.NullValue = Nothing

        '    'DgItms.Columns.Add("ColUnittype", "Unit Type")
        '    DgItms.Columns(4).HeaderText = "Unit Type"
        '    DgItms.Columns(4).Name = "ColUnittype"
        '    DgItms.Columns(4).Width = 100
        '    DgItms.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        '    ' DgItms.Columns.Add("colAmt", "Amount")
        '    DgItms.Columns(5).HeaderText = "Amount"
        '    DgItms.Columns(5).Name = "colAmt"
        '    DgItms.Columns(5).Width = 100
        '    DgItms.Columns(5).DefaultCellStyle.Format = "N2"
        '    DgItms.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        '    'DgItms.Columns.Add("ColITmId", "Item id")
        '    DgItms.Columns(6).HeaderText = "Item id"
        '    DgItms.Columns(6).Name = "ColITmId"
        '    DgItms.Columns(6).Width = 100
        '    ' DgItms.Columns(6).Visible = False

        '    '  DgItms.Columns.Add("CoICode", "Item Code")
        '    DgItms.Columns(7).HeaderText = "Item Code"
        '    DgItms.Columns(7).Name = "CoICode"
        '    DgItms.Columns(7).DefaultCellStyle.Format.ToString()
        '    DgItms.Columns(7).Width = 100
        '    ' DgItms.Columns(7).Visible = False

        '    'DgItms.Columns.Add("ColStatus", "itemcode")
        '    DgItms.Columns(8).HeaderText = "Item Code"
        '    DgItms.Columns(8).Name = "ColStatus"
        '    DgItms.Columns(8).Width = 100
        '    DgItms.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


        '    DgItms.Columns.Add("ColInStok", "Sotck In Hand")
        '    ''DgItms.Columns(9).HeaderText = "Sotck In Hand"
        '    ''DgItms.Columns(9).Name = "ColInStok"
        '    DgItms.Columns(9).Width = 100
        '    DgItms.Columns(9).DefaultCellStyle.Format = "N3"
        '    DgItms.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    DgItms.Columns(9).DefaultCellStyle.NullValue = Nothing

        '    DgItms.Columns.Add("ColresStok", "Edit Flag")
        '    'DgItms.Columns(10).HeaderText = "Edit Flag"
        '    'DgItms.Columns(10).Name = "ColresStok"
        '    DgItms.Columns(10).Width = 10
        '    'DgItms.Columns(10).Visible = False
        '    'DgItms.Columns(10).DefaultCellStyle.Format = "No"
        '    DgItms.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '    DgItms.Columns(10).DefaultCellStyle.NullValue = Nothing
        '    Dim rc As Integer = 0
        '    For rc = 0 To Me.Dgitmems.Rows.Count - 2
        '        Me.Dgitmems.Rows(rc).Cells(10).Value = 1 '1 is  satand for already existed record.
        '    Next

        '    DgItms.MultiSelect = False
        '    DgItms.AllowUserToDeleteRows = False


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    Po_WrkOcmd.Dispose()
        '    TpoAdptr.Dispose()

        'End Try
    End Sub
    Private Sub Select_2rec_where_Not(ByVal xfield1id As String, ByVal xfield2name As String, ByVal xFieldcond As String, ByVal xFielddt As String, ByVal xFieldordrby As String, ByVal xtblename As String, ByVal xCombobox As ComboBox, ByVal CondStr As String, ByVal Conddt As Date)
        Dim xStr As String = "Select " & (xfield1id) & "," & (xfield2name) & " from " & (xtblename) & " where " & Trim(xFieldcond) & "= @fldval and   " & Trim(xFielddt) & " <= @fldvaldt order by " & Trim(xFieldordrby) & " "
        Po_WrkoDset = New DataSet
        Po_WrkoDset.Tables.Clear()
        Try
            Po_WrkOcmd = New SqlCommand(xStr, FinActConn1)
            Po_WrkOcmd.Parameters.AddWithValue("@fldval", CondStr)
            Po_WrkOcmd.Parameters.AddWithValue("@fldvaldt", Conddt)
            Po_WrkoAdptr = New SqlDataAdapter(Po_WrkOcmd)
            Po_WrkoDset = New DataSet(Po_WrkOcmd.CommandText)
            Po_WrkoAdptr.Fill(Po_WrkoDset)
            xCombobox.DataSource = Po_WrkoDset.Tables(0)
            xCombobox.ValueMember = xfield1id
            xCombobox.DisplayMember = xfield2name
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Po_WrkOcmd.Dispose()
            Po_WrkoAdptr.Dispose()
        End Try
    End Sub

    Private Sub CmbxSaleorderno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSaleorderno.GotFocus
        Try
            If Me.CmbxSaleorderno.Items.Count > 0 Then
                If Me.CmbxSaleorderno.SelectedIndex = -1 Then
                    Me.CmbxSaleorderno.SelectedIndex = 0
                End If
            Else
                Select_2rec_where_Not("saleid", "saleordno", "salestatus", "saleorddt", "saleorddt", "finactsaleorder", Me.CmbxSaleorderno, "On Order", Me.DtpWrkordrdt.Value.Date)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxSaleorderno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSaleorderno.Leave
        Try
            If Me.CmbxSaleorderno.Items.Count > 0 Then
                If fill_Xcmbx = True Then
                    CreateGridColumns()
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxSaleorderno_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxSaleorderno.SelectionChangeCommitted
        Try
            If Me.CmbxSaleorderno.Items.Count > 0 Then
                CreateGridColumns()

            End If
        Catch ex As Exception
            fill_Xcmbx = False
        End Try
    End Sub

    Private Sub CmbxSaleorderno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSaleorderno.SelectedIndexChanged

    End Sub
End Class