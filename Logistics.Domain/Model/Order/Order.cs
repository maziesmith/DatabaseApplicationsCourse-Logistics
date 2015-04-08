using System;

namespace Logistics.Domain.Model
{
	public class Order
	{
		public uint Id { get; set; }
		public Adress Adress { get; set; }
		public Payment Payment { get; set; }
		public Status Status { get; set; }
		public DateTime UpdatedAt { get; set; }
		public User UpdatedBy { get; set; }
		public DateTime DeliveryDateTime { get; set; }
		public uint Priority { get; set; }
		public User Client { get; set; }
		public User Driver { get; set; }
	}
}

