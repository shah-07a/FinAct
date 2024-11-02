Public Class DGVEnterTab

    Inherits DataGridView

    Protected Overloads Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean

        'cell is in Edit mode

        If keyData = Keys.Enter Then

            keyData = Keys.Tab

        End If

        Return MyBase.ProcessDialogKey(keyData)

    End Function



    Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        'cell is not in Edit mode

        If keyData = Keys.Enter Then

            keyData = Keys.Tab

            msg.LParam = CType(&HF0001, IntPtr)

            msg.WParam = CType(&H9, IntPtr)



            If Me.CurrentCell.RowIndex = Me.RowCount - 1 And Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then

                Me.FindForm.SelectNextControl(Me, True, True, True, True)

                Return False

            End If

        End If

        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function

End Class