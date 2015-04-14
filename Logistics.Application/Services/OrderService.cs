using System;
using Logistics.Infrastructure.Repositories;
using Logistics.Application.Services;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Repositories;

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
		public Order CreateOrder( Adress adress, Payment payment, uint priority )
		{
			Order o = new Order { 
				Adress = adress,
				Payment = payment,
				Priority = priority
			};
			return o;
		}
		public void DeleteOrder (Order order)
		{
			_orderRepository.Delete (order.Id);
		}
		public Order GetOrder (uint id)
		{
			return _orderRepository.Find (id);
		}

		public IList<Order> GetAllOrders ()
		{
			return _orderRepository.FindAll ();
		}
	}
}

