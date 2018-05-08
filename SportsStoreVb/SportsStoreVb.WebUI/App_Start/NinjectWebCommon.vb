Imports System.Runtime.Remoting.Messaging
Imports Microsoft.Web.Infrastructure.DynamicModuleHelper
Imports Ninject
Imports Ninject.Web.Common

<Assembly: WebActivator.PreApplicationStartMethod(GetType(NinjectWebCommon), "Start")>
<Assembly: WebActivator.ApplicationShutdownMethodAttribute(GetType(NinjectWebCommon), "Stop1")>

Public Class NinjectWebCommon
    Private Shared ReadOnly bootstrapper = New Bootstrapper()

    Public Shared Sub Start()
        DynamicModuleUtility.RegisterModule(GetType(OnePerRequestHttpModule))
        DynamicModuleUtility.RegisterModule(GetType(NinjectHttpModule))
        bootstrapper.Initialize(CreateKernel())
    End Sub

    Public Shared Sub Stop1()
        bootstrapper.ShutDown()
    End Sub

    Private Shared Function CreateKernel() As Func(Of IKernel) 'IKernel
        Dim kernel = New StandardKernel()
        kernel.Bind(Of Func(Of IKernel))().ToMethod(
            Function(ctx)
                Return Function() New Bootstrapper().Kernel
            End Function)
        kernel.Bind(Of IHttpModule).To(Of HttpApplicationInitializationHttpModule)()

        RegisterServices(kernel)
        ' Return kernel
        Return Function() kernel
    End Function

    Private Shared Sub RegisterServices(kernel As IKernel)
        System.Web.Mvc.DependencyResolver.SetResolver(New NinjectDependencyResolver(kernel))
    End Sub
End Class
