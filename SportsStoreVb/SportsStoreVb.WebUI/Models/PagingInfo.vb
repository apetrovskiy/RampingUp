Public Class PagingInfo
    Public Property TotalItems() As Integer
    Public Property ItemsPerPage() As Integer
    Public Property CurrentPage() As Integer
    Public ReadOnly Property TotalPages() As Integer
        Get
            Return CInt(Math.Ceiling(CDec(TotalItems / ItemsPerPage)))
        End Get
    End Property
End Class