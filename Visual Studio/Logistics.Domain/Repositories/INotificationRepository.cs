using System;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Model.Entities.Notification;
using Logistics.Domain.Model.Entities.User;

namespace Logistics.Domain.Repositories
{
	public interface INotificationRepository
	{
		void Insert(Notification notification);

		void Delete(int id);

		void Update(Notification notification);

		Notification Find(int id);

		IList<Notification> FindAllForUser(User user);

		IList<Notification> FindAll();
	}
}

