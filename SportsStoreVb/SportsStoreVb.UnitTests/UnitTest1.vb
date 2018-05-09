Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports SportsStoreVb.Domain
Imports SportsStoreVb.Domain.Entities
Imports SportsStoreVb.WebUI
Imports SportsStoreVb.WebUI.Controllers
Imports SportsStoreVb.WebUI.HtmlHelpers

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub Can_Paginate()
        Dim mock As New Mock(Of IProductRepository)
        mock.Setup(Function(m) m.Products).Returns(New List(Of Product) From {
                                                      New Product() With {.ProductID = 1, .Name = "P1"},
                                                      New Product() With {.ProductID = 2, .Name = "P2"},
                                                      New Product() With {.ProductID = 3, .Name = "P3"},
                                                      New Product() With {.ProductID = 4, .Name = "P4"},
                                                      new Product() With {.ProductID = 5, .Name = "P5"}
                                                                                                         })
        Dim controller As New ProductController(mock.Object)
        controller.PageSize = 3

        Dim result = CType(controller.List(2).Model, IEnumerable(Of Product))

        Dim prodArray = result.ToArray()
        Assert.IsTrue(prodArray.Length = 2)
        Assert.AreEqual(prodArray(0).Name, "P4")
        Assert.AreEqual(prodArray(1).Name, "P5")
    End Sub

    <TestMethod()> Public Sub Can_Generate_Page_Links()
        Dim myHelper As HtmlHelper = Nothing
        Dim pagingInfo As New PagingInfo() With {
                .CurrentPage = 2,
                .TotalItems = 28,
                .ItemsPerPage = 10
                            }
        Dim pageUrlDelegate As Func(Of Integer, String) = Function(i) "Page" & i

        Dim result = myHelper.PageLinks(pagingInfo, pageUrlDelegate)

        Assert.AreEqual("<a class=""btn btn-default"" href=""Page1"">1</a>" & _
            "<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" & _
            "<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString())
    End Sub
End Class