using System.Data;
using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WaterLifeMVC.Models;

namespace WaterLifeMVC.Controllers
{
    public class ShopcartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
