using System;
using Logistics.Infrastructure.Repositories;
using Logistics.Application.Services;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Repositories;

namespace Logistics.Application.Services
{
	public class UserService : IUserService
	{
		private IUserRepository _userRepository;

		public UserService ()
		{
			_userRepository = new UserRepository ();
		}

		public UserService( IUserRepository userRepository )
		{
			_userRepository = userRepository;
		}
			
		public bool SignIn (string login, string password)
		{
			if (login == "Robcio" && password == "asdfghjkl11#2")
				return true;
			else 
				return false;
		}
		public void CreateNewUser( User user)
		{
			switch (user.Role) {
				case Role.CLIENT:
					CreateNewClient (user);
					break;
				case Role.DRIVER:
					CreateNewDriver (user);
					break;
				case Role.ADMIN:
					CreateNewAdmin (user);
					break;
			}
		}

		public void CreateNewClient (User user)
		{
			user.Role = Role.CLIENT;
			_userRepository.Insert (user);
		}

		public void CreateNewDriver (User user)
		{
			user.Role = Role.DRIVER;
			_userRepository.Insert (user);
		}

		public void CreateNewAdmin (User user)
		{
			user.Role = Role.ADMIN;
			_userRepository.Insert (user);
		}

		public void DeleteUser (User user)
		{
			_userRepository.Delete (user.Id);
		}
		public User GetUser (uint id)
		{
			return _userRepository.Find (id);
		}
		public IList<User> GetAllClients ()
		{
			return _userRepository.FindAllWithRole (Role.CLIENT);
		}
		public IList<User> GetAllDrivers ()
		{
			return _userRepository.FindAllWithRole (Role.DRIVER);
		}
		public IList<User> GetAllAdmins ()
		{
			return _userRepository.FindAllWithRole (Role.ADMIN);
		}

		public IList<User> GetAllUsers ()
		{
			return _userRepository.FindAll();
		}
	}
}

