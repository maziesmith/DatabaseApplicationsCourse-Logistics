using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using Logistics.Domain.Model;
using Logistics.Domain.Repositories;

namespace Logistics.Infrastructure.Repositories
{
	public class NotificationRepository : INotificationRepository
	{
		private List<Notification> notifications  = new List<Notification>();

		public NotificationRepository ()
		{
			notifications = new List<Notification>
			{
				new Notification {
					ShortValue = "Ola",
					FullValue = "Piesek",
					NotificationType = NotificationType.EMAIL
				}
			};
		}
			
		public void Insert (Notification notification)
		{
			notifications.Add(notification);
		}

		public void Update(Notification notification)
		{
			var oldNotification = notifications.FirstOrDefault(n => n.Id == notification.Id);
			oldNotification.ShortValue = notification.ShortValue;
			oldNotification.FullValue = notification.FullValue;
		}

		public void Delete (uint id)
		{
			notifications.Remove(notifications.Find(n => n.Id == id));
		}

		public Notification Find (uint id)
		{
			return notifications.FirstOrDefault(n => n.Id == id);
		}

		public IList<Notification> FindAllForUser (User user)
		{
			return notifications.Where(n => n.User == user).ToList();
		}

		public IList<Notification> FindAll ()
		{
			return notifications;
		}
	}
}

