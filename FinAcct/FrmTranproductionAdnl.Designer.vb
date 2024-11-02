<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTranproductionAdnl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTranproductionAdnl))
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel5 = New System.Windows.Forms.Panel
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
        Me.ColPrcsid = New System.Windows.Forms.ColumnHeader
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblalrt = New System.Windows.Forms.Label
        Me.lblsuggest = New System.Windows.Forms.Label
        Me.BtnAdlOk = New System.Windows.Forms.Button
        Me.BtnAdlcancl = New System.Windows.Forms.Button
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.09693!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.90308!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(975, 404)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Lstvewitmall)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(967, 396)
        Me.Panel5.TabIndex = 24
        '
        'Lstvewitmall
        '
        Me.Lstvewitmall.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Colitmname, Me.Colstore, Me.ColItmQnty, Me.Colrqnty, Me.ColSih, Me.colblokstok, Me.colfreestock, Me.Colitmid, Me.Colchk1, Me.Colunit, Me.collocid, Me.ColPrcsid})
        Me.Lstvewitmall.FullRowSelect = True
        Me.Lstvewitmall.GridLines = True
        Me.Lstvewitmall.Location = New System.Drawing.Point(0, 43)
        Me.Lstvewitmall.Name = "Lstvewitmall"
        Me.Lstvewitmall.Size = New System.Drawing.Size(967, 351)
        Me.Lstvewitmall.TabIndex = 1
        Me.Lstvewitmall.UseCompatibleStateImageBehavior = False
        Me.Lstvewitmall.View = System.Windows.Forms.View.Details
        '
        'Colitmname
        '
        Me.Colitmname.Text = "Process & Item Name"
        Me.Colitmname.Width = 202
        '
        'Colstore
        '
        Me.Colstore.Text = "Name Of Location(Store) From  Item(s) To Be Issued."
        Me.Colstore.Width = 202
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
        Me.Colrqnty.Width = 87
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
        Me.colblokstok.Text = "Restricted Stock"
        Me.colblokstok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colblokstok.Width = 94
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
        Me.Colchk1.Width = 100
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
        'ColPrcsid
        '
        Me.ColPrcsid.Text = "Process id"
        Me.ColPrcsid.Width = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(0, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(967, 40)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Attached Item(s) Movement Schema "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblalrt
        '
        Me.lblalrt.AutoSize = True
        Me.lblalrt.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblalrt.ForeColor = System.Drawing.Color.Navy
        Me.lblalrt.Location = New System.Drawing.Point(7, 420)
        Me.lblalrt.Name = "lblalrt"
        Me.lblalrt.Size = New System.Drawing.Size(56, 16)
        Me.lblalrt.TabIndex = 15
        Me.lblalrt.Text = "Label1"
        '
        'lblsuggest
        '
        Me.lblsuggest.AutoSize = True
        Me.lblsuggest.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsuggest.ForeColor = System.Drawing.Color.Navy
        Me.lblsuggest.Location = New System.Drawing.Point(78, 420)
        Me.lblsuggest.Name = "lblsuggest"
        Me.lblsuggest.Size = New System.Drawing.Size(56, 16)
        Me.lblsuggest.TabIndex = 16
        Me.lblsuggest.Text = "Label2"
        Me.lblsuggest.Visible = False
        '
        'BtnAdlOk
        '
        Me.BtnAdlOk.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdlOk.BackgroundImage = CType(resources.GetObject("BtnAdlOk.BackgroundImage"), System.Drawing.Image)
        Me.BtnAdlOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdlOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdlOk.FlatAppearance.BorderSize = 0
        Me.BtnAdlOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnAdlOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdlOk.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdlOk.ForeColor = System.Drawing.Color.Navy
        Me.BtnAdlOk.Location = New System.Drawing.Point(765, 420)
        Me.BtnAdlOk.Name = "BtnAdlOk"
        Me.BtnAdlOk.Size = New System.Drawing.Size(100, 33)
        Me.BtnAdlOk.TabIndex = 2
        Me.BtnAdlOk.Text = "&Ok"
        Me.BtnAdlOk.UseVisualStyleBackColor = False
        '
        'BtnAdlcancl
        '
        Me.BtnAdlcancl.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdlcancl.BackgroundImage = CType(resources.GetObject("BtnAdlcancl.BackgroundImage"), System.Drawing.Image)
        Me.BtnAdlcancl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdlcancl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdlcancl.FlatAppearance.BorderSize = 0
        Me.BtnAdlcancl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.BtnAdlcancl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdlcancl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdlcancl.ForeColor = System.Drawing.Color.Navy
        Me.BtnAdlcancl.Location = New System.Drawing.Point(871, 420)
        Me.BtnAdlcancl.Name = "BtnAdlcancl"
        Me.BtnAdlcancl.Size = New System.Drawing.Size(100, 33)
        Me.BtnAdlcancl.TabIndex = 3
        Me.BtnAdlcancl.Text = "&Cancel"
        Me.BtnAdlcancl.UseVisualStyleBackColor = False
        '
        'FrmTranproductionAdnl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.SpringGreen
        Me.ClientSize = New System.Drawing.Size(978, 468)
        Me.Controls.Add(Me.BtnAdlcancl)
        Me.Controls.Add(Me.BtnAdlOk)
        Me.Controls.Add(Me.lblsuggest)
        Me.Controls.Add(Me.lblalrt)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTranproductionAdnl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Step wise item(s) issue"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblalrt As System.Windows.Forms.Label
    Friend WithEvents lblsuggest As System.Windows.Forms.Label
    Friend WithEvents BtnAdlOk As System.Windows.Forms.Button
    Friend WithEvents BtnAdlcancl As System.Windows.Forms.Button
    Friend WithEvents ColPrcsid As System.Windows.Forms.ColumnHeader
End Class
