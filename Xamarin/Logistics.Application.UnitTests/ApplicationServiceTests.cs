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
	public class ApplicationServiceTests
	{
		[Test ()]
		public void AddOrderToUserAndDriverTest ()
		{
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			Mock<INotificationRepository> notificationRepositoryMock = new Mock<INotificationRepository>();
			Mock<ILogRepository> logRepositoryMock = new Mock<ILogRepository>();
			Mock<IOrderRepository> orderRepositoryMock = new Mock<IOrderRepository>();

			IApplicationService aps = new ApplicationService(userRepositoryMock.Object, orderRepositoryMock.Object, notificationRepositoryMock.Object, logRepositoryMock.Object);

			var order = new Order { 
				Address = new Address { City = "Wroclaw", Street = "Szczytnicka", HouseNumber = 4 }
			};

			var client = UserObjectMother.CreateNewClient();
			var driver = UserObjectMother.CreateNewDriver();

			aps.AddOrderToUserAndDriver (order, client, driver);

			orderRepositoryMock.Verify(k => k.Insert(order), Times.Once());
		}

		[Test ()]
		public void CreateNewNotificationTest ()
		{
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			Mock<INotificationRepository> notificationRepositoryMock = new Mock<INotificationRepository>();
			Mock<ILogRepository> logRepositoryMock = new Mock<ILogRepository>();
			Mock<IOrderRepository> orderRepositoryMock = new Mock<IOrderRepository>();

			IApplicationService aps = new ApplicationService(userRepositoryMock.Object, orderRepositoryMock.Object, notificationRepositoryMock.Object, logRepositoryMock.Object);

			var order = new Order { 
				Address = new Address { City = "Wroclaw", Street = "Szczytnicka", HouseNumber = 4 }
			};
					 
			var client = UserObjectMother.CreateNewClient();

			var newNotification = aps.CreateNewNotification (order, Status.INFORMATION_RECEIVED, client);

			Assert.IsInstanceOf<Notification>(newNotification);
		}


		[Test ()]
		public void GetAllOrdersFromDriverTest ()
		{
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			Mock<INotificationRepository> notificationRepositoryMock = new Mock<INotificationRepository>();
			Mock<ILogRepository> logRepositoryMock = new Mock<ILogRepository>();
			Mock<IOrderRepository> orderRepositoryMock = new Mock<IOrderRepository>();

			IApplicationService aps = new ApplicationService(userRepositoryMock.Object, orderRepositoryMock.Object, notificationRepositoryMock.Object, logRepositoryMock.Object);

			var order = new Order { 
				Address = new Address { City = "Wroclaw", Street = "Szczytnicka", HouseNumber = 4 }
			};

			var client = UserObjectMother.CreateNewClient();
			var driver = UserObjectMother.CreateNewDriver();

			aps.AddOrderToUserAndDriver (order, client, driver);
		}
	}
}

