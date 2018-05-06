Imports EssentialToolsVb

Public Class DefaultDiscountHelper
    Implements IDiscountHelper

    ' property injection
    ' Public Property DiscountSize() As Decimal

    'constructor injection
    ReadOnly discountSize As Decimal

    Public Sub New(discountParam As Decimal)
        discountSize = discountParam
    End Sub

    Public Function ApplyDiscount(totalParam As Decimal) As Decimal Implements IDiscountHelper.ApplyDiscount
        ' Return (totalParam - (10D / 100D * totalParam))
        ' property injection
        ' Return (totalParam - (DiscountSize / 100D * totalParam))
        'constructor injection
        Return (totalParam - (discountSize / 100D * totalParam))
    End Function
End Class