using Microsoft.AspNetCore.Mvc;

namespace WaterLifeMVC.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
