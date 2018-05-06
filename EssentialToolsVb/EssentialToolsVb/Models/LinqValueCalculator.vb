Public Class LinqValueCalculator
    Implements IValueCalculator
    Public Function ValueProducts(products As IEnumerable(Of Product)) As Decimal Implements IValueCalculator.ValueProducts
        Return products.Sum(Function(p) p.Price)
    End Function
End Class