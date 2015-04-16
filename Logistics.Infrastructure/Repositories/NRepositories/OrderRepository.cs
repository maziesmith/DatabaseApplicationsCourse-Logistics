using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using Logistics.Domain.Model;
using Logistics.Domain.Repositories;
using Logistics.Domain;

namespace Logistics.Infrastructure.NRepositories
{
	public class OrderRepository : IOrderRepository
	{
		public OrderRepository ()
		{

		}

		public void Insert (Order order)
		{
			NHibernateHelper.Insert (order);
		}

		public void Update (Order order)
		{
			NHibernateHelper.Update (order);
		}

		public void Delete (int id)
		{
			Order order = Find (id);
			NHibernateHelper.Delete (order);
		}

		public Order Find (int id)
		{
			return FindAll().FirstOrDefault(o => o.Id == id);
		}

		public IList<Order> FindAll ()
		{
			return NHibernateHelper.Read<Order>().ToList();
		}

		public IList<Order> FindAllForUser (User user)
		{
			return FindAll().Where(o => (o.Driver == user || o.Client == user)).ToList();
		}
	}
}

