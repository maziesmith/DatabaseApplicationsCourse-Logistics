using NUnit.Framework;
using System;
using Logistics.Infrastructure.Repositories;
using Logistics.Application.Services;
using Logistics.Domain.Repositories;
using Moq;
using Logistics.ObjectMothers;
using Logistics.Domain.Model;

namespace Logistics.Application.UnitTests
{
	[TestFixture ()]
	public class OrderServiceTests
	{
		[Test ()]
		public void GetOrderServiceTest ()
		{
			Mock<IOrderRepository> orderRepositoryMock = new Mock<IOrderRepository>();
			IOrderService ls = new OrderService(orderRepositoryMock.Object);

			ls.GetOrder (1);

			orderRepositoryMock.Verify(k => k.Find(1), Times.Once());
		}

		[Test ()]
		public void GetAllOrderServiceTest ()
		{
			Mock<IOrderRepository> orderRepositoryMock = new Mock<IOrderRepository>();
			IOrderService ls = new OrderService(orderRepositoryMock.Object);

			ls.GetAllOrders ();

			orderRepositoryMock.Verify(k => k.FindAll(), Times.Once());
		}
	}
}

