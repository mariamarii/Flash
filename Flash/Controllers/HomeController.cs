using Flash.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Flash.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Category()
        {
			FlashContext db= new FlashContext();
             var  cats= db.Categories.ToList();

			return View(cats);
        }
        public IActionResult Burgsta()
        {
            FlashContext db = new FlashContext();
            var menu_item = db.Products.ToList();

            return View(menu_item);
        }
		public IActionResult Creme()
		{
			FlashContext db = new FlashContext();
			var menu_item = db.Products.ToList();

			return View(menu_item);
		}

		public IActionResult Crinkle()
		{
			FlashContext db = new FlashContext();
			var menu_item = db.Products.ToList();

			return View(menu_item);
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}