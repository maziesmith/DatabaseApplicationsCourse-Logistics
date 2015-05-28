using System;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Model.Entities.User;

namespace Logistics.Domain.Repositories
{
	public interface IUserRepository
	{
		void Insert(User user);

		void Delete(int id);

		User Find(int id);

		void Update(User user);

		IList<User> FindAll();

		IList<User> FindAllWithRole (Role role);
	}
}

