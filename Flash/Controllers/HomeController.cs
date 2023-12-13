using Flash.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
            var cats = db.Categories.ToList();

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

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveContact(Contact model)
        {
            using (var db = new aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context())
            {
                try
                {
                    // Add the entity to the context
                    db.Contacts.Add(model);
                    db.Entry(model).State = EntityState.Added;
                    var entry = db.Entry(model);
                    Console.WriteLine($"Entity State: {entry.State}");

                    // Save changes to the database
                    db.SaveChanges();

                    // Optionally, do more operations if needed

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log or print the exception details
                    Console.WriteLine($"Error during SaveChanges(): {ex.Message}");
                    // Optionally, handle the exception appropriately
                    // You can redirect to an error page or return an error view
                    return View("Error");
                }
            }
        }


    }
}
        
        
           
       
