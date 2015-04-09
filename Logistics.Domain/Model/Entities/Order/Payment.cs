using System;

namespace Logistics.Domain.Model
{
	public class Payment
	{
		public virtual double Value { get; set; }
		public virtual Currency Currency { get; set; }
	}
}

