<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWinFormPrinting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.print1Button = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'print1Button
        '
        Me.print1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.print1Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.print1Button.Location = New System.Drawing.Point(37, 114)
        Me.print1Button.Name = "print1Button"
        Me.print1Button.Size = New System.Drawing.Size(136, 40)
        Me.print1Button.TabIndex = 0
        Me.print1Button.Text = "Print the file."
        '
        'FrmWinFormPrinting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 381)
        Me.Controls.Add(Me.print1Button)
        Me.Name = "FrmWinFormPrinting"
        Me.Text = "Print Example"
        Me.ResumeLayout(False)

    End Sub
End Class
