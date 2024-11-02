Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public NotInheritable Class FrmWelcomeSplashScreen
    Dim rpt As New CrRptWelcome
    Private Sub Btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnexit.Click
        Me.Close()
    End Sub

    Private Sub CrRptVewWelcome_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles CrRptVewWelcome.Paint
        Try

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

 
End Class
