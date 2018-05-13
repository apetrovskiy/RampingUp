
Partial Class CurrencyConverter
    Inherits System.Web.UI.Page

    Protected Sub Convert_ServerClick(ByVal sender As Object, ByVal d As System.EventArgs) Handles Convert.ServerClick
        'Dim USAmount As Double = Val(US.value)
        'Dim EuroAmount As Double = USAmount * 0.85
        'Result.InnerText = USAmount.ToString() & " U.S. dollars = "
        'Result.InnerText &= EuroAmount.ToString() & " Euros."

        Dim oldAmount As Double = Val(US.Value)

        ' Retrieve the selected ListItem object by its index number.
        Dim item As ListItem = Currency.Items(Currency.SelectedIndex)

        Dim newAmount As Double = oldAmount * Val(item.Value)
        Result.InnerText = oldAmount.ToString() & " U.S. dollars = "
        Result.InnerText &= newAmount.ToString() & " " & item.Text
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Currency.Items.Add(New ListItem("Euros", "0.85"))
            Currency.Items.Add(New ListItem("Japanese Yen", "110.33"))
            Currency.Items.Add(New ListItem("Canadian Dollars", "1.2"))

            Graph.Visible = False
        End If
    End Sub

    Protected Sub ShowGraph_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowGraph.ServerClick
        Graph.Src = "Pic" & Currency.SelectedIndex.ToString() & ".png"
        Graph.Visible = True
    End Sub
End Class
