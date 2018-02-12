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

		[Required]
		public string Bib_key { get; set; }

		public string Info_url { get; set; }
		public string Preview { get; set; }
		public string Preview_url { get; set; }
		public string Thumbnail_url { get; set; }
		public string Url { get; set; }
		public string Subtitle { get; set; }
		public string Identifiers { get; set; }
		public string Classifications { get; set; }
		public string Subjects { get; set; }
		public string Subject_places { get; set; }
		public string Subject_people { get; set; }
		public string Subject_times { get; set; }
		public string Publishers { get; set; }
		public string Publish_places { get; set; }
		public string Publish_date { get; set; }
		public string Excerpts { get; set; }
		public string Links { get; set; }
		public string Cover { get; set; }
		public string Ebooks { get; set; }
		public string Number_of_pages { get; set; }
		public string Weight { get; set; }
	}
}