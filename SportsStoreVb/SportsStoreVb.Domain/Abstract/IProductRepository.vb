Imports SportsStoreVb.Domain.Entities
Imports SportsStoreVb.Domain.SportsStoreVb.Domain.Entities

Public Interface IProductRepository
    ReadOnly Property Products() As IEnumerable(Of Product)
End Interface