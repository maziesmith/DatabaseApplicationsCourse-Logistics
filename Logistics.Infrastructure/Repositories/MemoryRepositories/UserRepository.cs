using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using Logistics.Domain.Repositories;
using Logistics.Domain.Model;

namespace Logistics.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private List<User> users = new List<User>();

		public UserRepository ()
		{
			users = new List<User>
			{
				new User { Login = "Olamakota", Email = "tori@robert-i.com", EncryptedPassword = "olamakota123", Role = Role.ADMIN }
			};
		}
			
		public void Insert (User user)
		{
			users.Add(user);
		}
			
		public void Update(User user)
		{
			var oldUser = users.FirstOrDefault(u => u.Id == user.Id);
			oldUser.Login = user.Login;
			oldUser.Username = user.Username;
			oldUser.Email = user.Email;
			oldUser.EncryptedPassword = user.EncryptedPassword;
			oldUser.PhoneNumber = user.PhoneNumber;
			oldUser.Role = user.Role;
			oldUser.PhoneNumber = user.PhoneNumber;
		}

		public void Delete (int id)
		{
			users.Remove(users.Find(u => u.Id == id));
		}

		public User Find (int id)
		{
			return users.FirstOrDefault(u => u.Id == id);
		}

		public IList<User> FindAll ()
		{
			return users;
		}

		public IList<User> FindAllWithRole (Role role)
		{
			return users.Where(o => o.Role == role).ToList();
		}
	}
}

