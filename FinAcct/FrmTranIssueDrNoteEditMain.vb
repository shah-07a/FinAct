Imports System.Data
Imports System.Data.SqlClient

Public Class FrmTranIssueDrNoteEditMain
    Inherits System.Windows.Forms.Form
    Dim SaleEntCmd As SqlCommand
    Dim SaleEntRdr As SqlDataReader
    Dim SaleEntAdptr As SqlDataAdapter
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
    Friend WithEvents DgSaleEntery As System.Windows.Forms.DataGridView
    Friend WithEvents Contxpurentry As System.Windows.Forms.ContextMenuStrip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranIssueDrNoteEditMain))
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.BtnSaleClose = New System.Windows.Forms.Button
        Me.BtnSaleFilter = New System.Windows.Forms.Button
        Me.BtnSaleFind = New System.Windows.Forms.Button
        Me.BtnSaleEdit = New System.Windows.Forms.Button
        Me.DgSaleEntery = New System.Windows.Forms.DataGridView
        Me.Contxpurentry = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgSaleEntery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Contxpurentry.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BackgroundImage = Global.FinAcct.My.Resources.Resources.Nights9559hb1
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSaleClose)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSaleFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSaleFind)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSaleEdit)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgSaleEntery)
        Me.SplitContainer1.Size = New System.Drawing.Size(990, 483)
        Me.SplitContainer1.SplitterDistance = 150
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 29
        '
        'BtnSaleClose
        '
        Me.BtnSaleClose.BackColor = System.Drawing.Color.Transparent
        Me.BtnSaleClose.BackgroundImage = CType(resources.GetObject("BtnSaleClose.BackgroundImage"), System.Drawing.Image)
        Me.BtnSaleClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSaleClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaleClose.FlatAppearance.BorderSize = 0
        Me.BtnSaleClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSaleClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaleClose.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaleClose.ForeColor = System.Drawing.Color.Navy
        Me.BtnSaleClose.Location = New System.Drawing.Point(9, 440)
        Me.BtnSaleClose.Name = "BtnSaleClose"
        Me.BtnSaleClose.Size = New System.Drawing.Size(133, 33)
        Me.BtnSaleClose.TabIndex = 0
        Me.BtnSaleClose.Text = "&Close"
        Me.BtnSaleClose.UseVisualStyleBackColor = False
        '
        'BtnSaleFilter
        '
        Me.BtnSaleFilter.BackColor = System.Drawing.Color.Transparent
        Me.BtnSaleFilter.BackgroundImage = CType(resources.GetObject("BtnSaleFilter.BackgroundImage"), System.Drawing.Image)
        Me.BtnSaleFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSaleFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaleFilter.FlatAppearance.BorderSize = 0
        Me.BtnSaleFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSaleFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaleFilter.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaleFilter.ForeColor = System.Drawing.Color.Navy
        Me.BtnSaleFilter.Location = New System.Drawing.Point(9, 402)
        Me.BtnSaleFilter.Name = "BtnSaleFilter"
        Me.BtnSaleFilter.Size = New System.Drawing.Size(133, 33)
        Me.BtnSaleFilter.TabIndex = 0
        Me.BtnSaleFilter.Text = "&Refresh "
        Me.BtnSaleFilter.UseVisualStyleBackColor = False
        '
        'BtnSaleFind
        '
        Me.BtnSaleFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnSaleFind.BackgroundImage = CType(resources.GetObject("BtnSaleFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnSaleFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSaleFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaleFind.FlatAppearance.BorderSize = 0
        Me.BtnSaleFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSaleFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaleFind.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaleFind.ForeColor = System.Drawing.Color.Navy
        Me.BtnSaleFind.Location = New System.Drawing.Point(9, 364)
        Me.BtnSaleFind.Name = "BtnSaleFind"
        Me.BtnSaleFind.Size = New System.Drawing.Size(133, 33)
        Me.BtnSaleFind.TabIndex = 0
        Me.BtnSaleFind.Text = "&Find"
        Me.BtnSaleFind.UseVisualStyleBackColor = False
        '
        'BtnSaleEdit
        '
        Me.BtnSaleEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnSaleEdit.BackgroundImage = CType(resources.GetObject("BtnSaleEdit.BackgroundImage"), System.Drawing.Image)
        Me.BtnSaleEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSaleEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaleEdit.FlatAppearance.BorderSize = 0
        Me.BtnSaleEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnSaleEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaleEdit.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaleEdit.ForeColor = System.Drawing.Color.Navy
        Me.BtnSaleEdit.Location = New System.Drawing.Point(9, 326)
        Me.BtnSaleEdit.Name = "BtnSaleEdit"
        Me.BtnSaleEdit.Size = New System.Drawing.Size(133, 33)
        Me.BtnSaleEdit.TabIndex = 0
        Me.BtnSaleEdit.Text = "&Edit"
        Me.BtnSaleEdit.UseVisualStyleBackColor = False
        '
        'DgSaleEntery
        '
        Me.DgSaleEntery.AllowUserToAddRows = False
        Me.DgSaleEntery.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.DgSaleEntery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgSaleEntery.ContextMenuStrip = Me.Contxpurentry
        Me.DgSaleEntery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgSaleEntery.Location = New System.Drawing.Point(0, 0)
        Me.DgSaleEntery.Name = "DgSaleEntery"
        Me.DgSaleEntery.Size = New System.Drawing.Size(836, 481)
        Me.DgSaleEntery.TabIndex = 0
        '
        'Contxpurentry
        '
        Me.Contxpurentry.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.Contxpurentry.Name = "Contxpurentry"
        Me.Contxpurentry.Size = New System.Drawing.Size(139, 92)
        Me.Contxpurentry.Text = "&File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItem1.Text = "Refresh Grid"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'FrmTranIssueDrNoteEditMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.ClientSize = New System.Drawing.Size(994, 558)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranIssueDrNoteEditMain"
        Me.Text = "Item(s) Rejected/Received Back Alter Section"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgSaleEntery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Contxpurentry.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub FrmTranSaleentryMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.TopMost = True
            fill_Saleentgridview()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSaleEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaleEdit.Click
        If Me.DgSaleEntery.SelectedRows.Count = 1 Then
            Try
                Selected_xInvoice_xId = Me.DgSaleEntery.SelectedRows(0).Cells(6).Value
                SBRType = Trim(Me.DgSaleEntery.SelectedRows(0).Cells(2).Value)
                Dim FrmIDNE As New FrmTranIssueDrNoteEdit
                FrmIDNE.ShowInTaskbar = False
                FrmIDNE.ShowDialog()
            Catch ex As Exception

            End Try
        End If

    End Sub
    Public Sub fill_Saleentgridview()
        Dim temp As String = ""
        Try
            SaleEntCmd = New SqlCommand("Finact_SBR_entry_Select", FinActConn1)
            SaleEntCmd.CommandType = CommandType.StoredProcedure
            ''SaleEntCmd.Parameters.AddWithValue("@SBR_entorderid", 0)
            SaleEntAdptr = New Data.SqlClient.SqlDataAdapter(SaleEntCmd)
            dtaset = New Data.DataSet()
            SaleEntAdptr.Fill(dtaset, "finactSaleentry")
            Me.DgSaleEntery.DataSource = dtaset.Tables("FinactSaleentry")
            Me.DgSaleEntery.Columns(0).HeaderText = "Date"
            Me.DgSaleEntery.Columns(0).Width = 125
            Me.DgSaleEntery.Columns(0).DefaultCellStyle.ForeColor = Color.Navy
            Me.DgSaleEntery.Columns(0).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgSaleEntery.Columns(0).DefaultCellStyle.Format = "dd/MM/yyyy"
            Me.DgSaleEntery.Columns(1).HeaderText = "Invoice No."
            Me.DgSaleEntery.Columns(1).Width = 100
            Me.DgSaleEntery.Columns(2).HeaderText = "InvoiceStatus"
            Me.DgSaleEntery.Columns(2).Width = 125
            Me.DgSaleEntery.Columns(3).HeaderText = "Customer Id"
            Me.DgSaleEntery.Columns(3).Width = 0
            Me.DgSaleEntery.Columns(3).Visible = False
            Me.DgSaleEntery.Columns(4).HeaderText = "Customer Name"
            Me.DgSaleEntery.Columns(4).Width = 290
            Me.DgSaleEntery.Columns(5).HeaderText = "Amount"
            Me.DgSaleEntery.Columns(5).Width = 150
            Me.DgSaleEntery.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DgSaleEntery.Columns(5).DefaultCellStyle.Format = "N2"
            Me.DgSaleEntery.Columns(5).DefaultCellStyle.ForeColor = Color.Navy
            Me.DgSaleEntery.Columns(5).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgSaleEntery.Columns(6).HeaderText = "Invoice Id"
            Me.DgSaleEntery.Columns(6).Width = 0
            Me.DgSaleEntery.Columns(6).Visible = False
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
                Try
                    If MessageBox.Show("Are you sure to delete current record?", "Deleting Confirmation!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                      
                        Dim Delid As Integer = Me.DgSaleEntery.SelectedRows(0).Cells(6).Value
                        If xxVATrtrnStatus("SBR_Entid", "SBRVATrtrnFlg", Delid, "FinactSaleItemBackRecdEntry") = True Then
                            MsgBox("System can't delete current record as it has a relation with VAT Return alreaded Filed", MsgBoxStyle.Critical, "See VAT Return")
                            Exit Sub
                        Else
                            If FinActConn.State Then FinActConn.Close()
                            FinActConn.Open()
                            SaleEntCmd = New SqlCommand("Finact_SBR_DelFromAllTableAttached_Delete", FinActConn)
                            SaleEntCmd.CommandType = CommandType.StoredProcedure
                            SaleEntCmd.Parameters.AddWithValue("@ConIdxx", Delid)
                            SaleEntCmd.ExecuteNonQuery()
                            MsgBox("Current item has been successfully deleted", MsgBoxStyle.Information, "Order and Details Deleting")
                            Me.DgSaleEntery.Rows.Remove(Me.DgSaleEntery.CurrentRow)
                            Me.DgSaleEntery.Focus()
                        End If
                    Else
                        Return
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    SaleEntCmd.Dispose()
                End Try

            Else
                MsgBox("Invalid action!, System could not found any selected item", MsgBoxStyle.Critical, "Selecting Error!!!!")
                Me.DgSaleEntery.Focus()
            End If
        End If


    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Me.BtnSaleEdit_Click(sender, e)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Me.BtnSaleFilter_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSaleFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaleFilter.Click
        Try
            fill_Saleentgridview()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnSaleClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaleClose.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaleEdit.GotFocus, BtnSaleClose.GotFocus _
    , BtnSaleFilter.GotFocus, BtnSaleFind.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaleClose.Leave, BtnSaleEdit.Leave _
    , BtnSaleFilter.Leave, BtnSaleFind.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent

        Catch ex As Exception

        End Try
    End Sub
End Class
