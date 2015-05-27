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
	public class NotificationServiceTests
	{
		[Test ()]
		public void GetNotificationServiceTest ()
		{
			Mock<INotificationRepository> notificationRepositoryMock = new Mock<INotificationRepository>();
			INotificationService ls = new NotificationService(notificationRepositoryMock.Object);

			ls.GetNotification (1);

			notificationRepositoryMock.Verify(k => k.Find(1), Times.Once());
		}

		[Test ()]
		public void GetAllNotificationsServiceTest ()
		{
			Mock<INotificationRepository> notificationRepositoryMock = new Mock<INotificationRepository>();
			INotificationService ls = new NotificationService(notificationRepositoryMock.Object);

			ls.GetAllNotification ();

			notificationRepositoryMock.Verify(k => k.FindAll(), Times.Once());
		}
	}
}

