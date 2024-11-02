Public Class TextBoxOnPaste
    Inherits NativeWindow
    Private tb As TextBox
    Private Sub New()
    End Sub
    Public Sub New(ByVal tb As TextBox)
        Me.tb = tb
        Me.AssignHandle(tb.Handle)
    End Sub

    Private Const WM_PASTE As Integer = &H302

    Protected Overrides Sub WndProc(ByRef m As Message)
        'With every key press, click, key-combination press, etc a Message is sent to the
        ' window. You need to read about Win32 programming if you don't understand it.
        Select Case m.Msg
            Case WM_PASTE
                'User has tried a way to paste something, like SHIFT+INSERT or
                ' right-click context menu...
                If Clipboard.GetDataObject.GetDataPresent(DataFormats.Text) Then
                    'What user has tried to paste is a piece of text...
                    Dim str As String = Clipboard.GetDataObject.GetData(DataFormats.Text)
                    'Remove all appearances of coma
                    str = Replace(str, ",", "")
                    Dim NewVal As String
                    NewVal = Mid(tb.Text, 1, tb.SelectionStart) & str & Mid(tb.Text, tb.SelectionStart + tb.SelectionLength + 1, Len(tb.Text))
                    'NewVal will contain the future value of the textbox, if we would let
                    ' what user wanted to paste to actually paste there...
                    If IsNumeric(NewVal) Then
                        ' The result will be a numeric value. So go ahead and paste it!
                        tb.SelectedText = str
                    End If
                    ' We're done, so we exit the sub (not letting the default WndProc() to
                    ' paste the original string user tried to paste.
                    Exit Sub
                End If
        End Select
        'In situations other than what we handled, the default WndProc() needs to be run
        MyBase.WndProc(m)
    End Sub

End Class
