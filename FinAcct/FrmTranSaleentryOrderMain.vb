Imports System.Data
Imports System.Data.SqlClient

Public Class FrmTranSaleentryOrderMain
    Inherits System.Windows.Forms.Form
    Dim SaleEntCmd As SqlCommand
    Dim SaleEntRdr As SqlDataReader
    Dim SaleEntAdptr As SqlDataAdapter
    Friend WithEvents LblTsale As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Dim SaleEntDtaset As DataSet

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents BtnSaleClose As System.Windows.Forms.Button
    Friend WithEvents BtnSaleFilter As System.Windows.Forms.Button
    Friend WithEvents BtnSaleFind As System.Windows.Forms.Button
    Friend WithEvents BtnSaleEdit As System.Windows.Forms.Button
    Friend WithEvents BtnSaleNew As System.Windows.Forms.Button
    Friend WithEvents DgSaleEntery As System.Windows.Forms.DataGridView
    Friend WithEvents ContxSaleentry As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranSaleentryOrderMain))
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.LblTsale = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnSaleClose = New System.Windows.Forms.Button
        Me.BtnSaleFilter = New System.Windows.Forms.Button
        Me.BtnSaleFind = New System.Windows.Forms.Button
        Me.BtnSaleEdit = New System.Windows.Forms.Button
        Me.BtnSaleNew = New System.Windows.Forms.Button
        Me.DgSaleEntery = New System.Windows.Forms.DataGridView
        Me.ContxSaleentry = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgSaleEntery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContxSaleentry.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BackgroundImage = Global.FinAcct.My.Resources.Resources.METALR6A
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Location = New System.Drawing.Point(-1, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(995, 73)
        Me.Panel4.TabIndex = 28
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 74)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Turquoise
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblTsale)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSaleClose)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSaleFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSaleFind)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSaleEdit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSaleNew)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgSaleEntery)
        Me.SplitContainer1.Size = New System.Drawing.Size(990, 483)
        Me.SplitContainer1.SplitterDistance = 150
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 29
        '
        'LblTsale
        '
        Me.LblTsale.BackColor = System.Drawing.Color.White
        Me.LblTsale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTsale.Location = New System.Drawing.Point(5, 23)
        Me.LblTsale.Name = "LblTsale"
        Me.LblTsale.Size = New System.Drawing.Size(141, 22)
        Me.LblTsale.TabIndex = 3
        Me.LblTsale.Text = "0.00"
        Me.LblTsale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Total Sale"
        '
        'BtnSaleClose
        '
        Me.BtnSaleClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaleClose.BackColor = System.Drawing.Color.Transparent
        Me.BtnSaleClose.BackgroundImage = CType(resources.GetObject("BtnSaleClose.BackgroundImage"), System.Drawing.Image)
        Me.BtnSaleClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSaleClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaleClose.FlatAppearance.BorderSize = 0
        Me.BtnSaleClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSaleClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaleClose.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaleClose.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnSaleClose.Location = New System.Drawing.Point(9, 440)
        Me.BtnSaleClose.Name = "BtnSaleClose"
        Me.BtnSaleClose.Size = New System.Drawing.Size(128, 33)
        Me.BtnSaleClose.TabIndex = 0
        Me.BtnSaleClose.Text = "&Close"
        Me.BtnSaleClose.UseVisualStyleBackColor = False
        '
        'BtnSaleFilter
        '
        Me.BtnSaleFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaleFilter.BackColor = System.Drawing.Color.Transparent
        Me.BtnSaleFilter.BackgroundImage = CType(resources.GetObject("BtnSaleFilter.BackgroundImage"), System.Drawing.Image)
        Me.BtnSaleFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSaleFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaleFilter.FlatAppearance.BorderSize = 0
        Me.BtnSaleFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSaleFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaleFilter.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaleFilter.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnSaleFilter.Location = New System.Drawing.Point(9, 402)
        Me.BtnSaleFilter.Name = "BtnSaleFilter"
        Me.BtnSaleFilter.Size = New System.Drawing.Size(128, 33)
        Me.BtnSaleFilter.TabIndex = 0
        Me.BtnSaleFilter.Text = "&Refresh"
        Me.BtnSaleFilter.UseVisualStyleBackColor = False
        '
        'BtnSaleFind
        '
        Me.BtnSaleFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaleFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnSaleFind.BackgroundImage = CType(resources.GetObject("BtnSaleFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnSaleFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSaleFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaleFind.FlatAppearance.BorderSize = 0
        Me.BtnSaleFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSaleFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaleFind.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaleFind.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnSaleFind.Location = New System.Drawing.Point(9, 364)
        Me.BtnSaleFind.Name = "BtnSaleFind"
        Me.BtnSaleFind.Size = New System.Drawing.Size(128, 33)
        Me.BtnSaleFind.TabIndex = 0
        Me.BtnSaleFind.Text = "&Find"
        Me.BtnSaleFind.UseVisualStyleBackColor = False
        '
        'BtnSaleEdit
        '
        Me.BtnSaleEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaleEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnSaleEdit.BackgroundImage = CType(resources.GetObject("BtnSaleEdit.BackgroundImage"), System.Drawing.Image)
        Me.BtnSaleEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSaleEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaleEdit.FlatAppearance.BorderSize = 0
        Me.BtnSaleEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSaleEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaleEdit.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaleEdit.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnSaleEdit.Location = New System.Drawing.Point(9, 326)
        Me.BtnSaleEdit.Name = "BtnSaleEdit"
        Me.BtnSaleEdit.Size = New System.Drawing.Size(128, 33)
        Me.BtnSaleEdit.TabIndex = 0
        Me.BtnSaleEdit.Text = "&Edit"
        Me.BtnSaleEdit.UseVisualStyleBackColor = False
        '
        'BtnSaleNew
        '
        Me.BtnSaleNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaleNew.BackColor = System.Drawing.Color.Transparent
        Me.BtnSaleNew.BackgroundImage = CType(resources.GetObject("BtnSaleNew.BackgroundImage"), System.Drawing.Image)
        Me.BtnSaleNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSaleNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaleNew.FlatAppearance.BorderSize = 0
        Me.BtnSaleNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSaleNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaleNew.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaleNew.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnSaleNew.Location = New System.Drawing.Point(9, 288)
        Me.BtnSaleNew.Name = "BtnSaleNew"
        Me.BtnSaleNew.Size = New System.Drawing.Size(128, 33)
        Me.BtnSaleNew.TabIndex = 0
        Me.BtnSaleNew.Text = "&New"
        Me.BtnSaleNew.UseVisualStyleBackColor = False
        '
        'DgSaleEntery
        '
        Me.DgSaleEntery.AllowUserToAddRows = False
        Me.DgSaleEntery.BackgroundColor = System.Drawing.Color.PaleTurquoise
        Me.DgSaleEntery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgSaleEntery.ContextMenuStrip = Me.ContxSaleentry
        Me.DgSaleEntery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgSaleEntery.GridColor = System.Drawing.Color.White
        Me.DgSaleEntery.Location = New System.Drawing.Point(0, 0)
        Me.DgSaleEntery.Name = "DgSaleEntery"
        Me.DgSaleEntery.Size = New System.Drawing.Size(836, 481)
        Me.DgSaleEntery.TabIndex = 0
        '
        'ContxSaleentry
        '
        Me.ContxSaleentry.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.ContxSaleentry.Name = "Contxpurentry"
        Me.ContxSaleentry.Size = New System.Drawing.Size(124, 114)
        Me.ContxSaleentry.Text = "&File"
        '
        'AddNewToolStripMenuItem
        '
        Me.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        Me.AddNewToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.AddNewToolStripMenuItem.Text = "&Add New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.EditToolStripMenuItem.Text = "Ed&it"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 22)
        Me.ToolStripMenuItem1.Text = "Fil&ter"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'FrmTranSaleentryOrderMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.MediumTurquoise
        Me.ClientSize = New System.Drawing.Size(994, 558)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranSaleentryOrderMain"
        Me.Text = "Sale Entry (Through Sale Order)"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgSaleEntery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContxSaleentry.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub BtnSaleNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaleNew.Click
        Dim FrmNped1 As New FrmTranSaleEntrySelectOrder
        FrmNped1.ShowInTaskbar = False
        FrmNped1.ShowDialog()

    End Sub
    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaleNew.GotFocus, BtnSaleClose.GotFocus _
  , BtnSaleEdit.GotFocus, BtnSaleFilter.GotFocus, BtnSaleFind.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaleClose.Leave, BtnSaleEdit.Leave _
    , BtnSaleFilter.Leave, BtnSaleFind.Leave, BtnSaleNew.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmTranSaleentryMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 40, Screen.PrimaryScreen.WorkingArea.Height - 80)
            Me.Top = 0
            Me.Left = 0

            fill_Saleentgridview()
            xSalxTotl()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub xSalxTotl()
        Try
            Dim xSale As Double = 0
            For Each xrW As DataGridViewRow In Me.DgSaleEntery.Rows
                xSale += xrW.Cells(6).Value
            Next
            Me.LblTsale.Text = FormatNumber(xSale, 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnSaleEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaleEdit.Click
        If Me.DgSaleEntery.SelectedRows.Count = 1 Then
            Dim frmEdit As New FrmTranSaleEnteryOrderEdit
            Selected_xInvoice_xId = Me.DgSaleEntery.SelectedRows(0).Cells(7).Value
            frmEdit.ShowInTaskbar = False
            frmEdit.ShowDialog()
        End If

    End Sub
    Public Sub fill_Saleentgridview()
        Dim temp As String = ""
        Try
            SaleEntCmd = New SqlCommand("Finact_Saleentry_order_Select", FinActConn1)
            SaleEntCmd.CommandType = CommandType.StoredProcedure
            SaleEntCmd.Parameters.AddWithValue("@Saleentorderid", 0)
            SaleEntAdptr = New Data.SqlClient.SqlDataAdapter(SaleEntCmd)
            dtaset = New Data.DataSet()
            SaleEntAdptr.Fill(dtaset, "finactSaleentry")
            Me.DgSaleEntery.DataSource = dtaset.Tables("FinactSaleentry")
            Me.DgSaleEntery.Columns(0).HeaderText = "Date"
            Me.DgSaleEntery.Columns(0).Width = 95
            Me.DgSaleEntery.Columns(0).DefaultCellStyle.ForeColor = Color.Navy
            Me.DgSaleEntery.Columns(0).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgSaleEntery.Columns(0).DefaultCellStyle.Format = "dd/MM/yyyy"
            Me.DgSaleEntery.Columns(1).HeaderText = "Invoice No."
            Me.DgSaleEntery.Columns(1).Width = 80
            Me.DgSaleEntery.Columns(2).HeaderText = "Due Date"
            Me.DgSaleEntery.Columns(2).Width = 95
            Me.DgSaleEntery.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
            Me.DgSaleEntery.Columns(3).HeaderText = "InvoiceStatus"
            Me.DgSaleEntery.Columns(3).Width = 100
            Me.DgSaleEntery.Columns(4).HeaderText = "Customer Id"
            Me.DgSaleEntery.Columns(4).Width = 0
            Me.DgSaleEntery.Columns(4).Visible = False
            Me.DgSaleEntery.Columns(5).HeaderText = "Customer Name"
            Me.DgSaleEntery.Columns(5).Width = 240
            Me.DgSaleEntery.Columns(6).HeaderText = "Amount"
            Me.DgSaleEntery.Columns(6).Width = 120
            Me.DgSaleEntery.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DgSaleEntery.Columns(6).DefaultCellStyle.Format = "N2"
            Me.DgSaleEntery.Columns(6).DefaultCellStyle.ForeColor = Color.Navy
            Me.DgSaleEntery.Columns(6).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgSaleEntery.Columns(7).HeaderText = "Invoice Id"
            Me.DgSaleEntery.Columns(7).Width = 0
            Me.DgSaleEntery.Columns(7).Visible = False
            Me.DgSaleEntery.ReadOnly = True
            Me.DgSaleEntery.MultiSelect = False
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            SaleEntCmd.Dispose()
            SaleEntAdptr.Dispose()
        End Try
    End Sub


    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Me.DgSaleEntery.Rows.Count > 0 Then
            If Me.DgSaleEntery.SelectedRows.Count = 1 Then
                If Trim(Me.DgSaleEntery.CurrentRow.Cells(3).Value) = "Cancelled" Or Trim(Me.DgSaleEntery.CurrentRow.Cells(3).Value) = "Worksheet" Then
                    Try
                        Dim Delid As Integer = Me.DgSaleEntery.SelectedRows(0).Cells(7).Value
                        SaleEntCmd = New SqlCommand("Delete from finactSaleorder where Saleid=@pid", FinActConn)
                        SaleEntCmd.Parameters.AddWithValue("@pid", Delid)
                        SaleEntCmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Sub
                    Finally
                        SaleEntCmd.Dispose()
                    End Try
                    Try
                        Dim Delid As Integer = Me.DgSaleEntery.SelectedRows(0).Cells(7).Value
                        SaleEntCmd = New SqlCommand("Delete from finactSaleorder_details where dSaleconcrnid=@pid1", FinActConn)
                        SaleEntCmd.Parameters.AddWithValue("@pid1", Delid)
                        SaleEntCmd.ExecuteNonQuery()
                        MsgBox("Current item has been successfully deleted", MsgBoxStyle.Information, "Order and Details Deleting")
                        Me.DgSaleEntery.Rows.Remove(Me.DgSaleEntery.CurrentRow)
                        Me.DgSaleEntery.Focus()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        SaleEntCmd.Dispose()
                    End Try
                Else
                    MsgBox("Invalid action! System found currently selected item has one or more relations", MsgBoxStyle.Critical, "Used item")
                    Me.DgSaleEntery.Focus()
                End If
            Else
                MsgBox("Invalid action!, System could not found any selected item", MsgBoxStyle.Critical, "Selecting Error!!!!")
                Me.DgSaleEntery.Focus()
            End If
        Else
            'Me.ContxPSaleent.Visible = False
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripMenuItem.Click
        Me.BtnSaleNew_Click(sender, e)
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Me.BtnSaleEdit_Click(sender, e)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Me.BtnSaleFilter_Click(sender, e)
    End Sub

    Private Sub BtnSaleFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaleFilter.Click
        'code to be write here, so  don't delete it.
        Try
            fill_Saleentgridview()
            xSalxTotl()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSaleClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaleClose.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
