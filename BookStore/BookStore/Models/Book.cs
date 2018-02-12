using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Author { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		[Range(0d, double.MaxValue)]
		public decimal Price { get; set; }

		public List<OrderLine> OrderLines { get; set; }
	}
}