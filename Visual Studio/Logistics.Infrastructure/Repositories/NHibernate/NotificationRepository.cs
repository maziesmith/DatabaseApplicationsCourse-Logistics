using System.Collections.Generic;
using System.Linq;
using Logistics.Domain.Model.Entities.Notification;
using Logistics.Domain.Model.Entities.User;
using Logistics.Domain.Repositories;
using Logistics.Infrastructure.Mappings;
using NHibernate.Linq;

namespace Logistics.Infrastructure.Repositories.NHibernate
{
	public class NotificationRepository : INotificationRepository
	{
		public NotificationRepository ()
		{
		}

		public void Insert (Notification notification)
		{
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(notification);
                    tx.Commit();
                }
            }
        }

		public void Update (Notification notification)
		{
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(notification);
                    tx.Commit();
                }
            }
		}

		public void Delete (int id)
		{
			Notification notification = Find (id);
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(notification);
                    tx.Commit();
                }
            }
		}

		public Notification Find (int id)
		{
			return FindAll().FirstOrDefault(l => l.Id == id);
		}

		public IList<Notification> FindAllForUser (User user)
		{
			return FindAll().Where(l => l.User == user).ToList();
		}

        public IList<Notification> FindAll()
        {
            using (var session = NHibernateHelper.OpenConnection())
            {
                return session.Query<Notification>().ToList();
            }
        }

        public IQueryable<Notification> FindAllQuery()
        {
            using (var session = NHibernateHelper.OpenConnection())
            {
                return session.Query<Notification>();
            }
        }
	}
}

