using System;
using Logistics.Infrastructure.Repositories;
using Logistics.Application.Services;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Model.Entities.Order;
using Logistics.Domain.Repositories;
using Logistics.Infrastructure.Repositories.NHibernate;

namespace Logistics.Application.Services
{
	public class OrderService : IOrderService
	{
		private IOrderRepository _orderRepository;

		public OrderService ()
		{
			_orderRepository = new OrderRepository ();
		}

		public OrderService ( IOrderRepository orderRepository )
		{
			_orderRepository = orderRepository;
		}
		public Order CreateOrder( Address adress, Payment payment, int priority )
		{
			Order o = new Order { 
				Address = adress,
				Payment = payment,
				Priority = priority
			};
			_orderRepository.Insert (o);
			return o;
		}
		public void DeleteOrder (Order order)
		{
			_orderRepository.Delete (order.Id);
		}
		public Order GetOrder (int id)
		{
			return _orderRepository.Find (id);
		}

		public IList<Order> GetAllOrders ()
		{
			return _orderRepository.FindAll ();
		}
	}
}

