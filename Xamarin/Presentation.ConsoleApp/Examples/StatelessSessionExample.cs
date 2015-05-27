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
	public static class StatelessSessionExample
	{
		public static void Run()
		{
			List<User> users = UserObjectMother.CreateNewClients (5000);

			var stopwatch1 = new Stopwatch();
			stopwatch1.Start();

			using (ISession session = NHibernateHelper.OpenConnection ()) {
				using (var tx = session.BeginTransaction ()) {
					foreach (var testUser in users) {
						session.Save (testUser);
					}
					tx.Commit ();
				}
			}

			stopwatch1.Stop();
			var time1 = stopwatch1.Elapsed;

			List<User> users2 = UserObjectMother.CreateNewClients (5000);

			var stopwatch2 = new Stopwatch();
			stopwatch2.Start ();

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

	}
}

