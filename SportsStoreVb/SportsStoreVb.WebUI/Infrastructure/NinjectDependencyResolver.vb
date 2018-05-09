Imports System.Web.Mvc
Imports Ninject
Imports SportsStoreVb.Domain
Imports SportsStoreVb.Domain.Concrete
Imports SportsStoreVb.Domain.SportsStoreVb.Domain.Concrete

Public Class NinjectDependencyResolver
    Implements IDependencyResolver
    ReadOnly kernel As IKernel

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
        ' Dim mock As New Mock(Of IProductRepository)
        ' mock.Setup(Function(m) m.Products).Returns(New List(Of Product) From {
        '                                               New Product() With{.Name = "Football", .Price = 25},
        '                                               New Product() With {.Name="Surf board", .Price = 179 },
        '                                               New Product() With{.Name = "Running shoes", .Price = 95 }
        '                                            })
        ' kernel.Bind(Of IProductRepository).ToConstant(mock.Object)
        kernel.Bind(Of IProductRepository).To(Of EFProductRepository)
    End Sub
End Class