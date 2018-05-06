Public Class ShoppingCart
    ReadOnly calc As IValueCalculator

    Public Sub New(calcParam As IValueCalculator)
        calc = calcParam
    End Sub

    Public Property Products() As IEnumerable(Of Product)

    Public Function CalculateProductTotal() As Decimal
        Return calc.ValueProducts(Products)
    End Function
End Class