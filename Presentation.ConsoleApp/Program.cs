using System;
using Logistics.Domain;
using Logistics.Domain.Model;
using Logistics.Infrastructure;
using System.Linq;
using Logistics.ObjectMothers;
using System.Collections.Generic;
using System.Diagnostics;
using NHibernate;

namespace Presentation.ConsoleApp
{
	class MainClass
	{
		public static void TestStatelessSession()
		{
			List<User> users = UserObjectMother.CreateNewClients (5000);

			var stopwatch1 = new Stopwatch();
			stopwatch1.Start();

			using (ISession session = NHibernateHelper.OpenSession ()) {
				using (var tx = session.BeginTransaction ()) {
					foreach (var testUser in users) {
						session.Save (testUser);
					}
					tx.Commit ();
				}
			}

			stopwatch1.Stop();
			var time1 = stopwatch1.Elapsed;
			var stopwatch2 = new Stopwatch();
			stopwatch2.Start ();

			List<User> users2 = UserObjectMother.CreateNewClients (5000);

			using (IStatelessSession session = NHibernateHelper.OpenStatelessSession ()) {
				// 
				// http://stackoverflow.com/questions/10308894/fluent-sqlite-exception-on-setbatchsize ?
				// session.SetBatchSize (500);
				using (var tx = session.BeginTransaction ()) {
					foreach (var testUser in users2)
						session.Insert (testUser);
					tx.Commit ();
				}
			}
			stopwatch2.Stop();
			var time2 = stopwatch2.Elapsed;
			Console.WriteLine (time1);
			Console.WriteLine (time2);
		}

		public static void Main (string[] args)
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
			TestStatelessSession ();
			Console.ReadKey ();
		}
	}
}
