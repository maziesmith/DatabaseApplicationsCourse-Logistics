using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Domain.Repositories
{
	public interface INotificationRepository
	{
		void Insert(Notification notification);

		void Delete(uint id);

		Notification Find(uint id);

		IList<Notification> FindAllForUser(User user);

		IList<Notification> FindAll();
	}
}

