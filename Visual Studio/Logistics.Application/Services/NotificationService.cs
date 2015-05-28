using System;
using Logistics.Infrastructure.Repositories;
using Logistics.Application.Services;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Model.Entities.Notification;
using Logistics.Domain.Repositories;
using Logistics.Infrastructure.Repositories.NHibernate;

namespace Logistics.Application.Services
{
	public class NotificationService : INotificationService
	{
		private INotificationRepository _notificationRepository;

		public NotificationService ()
		{
			_notificationRepository = new NotificationRepository ();
		}

		public NotificationService ( INotificationRepository notificationRepository )
		{
			_notificationRepository = notificationRepository;
		}
			
		public void DeleteNotification (Notification notification)
		{
			_notificationRepository.Delete (notification.Id);
		}

		public Notification GetNotification (int id)
		{
			return _notificationRepository.Find (id);
		}

		public IList<Notification> GetAllNotification ()
		{
			return _notificationRepository.FindAll ();
		}
	}
}

