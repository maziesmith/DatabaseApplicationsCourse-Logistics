using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Application.Services
{
	public interface IApplicationService
	{
		void AddOrderToUserAndDriver(Order order, User client, User driver);
		Notification CreateNewNotification (Order order, Status status, User client);
		void ChangeNotificationForUser (Notification notification, Status status, User user);
		void SendNotificationToAllClients (Notification notification);
		void SendNotificationToAllDrivers (Notification notification);
		void SendNotificationToAllAdmins(Notification notification);
		void SendNotificationToAllUsers(Notification notification);
		void DeleteAllNotificationFromUser(User user);
		IList<Order> GetAllOrdersFromDriver(User driver);
	}
}

