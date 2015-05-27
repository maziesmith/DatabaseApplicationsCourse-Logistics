using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Application.Services
{
	public interface IUserService
	{
		bool SignIn(string login, string password);
		void CreateNewUser(User user);
		void CreateNewClient(User user);
		void CreateNewDriver(User user);
		void CreateNewAdmin(User user);
		void DeleteUser(User user);
		User GetUser(int id);
		IList<User> GetAllClients();
		IList<User> GetAllDrivers();
		IList<User> GetAllAdmins();
		IList<User> GetAllUsers();
	}
}

