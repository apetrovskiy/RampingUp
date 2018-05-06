Imports System.Web.Mvc
Imports Ninject

Public Class NinjectDependencyResolver
    Implements IDependencyResolver

    Private ReadOnly kernel As IKernel

    Public Sub New(kernelParam As IKernel)
        kernel = kernelParam
        AddBindings()
    End Sub

    Public Function GetService(serviceType As Type) As Object Implements IDependencyResolver.GetService
        Return kernel.TryGet(serviceType)
    End Function

    Public Function GetServices(serviceType As Type) As IEnumerable(Of Object) Implements IDependencyResolver.GetServices
        Return kernel.GetAll(serviceType)
    End Function

    Private Sub AddBindings()
        kernel.Bind(Of IValueCalculator).To(Of LinqValueCalculator)()
        ' kernel.Bind(Of IDiscountHelper).To(Of DefaultDiscountHelper)()
        ' property injection
        ' kernel.Bind(Of IDiscountHelper).To(Of DefaultDiscountHelper)().WithPropertyValue("DiscountSize", 50D)
        ' constructor injection
        kernel.Bind(Of IDiscountHelper).To(Of DefaultDiscountHelper)().WithConstructorArgument("discountParam", 50D)
    End Sub
End Class