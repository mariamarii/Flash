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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}