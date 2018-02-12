using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class CheckoutController : Controller
    {
		const string PromoCode = "Free";

		public ActionResult AddressAndPayment()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddressAndPayment(FormCollection values)
		{
			var order = new Order();
			TryUpdateModel(order);

			if (string.Equals(values["PromoCode"], PromoCode,
					StringComparison.OrdinalIgnoreCase) == false)
			{
				return View(order);
			}
			else
			{
				order.OrderDate = DateTime.Now;

				//Save Order
				using (var db = new DatabaseContext())
				{
					db.Orders.Add(order);
					db.SaveChanges();
				}

				return RedirectToAction("Complete", new { id = order.Id });
			}
		}

		public ActionResult Complete(int id)
		{
			return View(id);
		}
    }
}