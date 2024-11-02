<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmsrfixmstr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmsrfixmstr))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.LstVewFnd = New System.Windows.Forms.ListView
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TxtSrfix = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnAddWithValue = New System.Windows.Forms.Button
        Me.BtnFind = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnClos = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Panel1.Controls.Add(Me.LstVewFnd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnAddWithValue)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnFind)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnSave)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnClos)
        Me.SplitContainer1.Size = New System.Drawing.Size(284, 114)
        Me.SplitContainer1.SplitterDistance = 70
        Me.SplitContainer1.TabIndex = 0
        '
        'LstVewFnd
        '
        Me.LstVewFnd.AllowDrop = True
        Me.LstVewFnd.BackColor = System.Drawing.Color.LightCyan
        Me.LstVewFnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstVewFnd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVewFnd.ForeColor = System.Drawing.Color.Navy
        Me.LstVewFnd.GridLines = True
        Me.LstVewFnd.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstVewFnd.HoverSelection = True
        Me.LstVewFnd.Location = New System.Drawing.Point(3, 50)
        Me.LstVewFnd.MultiSelect = False
        Me.LstVewFnd.Name = "LstVewFnd"
        Me.LstVewFnd.Size = New System.Drawing.Size(151, 17)
        Me.LstVewFnd.TabIndex = 5
        Me.LstVewFnd.UseCompatibleStateImageBehavior = False
        Me.LstVewFnd.View = System.Windows.Forms.View.Details
        Me.LstVewFnd.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.44628!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.55372!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtSrfix, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 11)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(241, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TxtSrfix
        '
        Me.TxtSrfix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSrfix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSrfix.Location = New System.Drawing.Point(66, 3)
        Me.TxtSrfix.MaxLength = 8
        Me.TxtSrfix.Name = "TxtSrfix"
        Me.TxtSrfix.Size = New System.Drawing.Size(85, 20)
        Me.TxtSrfix.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SurFix "
        '
        'BtnAddWithValue
        '
        Me.BtnAddWithValue.BackColor = System.Drawing.Color.LightCyan
        Me.BtnAddWithValue.BackgroundImage = CType(resources.GetObject("BtnAddWithValue.BackgroundImage"), System.Drawing.Image)
        Me.BtnAddWithValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAddWithValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddWithValue.Location = New System.Drawing.Point(135, 8)
        Me.BtnAddWithValue.Name = "BtnAddWithValue"
        Me.BtnAddWithValue.Size = New System.Drawing.Size(61, 24)
        Me.BtnAddWithValue.TabIndex = 9
        Me.BtnAddWithValue.Text = "&Cancel"
        Me.BtnAddWithValue.UseVisualStyleBackColor = False
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.LightCyan
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.Location = New System.Drawing.Point(68, 8)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(61, 24)
        Me.BtnFind.TabIndex = 8
        Me.BtnFind.Text = "&Find"
        Me.BtnFind.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.LightCyan
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(1, 8)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(61, 24)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnClos
        '
        Me.BtnClos.BackColor = System.Drawing.Color.LightCyan
        Me.BtnClos.BackgroundImage = CType(resources.GetObject("BtnClos.BackgroundImage"), System.Drawing.Image)
        Me.BtnClos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClos.Location = New System.Drawing.Point(202, 8)
        Me.BtnClos.Name = "BtnClos"
        Me.BtnClos.Size = New System.Drawing.Size(61, 24)
        Me.BtnClos.TabIndex = 10
        Me.BtnClos.Text = "C&lose"
        Me.BtnClos.UseVisualStyleBackColor = False
        '
        'Frmsrfixmstr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(284, 114)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frmsrfixmstr"
        Me.Text = "Account Name Surfix Master"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAddWithValue As System.Windows.Forms.Button
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClos As System.Windows.Forms.Button
    Friend WithEvents TxtSrfix As System.Windows.Forms.TextBox
    Friend WithEvents LstVewFnd As System.Windows.Forms.ListView
End Class
