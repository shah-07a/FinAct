Public Class cLSmYgrid


    Inherits DataGridView

    Private m_columnToSkip As Integer = -1



    Public Property ColumnToSkip() As Integer

        Get

            Return m_columnToSkip

        End Get

        Set(ByVal value As Integer)

            m_columnToSkip = value

        End Set

    End Property



    Protected Overloads Overrides Function SetCurrentCellAddressCore(ByVal columnIndex As Integer, ByVal rowIndex As Integer, ByVal setAnchorCellAddress As Boolean, ByVal validateCurrentCell As Boolean, ByVal throughMouseClick As Boolean) As Boolean

        If columnIndex = Me.m_columnToSkip AndAlso Me.m_columnToSkip <> -1 Then

            If Me.m_columnToSkip = Me.ColumnCount - 1 Then

                Return MyBase.SetCurrentCellAddressCore(0, rowIndex + 1, setAnchorCellAddress, validateCurrentCell, throughMouseClick)

            Else

                If Me.ColumnCount <> 0 Then

                    Return MyBase.SetCurrentCellAddressCore(columnIndex + 1, rowIndex, setAnchorCellAddress, validateCurrentCell, throughMouseClick)

                End If

            End If

        End If

        Return MyBase.SetCurrentCellAddressCore(columnIndex, rowIndex, setAnchorCellAddress, validateCurrentCell, throughMouseClick)

    End Function



    Protected Overloads Overrides Sub SetSelectedCellCore(ByVal columnIndex As Integer, ByVal rowIndex As Integer, ByVal selected As Boolean)

        If columnIndex = Me.m_columnToSkip Then

            If Me.m_columnToSkip = Me.ColumnCount - 1 Then

                MyBase.SetSelectedCellCore(0, rowIndex + 1, selected)

            Else

                If Me.ColumnCount <> 0 Then

                    MyBase.SetSelectedCellCore(columnIndex + 1, rowIndex, selected)

                End If

            End If

        Else

            MyBase.SetSelectedCellCore(columnIndex, rowIndex, selected)

        End If

    End Sub


End Class
