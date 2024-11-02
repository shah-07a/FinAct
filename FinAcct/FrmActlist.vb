Imports System.Data
Imports system.data.sqlclient

Public Class FrmActlist
    Inherits System.Windows.Forms.Form
    Dim Actgrpcmd As SqlCommand
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Dim Actrdr As SqlDataReader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents LnkSelCon As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkHavOpng As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkSelCty As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkSelName As System.Windows.Forms.LinkLabel
    Friend WithEvents LstviewName As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader


    Friend WithEvents LstViewCty As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LstViewContct As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Dim concrnid As Integer
    Dim cityid As Integer
    Dim conid As Integer
    Dim sprid As Integer
    Dim range As Integer
    Dim splid As Integer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LstvewUndrGrp As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Dim crt As Integer
    Dim undrgrpid As Integer

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LstvewAct As System.Windows.Forms.ListView
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents TolNext As System.Windows.Forms.ToolBarButton
    Friend WithEvents TolPrv As System.Windows.Forms.ToolBarButton
    Friend WithEvents Tolshow As System.Windows.Forms.ToolBarButton
    Friend WithEvents TolPrint As System.Windows.Forms.ToolBarButton
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Tolexit As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmActlist))
        Me.LstvewAct = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LstViewContct = New System.Windows.Forms.ListView
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.LstViewCty = New System.Windows.Forms.ListView
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.LstviewName = New System.Windows.Forms.ListView
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.LnkSelCon = New System.Windows.Forms.LinkLabel
        Me.LnkHavOpng = New System.Windows.Forms.LinkLabel
        Me.LnkSelCty = New System.Windows.Forms.LinkLabel
        Me.LnkSelName = New System.Windows.Forms.LinkLabel
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.TolNext = New System.Windows.Forms.ToolBarButton
        Me.TolPrv = New System.Windows.Forms.ToolBarButton
        Me.Tolshow = New System.Windows.Forms.ToolBarButton
        Me.TolPrint = New System.Windows.Forms.ToolBarButton
        Me.Tolexit = New System.Windows.Forms.ToolBarButton
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LstvewUndrGrp = New System.Windows.Forms.ListView
        Me.ColumnHeader19 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader20 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LstvewAct
        '
        Me.LstvewAct.AllowColumnReorder = True
        Me.LstvewAct.BackColor = System.Drawing.Color.LightCyan
        Me.LstvewAct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstvewAct.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16})
        Me.LstvewAct.GridLines = True
        Me.LstvewAct.Location = New System.Drawing.Point(0, 252)
        Me.LstvewAct.Name = "LstvewAct"
        Me.LstvewAct.Size = New System.Drawing.Size(935, 216)
        Me.LstvewAct.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LstvewAct.TabIndex = 1
        Me.LstvewAct.UseCompatibleStateImageBehavior = False
        Me.LstvewAct.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "UndrGrup"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "City"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "State"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Country"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "E-Mail"
        Me.ColumnHeader7.Width = 150
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Address"
        Me.ColumnHeader14.Width = 200
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Phone"
        Me.ColumnHeader15.Width = 100
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Mobile"
        Me.ColumnHeader16.Width = 100
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Aquamarine
        Me.GroupBox2.Controls.Add(Me.LstViewContct)
        Me.GroupBox2.Controls.Add(Me.LstViewCty)
        Me.GroupBox2.Controls.Add(Me.LstviewName)
        Me.GroupBox2.Controls.Add(Me.LnkSelCon)
        Me.GroupBox2.Controls.Add(Me.LnkHavOpng)
        Me.GroupBox2.Controls.Add(Me.LnkSelCty)
        Me.GroupBox2.Controls.Add(Me.LnkSelName)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.IndianRed
        Me.GroupBox2.Location = New System.Drawing.Point(4, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(739, 168)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dynamic Selection"
        '
        'LstViewContct
        '
        Me.LstViewContct.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader13})
        Me.LstViewContct.Location = New System.Drawing.Point(572, 33)
        Me.LstViewContct.Name = "LstViewContct"
        Me.LstViewContct.Size = New System.Drawing.Size(161, 129)
        Me.LstViewContct.TabIndex = 11
        Me.LstViewContct.UseCompatibleStateImageBehavior = False
        Me.LstViewContct.View = System.Windows.Forms.View.Details
        Me.LstViewContct.Visible = False
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Contact"
        Me.ColumnHeader12.Width = 160
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "ID"
        Me.ColumnHeader13.Width = 0
        '
        'LstViewCty
        '
        Me.LstViewCty.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader11})
        Me.LstViewCty.Location = New System.Drawing.Point(405, 33)
        Me.LstViewCty.Name = "LstViewCty"
        Me.LstViewCty.Size = New System.Drawing.Size(161, 129)
        Me.LstViewCty.TabIndex = 10
        Me.LstViewCty.UseCompatibleStateImageBehavior = False
        Me.LstViewCty.View = System.Windows.Forms.View.Details
        Me.LstViewCty.Visible = False
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "City"
        Me.ColumnHeader10.Width = 159
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "ID"
        Me.ColumnHeader11.Width = 0
        '
        'LstviewName
        '
        Me.LstviewName.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LstviewName.Location = New System.Drawing.Point(6, 33)
        Me.LstviewName.Name = "LstviewName"
        Me.LstviewName.Size = New System.Drawing.Size(231, 129)
        Me.LstviewName.TabIndex = 9
        Me.LstviewName.UseCompatibleStateImageBehavior = False
        Me.LstviewName.View = System.Windows.Forms.View.Details
        Me.LstviewName.Visible = False
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Name"
        Me.ColumnHeader8.Width = 215
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "ID"
        Me.ColumnHeader9.Width = 0
        '
        'LnkSelCon
        '
        Me.LnkSelCon.AutoSize = True
        Me.LnkSelCon.Location = New System.Drawing.Point(569, 16)
        Me.LnkSelCon.Name = "LnkSelCon"
        Me.LnkSelCon.Size = New System.Drawing.Size(102, 14)
        Me.LnkSelCon.TabIndex = 8
        Me.LnkSelCon.TabStop = True
        Me.LnkSelCon.Text = "Select By Contact"
        '
        'LnkHavOpng
        '
        Me.LnkHavOpng.AutoSize = True
        Me.LnkHavOpng.Location = New System.Drawing.Point(248, 16)
        Me.LnkHavOpng.Name = "LnkHavOpng"
        Me.LnkHavOpng.Size = New System.Drawing.Size(148, 14)
        Me.LnkHavOpng.TabIndex = 7
        Me.LnkHavOpng.TabStop = True
        Me.LnkHavOpng.Text = "Select By Having Opening "
        '
        'LnkSelCty
        '
        Me.LnkSelCty.AutoSize = True
        Me.LnkSelCty.Location = New System.Drawing.Point(402, 16)
        Me.LnkSelCty.Name = "LnkSelCty"
        Me.LnkSelCty.Size = New System.Drawing.Size(81, 14)
        Me.LnkSelCty.TabIndex = 6
        Me.LnkSelCty.TabStop = True
        Me.LnkSelCty.Text = "Select By City"
        '
        'LnkSelName
        '
        Me.LnkSelName.AutoSize = True
        Me.LnkSelName.Location = New System.Drawing.Point(6, 16)
        Me.LnkSelName.Name = "LnkSelName"
        Me.LnkSelName.Size = New System.Drawing.Size(91, 14)
        Me.LnkSelName.TabIndex = 5
        Me.LnkSelName.TabStop = True
        Me.LnkSelName.Text = "Select By Name"
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.AutoSize = False
        Me.ToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TolNext, Me.TolPrv, Me.Tolshow, Me.TolPrint, Me.Tolexit})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(55, 45)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(952, 55)
        Me.ToolBar1.TabIndex = 5
        '
        'TolNext
        '
        Me.TolNext.ImageIndex = 2
        Me.TolNext.Name = "TolNext"
        Me.TolNext.ToolTipText = "Move Next"
        '
        'TolPrv
        '
        Me.TolPrv.ImageIndex = 3
        Me.TolPrv.Name = "TolPrv"
        Me.TolPrv.ToolTipText = "Move Previous"
        '
        'Tolshow
        '
        Me.Tolshow.ImageIndex = 7
        Me.Tolshow.Name = "Tolshow"
        Me.Tolshow.ToolTipText = "Show List"
        '
        'TolPrint
        '
        Me.TolPrint.ImageIndex = 8
        Me.TolPrint.Name = "TolPrint"
        Me.TolPrint.ToolTipText = "Print List"
        '
        'Tolexit
        '
        Me.Tolexit.ImageIndex = 1
        Me.Tolexit.Name = "Tolexit"
        Me.Tolexit.ToolTipText = "exit this "
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Aquamarine
        Me.GroupBox1.Controls.Add(Me.LstvewUndrGrp)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.IndianRed
        Me.GroupBox1.Location = New System.Drawing.Point(749, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 168)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'LstvewUndrGrp
        '
        Me.LstvewUndrGrp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader20})
        Me.LstvewUndrGrp.Location = New System.Drawing.Point(5, 33)
        Me.LstvewUndrGrp.Name = "LstvewUndrGrp"
        Me.LstvewUndrGrp.Size = New System.Drawing.Size(177, 129)
        Me.LstvewUndrGrp.TabIndex = 0
        Me.LstvewUndrGrp.UseCompatibleStateImageBehavior = False
        Me.LstvewUndrGrp.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "UnderGroup"
        Me.ColumnHeader19.Width = 150
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "ID"
        Me.ColumnHeader20.Width = 0
        '
        'FrmActlist
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(952, 480)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LstvewAct)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmActlist"
        Me.Text = "Account List"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmActlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        'selectcity()
        UndrGrup()
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter
    End Sub

    Private Sub LnkSelName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSelName.Click
        LstvewAct.Items.Clear()
        LstviewName.Items.Clear()
        LstviewName.Visible = True
        select_name()
    End Sub

    Private Sub LnkSelName_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSelName.LinkClicked
        LstViewCty.Visible = False
        LstViewContct.Visible = False

    End Sub
    Private Sub select_name()
        Dim LstView As ListViewItem
        Try
            Actgrpcmd = New SqlCommand("select splrname,splrid from Finactsplrmstr order by splrname", FinActConn)
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read()
                LstView = LstviewName.Items.Add(Actrdr("splrname"))
                LstView.SubItems.Add(Actrdr("splrid"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()

        End Try

    End Sub

    Private Sub LstviewName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstviewName.DoubleClick
        LstvewAct.Items.Clear()
        splid = LstviewName.SelectedItems(0).SubItems.Item(1).Text
        sel_rec()
        'LstviewName.Visible = False

    End Sub


    Private Sub LstviewName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstviewName.SelectedIndexChanged

    End Sub

    Private Sub LstvewAct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstvewAct.SelectedIndexChanged

    End Sub
    Private Sub sel_rec()
        Dim LstviewRcord As ListViewItem
        Try
            Actgrpcmd = New SqlCommand("FinAct_SplrMstr_Select_ByName", FinActConn)
            Actgrpcmd.CommandType = CommandType.StoredProcedure
            Actgrpcmd.Parameters.AddWithValue("@sid", splid)
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read()
                LstviewRcord = LstvewAct.Items.Add(Actrdr("splrid"))
                LstviewRcord.SubItems.Add(Actrdr("splrname"))
                LstviewRcord.SubItems.Add(Actrdr("gname"))
                'Actrdr.NextResult()
                LstviewRcord.SubItems.Add(Actrdr("cscctyname"))
                LstviewRcord.SubItems.Add(Actrdr("cscstatename"))
                LstviewRcord.SubItems.Add(Actrdr("csccontry"))
                LstviewRcord.SubItems.Add(Actrdr("adrsemail"))
                LstviewRcord.SubItems.Add(Actrdr("adrs1"))
                LstviewRcord.SubItems.Add(Actrdr("adrsphwork"))
                LstviewRcord.SubItems.Add(Actrdr("adrsmoble"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try
    End Sub
    Private Sub select_city()
        Dim Lstvewcty As ListViewItem
        Try

            Actgrpcmd = New SqlCommand("select cscid,cscctyname from FinactCscmstr where csctype=@outer", FinActConn)
            Actgrpcmd.Parameters.AddWithValue("@outer", "Outer")
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read()
                Lstvewcty = LstViewCty.Items.Add(Actrdr("cscctyname"))
                Lstvewcty.SubItems.Add(Actrdr("cscid"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try
    End Sub

    Private Sub LnkSelCty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSelCty.Click
        LstViewCty.Items.Clear()

        LstViewCty.Visible = True
        select_city()

    End Sub

    Private Sub LnkSelCty_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSelCty.LinkClicked
        LstviewName.Visible = False
        LstViewContct.Visible = False
    End Sub
    Private Sub select_bycontact()
        Try
            Dim Lstvewcon As ListViewItem
            Actgrpcmd = New SqlCommand("select adrsid,adrsphwork from Finactadrsmstr", FinActConn)
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read
                Lstvewcon = LstViewContct.Items.Add(Actrdr("adrsphwork"))
                Lstvewcon.SubItems.Add(Actrdr("adrsid"))
            End While

        Catch ex As Exception
            Throw ex
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try


    End Sub

    Private Sub LnkSelCon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSelCon.Click
        LstViewContct.Items.Clear()

        LstViewCty.Visible = False
        LstviewName.Visible = False

        LstViewContct.Visible = True
        select_bycontact()
    End Sub

    Private Sub LnkSelCon_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSelCon.DoubleClick
        'LstViewContct.Items.Clear()

        'LstViewCty.Visible = False
        'LstviewName.Visible = False

        'LstViewContct.Visible = True
        'select_bycontact()

    End Sub


    Private Sub LnkSelCon_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSelCon.LinkClicked

    End Sub

   

    Private Sub LstViewCty_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstViewCty.DoubleClick
        LstvewAct.Items.Clear()
        cityid = LstViewCty.SelectedItems(0).SubItems.Item(1).Text
        sel_bycity()


    End Sub

    Private Sub LstViewCty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstViewCty.SelectedIndexChanged

    End Sub
    Private Sub sel_bycity()
        Dim LstviewRcord As ListViewItem
        Try
            Actgrpcmd = New SqlCommand("FinAct_SplrMstr_Select_Bycity", FinActConn)
            Actgrpcmd.CommandType = CommandType.StoredProcedure
            Actgrpcmd.Parameters.AddWithValue("@ctyid", cityid)
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read()
                LstviewRcord = LstvewAct.Items.Add(Actrdr("splrid"))
                LstviewRcord.SubItems.Add(Actrdr("splrname"))
                LstviewRcord.SubItems.Add(Actrdr("gname"))
                LstviewRcord.SubItems.Add(Actrdr("cscctyname"))
                LstviewRcord.SubItems.Add(Actrdr("cscstatename"))
                LstviewRcord.SubItems.Add(Actrdr("csccontry"))
                LstviewRcord.SubItems.Add(Actrdr("adrsemail"))
                LstviewRcord.SubItems.Add(Actrdr("adrs1"))
                LstviewRcord.SubItems.Add(Actrdr("adrsphwork"))
                LstviewRcord.SubItems.Add(Actrdr("adrsmoble"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try
    End Sub
    Private Sub sel_Con()
        Dim LstviewRcord As ListViewItem
        Try
            Actgrpcmd = New SqlCommand("FinAct_SplrMstr_Select_Bycon", FinActConn)
            Actgrpcmd.CommandType = CommandType.StoredProcedure
            Actgrpcmd.Parameters.AddWithValue("@conid", conid)
            Actrdr = Actgrpcmd.ExecuteReader()
            While Actrdr.Read()
                LstviewRcord = LstvewAct.Items.Add(Actrdr("splrid"))
                LstviewRcord.SubItems.Add(Actrdr("splrname"))
                LstviewRcord.SubItems.Add(Actrdr("gname"))
                LstviewRcord.SubItems.Add(Actrdr("cscctyname"))
                LstviewRcord.SubItems.Add(Actrdr("cscstatename"))
                LstviewRcord.SubItems.Add(Actrdr("csccontry"))
                LstviewRcord.SubItems.Add(Actrdr("adrsemail"))
                LstviewRcord.SubItems.Add(Actrdr("adrs1"))
                LstviewRcord.SubItems.Add(Actrdr("adrsphwork"))
                LstviewRcord.SubItems.Add(Actrdr("adrsmoble"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()

        End Try

    End Sub

    Private Sub LstViewContct_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstViewContct.DoubleClick
        LstvewAct.Items.Clear()
        conid = LstViewContct.SelectedItems(0).SubItems(1).Text
        sel_Con()
    End Sub

    Private Sub LstViewContct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstViewContct.SelectedIndexChanged

    End Sub

    Private Sub LnkHavOpng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkHavOpng.Click
        LstvewAct.Items.Clear()

        LstViewCty.Visible = False
        LstviewName.Visible = False
        LstViewContct.Visible = False
        sel_OpngBal()
    End Sub
    Private Sub sel_OpngBal()
        Try
            Dim Lstviewbal As ListViewItem
            Actgrpcmd = New SqlCommand("FinAct_SplrMstr_Select_ByOpnBlnce", FinActConn)
            Actgrpcmd.CommandType = CommandType.StoredProcedure

            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read
                Lstviewbal = LstvewAct.Items.Add(Actrdr("splrid"))
                Lstviewbal.SubItems.Add(Actrdr("splrname"))
                Lstviewbal.SubItems.Add(Actrdr("gname"))
                Lstviewbal.SubItems.Add(Actrdr("cscctyname"))
                Lstviewbal.SubItems.Add(Actrdr("cscstatename"))
                Lstviewbal.SubItems.Add(Actrdr("csccontry"))
                Lstviewbal.SubItems.Add(Actrdr("adrsemail"))
                Lstviewbal.SubItems.Add(Actrdr("adrs1"))
                Lstviewbal.SubItems.Add(Actrdr("adrsphwork"))
                Lstviewbal.SubItems.Add(Actrdr("adrsmoble"))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try
    End Sub

   

   
    Private Sub all_Range()
        Try
            Dim LstView As ListViewItem

            Actgrpcmd = New SqlCommand("select splrname,splrid from Finactsplrmstr order by splrname ", FinActConn)
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read()
                LstView = LstviewName.Items.Add(Actrdr("splrname"))
                range = Actrdr("splrid")

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()

        End Try
        Try
            Dim LstviewRange As ListViewItem
            Actgrpcmd = New SqlCommand("FinAct_SplrMstr_Select_ByRange", FinActConn)
            Actgrpcmd.CommandType = CommandType.StoredProcedure
            Actgrpcmd.Parameters.AddWithValue("@sid", range)
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read
                LstviewRange = LstvewAct.Items.Add(Actrdr("splrid"))
                LstviewRange.SubItems.Add(Actrdr("splrname"))
                LstviewRange.SubItems.Add(Actrdr("splrundrgrup"))
                LstviewRange.SubItems.Add(Actrdr("cscctyname"))
                LstviewRange.SubItems.Add(Actrdr("cscstatename"))
                LstviewRange.SubItems.Add(Actrdr("csccontry"))
                LstviewRange.SubItems.Add(Actrdr("adrsemail"))
                LstviewRange.SubItems.Add(Actrdr("adrs1"))
                LstviewRange.SubItems.Add(Actrdr("adrsphwork"))
                LstviewRange.SubItems.Add(Actrdr("adrsmoble"))
            End While

        Catch ex As Exception
            Throw ex
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()
        End Try
    End Sub

    Private Sub UndrGrup()
        Try
            Dim Lstvew As ListViewItem
            Actgrpcmd = New SqlCommand("select cogrupnam,cogrpid from finactgrupname ", FinActConn)
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read
                Lstvew = LstvewUndrGrp.Items.Add(Actrdr("cogrupnam"))
                Lstvew.SubItems.Add(Actrdr("cogrpid"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()

        End Try

    End Sub

    Private Sub LstvewUndrGrp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstvewUndrGrp.DoubleClick
        LstvewAct.Items.Clear()
        undrgrpid = LstvewUndrGrp.SelectedItems(0).SubItems.Item(1).Text
        UnderGrup()
    End Sub




    Private Sub LstvewUndrGrp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstvewUndrGrp.SelectedIndexChanged

    End Sub
    Private Sub UnderGrup()

        Dim Lstvewgrp As ListViewItem
       
        Try
            Actgrpcmd = New SqlCommand("FinAct_SplrMstr_Select_Bygrp", FinActConn)
            Actgrpcmd.CommandType = CommandType.StoredProcedure
            Actgrpcmd.Parameters.AddWithValue("@crt", undrgrpid)
            Actrdr = Actgrpcmd.ExecuteReader
            While Actrdr.Read
                Lstvewgrp = LstvewAct.Items.Add(Actrdr("splrid"))
                Lstvewgrp.SubItems.Add(Actrdr("splrname"))
                Lstvewgrp.SubItems.Add(Actrdr("gname"))
                Lstvewgrp.SubItems.Add(Actrdr("cscctyname"))
                Lstvewgrp.SubItems.Add(Actrdr("cscstatename"))
                Lstvewgrp.SubItems.Add(Actrdr("csccontry"))
                Lstvewgrp.SubItems.Add(Actrdr("adrsemail"))
                Lstvewgrp.SubItems.Add(Actrdr("adrs1"))
                Lstvewgrp.SubItems.Add(Actrdr("adrsphwork"))
                Lstvewgrp.SubItems.Add(Actrdr("adrsmoble"))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Actgrpcmd = Nothing
            Actrdr.Close()

        End Try
    End Sub
End Class
