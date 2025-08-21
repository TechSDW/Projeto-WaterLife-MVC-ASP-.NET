using System.Data;
using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WaterLifeMVC.Models;

namespace WaterLifeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetProduct(string name)
        {
            try
            {
                CrudModel crud = new CrudModel();
                ProductModel product = crud.GetProduct(name);
                AddCart(product);
                return View();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpPost]
        public IActionResult AddCart(ProductModel produtos)
        {
            if (!ModelState.IsValid)
            {
                return View(produtos);
            }

            try
            {
                CrudModel crud = new CrudModel();
                crud.createProduct(produtos);
                return RedirectToAction(nameof(Create));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
