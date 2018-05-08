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

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}