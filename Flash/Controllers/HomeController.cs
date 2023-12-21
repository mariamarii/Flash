using Flash.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Flash.Repositories;
using Stripe.Checkout;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace Flash.Controllers
{
    public class HomeController : Controller
    {
		private readonly IUnityOfWork _unityOfWork;
        [BindProperty]
		public ShoppingCartVM ShoppingCartVM { get; set; }

		public HomeController(IUnityOfWork unityOfWork)
		{
			_unityOfWork = unityOfWork;
		}


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

		/// </summary>
		/// <returns></returns>
		public IActionResult Details(int id=1)
		{
			ShoppingCart cart = new()
			{
				Product = _unityOfWork.Product.Get(u => u.Id == id),
				ProductId = id,
				Count = 1,
				
			};
			return View("Details",cart);
		}
        [HttpPost]
        [Authorize]
		[ValidateAntiForgeryToken]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            shoppingCart.Id = 0;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.UserId = userId;

            ShoppingCart cartFromDb = _unityOfWork.ShoppingCart.Get(x => x.UserId == userId && x.ProductId == shoppingCart.ProductId);
            if (cartFromDb != null)
            {

                cartFromDb.Count += shoppingCart.Count;
				cartFromDb.Price += shoppingCart.Price;
				_unityOfWork.ShoppingCart.Update(cartFromDb);
				_unityOfWork.Save();

			}
            else
            {
                _unityOfWork.ShoppingCart.Add(shoppingCart);
            }

            _unityOfWork.Save();

            return RedirectToAction(nameof(CartIndex));
        }
     
        public IActionResult CartIndex()
		{
			if (!User.Identity.IsAuthenticated)
			{
				return Redirect($"https://localhost:7166/Identity/Account/Login");
			}
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			
			ShoppingCartVM = new ()
			{
				ShoppingCartList = _unityOfWork.ShoppingCart.GetAll(x => x.UserId == UserId, includeProperties: "Product"),
				OrderHeader = new()
				
			};

            ShoppingCartVM.OrderHeader.OrderTotal = 0;
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
			{

				cart.Price = GetPriceBasedOnQuantity(cart);
				ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
			}
			return View("CartIndex",ShoppingCartVM);
		}
		private decimal GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
		{
			return (decimal)shoppingCart.Product.Price;

		}

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new ShoppingCartVM()
            {
                ShoppingCartList = _unityOfWork.ShoppingCart.GetAll(u => u.UserId == userId,
                includeProperties: "Product"),
                OrderHeader = new()
            };

            ShoppingCartVM.OrderHeader.User = _unityOfWork.User.Get(u => u.Id == userId);

            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.User.UserName;
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.User.PhoneNumber;
            ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.User.StreetAddress;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.User.City;
            ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.User.State;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.User.PostalCode;

            ShoppingCartVM.OrderHeader.OrderTotal = 0;
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = (decimal)GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);

            }

		      //_unityOfWork.OrderHeader.Update(ShoppingCartVM.OrderHeader);
		      //_unityOfWork.Save();
			var name = ShoppingCartVM.OrderHeader.Name;
            return View(ShoppingCartVM);
        }





        [HttpPost]
		[ActionName("Summary")]
		[ValidateAntiForgeryToken]
		public IActionResult Summary(ShoppingCartVM shoppingCartVM)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            //ShoppingCartVM.OrderHeader = _unityOfWork.OrderHeader
			  //.GetLast(o => o.UserId == userId);


            shoppingCartVM.ShoppingCartList = _unityOfWork.ShoppingCart.GetAll(u => u.UserId == userId, includeProperties: "Product");


			shoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
			shoppingCartVM.OrderHeader.UserId = userId;

			shoppingCartVM.OrderHeader.OrderTotal = 0;

			foreach (var cart in shoppingCartVM.ShoppingCartList)
			{

				cart.Price = (decimal)GetPriceBasedOnQuantity(cart);
				shoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
			}

			_unityOfWork.OrderHeader.Add(shoppingCartVM.OrderHeader);
			_unityOfWork.Save();

			foreach (var cart in shoppingCartVM.ShoppingCartList)
			{
				OrderDetail orderDetail = new()
				{
					ProductId = cart.ProductId,
					Count = cart.Count,
					Price = cart.Price,
					OrderHeaderId = shoppingCartVM.OrderHeader.Id,

				};
				_unityOfWork.OrderDetail.Add(orderDetail);
				_unityOfWork.Save();

			}
			
			_unityOfWork.ShoppingCart.RemoveRange(shoppingCartVM.ShoppingCartList);
			_unityOfWork.Save();



			//return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });
			// Stripe Setting
			var domain = "https://localhost:7166/";
			var options = new SessionCreateOptions
			{
                
				SuccessUrl = domain + $"Home/Category",
				CancelUrl = domain + $"Home/index",
				LineItems = new List<SessionLineItemOptions>(),
				Mode = "payment",
			};

			foreach (var item in shoppingCartVM.ShoppingCartList)
			{
				var sessionLineItem = new SessionLineItemOptions
				{
					PriceData = new SessionLineItemPriceDataOptions
					{
						UnitAmount = (long)(item.Price * 100), // $20.50 => 2050
						Currency = "usd",
						ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = item.Product.Name
						}
					},
					Quantity = item.Count
				};
				options.LineItems.Add(sessionLineItem);
			}

			var service = new SessionService();
			Session session = service.Create(options);
			_unityOfWork.OrderHeader.UpdateStripePaymentID(shoppingCartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
			_unityOfWork.Save();
			Response.Headers.Add("Location", session.Url);
			return new StatusCodeResult(303);


		}






		public IActionResult Plus(int cartId)
		{
			var cartFromDb = _unityOfWork.ShoppingCart.Get(x => x.Id == cartId);
			cartFromDb.Count +=1;
			//cartFromDb.Price += GetPriceBasedOnQuantity(cartFromDb);
			//cartFromDb.Price += (decimal)(cartFromDb.Product.Price);
			_unityOfWork.ShoppingCart.Update(cartFromDb);
			_unityOfWork.Save();
			return RedirectToAction(nameof(CartIndex));
		}



		public IActionResult Minus(int cartId)
		{
			var cartFromDb = _unityOfWork.ShoppingCart.Get(x => x.Id == cartId);
			if (cartFromDb.Count <= 1)
			{
				_unityOfWork.ShoppingCart.Remove(cartFromDb);

			}
			else
			{
				cartFromDb.Count -= 1;
				//cartFromDb.Price -= (decimal)(cartFromDb.Product.Price);

				_unityOfWork.ShoppingCart.Update(cartFromDb);
			}
			_unityOfWork.Save();
			return RedirectToAction(nameof(CartIndex));
		}


		public IActionResult Remove(int cartId)
		{
			var cartFromDb = _unityOfWork.ShoppingCart.Get(x => x.Id == cartId);
			_unityOfWork.ShoppingCart.Remove(cartFromDb);
			_unityOfWork.Save();
			return RedirectToAction(nameof(CartIndex));
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
        
        
           
       
