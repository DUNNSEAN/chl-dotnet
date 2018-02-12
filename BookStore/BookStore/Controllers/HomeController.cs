using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using (var db = new DatabaseContext())
			{
				var books = db.Books.OrderBy(b => b.Price)
					.Take(3)
					.OrderBy(b => b.Title)
					.ToArray();

				return View(books);
			}
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}