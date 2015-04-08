using NUnit.Framework;
using System;
using Logistics.ObjectMothers;
using Logistics.Domain.Model;

namespace Logistics.Domain.UnitTests
{
	[TestFixture ()]
	public class OrderTests
	{
		[Test ()]
		public void CheckForCorrectCurrencyStatus ()
		{
			var order = OrderObjectMother.CreateNewPLNOrder ();
			Assert.AreEqual(order.Payment.Currency, Currency.PLN);
		}

		[Test ()]
		public void CheckForNewOrderStatus ()
		{
			var order = OrderObjectMother.CreateNewPLNOrder ();
			Assert.AreNotEqual(order.Status, Status.WAITING_FOR_TRANSPORT_SPACE);
		}

		[Test ()]
		public void CheckForNewChangeStatus ()
		{
			var order = OrderObjectMother.CreateNewPLNOrder ();
			order.Status = Status.WAITING_FOR_TRANSPORT_SPACE;

			Assert.AreEqual(order.Status, Status.WAITING_FOR_TRANSPORT_SPACE);
		}

		[Test]
		public void TestForNullValuesInOrder()
		{
			var order = OrderObjectMother.CreateNewPLNOrder();
			Assert.IsNotNull (order.Payment);
		}

		[Test]
		public void TestForZeroValueInOrder()
		{
			var order = OrderObjectMother.CreateNewPLNOrder();
			Assert.That( order.Payment.Value, Is.InRange(0.01, Double.MaxValue) );
		}

		[Test ()]
		public void TestForCorrectValuesInId ()
		{
			var notification = UserObjectMother.CreateEmailNotification (0); 
			Assert.GreaterOrEqual(notification.Id, 0);
		}
	}
}

