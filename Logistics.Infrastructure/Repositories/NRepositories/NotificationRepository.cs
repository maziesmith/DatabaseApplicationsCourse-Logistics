using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using Logistics.Domain.Model;
using Logistics.Domain.Repositories;
using Logistics.Domain;

namespace Logistics.Infrastructure.NRepositories
{
	public class NotificationRepository : INotificationRepository
	{
		public NotificationRepository ()
		{
		}

		public void Insert (Notification notification)
		{
			NHibernateHelper.Insert (notification);
		}

		public void Update (Notification notification)
		{
			NHibernateHelper.Update (notification);
		}

		public void Delete (int id)
		{
			Notification notification = Find (id);
			NHibernateHelper.Delete (notification);
		}

		public Notification Find (int id)
		{
			return FindAll().FirstOrDefault(l => l.Id == id);
		}

		public IList<Notification> FindAllForUser (User user)
		{
			return FindAll().Where(l => l.User == user).ToList();
		}

		public IList<Notification> FindAll ()
		{
			return NHibernateHelper.Read<Notification>().ToList();
		}
	}
}

