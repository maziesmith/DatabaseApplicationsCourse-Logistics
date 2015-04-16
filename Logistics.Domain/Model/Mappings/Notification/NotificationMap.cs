using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Logistics.Domain.Model
{
	public class NotificationMap : ClassMap<Notification>
	{
		public NotificationMap()
		{
			Id (x => x.Id);
			Map (x => x.ShortValue);
			Map (x => x.FullValue);
			References (x => x.Order);
			References (x => x.User);
			Map (x => x.NotificationType);
		}
	} 
}

