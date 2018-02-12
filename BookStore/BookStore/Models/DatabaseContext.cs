using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace BookStore.Models
{
	public class DatabaseContext
		: DbContext
	{
		public DatabaseContext()
			: base(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStore;Integrated Security=True;MultipleActiveResultSets=True")
		{
		}

		public DbSet<Order> Orders { get; set; }

		public DbSet<Book> Books { get; set; }

		public DbSet<OrderLine> OrderLines { get; set; }
	}
}