Public Class DisValueMemberLstBox


    Public Delegate Function displayPersonDelegate _
    (ByVal ItmDtl As DisValueMemberLstBox) As String
    Private itmID As Long
    Private itmName As String
    'Private mFirstName As String
    'Private mStatus As String
    Private mDisplayMethod As displayPersonDelegate
    Public Sub New(ByVal anID As Long, ByVal Iname As String)
        itmID = anID
        itmName = Iname
    End Sub
    Public Property ID() As Long
        Get
            Return itmID
        End Get
        Set(ByVal Value As Long)
            itmID = Value
        End Set
    End Property
    Public Property Itm_Name() As String
        Get
            Return itmName
        End Get
        Set(ByVal Value As String)
            itmName = Value
        End Set
    End Property
    ''Public Property FirstName() As String
    ''    Get
    ''        Return mFirstName
    ''    End Get
    ''    Set(ByVal Value As String)
    ''        mFirstName = Value
    ''    End Set
    ''End Property
    ''Public Property Status() As String
    ''    Get
    ''        Return mStatus
    ''    End Get
    ''    Set(ByVal Value As String)
    ''        mStatus = Value
    ''    End Set
    ''End Property
    Public Overloads Overrides Function ToString() As String
        Try
            Return Me.DisplayMethod(Me)
        Catch
            Return MyBase.ToString()
        End Try
    End Function
    Public Property DisplayMethod() As displayPersonDelegate
        Get
            Return mDisplayMethod
        End Get
        Set(ByVal Value As displayPersonDelegate)
            mDisplayMethod = Value
        End Set
    End Property
    Public ReadOnly Property LastFirst() As String
        Get
            Return Me.Itm_Name '", " & Me.FirstName
        End Get
    End Property
    ''Public ReadOnly Property FirstLast() As String
    ''    Get
    ''        Return Me.FirstName & " " & Me.LastName
    ''    End Get
    ''End Property


End Class
