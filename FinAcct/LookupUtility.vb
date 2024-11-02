
Public Class LookupUtility

    Public Shared Sub SetLookupBinding(ByVal toBind As ComboBox, ByVal dataSource As Object, ByVal displayMember As String, ByVal valueMember As String)
        toBind.DisplayMember = displayMember
        toBind.ValueMember = valueMember
        toBind.DataSource = dataSource
    End Sub


End Class
