using System;
using Logistics.Domain.Model;

namespace Logistics.ObjectMothers
{
	public class OrderObjectMother
	{
		public static Order CreateNewPLNOrder()
		{
			Order o = new Order {
				Address = new Address { City = "Wroclaw", Street = "Szczytnicka", HouseNumber = 4 },
				Payment = new Payment { Value = 100, Currency = Currency.PLN },
				Status = Status.INFORMATION_RECEIVED
			};
			return o;
		}
	}
}