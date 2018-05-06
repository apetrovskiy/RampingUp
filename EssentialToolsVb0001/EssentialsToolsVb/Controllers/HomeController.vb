Imports System.Web.Mvc
Imports Ninject

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        Dim calc As IValueCalculator
        Dim products = New List(Of Product) From
            {
            New Product With {.Name = "Kayak", .Category = "Watersports", .Price = 275D},
            New Product With {.Name = "Lifejacket", .Category = "Watersports", .Price = 48.95D},
            New Product With {.Name = "Soccer ball", .Category = "Soccer", .Price = 19.5D},
            New Product With {.Name = "Corner flag", .Category = "Soccer", .Price = 34.95D}
        }

        Public Sub New(calcParam As IValueCalculator)
            calc = calcParam
        End Sub

        ' GET: Home
        Function Index() As ActionResult
            Dim ninjectKernel As New StandardKernel
            ninjectKernel.Bind(Of IValueCalculator).To(Of LinqValueCalculator)()

            ' Dim calc As New LinqValueCalculator
            Dim calc = ninjectKernel.Get(Of IValueCalculator)
            Dim cart As New ShoppingCart(calc) With {.Products = products}
            Dim totalValue = cart.CalculateProductTotal()
            Return View(totalValue)
        End Function
    End Class
End Namespace