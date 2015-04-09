using System;

namespace Logistics.Domain.Model
{
	public class Adress
	{	
		public virtual string City { get; set; }
		public virtual string Street { get; set; }
		public virtual uint HouseNumber { get; set; }
	}
}

