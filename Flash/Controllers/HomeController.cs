using Flash.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.Build.Framework;

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
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

            [HttpPost]

        
        public IActionResult Contact(Contact contact)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                MailMessage mail = new MailMessage();
                // you need to enter your mail address
                mail.From = new MailAddress("fromemailaddress@example.com");

                //To Email Address - your need to enter your to email address
                mail.To.Add("toemailaddress@example.com");

                mail.Subject = contact.Subject;

                //you can specify also CC and BCC - i will skip this
                //mail.CC.Add("");
                //mail.Bcc.Add("");

                mail.IsBodyHtml = true;

                string content = "Name : " + contact.Name;
                content += "<br/> Message : " + contact.Message;

                mail.Body = content;


                //create SMTP instant

                //you need to pass mail server address and you can also specify the port number if you required
                SmtpClient smtpClient = new SmtpClient("mail.example.com");

                //Create nerwork credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("fromemailaddress@example.com", "password");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 25; // this is default port number - you can also change this
                smtpClient.EnableSsl = false; // if ssl required you need to enable it
                smtpClient.Send(mail);

                ViewBag.Message = "Mail Send";

                // now i need to create the from 
                ModelState.Clear();

            }
            catch (Exception ex)
            {
                //If any error occured it will show
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }
    }

}
