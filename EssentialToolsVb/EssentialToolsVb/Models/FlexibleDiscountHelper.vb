Imports EssentialToolsVb

Public Class FlexibleDiscountHelper
    Implements IDiscountHelper

    Public Function ApplyDiscount(totalParam As Decimal) As Decimal Implements IDiscountHelper.ApplyDiscount
        Dim discount = If(totalParam > 100, 70, 25)
        Return (totalParam - (discount / 100D * totalParam))
    End Function
End Class