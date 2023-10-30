using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork unit;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            unit = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list = unit.Product.GetAll("Category");
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var pro = unit.Product.Get(p => p.Id == id, "Category");
            return View(pro);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
