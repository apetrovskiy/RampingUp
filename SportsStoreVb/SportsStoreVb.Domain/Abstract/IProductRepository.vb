Imports SportsStoreVb.Domain.SportsStoreVb.Domain.Entities

Public Interface IProductRepository
    Property Products() As IEnumerable(Of Product)
End Interface