using System;
using Logistics.Domain;
using Logistics.Domain.Model;

namespace Presentation.ConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (var session = NHibernateHelper.OpenSession()) {
				using (var tx = session.BeginTransaction ()) {
					Order o = new Order {
						Address = new Address { City = "Wroclaw", Street = "Szczytnicka", HouseNumber = 4 },
						Payment = new Payment { Value = 100, Currency = Currency.PLN },
						Status = Status.INFORMATION_RECEIVED
					};
					session.Save (o);
					tx.Commit ();
				}

				using (session.BeginTransaction())
				{
					var orders = session.CreateCriteria(typeof(Order))
						.List<Order>();

					foreach (var o in orders)
					{
						Console.WriteLine(o.Address.City);
					}
				}
			}
			Console.ReadKey ();
		}
	}
}
