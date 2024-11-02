<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMRPlanner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMRPlanner))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.BtnMMexit = New System.Windows.Forms.Button
        Me.Lstvewitmall = New System.Windows.Forms.ListView
        Me.Colitmname = New System.Windows.Forms.ColumnHeader
        Me.Colstore = New System.Windows.Forms.ColumnHeader
        Me.ColItmQnty = New System.Windows.Forms.ColumnHeader
        Me.Colrqnty = New System.Windows.Forms.ColumnHeader
        Me.ColSih = New System.Windows.Forms.ColumnHeader
        Me.colblokstok = New System.Windows.Forms.ColumnHeader
        Me.colfreestock = New System.Windows.Forms.ColumnHeader
        Me.Colitmid = New System.Windows.Forms.ColumnHeader
        Me.Colchk1 = New System.Windows.Forms.ColumnHeader
        Me.Colunit = New System.Windows.Forms.ColumnHeader
        Me.collocid = New System.Windows.Forms.ColumnHeader
        Me.ColShort = New System.Windows.Forms.ColumnHeader
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.SplitContainer1.Panel1.Enabled = False
        Me.SplitContainer1.Panel1MinSize = 0
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnMMexit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Lstvewitmall)
        Me.SplitContainer1.Panel2MinSize = 0
        Me.SplitContainer1.Size = New System.Drawing.Size(898, 431)
        Me.SplitContainer1.SplitterDistance = 0
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.TabStop = False
        '
        'BtnMMexit
        '
        Me.BtnMMexit.BackgroundImage = CType(resources.GetObject("BtnMMexit.BackgroundImage"), System.Drawing.Image)
        Me.BtnMMexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMMexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMMexit.ForeColor = System.Drawing.Color.Navy
        Me.BtnMMexit.Location = New System.Drawing.Point(804, 397)
        Me.BtnMMexit.Name = "BtnMMexit"
        Me.BtnMMexit.Size = New System.Drawing.Size(85, 29)
        Me.BtnMMexit.TabIndex = 29
        Me.BtnMMexit.Text = "&Close"
        Me.BtnMMexit.UseVisualStyleBackColor = True
        '
        'Lstvewitmall
        '
        Me.Lstvewitmall.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Colitmname, Me.Colstore, Me.ColItmQnty, Me.Colrqnty, Me.ColSih, Me.colblokstok, Me.colfreestock, Me.Colitmid, Me.Colchk1, Me.Colunit, Me.collocid, Me.ColShort})
        Me.Lstvewitmall.FullRowSelect = True
        Me.Lstvewitmall.GridLines = True
        Me.Lstvewitmall.Location = New System.Drawing.Point(3, 3)
        Me.Lstvewitmall.Name = "Lstvewitmall"
        Me.Lstvewitmall.Size = New System.Drawing.Size(886, 389)
        Me.Lstvewitmall.TabIndex = 30
        Me.Lstvewitmall.UseCompatibleStateImageBehavior = False
        Me.Lstvewitmall.View = System.Windows.Forms.View.Details
        '
        'Colitmname
        '
        Me.Colitmname.Text = "Process & Item Name"
        Me.Colitmname.Width = 252
        '
        'Colstore
        '
        Me.Colstore.Text = "Item Location"
        Me.Colstore.Width = 179
        '
        'ColItmQnty
        '
        Me.ColItmQnty.Text = "Qnty. Per Unit"
        Me.ColItmQnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColItmQnty.Width = 81
        '
        'Colrqnty
        '
        Me.Colrqnty.Text = "Required Qnty."
        Me.Colrqnty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Colrqnty.Width = 97
        '
        'ColSih
        '
        Me.ColSih.DisplayIndex = 5
        Me.ColSih.Text = "Stock In Hand"
        Me.ColSih.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColSih.Width = 85
        '
        'colblokstok
        '
        Me.colblokstok.DisplayIndex = 6
        Me.colblokstok.Text = "Stock In Demand"
        Me.colblokstok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colblokstok.Width = 0
        '
        'colfreestock
        '
        Me.colfreestock.DisplayIndex = 7
        Me.colfreestock.Text = "Available Stock"
        Me.colfreestock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colfreestock.Width = 90
        '
        'Colitmid
        '
        Me.Colitmid.DisplayIndex = 8
        Me.Colitmid.Text = "Item Id"
        Me.Colitmid.Width = 0
        '
        'Colchk1
        '
        Me.Colchk1.DisplayIndex = 9
        Me.Colchk1.Text = "Issue Status"
        Me.Colchk1.Width = 0
        '
        'Colunit
        '
        Me.Colunit.DisplayIndex = 4
        Me.Colunit.Text = "Unit Type"
        Me.Colunit.Width = 0
        '
        'collocid
        '
        Me.collocid.Text = "Location Id"
        Me.collocid.Width = 0
        '
        'ColShort
        '
        Me.ColShort.Text = "Short Status"
        Me.ColShort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColShort.Width = 95
        '
        'FrmMRPlanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(898, 431)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "FrmMRPlanner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material Requirment Planner (MRP)"
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents BtnMMexit As System.Windows.Forms.Button
    Friend WithEvents Lstvewitmall As System.Windows.Forms.ListView
    Friend WithEvents Colitmname As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colstore As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColItmQnty As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colrqnty As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColSih As System.Windows.Forms.ColumnHeader
    Friend WithEvents colblokstok As System.Windows.Forms.ColumnHeader
    Friend WithEvents colfreestock As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colitmid As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colchk1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colunit As System.Windows.Forms.ColumnHeader
    Friend WithEvents collocid As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColShort As System.Windows.Forms.ColumnHeader
End Class
