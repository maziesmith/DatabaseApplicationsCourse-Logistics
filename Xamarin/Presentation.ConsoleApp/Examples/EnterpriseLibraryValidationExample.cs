using System;
using Logistics.Domain;
using Logistics.Domain.Model;
using Logistics.Infrastructure;
using System.Linq;
using Logistics.ObjectMothers;
using System.Collections.Generic;
using System.Diagnostics;
using NHibernate;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Presentation.ConsoleApp
{
	public static class EnterpriseLibraryValidationExample
	{
		public static void Run ()
		{
			User exampleClient = new User { Login = "Torianin", 
				Email = "tori@robert-i.com", 
				EncryptedPassword = "olamakota123", 
				Role = Role.CLIENT 
			};

			Log wrongLog =  new Log {
				Value = "Ola",
				CreatedAt = DateTime.Now
			};

			ValidationResults r = Validation.Validate(wrongLog);
			if (!r.IsValid) 
				Console.WriteLine ("Input Not Vaild :<");
			else 
				Console.WriteLine ("Everything is OK :>");

			Log correctLog =  new Log {
				Value = "Poprawny log zawierający więcej niż 10 znaków i mniej niż 50.",
				CreatedAt = DateTime.Now,
				User = exampleClient
			};

			r = Validation.Validate(correctLog);
			if (!r.IsValid) 
				Console.WriteLine ("Input Not Vaild :<");
			else 
				Console.WriteLine ("Everything is OK :>");


			Notification notification1 = new Notification {
				FullValue = "Piesek. Jedyna słuszna w życiu jest niepewność dnia poprzedniego.",
				NotificationType = NotificationType.SMS
			};

			r = Validation.Validate(notification1);
			if (!r.IsValid) 
				Console.WriteLine ("Input Not Vaild :<");
			else 
				Console.WriteLine ("Everything is OK :>");
		}
	}
}

