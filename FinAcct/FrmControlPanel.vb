Public Class FrmControlPanel
    Dim xPass As String = ""
    Private Sub FrmControlPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            xPass = "mohd@786#rafiq#finact09"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Me.TxtPass.Text.Trim = xPass.Trim Then
                Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, Screen.PrimaryScreen.WorkingArea.Height - 20)

            Else
                Me.Size = New System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 20, 117)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class