Imports System.Web.Mvc
Imports System.Linq
Imports SportsStoreVb.Domain

Namespace Controllers
    Public Class ProductController
        Inherits Controller

        ReadOnly repository As IProductRepository
        Public PageSize As Integer = 4

        Public Sub New (productRepository As IProductRepository)
            Me.repository = productRepository
        End Sub

        ' GET: Product
        'Function Index() As ActionResult
        '    Return View()
        'End Function

        ' Public Function List() As ViewResult
        Public Function List(Optional page As Integer = 1) As ViewResult
            ' Return View(repository.Products)
            Return View(repository.Products _
                        .OrderBy(Function(p) p.ProductID) _
                        .Skip((page - 1) * PageSize) _
                        .Take(PageSize)
                        )
        End Function
    End Class
End Namespace