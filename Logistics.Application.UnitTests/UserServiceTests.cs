using NUnit.Framework;
using System;
using Logistics.Infrastructure.Repositories;
using Logistics.Application.Services;
using Logistics.Domain.Repositories;
using Moq;
using Logistics.ObjectMothers;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Application.UnitTests
{
	[TestFixture ()]
	public class UserSericeTests
	{
		[Test ()]
		public void CorrectUserSignInServiceTest ()
		{
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			IUserService us = new UserService(userRepositoryMock.Object);

			bool firstUserSignIn = us.SignIn ("Robcio", "asdfghjkl11#2");

			Assert.IsTrue (firstUserSignIn);
		}

		[Test ()]
		public void WrongUserSignInServiceTest ()
		{
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			IUserService us = new UserService(userRepositoryMock.Object);

			bool secondUserSignIn = us.SignIn ("Anulka", "asdfghjkl11#2");

			Assert.IsFalse (secondUserSignIn);
		}

		[Test ()]
		public void CreateNewUserTest ()
		{
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			IUserService us = new UserService(userRepositoryMock.Object);

			var user = UserObjectMother.CreateNewAdmin();
			us.CreateNewUser (user);

			userRepositoryMock.Verify(k => k.Insert(user), Times.Once());
		}

		[Test ()]
		public void DeleteUserTest ()
		{
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			IUserService us = new UserService(userRepositoryMock.Object);

			var user = UserObjectMother.CreateNewAdmin();
			us.CreateNewUser (user);
			us.DeleteUser (user);

			userRepositoryMock.Verify(k => k.Delete(user.Id), Times.Once());
		}

		[Test ()]
		public void GetAllClientsServiceTest ()
		{
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			IUserService us = new UserService(userRepositoryMock.Object);

			var user = UserObjectMother.CreateNewClient();
			us.CreateNewUser (user);

			// Czemu nie działa ಥ_ಥ
			// Console.WriteLine (us.GetAllUsers ().Count);
			us.GetAllClients();
			us.GetAllClients();
			us.GetAllClients();

			userRepositoryMock.Verify(k => k.FindAllWithRole(Role.CLIENT), Times.Exactly(3));
		}

		[Test ()]
		public void GetAllUsersServiceTest ()
		{
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			IUserService us = new UserService(userRepositoryMock.Object);

			us.GetAllUsers();

			userRepositoryMock.Verify(k => k.FindAll(), Times.Once());
		}
	}
}

