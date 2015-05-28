using System;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Model.Entities.Notification;

namespace Logistics.Application.Services
{
	public interface INotificationService
	{
		void DeleteNotification(Notification notification);
		Notification GetNotification(int id);
		IList<Notification> GetAllNotification();
	}
}

