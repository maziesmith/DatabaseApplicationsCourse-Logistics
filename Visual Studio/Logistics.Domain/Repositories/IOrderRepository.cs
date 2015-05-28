using System;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Model.Entities.Order;
using Logistics.Domain.Model.Entities.User;

namespace Logistics.Domain.Repositories
{
	public interface IOrderRepository
	{
		void Insert(Order order);

		void Delete(int id);

		void Update(Order order);

		Order Find(int id);

		IList<Order> FindAllForUser(User user);

		IList<Order> FindAll();
	}
}

