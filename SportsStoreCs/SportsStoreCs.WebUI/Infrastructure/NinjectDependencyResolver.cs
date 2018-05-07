namespace SportsStoreCs.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.WebSockets;
    using Moq;
    using Ninject;
    using SportsStoreCs.Domain.Abstract;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void AddBindings()
        {
            var mock = new Mock<IProductRepository>();

        }
    }
}