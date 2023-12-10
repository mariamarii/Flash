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
            aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db = new aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context();
             var  cats= db.Categories.ToList();

            return View(cats);
        }
        public IActionResult Burgsta()
        {
            aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db = new aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context();
            var menu_item = db.Products.ToList();

            return View(menu_item);
        }
		public IActionResult Creme()
		{
            aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db = new aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context();
			var menu_item = db.Products.ToList();

			return View(menu_item);
		}

		public IActionResult Crinkle()
		{
            aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db = new aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context();
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