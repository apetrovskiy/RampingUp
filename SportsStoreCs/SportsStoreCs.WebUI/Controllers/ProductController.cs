using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStoreCs.WebUI.Controllers
{
    using Domain.Abstract;

    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // public ViewResult List()
        public ViewResult List(int page = 1)
        {
            // return View(repository.Products);
            return View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
            );
        }
    }
}