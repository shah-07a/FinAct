Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmStokgrup
    Inherits System.Windows.Forms.Form
    Dim StokGNamCmd As SqlCommand
    Dim StokGNamCmd1 As SqlCommand
    Dim StokGNamRdr As SqlDataReader
    Dim StkIndx, Prvusrid As Integer
    Dim Editid As Integer = 0
    Dim DelStatus As Integer = 0
    Dim Delid As Integer = 0
    Dim Grpid As Integer = 0

    Dim AcGdgr As DataGridViewRow
    Dim AcGcel As DataGridViewTextBoxCell
    Dim AcGcom As DataGridViewComboBoxCell
    Dim sql As inv_sql
    Dim sql1 As inv_sql
    Dim Flagcelval, FlagCelVal1, FlagCelVal2, FlagCelVal3 As String
    Dim FlagEditAllow As Boolean
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbxAgp As System.Windows.Forms.ComboBox
    Friend WithEvents CmbxGrplst As System.Windows.Forms.ComboBox
    Friend WithEvents dGacgrup As System.Windows.Forms.DataGridView
    Friend WithEvents lstvew1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Dim FindStkgrup As String = ""

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents Btnedit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStokgrup))
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Btnsave = New System.Windows.Forms.Button
        Me.Btndel = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.Btnedit = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dGacgrup = New System.Windows.Forms.DataGridView
        Me.lstvew1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.CmbxAgp = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbxGrplst = New System.Windows.Forms.ComboBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dGacgrup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtName
        '
        Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(130, 4)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(431, 22)
        Me.TxtName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Name :-"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(4, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Under Group :-"
        '
        'Btnsave
        '
        Me.Btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnsave.BackColor = System.Drawing.Color.Transparent
        Me.Btnsave.BackgroundImage = CType(resources.GetObject("Btnsave.BackgroundImage"), System.Drawing.Image)
        Me.Btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnsave.FlatAppearance.BorderSize = 0
        Me.Btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnsave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnsave.ForeColor = System.Drawing.Color.Navy
        Me.Btnsave.Location = New System.Drawing.Point(6, 183)
        Me.Btnsave.Name = "Btnsave"
        Me.Btnsave.Size = New System.Drawing.Size(128, 33)
        Me.Btnsave.TabIndex = 3
        Me.Btnsave.Text = "&Save"
        Me.Btnsave.UseVisualStyleBackColor = False
        '
        'Btndel
        '
        Me.Btndel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btndel.BackColor = System.Drawing.Color.Transparent
        Me.Btndel.BackgroundImage = CType(resources.GetObject("Btndel.BackgroundImage"), System.Drawing.Image)
        Me.Btndel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btndel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btndel.FlatAppearance.BorderSize = 0
        Me.Btndel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btndel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btndel.ForeColor = System.Drawing.Color.Navy
        Me.Btndel.Location = New System.Drawing.Point(6, 261)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(128, 33)
        Me.Btndel.TabIndex = 5
        Me.Btndel.Text = "Ca&ncel"
        Me.Btndel.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClos.BackColor = System.Drawing.Color.Transparent
        Me.BtnClos.BackgroundImage = CType(resources.GetObject("BtnClos.BackgroundImage"), System.Drawing.Image)
        Me.BtnClos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClos.FlatAppearance.BorderSize = 0
        Me.BtnClos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BtnClos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClos.ForeColor = System.Drawing.Color.Navy
        Me.BtnClos.Location = New System.Drawing.Point(6, 300)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(128, 33)
        Me.BtnClos.TabIndex = 6
        Me.BtnClos.Text = "&Close"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'Btnedit
        '
        Me.Btnedit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btnedit.BackColor = System.Drawing.Color.Transparent
        Me.Btnedit.BackgroundImage = CType(resources.GetObject("Btnedit.BackgroundImage"), System.Drawing.Image)
        Me.Btnedit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnedit.FlatAppearance.BorderSize = 0
        Me.Btnedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnedit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnedit.ForeColor = System.Drawing.Color.Navy
        Me.Btnedit.Location = New System.Drawing.Point(6, 222)
        Me.Btnedit.Name = "Btnedit"
        Me.Btnedit.Size = New System.Drawing.Size(128, 33)
        Me.Btnedit.TabIndex = 4
        Me.Btnedit.Text = "&Find"
        Me.Btnedit.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackgroundImage = Global.FinAcct.My.Resources.Resources.BRICKV7A
        Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer1.Panel1.Controls.Add(Me.dGacgrup)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnClos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btndel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btnedit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btnsave)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.LightBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.lstvew1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(729, 356)
        Me.SplitContainer1.SplitterDistance = 142
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 29
        Me.SplitContainer1.TabStop = False
        '
        'dGacgrup
        '
        Me.dGacgrup.AllowUserToDeleteRows = False
        Me.dGacgrup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGacgrup.Location = New System.Drawing.Point(9, 37)
        Me.dGacgrup.Name = "dGacgrup"
        Me.dGacgrup.Size = New System.Drawing.Size(117, 38)
        Me.dGacgrup.TabIndex = 16
        Me.dGacgrup.Visible = False
        '
        'lstvew1
        '
        Me.lstvew1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstvew1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstvew1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstvew1.FullRowSelect = True
        Me.lstvew1.GridLines = True
        Me.lstvew1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstvew1.Location = New System.Drawing.Point(133, 166)
        Me.lstvew1.Name = "lstvew1"
        Me.lstvew1.Size = New System.Drawing.Size(386, 169)
        Me.lstvew1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstvew1.TabIndex = 44
        Me.lstvew1.TabStop = False
        Me.lstvew1.UseCompatibleStateImageBehavior = False
        Me.lstvew1.View = System.Windows.Forms.View.Details
        Me.lstvew1.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 350
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Id"
        Me.ColumnHeader2.Width = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.10526!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.89474!))
        Me.TableLayoutPanel1.Controls.Add(Me.CmbxAgp, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbxGrplst, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(571, 152)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CmbxAgp
        '
        Me.CmbxAgp.BackColor = System.Drawing.SystemColors.HighlightText
        Me.CmbxAgp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbxAgp.Enabled = False
        Me.CmbxAgp.ForeColor = System.Drawing.Color.Navy
        Me.CmbxAgp.Items.AddRange(New Object() {"Yes", "No"})
        Me.CmbxAgp.Location = New System.Drawing.Point(130, 154)
        Me.CmbxAgp.Name = "CmbxAgp"
        Me.CmbxAgp.Size = New System.Drawing.Size(171, 22)
        Me.CmbxAgp.TabIndex = 2
        Me.CmbxAgp.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 1)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Can Qnty. of Items be Added  ?"
        Me.Label5.Visible = False
        '
        'CmbxGrplst
        '
        Me.CmbxGrplst.Location = New System.Drawing.Point(130, 79)
        Me.CmbxGrplst.Name = "CmbxGrplst"
        Me.CmbxGrplst.Size = New System.Drawing.Size(431, 22)
        Me.CmbxGrplst.TabIndex = 1
        '
        'FrmStokgrup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(733, 359)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmStokgrup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Group"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dGacgrup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub FrmStokgrup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 0
            fill_prmgrplst()
            sql = New inv_sql
            sql1 = New inv_sql

            CheckAcess_Btn_frm(Btnsave, Btnedit, Btndel)
            CmbxGrplst.SelectedIndex = 0
            Me.CmbxAgp.SelectedIndex = 1
            ' Me.SplitContainer1.Panel1.Enabled = False
            Me.TxtName.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CheckAcess_Btn_frm(ByVal BtnnSave As Button, ByVal BtnnEdt As Button, _
       ByVal BtnnDel As Button)
        Select Case Trim(AcessRight)
            Case "OwnrFull"
                BtnnSave.Enabled = True
                BtnnEdt.Enabled = True
                BtnnDel.Enabled = True
            Case "DataEntryMstr"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(174, 261)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
            Case "PayRoll"
                BtnnSave.Enabled = True
                BtnnSave.Location = New System.Drawing.Point(174, 261)
                BtnnEdt.Visible = False
                BtnnDel.Visible = False
        End Select
    End Sub
    Private Sub SaveGrupName()
        Dim YesNo1, Grupid As Integer
        Try
            StokGNamCmd = New SqlCommand("select cogrpid,copconcrnprmid from finactstokgrupname where coprmtype='" & ("Stok") & "' and cogrupnam=@Gname", FinActConn)
            If CmbxGrplst.Text <> "" Then
                StokGNamCmd.Parameters.AddWithValue("@gname", CmbxGrplst.Text)
            Else
                Exit Sub
                Exit Try
            End If

            StokGNamCmd.CommandType = CommandType.Text
            StokGNamRdr = StokGNamCmd.ExecuteReader
            StokGNamRdr.Read()
            Grupid = StokGNamRdr("cogrpid")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            StokGNamCmd = Nothing
            StokGNamRdr.Close()
        End Try
        Try
            StokGNamCmd = New SqlCommand("Finact_stokGrupName_Insert", FinActConn)
            StokGNamCmd.CommandType = CommandType.StoredProcedure
            StokGNamCmd.Parameters.AddWithValue("@Cogrupnam", TxtName.Text)
            StokGNamCmd.Parameters.AddWithValue("@CoUndrgrup", Grupid)
            StokGNamCmd.Parameters.AddWithValue("@coptype", Trim("Stok"))
            StokGNamCmd.Parameters.AddWithValue("@copconid", Grupid)
            StokGNamCmd.Parameters.AddWithValue("@cobalhed", "Stok")
            If Trim(CmbxAgp.Text) = "Yes" Then
                YesNo1 = 1
            Else
                YesNo1 = 0
            End If


            StokGNamCmd.Parameters.AddWithValue("@CoAfect", YesNo1)
            StokGNamCmd.Parameters.AddWithValue("@coaddt", Now)
            StokGNamCmd.Parameters.AddWithValue("@coadusrid", Current_UsrId)
            StokGNamCmd.Parameters.AddWithValue("@coDelStatus", DelStatus) ' if record not deleted 0 for Deleted recor

            StokGNamCmd.ExecuteNonQuery()
            MsgBox("Current record has been successfully save", MsgBoxStyle.Information, "Group Name")
            If FrmShow_flag(1) = True Then  ' for stock item 
                StrUndrgrup = Trim(TxtName.Text)
            End If
            If FrmShow_flag(2) = True Then   ' for stock bom
                StrUndrgrup = Trim(TxtName.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        DelStatus = 1

        If Btnsave.Text = "&Save" Then
            Chk_Blnk()
            If StkIndx <> 0 Then
                StkIndx = 0
                Exit Sub
            Else
                Dim Txtstr As String = Trim(TxtName.Text)
                Chk_Exisit("finactStokgrupname", "cogrupnam", Txtstr)
                If xStr1.ToUpper.Equals(Txtstr.ToUpper) = True Then
                    MsgBox("Invalid input, system found a record with same value, try another value", MsgBoxStyle.Critical)
                    TxtName.Focus()
                    TxtName.SelectAll()
                    Exit Sub
                End If
                SaveGrupName()
                TxtName.Text = ""
                TxtName.Focus()
            End If
        ElseIf Btnsave.Text = "&Update" Then

            Delid = 0
            Editid = Current_UsrId
            GrupnamEdt()

        End If

    End Sub

    Private Sub Btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click

        If Btnedit.Text = "&Delete" Then
            dGacgrup.Visible = False
            Me.TableLayoutPanel1.Visible = True
            Me.Width = 739
            Me.Height = 387
            Me.SplitContainer1.SplitterDistance = 142
            Me.SplitContainer1.IsSplitterFixed = False

            Btnsave.Text = "&Save"
            Btnedit.Text = "&Find"
        End If
        'DelStatus = 0
        'Delid = Current_UsrId
        'Editid = 0
        'Chk_Blnk()
        'If StkIndx <> 0 Then
        '    StkIndx = 0
        '    Exit Sub
        'Else
        '    GrupnamEdt()
        '    Btnsave.Text = "&Save"
        '    TxtName.Text = ""
        '    TxtName.Focus()
        'End If

    End Sub
    Private Sub Chk_Blnk()
        With TxtName
            If .Text = "" Then
                .BackColor = Color.PapayaWhip
                .Focus()
                StkIndx += 1
            Else
                .BackColor = Color.White
            End If
        End With

        With CmbxGrplst
            If .SelectedIndex = -1 Then
                .Focus()
                StkIndx += 1
            End If
        End With
        With CmbxAgp
            If .Enabled = True Then
                If .SelectedIndex = -1 Then
                    .Focus()
                    StkIndx += 1
                End If
            End If

        End With

    End Sub

    Private Sub GrupnamEdt()
        Dim Xa As Integer
        Dim YesNo1, Grupid As Integer
        Dim dgcont As Integer = dGacgrup.Rows.Count - 1
        Dim dgcont1 As Integer = dGacgrup.CurrentRow.Index

        If dgcont = dgcont1 Then
            MsgBox("Invalid Input! System could not found any record to update", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        Xa = dGacgrup.SelectedRows.Count
        Try
            Dim Xi As Integer = 0
            If Xa > 0 Then
                For Xi = 0 To dGacgrup.SelectedRows.Count - 1
                    If FlagEditAllow = True Then
                        If validate_input() Then
                            MsgBox("Invalid input, system found a record with same value, try another value", MsgBoxStyle.Critical)
                            If Trim(FlagCelVal1) <> "" Then
                                Me.dGacgrup.SelectedRows(Xi).Cells(1).Value = (Trim(FlagCelVal1.ToUpper))
                            End If
                            If Trim(FlagCelVal2) <> "" Then
                                Me.dGacgrup.SelectedRows(Xi).Cells(2).Value = Trim(FlagCelVal2)
                            End If
                            If Trim(FlagCelVal3) <> "" Then
                                Me.dGacgrup.SelectedRows(Xi).Cells(3).Value = Trim(FlagCelVal3)
                            End If
                            FlagCelVal1 = ""
                            FlagCelVal2 = ""
                            FlagCelVal3 = ""
                            Xa = 0
                            FlagEditAllow = False
                            Exit Sub
                        End If
                    End If
                    StokGNamCmd = New SqlCommand("Finact_stokGrupName_Update", FinActConn)
                    StokGNamCmd.CommandType = CommandType.StoredProcedure
                    'for fetching grupid 
                    Try
                        StokGNamCmd1 = New SqlCommand("select cogrpid,copconcrnprmid from finactStokgrupname" _
                        & " where coprmtype='" & ("Stok") & "' and cogrupnam=@Gname", FinActConn1)
                        StokGNamCmd1.Parameters.AddWithValue("@gname", Trim(Me.dGacgrup.SelectedRows(Xi).Cells(2).Value))
                        StokGNamCmd1.CommandType = CommandType.Text
                        StokGNamRdr = StokGNamCmd1.ExecuteReader
                        StokGNamRdr.Read()
                        Grupid = StokGNamRdr("cogrpid")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        StokGNamCmd1 = Nothing
                        StokGNamRdr.Close()
                    End Try
                    StokGNamCmd.Parameters.AddWithValue("@Cogrupnam", Trim(Me.dGacgrup.SelectedRows(Xi).Cells(1).Value))
                    StokGNamCmd.Parameters.AddWithValue("@CoUndrgrup", Grupid)
                    StokGNamCmd.Parameters.AddWithValue("@coptype", "Stok")
                    StokGNamCmd.Parameters.AddWithValue("@copconid", Grupid)
                    StokGNamCmd.Parameters.AddWithValue("@cobalhed", "Stok") ' Trim(Me.dGacgrup.SelectedRows(Xi).Cells(3).Value))
                    If Trim(Me.dGacgrup.SelectedRows(Xi).Cells(3).Value) = "True" Then
                        YesNo1 = 1
                    ElseIf Trim(Me.dGacgrup.SelectedRows(Xi).Cells(3).Value) = "False" Then
                        YesNo1 = 0
                    End If
                    StokGNamCmd.Parameters.AddWithValue("@CoAfect", YesNo1)
                    StokGNamCmd.Parameters.AddWithValue("@coDelStatus", DelStatus) ' if record not deleted 0 for Deleted record
                    StokGNamCmd.Parameters.AddWithValue("@Cogrpid", Trim(Me.dGacgrup.SelectedRows(Xi).Cells(0).Value))
                    StokGNamCmd.Parameters.AddWithValue("@coEdtusrid", Editid)
                    StokGNamCmd.Parameters.AddWithValue("@coedtdt", Now)
                    StokGNamCmd.ExecuteNonQuery()
                Next
                Create_fill_AcGDgaCgrup()
                MsgBox("Record has been successfully updated", MsgBoxStyle.Information, "Record Updated")
            Else
                MsgBox("No record selected for updation.", MsgBoxStyle.Critical, Me.Text)
                Exit Sub

            End If
        Catch ex As SqlException
            Dim a As Integer = ex.Number
            If ex.Number = 2627 Then
                MsgBox("Invalid input! system found a record exisited with same value, Try another value", MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text & "  " & "Save_Recd()")
            End If
        Finally
            If Xa > 0 Then
                StokGNamCmd.Dispose()
            End If
        End Try


    End Sub
    Private Sub Btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnedit.Click
        Try
            If Btnedit.Text = "&Find" Then
                Me.TableLayoutPanel1.Visible = False
                Me.Width = Screen.PrimaryScreen.WorkingArea.Width / 1.5
                Me.Left = 0
                Me.Top = 0
                Me.Height = Screen.PrimaryScreen.WorkingArea.Height / 1.5
                Me.SplitContainer1.SplitterDistance = 142
                Me.SplitContainer1.IsSplitterFixed = True
                Create_fill_AcGDgaCgrup()
                Btnsave.Text = "&Update"
                Btnedit.Text = "&Delete"
            Else


                If MessageBox.Show("Are you sure to delete?", "Item configuration", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                Try
                    If dGacgrup.SelectedRows.Count > 0 Then
                        Dim i As Integer = 0
                        Dim flg As Integer = 0
                        For i = 0 To dGacgrup.SelectedRows.Count - 1
                            Try
                                If FinActConn.State Then FinActConn.Close()
                                FinActConn.Open()
                                StokGNamCmd = New SqlCommand("Select codelfalg from finactStokgrupname where cogrpid=@itmid", FinActConn)
                                StokGNamCmd.Parameters.AddWithValue("@itmid", Me.dGacgrup.SelectedRows(i).Cells(0).Value)
                                StokGNamCmd.ExecuteNonQuery()
                                StokGNamRdr = StokGNamCmd.ExecuteReader
                                While StokGNamRdr.Read
                                    flg = StokGNamRdr(0)
                                End While
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                StokGNamCmd.Dispose()
                                StokGNamRdr.Close()
                            End Try
                            If flg = 0 Then
                                MsgBox("System could not delete current record.", MsgBoxStyle.Critical, "System Reserved Group!!!")
                                Exit Sub
                            Else
                                If Chk_Exisit2("finactitmmstr", "itmcatid", "itmcatid", Me.dGacgrup.SelectedRows(i).Cells(0).Value) = True Then
                                    MsgBox("System could not delete current record, as it has a relation with other record(s).", MsgBoxStyle.Critical, "Record has relation(s)!!!")
                                    Exit Sub
                                End If
                                If FinActConn.State Then FinActConn.Close()
                                FinActConn.Open()
                                StokGNamCmd = New SqlCommand("Delete from finactStokgrupname where cogrpid=@itmid", FinActConn)
                                StokGNamCmd.Parameters.AddWithValue("@itmid", Me.dGacgrup.SelectedRows(i).Cells(0).Value)
                                StokGNamCmd.ExecuteNonQuery()
                            End If
                        Next
                        MsgBox("Current record has been successfully  deleted ", MsgBoxStyle.Information)
                        Create_fill_AcGDgaCgrup()
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
                    If dGacgrup.SelectedRows.Count > 0 Then
                        StokGNamCmd.Dispose()
                    End If
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally


        End Try


        ''If Panel1.Enabled = False Then
        ''    lstbxgrpmstr.Visible = True
        ''End If
        ''Label9.Visible = True
        ''lstbxgrpmstr.Visible = True
        ''Find_Rec_Grpname()

    End Sub

    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.GotFocus
        TxtName.SelectAll()
        'Me.SplitContainer1.Panel1.Enabled = True
    End Sub
    Private Sub fill_prmgrplst()
        StokGNamCmd = New SqlCommand("select * from finactstokgrupname where coprmtype='" & ("Stok") & "' and codelstatus=1 order by cogrupnam", FinActConn)
        Try
            StokGNamRdr = StokGNamCmd.ExecuteReader
            CmbxGrplst.Items.Clear()
            While StokGNamRdr.Read
                CmbxGrplst.Items.Add(StokGNamRdr("cogrupnam"))
            End While
            StokGNamRdr.Close()
            StokGNamCmd = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClos.Click
        Me.Close()
    End Sub


    Private Sub CmbxAgp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxAgp.GotFocus
        If CmbxAgp.Items.Count > 0 Then
            If CmbxAgp.SelectedIndex = -1 Then
                CmbxAgp.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub AllControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxAgp.KeyDown, TxtName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmbxGrplst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxGrplst.GotFocus
        Try
            Me.CmbxGrplst.DroppedDown = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbxGrplst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbxGrplst.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.CmbxGrplst_Leave(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Esckpress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Label1.KeyDown, Label2.KeyDown, TxtName.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.Close()

        End If
    End Sub

    Private Sub Btnsave_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.MouseHover, BtnClos.MouseHover, Btndel.MouseHover, Btnedit.MouseHover
        Dim tb As Button = CType(sender, Button)
        tb.ForeColor = Color.Red
        tb.BackColor = Color.Cyan

    End Sub

    Private Sub BtnClos_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.MouseLeave, BtnClos.MouseLeave, Btndel.MouseLeave, Btnedit.MouseLeave
        Dim tb As Button = CType(sender, Button)
        tb.ForeColor = Color.Black
        tb.BackColor = Color.Transparent

    End Sub
    Private Sub Create_fill_AcGDgaCgrup()
        Try
            dGacgrup.Columns.Clear()
            dGacgrup.Rows.Clear()
            dGacgrup.Size = New Drawing.Size(Me.Width - (Me.SplitContainer1.SplitterDistance + 10), Me.Height - (0 + 50))
            dGacgrup.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            dGacgrup.ForeColor = Color.Navy
            dGacgrup.Columns.Add("iid", "Id")
            dGacgrup.Columns.Add("gn", "Name Of The Group")
            dGacgrup.Columns(1).DefaultCellStyle.BackColor = Color.LightSteelBlue
            dGacgrup.Columns.Add("ug", "Under Group")
            dGacgrup.Columns.Add("agp", "Affect on GP")
            dGacgrup.Columns.Add("Adusr", "Add User")
            dGacgrup.Columns.Add("addt", "Add Date")
            dGacgrup.Columns.Add("edtusr", "Edit User")
            dGacgrup.Columns.Add("edtdt", "Edit Date")
            dGacgrup.Columns(7).DefaultCellStyle.BackColor = Color.LightGray
            dGacgrup.Columns(6).DefaultCellStyle.BackColor = Color.LightGray
            dGacgrup.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
            dGacgrup.Columns(4).DefaultCellStyle.BackColor = Color.LightGray
            dGacgrup.Columns(1).Width = 250
            dGacgrup.Columns(2).Width = 150
            dGacgrup.Columns(3).Width = 150
            dGacgrup.Columns(4).Width = 100
            dGacgrup.Columns(5).Width = 230
            dGacgrup.Columns(6).Width = 80
            dGacgrup.Columns(7).Width = 230

            dGacgrup.ColumnHeadersHeight = 60
            dGacgrup.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            dGacgrup.BorderStyle = BorderStyle.FixedSingle
            dGacgrup.BackgroundColor = Color.Snow
            Me.SplitContainer1.Panel2.Controls.Add(dGacgrup)
            dGacgrup.Visible = True
            dGacgrup.Left = 0
            dGacgrup.Top = 2
            dGacgrup.Columns(0).Visible = False
            dGacgrup.Columns(3).Visible = False
            dGacgrup.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red
            Dim pn1(0), pv1(0) As String
            Dim pn11(2), pv11(2) As String ''Arrays for procedure argu name n value
            pn11(0) = "@ta"
            pn11(1) = "@id"
            pn11(2) = "@idval"

            pv11(0) = "FinactStokGrupname"
            pv11(1) = "cogrupnam"
            pv11(2) = "PRIMARY"
            sql.get_data("select_where_Not_like", pn11, pv11, "AcgMaster")

            Dim mk, r As Integer
            For mk = 0 To sql.ds.Tables("AcgMaster").Rows.Count - 1
                AcGdgr = New DataGridViewRow()
                'for fetching id
                AcGcel = New DataGridViewTextBoxCell()
                AcGcel.Value = sql.ds.Tables("AcgMaster").Rows(mk).ItemArray(0).ToString()
                AcGdgr.Cells.Add(AcGcel)

                ' for fetching name
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("AcgMaster").Rows(mk).ItemArray(1).ToString()
                Dim xxStr As String = Trim(sql.ds.Tables("AcgMaster").Rows(mk).ItemArray(1).ToString())
                AcGdgr.Cells.Add(AcGcel)
                ' AcGdgr.Cells(1).ReadOnly = True

                'for fetching groupname
                AcGcom = New DataGridViewComboBoxCell()

                pn11(0) = "@ta"
                pn11(1) = "@id"
                pn11(2) = "@idval"

                pv11(0) = "FinactStokGrupname"
                pv11(1) = "cogrpid"
                pv11(2) = sql.ds.Tables("acgMaster").Rows(mk).ItemArray(2).ToString()

                sql1.get_data("select_where", pn11, pv11, "acg") ' acg stands for Account group Master
                AcGcom.Items.Add(sql1.ds.Tables("acg").Rows(0).ItemArray(1).ToString())
                pn1(0) = "@ta"
                pv1(0) = "FinactStokGrupname"
                sql1.get_data("select_all", pn1, pv1, "acga")

                For r = 0 To sql1.ds.Tables("acga").Rows.Count - 1
                    If sql1.ds.Tables("acga").Rows(r).ItemArray(1).ToString() <> AcGcom.Items(0) Then
                        If Trim(xxStr) <> Trim(sql1.ds.Tables("acga").Rows(r).ItemArray(1).ToString()) Then
                            AcGcom.Items.Add(sql1.ds.Tables("acga").Rows(r).ItemArray(1).ToString())
                        End If
                    End If
                Next
                sql1.ds.Tables("acga").Dispose()
                AcGcom.Value = AcGcom.Items(0)
                AcGcom.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                AcGdgr.Cells.Add(AcGcom)

                'for fetching affect on GP
                AcGcom = New DataGridViewComboBoxCell
                AcGcom.Items.Add("True")
                AcGcom.Items.Add("False")
                AcGcom.Value = sql.ds.Tables("acgMaster").Rows(mk).ItemArray(6).ToString()
                AcGdgr.Cells.Add(AcGcom)

                'for fetching add date
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("acgmaster").Rows(mk).ItemArray(8).ToString()
                AcGdgr.Cells.Add(AcGcel)
                AcGdgr.Cells(4).ReadOnly = True

                'for fetching add user
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("acgmaster").Rows(mk).ItemArray(7).ToString()
                AcGdgr.Cells.Add(AcGcel)
                AcGdgr.Cells(5).ReadOnly = True

                'for fetching edit user
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("acgmaster").Rows(mk).ItemArray(12).ToString()
                AcGdgr.Cells.Add(AcGcel)
                AcGdgr.Cells(6).ReadOnly = True

                'for fetching edit date
                AcGcel = New DataGridViewTextBoxCell
                AcGcel.Value = sql.ds.Tables("acgmaster").Rows(mk).ItemArray(13).ToString()
                AcGdgr.Cells.Add(AcGcel)
                AcGdgr.Cells(7).ReadOnly = True
                dGacgrup.Rows.Add(AcGdgr)

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.cnn.Close()
            sql.ds.Dispose()
        End Try
    End Sub
    Private Function validate_input() As Boolean
        Dim i, j As Integer
        For i = 0 To Me.dGacgrup.Rows.Count - 1
            For j = i + 1 To Me.dGacgrup.Rows.Count - 1
                If Me.dGacgrup.Rows(i).Cells(1).Value = Me.dGacgrup.Rows(j).Cells(1).Value Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function
    Private Sub DgaCgrup_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGacgrup.CellClick
        If dGacgrup.CurrentCell.ColumnIndex = 1 Then
            FlagCelVal1 = Trim(Me.dGacgrup.CurrentCell.Value).ToUpper
        End If
        If dGacgrup.CurrentCell.ColumnIndex = 2 Then
            FlagCelVal2 = Trim(Me.dGacgrup.CurrentCell.Value)
        End If
        If dGacgrup.CurrentCell.ColumnIndex = 3 Then
            FlagCelVal3 = Trim(Me.dGacgrup.CurrentCell.Value)
        End If
    End Sub
    Private Sub DgaCgrup_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGacgrup.CellValueChanged
        If dGacgrup.CurrentCell.ColumnIndex = 1 Then
            FlagEditAllow = True
            Flagcelval = Trim(dGacgrup.CurrentCell.Value).ToUpper
            dGacgrup.CurrentCell.Value = Trim(Flagcelval.ToUpper)

        End If
    End Sub

    Private Sub CmbxGrplst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbxGrplst.Leave
        Try
            If CheckBlank_Cmbx(Me.CmbxGrplst) = True Then
                Me.Btnsave.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TxtName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.Leave
        Try
            Me.lstvew1.Height = 10
            Me.lstvew1.Visible = False
            Me.lstvew1.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged
        Try
            If Len(Me.TxtName.Text.Trim) > 0 Then
                Me.lstvew1.Height = 169
                xFillLstVewWith2Recrd(Me.lstvew1, Me.TxtName.Text.Trim, "Cogrpid", "CogrupNam", "FinactStokgrupname", "Cogrupnam")
            Else
                Me.lstvew1.Visible = False
                Me.lstvew1.Enabled = False
                Me.lstvew1.Height = 10
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
