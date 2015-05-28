using System.Collections.Generic;
using System.Linq;
using Logistics.Domain.Model.Entities.Order;
using Logistics.Domain.Model.Entities.User;
using Logistics.Domain.Repositories;

namespace Logistics.Infrastructure.Repositories.Memory
{
	public class OrderRepository : IOrderRepository
	{
		private List<Order> orders = new List<Order>();

		public OrderRepository ()
		{
			orders = new List<Order>
			{
				new Order {  
					Address = new Address { City = "Wroclaw", Street = "Szczytnicka", HouseNumber = 4 }
				}
			};
		}
			
		public void Insert (Order order)
		{
			orders.Add (order);
		}

		public void Update(Order order)
		{
			var oldOrder = orders.FirstOrDefault(o => o.Id == order.Id);
			oldOrder.Address = order.Address;
			oldOrder.Payment = order.Payment;
			oldOrder.Status = order.Status;
		}

		public void Delete (int id)
		{
			orders.Remove(orders.Find(o => o.Id == id));
		}

		public Order Find (int id)
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

