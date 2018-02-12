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
		[ScaffoldColumn(false)]
		public int Id { get; set; }

		[Required]
		[ScaffoldColumn(false)]
		public decimal Price { get; set; }
		[ScaffoldColumn(false)]
		public string Status { get; set; }

		public List<OrderLine> OrderLines { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		[ScaffoldColumn(false)]
		public System.DateTime OrderDate { get; set; }
	}
}