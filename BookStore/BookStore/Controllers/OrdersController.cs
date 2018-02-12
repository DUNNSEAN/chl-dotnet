using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Orders()
        {
			using (var db = new DatabaseContext())
			{
				var orders = db.Orders.OrderBy(b => b.Id)
					.Take(db.Orders.Count())
					.OrderBy(b => b.Id)
					.ToArray();

				return View(orders);
			}
        }
    }
}