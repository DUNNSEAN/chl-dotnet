using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Status { get; set; }

		[Required]
		public decimal Price => OrderLines.Sum(ol => ol.Price);

		public List<OrderLine> OrderLines { get; set; }

	}
}