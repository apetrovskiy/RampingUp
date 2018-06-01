Imports System.Data.Entity

Public Class ProductContext
    Inherits DbContext

    Public Sub New () 
        MyBase.New("WingtipToysVb")
    End Sub

    Public Property Categories() As DbSet(Of Category)
    Public Property Products() As DbSet(Of Product)
End Class
