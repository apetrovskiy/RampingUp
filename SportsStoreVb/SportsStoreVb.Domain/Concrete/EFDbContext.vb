Imports System.Data.Entity
Imports SportsStoreVb.Domain.Entities
Imports SportsStoreVb.Domain.SportsStoreVb.Domain.Entities

Public Class EFDbContext
    Inherits DbContext
    
    Public Property Products() As DbSet(Of Product)
End Class