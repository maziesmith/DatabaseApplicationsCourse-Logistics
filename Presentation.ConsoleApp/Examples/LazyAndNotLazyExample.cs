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
	public static class LazyAndNotLazyExample
	{
		public static void Run ()
		{
			using (var session = NHibernateHelper.OpenSession()) {
				using (var tx = session.BeginTransaction ()) {

					User exampleClient = new User { Login = "Torianin", 
						Email = "tori@robert-i.com", 
						EncryptedPassword = "olamakota123", 
						Role = Role.CLIENT 
					};

					User exampleDriver = new User { Login = "Robcio", 
						Email = "tori@robert-i.com", 
						EncryptedPassword = "olamakota123", 
						Role = Role.DRIVER
					};

					Order order1 = new Order {
						Address = new Address { City = "Wroclaw", Street = "Szczytnicka", HouseNumber = 3 },
						Payment = new Payment { Value = 100, Currency = Currency.PLN },
						Status = Status.INFORMATION_RECEIVED,
						Client = exampleClient,
						Driver = exampleDriver
					};

					Order order2 = new Order {
						Address = new Address { City = "Wroclaw", Street = "Szczytnicka", HouseNumber = 4 },
						Payment = new Payment { Value = 100, Currency = Currency.PLN },
						Status = Status.DRIVER_HAS_ORDER
					};

					Notification notification1 = new Notification {
						FullValue = "Piesek. Jedyna słuszna w życiu jest niepewność dnia poprzedniego.",
						NotificationType = NotificationType.SMS
					};

					session.Save (exampleClient);
					session.Save (exampleDriver);
					session.Save (order1);
					session.Save (order2);
					session.Save (notification1);
					tx.Commit ();
				}

				using (session.BeginTransaction())
				{
					var notLazyOrders = session.QueryOver<Order>()
						.Fetch(u => u.Client)
						.Eager
						.List();

					var lazyOrders = session.QueryOver<Order>()
						.List();

					foreach (var o in lazyOrders)
					{
						Console.WriteLine(o.Id);
						Console.WriteLine(o.Address.City);
						Console.WriteLine(o.Address.Street);
						Console.WriteLine(o.Address.HouseNumber);

						Console.WriteLine(o.Status);
						Console.WriteLine();

					}
					Console.WriteLine();

					var notifications = session.CreateCriteria(typeof(Notification))
						.List<Notification>();

					Console.WriteLine();

					foreach (var n in notifications)
					{
						Console.WriteLine(n.Id);
						Console.WriteLine(n.FullValue);
						Console.WriteLine(n.ShortValue);
						Console.WriteLine();

					}
				}
			}
		}
	}
}

