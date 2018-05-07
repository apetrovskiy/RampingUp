Public Class LinqValueCalculator
    Implements IValueCalculator

    ReadOnly discounter As IDiscountHelper
    Shared counter As Integer = 0

    Public Sub New(discountParam As IDiscountHelper)
        discounter = discountParam
        System.Diagnostics.Debug.WriteLine(String.Format("Instance {0} created", ++counter))
    End Sub

    Public Function ValueProducts(products As IEnumerable(Of Product)) As Decimal Implements IValueCalculator.ValueProducts
        ' Return products.Sum(Function(p) p.Price)
        Return discounter.ApplyDiscount(products.Sum(Function(p) p.Price))
    End Function
End Class