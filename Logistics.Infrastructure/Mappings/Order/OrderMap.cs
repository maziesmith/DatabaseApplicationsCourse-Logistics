using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Logistics.Domain.Model;

namespace Logistics.Infrastructure.Model
{
	public class AddressMap : ComponentMap<Address>
	{
		public AddressMap()
		{
			Map (x => x.City);
			Map (x => x.Street);
			Map (x => x.PostalCode);
			Map (x => x.HouseNumber);
		}
	}

	public class PaymentMap : ComponentMap<Payment>
	{
		public PaymentMap()
		{
			Map (x => x.Value);
			Map (x => x.Currency).CustomType<int>();
		}
	}

	public class OrderMap : ClassMap<Order>
	{
		public OrderMap()
		{
			Id (x => x.Id);
			Component(x => x.Address);
			Component (x => x.Payment);
			Map (x => x.Status).CustomType<int>();
			Map (x => x.UpdatedAt);
			References (x => x.UpdatedBy);
			Map (x => x.DeliveryDateTime);
			Map (x => x.Priority);
			References (x => x.Client).LazyLoad();
			References (x => x.Driver).Not.LazyLoad();
		}
	} 
}

