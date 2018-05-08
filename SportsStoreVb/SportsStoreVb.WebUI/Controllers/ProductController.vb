Imports System.Web.Mvc
Imports SportsStoreVb.Domain

Namespace Controllers
    Public Class ProductController
        Inherits Controller

        ReadOnly repository As IProductRepository

        Public Sub New (productRepository As IProductRepository)
            Me.repository = productRepository
        End Sub

        ' GET: Product
        'Function Index() As ActionResult
        '    Return View()
        'End Function

        Public Function List() As ViewResult
            Return View(repository.Products)
        End Function
    End Class
End Namespace