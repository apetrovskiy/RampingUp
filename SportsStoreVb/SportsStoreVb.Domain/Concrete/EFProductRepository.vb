Imports SportsStoreVb.Domain.SportsStoreVb.Domain.Entities

Namespace SportsStoreVb.Domain.Concrete
    Public Class EFProductRepository
        Implements IProductRepository

        Private context As New EFDbContext()

        Public ReadOnly Property Products As IEnumerable(Of Product) Implements IProductRepository.Products
            Get
                Return context.Products
            End Get
        End Property
    End Class
End Namespace