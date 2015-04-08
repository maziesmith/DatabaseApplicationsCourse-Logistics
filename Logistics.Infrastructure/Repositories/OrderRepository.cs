using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using Logistics.Domain.Repositories;
using Logistics.Domain.Model;

namespace Logistics.Infrastructure.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private List<Order> orders = new List<Order>();

		public OrderRepository ()
		{
			orders = new List<Order>
			{
				new Order { 
					Id = 1, 
					Adress = new Adress { City = "Wroclaw", Street = "Szczytnicka", HouseNumber = 4 }
				}
			};
		}
			
		public void Insert (Order order)
		{
			orders.Add (order);
		}

		public void Delete (uint id)
		{
			orders.Remove(orders.Find(o => o.Id == id));
		}

		public Order Find (uint id)
		{
			return orders.FirstOrDefault(o => o.Id == id);
		}

		public IList<Order> FindAllForUser (User user)
		{
			return orders.Where(o => (o.Driver == user || o.Client == user)).ToList();
		}

		public IList<Order> FindAll ()
		{
			return orders;
		}
	}
}

