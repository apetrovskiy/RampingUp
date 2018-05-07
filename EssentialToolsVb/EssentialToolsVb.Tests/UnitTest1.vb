Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1
    Function GetTestObject() As IDiscountHelper
        Return New MinimumDiscountHelper()
    End Function

    <TestMethod()> Public Sub Discount_Above_100()
        Dim target = GetTestObject()
        Dim total As Decimal = 200

        Dim discountedTotal = target.ApplyDiscount(total)

        Assert.AreEqual(total * 0.9D, discountedTotal)
    End Sub

    <TestMethod()> Public Sub Discount_Between_10_And_100()
        Dim target = GetTestObject()

        Dim TenDollarDiscount = target.ApplyDiscount(10)
        Dim HundredDollarDiscount = target.ApplyDiscount(100)
        Dim FiflyDollarDiscount = target.ApplyDiscount(50)

        Assert.AreEqual(5D, TenDollarDiscount, "$10 discount is wrong")
        Assert.AreEqual(95D, HundredDollarDiscount, "$100 disocunt is wrong")
        Assert.AreEqual(45D, FiflyDollarDiscount, "$50 discount is wrong")
    End Sub

    <TestMethod()> Public Sub Discount_Less_Than_10()
        Dim target = GetTestObject()

        Dim discount5 = target.ApplyDiscount(5)
        Dim discount0 = target.ApplyDiscount(0)

        Assert.AreEqual(5D, discount5)
        Assert.AreEqual(0D, discount0)
    End Sub

    <TestMethod()> <ExpectedException(GetType(ArgumentOutOfRangeException))> Public Sub Discount_Negative_Total()
        Dim target = GetTestObject()

        target.ApplyDiscount(-5)
    End Sub
End Class