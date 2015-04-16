using System;

namespace Logistics.Domain.Model
{
	public class Address
	{	
		public virtual string City { get; set; }
		public virtual string Street { get; set; }
		public virtual int HouseNumber { get; set; }
	}
}

