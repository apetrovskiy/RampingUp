Public Class LinqValueCalculator
    Implements IValueCalculator

    ReadOnly discounter As IDiscountHelper

    Public Sub New(discountParam As IDiscountHelper)
        discounter = discountParam
    End Sub

    Public Function ValueProducts(products As IEnumerable(Of Product)) As Decimal Implements IValueCalculator.ValueProducts
        ' Return products.Sum(Function(p) p.Price)
        Return discounter.ApplyDiscount(products.Sum(Function(p) p.Price))
    End Function
End Class