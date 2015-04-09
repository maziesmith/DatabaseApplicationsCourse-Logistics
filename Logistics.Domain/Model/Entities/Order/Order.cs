using System;

namespace Logistics.Domain.Model
{
	public class Order
	{
		public virtual uint Id { get; protected set; }
		public virtual Adress Adress { get; set; }
		public virtual Payment Payment { get; set; }
		public virtual Status Status { get; set; }
		public virtual DateTime UpdatedAt { get; set; }
		public virtual User UpdatedBy { get; set; }
		public virtual DateTime DeliveryDateTime { get; set; }
		public virtual uint Priority { get; set; }
		public virtual User Client { get; set; }
		public virtual User Driver { get; set; }
	}
}

