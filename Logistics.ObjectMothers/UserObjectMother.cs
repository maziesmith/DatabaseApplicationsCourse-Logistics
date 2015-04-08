using System;
using Logistics.Domain.Model;

namespace Logistics.ObjectMothers
{
	public class UserObjectMother
	{
		public static User CreateNewClient()
		{
			User u = new User {
				Id = 1,
				Login = "Olamakota",
				Email = "tori@robert-i.com",
				EncryptedPassword = "321atokamalo",
				Role = Role.CLIENT
			};
			return u;
		}

		public static User CreateNewDriver()
		{
			User u = new User {
				Id = 1,
				Login = "Olamakota",
				Email = "tori@robert-i.com",
				EncryptedPassword = "321atokamalo",
				Role = Role.DRIVER
			};
			return u;
		}

		public static User CreateNewAdmin()
		{
			User u = new User {
				Id = 1,
				Login = "Olamakota",
				Email = "tori@robert-i.com",
				EncryptedPassword = "321atokamalo",
				Role = Role.ADMIN
			};
			return u;
		}

		public static Notification CreateSmsNotification(int id)
		{
			return new Notification {
				Id = 1,
				ShortValue = "Ola.",
				FullValue = "Piesek. Jedyna słuszna w życiu jest niepewność dnia poprzedniego.",
				NotificationType = NotificationType.SMS
			};
		}

		public static Notification CreateEmailNotification(int id)
		{
			return new Notification {
				Id = 2,
				ShortValue = "Zenek.",
				FullValue = "Zenek. Lubi jeś małe rybki. ",
				NotificationType = NotificationType.EMAIL
			};
		}

		public static Log CreateNewLog(uint id)
		{
			return new Log {
				Id = id,
				Value = "Ola",
				CreatedAt = DateTime.Now
			};
		}
	}
}