using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.ObjectMothers
{
	public class UserObjectMother
	{
		public static List<User> CreateNewClients(int numberOfClients)
		{
			List<User> users = new List<User> ();
			for (int i = 0; i < numberOfClients; i++) {
				User u = new User {
					Login = "Olamakota",
					Email = "tori@robert-i.com",
					EncryptedPassword = "321atokamalo",
					Role = Role.CLIENT
				};
				users.Add (u);
			}
			return users;
		}

		public static User CreateNewClient()
		{
			User u = new User {
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
				FullValue = "Piesek. Jedyna słuszna w życiu jest niepewność dnia poprzedniego.",
				NotificationType = NotificationType.SMS
			};
		}

		public static Notification CreateEmailNotification(int id)
		{
			return new Notification {
				FullValue = "Zenek. Lubi jeś małe rybki. ",
				NotificationType = NotificationType.EMAIL
			};
		}

		public static Log CreateNewLog(uint id)
		{
			return new Log {
				Value = "Ola",
				CreatedAt = DateTime.Now
			};
		}
	}
}