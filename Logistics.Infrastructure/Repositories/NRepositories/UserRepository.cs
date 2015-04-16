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
	public class UserRepository : IUserRepository
	{
		public UserRepository ()
		{

		}

		public void Insert (User user)
		{
			NHibernateHelper.Insert (user);
		}

		public void Update (User user)
		{
			NHibernateHelper.Update (user);
		}

		public void Delete (int id)
		{
			User user = Find (id);
			NHibernateHelper.Delete (user);
		}

		public User Find (int id)
		{
			return FindAll().FirstOrDefault(u => u.Id == id);
		}

		public IList<User> FindAll ()
		{
			return NHibernateHelper.Read<User>().ToList();
		}

		public IList<User> FindAllWithRole (Role role)
		{
			return FindAll().Where(u => u.Role == role).ToList();
		}
	}
}

