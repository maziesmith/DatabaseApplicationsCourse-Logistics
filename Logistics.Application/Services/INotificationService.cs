using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Application.Services
{
	public interface INotificationService
	{
		void DeleteNotification(Notification notification);
		Notification GetNotification(uint id);
		IList<Notification> GetAllNotification();
	}
}

