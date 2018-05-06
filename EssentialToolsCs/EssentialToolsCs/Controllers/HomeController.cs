namespace EssentialToolsCs.Controllers
{
    using System.Web.Mvc;
    using Models;
    using Ninject;

    // using Ninject;

    public class HomeController : Controller
    {
        private readonly IValueCalculator calc;
        private Product[] products =
        {
            new Product { Name = "Kayak", Category = "Watersports", Price = 275M }, 
            new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.95M }, 
            new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M }, 
            new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M }
        };

        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        // GET: Home
        public ActionResult Index()
        {
            //var ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            // var calc = new LinqValueCalculator();
            // var calc = ninjectKernel.Get<IValueCalculator>();
            var cart = new ShoppingCart(calc) {Products = products};
            var totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}