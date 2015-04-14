using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Domain.Repositories
{
	public interface IOrderRepository
	{
		void Insert(Order order);

		void Delete(uint id);

		void Update(Order order);

		Order Find(uint id);

		IList<Order> FindAllForUser(User user);

		IList<Order> FindAll();
	}
}

