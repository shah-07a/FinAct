Imports System.Data
Imports System.Data.SqlClient

Public Class FrmTranPurentryOrderMain
    Inherits System.Windows.Forms.Form
    Dim PurEntCmd As SqlCommand
    Dim PurEntRdr As SqlDataReader
    Dim PurEntAdptr As SqlDataAdapter
    Friend WithEvents LblTtlpur As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblTPur As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Dim PurEntDtaset As DataSet

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
    Friend WithEvents BtnPurClose As System.Windows.Forms.Button
    Friend WithEvents BtnPurFilter As System.Windows.Forms.Button
    Friend WithEvents BtnPurFind As System.Windows.Forms.Button
    Friend WithEvents BtnPurEdit As System.Windows.Forms.Button
    Friend WithEvents BtnPurNew As System.Windows.Forms.Button
    Friend WithEvents DgPurEntery As System.Windows.Forms.DataGridView
    Friend WithEvents Contxpurentry As System.Windows.Forms.ContextMenuStrip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranPurentryOrderMain))
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.LblTPur = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnPurClose = New System.Windows.Forms.Button
        Me.BtnPurFilter = New System.Windows.Forms.Button
        Me.BtnPurFind = New System.Windows.Forms.Button
        Me.BtnPurEdit = New System.Windows.Forms.Button
        Me.BtnPurNew = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblTtlpur = New System.Windows.Forms.Label
        Me.DgPurEntery = New System.Windows.Forms.DataGridView
        Me.Contxpurentry = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgPurEntery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Contxpurentry.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackgroundImage = Global.FinAcct.My.Resources.Resources._728x90_winning1
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Navy
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblTPur)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPurClose)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPurFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPurFind)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPurEdit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPurNew)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LblTtlpur)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgPurEntery)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Panel2.ForeColor = System.Drawing.Color.Black
        Me.SplitContainer1.Size = New System.Drawing.Size(990, 483)
        Me.SplitContainer1.SplitterDistance = 150
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 29
        '
        'LblTPur
        '
        Me.LblTPur.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.LblTPur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTPur.Location = New System.Drawing.Point(9, 27)
        Me.LblTPur.Name = "LblTPur"
        Me.LblTPur.Size = New System.Drawing.Size(128, 22)
        Me.LblTPur.TabIndex = 7
        Me.LblTPur.Text = "0.00"
        Me.LblTPur.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Total Purchase"
        '
        'BtnPurClose
        '
        Me.BtnPurClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPurClose.BackgroundImage = CType(resources.GetObject("BtnPurClose.BackgroundImage"), System.Drawing.Image)
        Me.BtnPurClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPurClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPurClose.FlatAppearance.BorderSize = 0
        Me.BtnPurClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPurClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPurClose.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPurClose.ForeColor = System.Drawing.Color.Navy
        Me.BtnPurClose.Location = New System.Drawing.Point(9, 440)
        Me.BtnPurClose.Name = "BtnPurClose"
        Me.BtnPurClose.Size = New System.Drawing.Size(128, 33)
        Me.BtnPurClose.TabIndex = 0
        Me.BtnPurClose.Text = "&Close"
        Me.BtnPurClose.UseVisualStyleBackColor = True
        '
        'BtnPurFilter
        '
        Me.BtnPurFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPurFilter.BackgroundImage = CType(resources.GetObject("BtnPurFilter.BackgroundImage"), System.Drawing.Image)
        Me.BtnPurFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPurFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPurFilter.FlatAppearance.BorderSize = 0
        Me.BtnPurFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPurFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPurFilter.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPurFilter.ForeColor = System.Drawing.Color.Navy
        Me.BtnPurFilter.Location = New System.Drawing.Point(9, 402)
        Me.BtnPurFilter.Name = "BtnPurFilter"
        Me.BtnPurFilter.Size = New System.Drawing.Size(128, 33)
        Me.BtnPurFilter.TabIndex = 0
        Me.BtnPurFilter.Text = "&Refresh"
        Me.BtnPurFilter.UseVisualStyleBackColor = True
        '
        'BtnPurFind
        '
        Me.BtnPurFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPurFind.BackgroundImage = CType(resources.GetObject("BtnPurFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnPurFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPurFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPurFind.FlatAppearance.BorderSize = 0
        Me.BtnPurFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPurFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPurFind.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPurFind.ForeColor = System.Drawing.Color.Navy
        Me.BtnPurFind.Location = New System.Drawing.Point(9, 364)
        Me.BtnPurFind.Name = "BtnPurFind"
        Me.BtnPurFind.Size = New System.Drawing.Size(128, 33)
        Me.BtnPurFind.TabIndex = 0
        Me.BtnPurFind.Text = "&Find"
        Me.BtnPurFind.UseVisualStyleBackColor = True
        '
        'BtnPurEdit
        '
        Me.BtnPurEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPurEdit.BackgroundImage = CType(resources.GetObject("BtnPurEdit.BackgroundImage"), System.Drawing.Image)
        Me.BtnPurEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPurEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPurEdit.FlatAppearance.BorderSize = 0
        Me.BtnPurEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPurEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPurEdit.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPurEdit.ForeColor = System.Drawing.Color.Navy
        Me.BtnPurEdit.Location = New System.Drawing.Point(9, 326)
        Me.BtnPurEdit.Name = "BtnPurEdit"
        Me.BtnPurEdit.Size = New System.Drawing.Size(128, 33)
        Me.BtnPurEdit.TabIndex = 0
        Me.BtnPurEdit.Text = "&Edit"
        Me.BtnPurEdit.UseVisualStyleBackColor = True
        '
        'BtnPurNew
        '
        Me.BtnPurNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPurNew.BackgroundImage = CType(resources.GetObject("BtnPurNew.BackgroundImage"), System.Drawing.Image)
        Me.BtnPurNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPurNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPurNew.FlatAppearance.BorderSize = 0
        Me.BtnPurNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnPurNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPurNew.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPurNew.ForeColor = System.Drawing.Color.Navy
        Me.BtnPurNew.Location = New System.Drawing.Point(9, 288)
        Me.BtnPurNew.Name = "BtnPurNew"
        Me.BtnPurNew.Size = New System.Drawing.Size(128, 33)
        Me.BtnPurNew.TabIndex = 0
        Me.BtnPurNew.Text = "&New"
        Me.BtnPurNew.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(623, 461)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Total >"
        '
        'LblTtlpur
        '
        Me.LblTtlpur.BackColor = System.Drawing.Color.White
        Me.LblTtlpur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTtlpur.Location = New System.Drawing.Point(685, 459)
        Me.LblTtlpur.Name = "LblTtlpur"
        Me.LblTtlpur.Size = New System.Drawing.Size(150, 20)
        Me.LblTtlpur.TabIndex = 1
        Me.LblTtlpur.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgPurEntery
        '
        Me.DgPurEntery.AllowUserToAddRows = False
        Me.DgPurEntery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgPurEntery.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.DgPurEntery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgPurEntery.ContextMenuStrip = Me.Contxpurentry
        Me.DgPurEntery.Location = New System.Drawing.Point(0, 0)
        Me.DgPurEntery.Name = "DgPurEntery"
        Me.DgPurEntery.Size = New System.Drawing.Size(836, 477)
        Me.DgPurEntery.TabIndex = 0
        '
        'Contxpurentry
        '
        Me.Contxpurentry.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.Contxpurentry.Name = "Contxpurentry"
        Me.Contxpurentry.Size = New System.Drawing.Size(139, 114)
        Me.Contxpurentry.Text = "&File"
        '
        'AddNewToolStripMenuItem
        '
        Me.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        Me.AddNewToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.AddNewToolStripMenuItem.Text = "Add New"
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
        'FrmTranPurentryOrderMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Navy
        Me.ClientSize = New System.Drawing.Size(994, 558)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranPurentryOrderMain"
        Me.Text = "Purchase Entry (Through Purchase Order)"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgPurEntery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Contxpurentry.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub FrmPurentry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnPurNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPurNew.Click
        Dim FrmNped1 As New FrmTranPurEntrySelectOrder
        FrmNped1.ShowInTaskbar = False
        FrmNped1.ShowDialog()

    End Sub

    Private Sub FrmTranPurentryMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fill_Purentgridview()
            xPurxTotl()
            Me.Top = 0
            Me.Left = 0
            Me.Size = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, Screen.PrimaryScreen.WorkingArea.Height - 80)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xPurxTotl()
        Try
            Dim xPur As Double = 0
            For Each xrW As DataGridViewRow In Me.DgPurEntery.Rows
                xPur += xrW.Cells(6).Value
            Next
            Me.LblTPur.Text = FormatNumber(xPur, 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnPurEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPurEdit.Click
        If Me.DgPurEntery.SelectedRows.Count = 1 Then
            Dim frmEdit As New FrmTranPurEnteryOrderEdit
            Selected_xInvoice_xId = Me.DgPurEntery.SelectedRows(0).Cells(7).Value
            frmEdit.ShowInTaskbar = False
            frmEdit.ShowDialog()
        End If

    End Sub
    Public Sub fill_Purentgridview()
        Dim temp As String = ""
        Try
            PurEntCmd = New SqlCommand("Finact_purentry_order_Select", FinActConn1)
            PurEntCmd.CommandType = CommandType.StoredProcedure
            PurEntCmd.Parameters.AddWithValue("@Purentorderid", 0)
            PurEntAdptr = New Data.SqlClient.SqlDataAdapter(PurEntCmd)
            dtaset = New Data.DataSet()
            PurEntAdptr.Fill(dtaset, "finactpurentry")
            Me.DgPurEntery.DataSource = dtaset.Tables("Finactpurentry")
            Me.DgPurEntery.Columns(0).HeaderText = "Date"
            Me.DgPurEntery.Columns(0).Width = 95
            Me.DgPurEntery.Columns(0).DefaultCellStyle.ForeColor = Color.Navy
            Me.DgPurEntery.Columns(0).DefaultCellStyle.BackColor = Color.Cyan
            Me.DgPurEntery.Columns(0).DefaultCellStyle.Format = "dd/MM/yyyy"
            Me.DgPurEntery.Columns(1).HeaderText = "Invoice No."
            Me.DgPurEntery.Columns(1).Width = 80
            Me.DgPurEntery.Columns(2).HeaderText = "Due Date"
            Me.DgPurEntery.Columns(2).Width = 95
            Me.DgPurEntery.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
            Me.DgPurEntery.Columns(3).HeaderText = "InvoiceStatus"
            Me.DgPurEntery.Columns(3).Width = 120
            Me.DgPurEntery.Columns(4).HeaderText = "Vendor Id"
            Me.DgPurEntery.Columns(4).Width = 0
            Me.DgPurEntery.Columns(4).Visible = False
            Me.DgPurEntery.Columns(5).HeaderText = "Vendor Name"
            Me.DgPurEntery.Columns(5).Width = 240
            Me.DgPurEntery.Columns(6).HeaderText = "Amount"
            Me.DgPurEntery.Columns(6).Width = 130
            Me.DgPurEntery.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DgPurEntery.Columns(6).DefaultCellStyle.Format = "N2"
            Me.DgPurEntery.Columns(6).DefaultCellStyle.ForeColor = Color.Navy
            Me.DgPurEntery.Columns(6).DefaultCellStyle.BackColor = Color.LightCyan
            Me.DgPurEntery.Columns(7).HeaderText = "Invoice Id"
            Me.DgPurEntery.Columns(7).Width = 0
            Me.DgPurEntery.Columns(7).Visible = False
            Me.DgPurEntery.ReadOnly = True
            Me.DgPurEntery.MultiSelect = False
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            PurEntCmd.Dispose()
            PurEntAdptr.Dispose()
            Dim PurTtl As Double = 0
            If Me.DgPurEntery.Rows.Count > 0 Then
                For Each rw As DataGridViewRow In Me.DgPurEntery.Rows
                    PurTtl += rw.Cells(6).Value
                Next
            End If
            Me.LblTtlpur.Text = FormatNumber(PurTtl, 2)
        End Try
    End Sub


    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Me.DgPurEntery.Rows.Count > 0 Then
            Dim xPOid As Integer = 0
            If Me.DgPurEntery.SelectedRows.Count = 1 Then
                If MessageBox.Show("It is strognly suggested not to delete entry(ies). Are you sure to delete current record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim Delid As Integer = Me.DgPurEntery.SelectedRows(0).Cells(7).Value
                        PurEntCmd = New SqlCommand("Finact_DelEntry_PurEntry_PurOrder", FinActConn)
                        PurEntCmd.CommandType = CommandType.StoredProcedure
                        PurEntCmd.Parameters.AddWithValue("@xpurentid", CInt(Delid))
                        PurEntRdr = PurEntCmd.ExecuteReader
                        While PurEntRdr.Read
                            If PurEntRdr("xMessage") = True Then
                                MsgBox("Access denied!, system could not delete current record.", MsgBoxStyle.Critical, "Relationship Developed")
                            Else
                                MsgBox("Current item has been successfully deleted", MsgBoxStyle.Information, Me.Text)
                                Me.DgPurEntery.Rows.Remove(Me.DgPurEntery.CurrentRow)
                                Me.DgPurEntery.Focus()

                            End If
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Sub
                    Finally
                        PurEntCmd.Dispose()
                        PurEntRdr.Close()
                    End Try
                  
                Else
                    Return
                End If
            Else
                Me.DgPurEntery.Focus()
            End If
   
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripMenuItem.Click
        Me.BtnPurNew_Click(sender, e)
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Me.BtnPurEdit_Click(sender, e)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Me.BtnPurFilter_Click(sender, e)
    End Sub

    Private Sub BtnPurFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPurFilter.Click
        Try
            fill_Purentgridview()
            xPurxTotl()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPurClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPurClose.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPurNew.GotFocus, BtnPurClose.GotFocus _
    , BtnPurEdit.GotFocus, BtnPurFilter.GotFocus, BtnPurFind.GotFocus
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Yellow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAllx_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPurClose.Leave, BtnPurEdit.Leave _
    , BtnPurFilter.Leave, BtnPurFind.Leave, BtnPurNew.Leave
        Try
            Dim xBtn As Button = CType(sender, Button)
            xBtn.BackColor = Color.Transparent
        Catch ex As Exception

        End Try
    End Sub
End Class
