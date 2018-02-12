using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using LinqKit;

namespace BookStore.Controllers
{
    public class CatalogController : Controller
    {

		public ActionResult Search(string searchTerm)
		{
			using (var db = new DatabaseContext())
			{
				var terms = searchTerm?.Split(' ') ?? new string[0];
				var predicate = terms.Aggregate(
					PredicateBuilder.New<Book>(string.IsNullOrEmpty(searchTerm)),
					(acc, term) => acc.Or(b => b.Title.Contains(term))
					.Or(b => b.Author.Contains(term)));

				var books = db.Books.AsExpandable()
					.Where(predicate)
					.OrderBy(b => b.Title)
					.ToArray();

				return View("List", books);
			}
		}

        public ActionResult Details(string title)
        {
			using (var db = new DatabaseContext())
			{
				var book = db.Books.First(b => b.Title == title);
				return View(book);
			}
        }
    }
}