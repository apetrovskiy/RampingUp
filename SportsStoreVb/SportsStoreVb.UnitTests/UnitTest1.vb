Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports SportsStoreVb.Domain
Imports SportsStoreVb.Domain.SportsStoreVb.Domain.Entities
Imports SportsStoreVb.WebUI.Controllers

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

End Class