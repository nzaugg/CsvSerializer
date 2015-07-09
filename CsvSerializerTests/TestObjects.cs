using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvSerializer;

namespace CsvSerializerTests
{
	public class Person
	{
		[CsvIgnore]
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}


	public class Order
	{
		public string Id { get; set; }
		public DateTime OrderDate { get; set; }
		public Person Customer { get; set; }
		public decimal Subtotal { get; set; }
		public decimal Tax { get; set; }
		public decimal Total { get; set; }

		public IEnumerable<OrderItem> Items { get; protected set; }

		public Order()
		{
			Items = new List<OrderItem>();
		}

		public void Add(OrderItem value)
		{
			((IList)Items).Add(value);
		}
	}

	public class OrderItem
	{
		[CsvIgnore]
		public string Id { get; set; }

		public string Name { get; set; }
		public string ShortDescription { get; set; }
		public decimal PricePerQty { get; set; }
		public decimal Qty { get; set; }
		public decimal LineTotal { get; set; }
	}
}
