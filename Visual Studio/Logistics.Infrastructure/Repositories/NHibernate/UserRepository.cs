using System.Collections.Generic;
using System.Linq;
using Logistics.Domain.Model.Entities.User;
using Logistics.Domain.Repositories;
using Logistics.Infrastructure.Mappings;
using NHibernate.Linq;

namespace Logistics.Infrastructure.Repositories.NHibernate
{
	public class UserRepository : IUserRepository
	{
		public UserRepository ()
		{

		}

		public void Insert (User user)
		{
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(user);
                    tx.Commit();
                }
            }
        }

		public void Update (User user)
		{
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(user);
                    tx.Commit();
                }
            }
        }

		public void Delete (int id)
		{
			User user = Find (id);
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(user);
                    tx.Commit();
                }
            }
        }

		public User Find (int id)
		{
			return FindAll().FirstOrDefault(u => u.Id == id);
		}

		public IList<User> FindAll ()
		{
            using (var session = NHibernateHelper.OpenConnection())
            {
                return session.Query<User>().ToList();
            }
        }

		public IList<User> FindAllWithRole (Role role)
		{
			return FindAll().Where(u => u.Role == role).ToList();
		}
	}
}

