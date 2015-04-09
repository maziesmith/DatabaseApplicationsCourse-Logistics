using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Logistics.Domain.Model
{
	public class OrderMap : ClassMap<Order>
	{
		public OrderMap()
		{
			Id (x => x.Id);
			Map (x => x.Adress);
			Map (x => x.Payment);
			Map (x => x.Status);
			Map (x => x.UpdatedAt);
			Map (x => x.UpdatedBy);
			Map (x => x.DeliveryDateTime);
			Map (x => x.Priority);
			Map (x => x.Client);
			Map (x => x.Driver);
		}
	} 
}

