using NUnit.Framework;
using System;
using Logistics.Infrastructure.Repositories;
using Logistics.Application.Services;
using Logistics.Domain.Repositories;
using Moq;
using Logistics.ObjectMothers;
using Logistics.Domain.Model;

namespace Logistics.Application.UnitTests
{
	[TestFixture ()]
	public class LogServiceTests
	{
		[Test ()]
		public void AddLogServiceTests ()
		{
			Mock<ILogRepository> logRepositoryMock = new Mock<ILogRepository>();
			ILogService ls = new LogService(logRepositoryMock.Object);
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			IUserService us = new UserService(userRepositoryMock.Object);

			var user = UserObjectMother.CreateNewAdmin();
			us.CreateNewUser (user);

			var log = UserObjectMother.CreateNewLog (2);
			ls.AddLog (log, user);

			logRepositoryMock.Setup(k => k.Find(2)).Returns(log);
		}

		[Test ()]
		public void DeleteLogServiceTests ()
		{
			Mock<ILogRepository> logRepositoryMock = new Mock<ILogRepository>();
			ILogService ls = new LogService(logRepositoryMock.Object);
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			IUserService us = new UserService(userRepositoryMock.Object);

			var user = UserObjectMother.CreateNewAdmin();
			us.CreateNewUser (user);

			var log = UserObjectMother.CreateNewLog (2);
			ls.AddLog (log, user);
 			ls.DeleteLog (log);

			logRepositoryMock.Verify(k => k.Delete(log.Id), Times.Once());
		}


		[Test ()]
		public void GetLogServiceTests ()
		{
			Mock<ILogRepository> logRepositoryMock = new Mock<ILogRepository>();
			ILogService ls = new LogService(logRepositoryMock.Object);
			Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
			IUserService us = new UserService(userRepositoryMock.Object);

			var user = UserObjectMother.CreateNewAdmin();
			us.CreateNewUser (user);

			var log = UserObjectMother.CreateNewLog (2);
			ls.AddLog (log, user);
			ls.GetLog (log.Id);

			logRepositoryMock.Verify(k => k.Find(log.Id), Times.Once());
		}

		[Test ()]
		public void GetAllLogServiceTests ()
		{
			Mock<ILogRepository> repositoryMock = new Mock<ILogRepository>();
			ILogService ls = new LogService(repositoryMock.Object);

			ls.GetAllLogs();

			repositoryMock.Verify(k => k.FindAll(), Times.Once());
		}
	}
}

