using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WaterLifeMVC.Data;
using WaterLifeMVC.Models;

namespace WaterLifeMVC.Controllers
{
    public class ProfileController : Controller
    {
        readonly private ApplicationDBContext _db;

        public ProfileController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductModel> products = _db.Products;
            return View(products);
        }

        [HttpGet]
        public IActionResult ManageProduct()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditDb(int? id)
        {
            ProductModel product = _db.Products.FirstOrDefault(x => x.id == id);

            if (id == null || id == 0 || product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult RemoveDb(int? id)
        {
            ProductModel product = _db.Products.FirstOrDefault(x => x.id == id);

            if (id == null || id == 0)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult RemoveDb(ProductModel product)
        {
            if (product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ManageProduct(ProductModel product, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    product.image = memoryStream.ToArray();
                }
            }

            _db.Products.Add(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditDb(ProductModel product, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    product.image = memoryStream.ToArray();
                }
            }

            _db.Products.Update(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
