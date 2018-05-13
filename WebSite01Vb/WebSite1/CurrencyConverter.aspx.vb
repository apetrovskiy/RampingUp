
Partial Class CurrencyConverter
    Inherits System.Web.UI.Page

    Protected Sub Convert_ServerClick(ByVal sender As Object, ByVal d As System.EventArgs) Handles Convert.ServerClick
        Dim USAmount As Double = Val(US.value)
        Dim EuroAmount As Double = USAmount * 0.85
        Result.InnerText = USAmount.ToString() & " U.S. dollars = "
        Result.InnerText &= EuroAmount.ToString() & " Euros."
    End Sub
End Class
