Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Linq
Imports EssentialToolsVb.Models
Imports Moq

<TestClass()> Public Class UnitTest2
    Dim products As Product() = New List(Of Product) From
        {
        New Product With {.Name = "Kayak", .Category = "Watersports", .Price = 275D},
        New Product With {.Name = "Lifejacket", .Category = "Watersports", .Price = 48.95D},
        New Product With {.Name = "Soccer ball", .Category = "Soccer", .Price = 19.5D},
        New Product With {.Name = "Corner flag", .Category = "Soccer", .Price = 34.95D}
        }.ToArray()

    <TestMethod()> Public Sub Sum_Products_Correctly()
        ' Dim discounter As New MinimumDiscountHelper
        ' Dim target As New LinqValueCalculator(discounter)
        ' Dim goalTotal = products.Sum(Function(e) e.Price)
        Dim mock As New Mock(Of IDiscountHelper)
        mock.Setup(Function(m) m.ApplyDiscount(It.IsAny(Of Decimal))).Returns(Of Decimal)(Function(total) total)
        Dim target As New LinqValueCalculator(mock.Object)

        Dim result = target.ValueProducts(products)

        ' Assert.AreEqual(goalTotal, result)
        Assert.AreEqual(products.Sum(Function(e) e.Price), result)
    End Sub

    Private Function CreateProduct(value As Decimal) As Product()
        Return New Product() {New Product() With {.Price = value}}
    End Function

    <TestMethod()> <ExpectedException(GetType(ArgumentOutOfRangeException))> Public Sub Pass_Through_Variable_Discounts()
        Dim mock As New Mock(Of IDiscountHelper)
        mock.Setup(Function(m) m.ApplyDiscount(It.IsAny(Of Decimal))).Returns(Of Decimal)(Function(total) total)
        mock.Setup(Function(m) m.ApplyDiscount(It.Is(Of Decimal)(Function(v) 0 = v))).Throws(Of ArgumentOutOfRangeException)()
        mock.Setup(Function(m) m.ApplyDiscount(It.Is(Of Decimal)(Function(v) v > 100))).Returns(Of Decimal)(Function(total) (total * 0.9D))
        mock.Setup(Function(m) m.ApplyDiscount(It.IsInRange(Of Decimal)(10, 100, Range.Inclusive))).Returns(Of Decimal)(Function(total) (total - 5))
        Dim target As New LinqValueCalculator(mock.Object)

        Dim FiveDollarDiscount = target.ValueProducts(CreateProduct(5))
        Dim TenDollarDiscount = target.ValueProducts(CreateProduct(10))
        Dim FiftyDollarDiscount = target.ValueProducts(CreateProduct(50))
        Dim HundredDollarDiscount = target.ValueProducts(CreateProduct(100))
        Dim FiveHundredDollarDiscount = target.ValueProducts(CreateProduct(500))

        Assert.AreEqual(5D, FiveDollarDiscount, "$5 Fail")
        Assert.AreEqual(5D, TenDollarDiscount, "$10 Fail")
        Assert.AreEqual(45D, FiftyDollarDiscount, "$50 Fail")
        Assert.AreEqual(95D, HundredDollarDiscount, "$100 Fail")
        Assert.AreEqual(450D, FiveHundredDollarDiscount, "$500 Fail")
        target.ValueProducts(CreateProduct(0))
    End Sub
End Class