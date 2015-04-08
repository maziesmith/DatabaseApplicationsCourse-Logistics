using NUnit.Framework;
using System;
using Logistics.ObjectMothers;
using Logistics.Domain.Model;

namespace Logistics.Domain.UnitTests
{
	[TestFixture ()]
	public class LogTest
	{
		[Test ()]
		public void TestLogIsNotEmpty ()
		{
			var log = UserObjectMother.CreateNewLog(2);

			Assert.IsTrue(log.Value != "");
		}

		[Test ()]
		public void TestCorrectDayOfNewLog ()
		{
			var log = UserObjectMother.CreateNewLog(2);

			Assert.AreEqual(log.CreatedAt.Day, DateTime.Now.Day);
		}

		[Test ()]
		public void TestCorrectMonthNumber ()
		{
			var log = UserObjectMother.CreateNewLog(2);

			Assert.Less(log.CreatedAt.Day, 32);
		}

		[Test ()]
		public void TestForCorrectValuesInId ()
		{
			var log = UserObjectMother.CreateNewLog(2);

			Assert.GreaterOrEqual(log.Id, 0);
		}
	}
}

