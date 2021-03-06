﻿namespace SportsStoreCs.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.WebSockets;
    using Domain.Concrete;
    using Domain.Entities;
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
            /*
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {Name = "Football", Price = 25},
                new Product {Name = "Surf board", Price = 179},
                new Product {Name = "Running shoes", Price = 95}
            });
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            */
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}