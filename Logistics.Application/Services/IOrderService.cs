using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Application.Services
{
	public interface IOrderService
	{
		Order CreateOrder(Adress adress, Payment payment, uint Priority);
		void DeleteOrder(Order order);
		Order GetOrder(uint id);
		IList<Order> GetAllOrders();
	}
}

