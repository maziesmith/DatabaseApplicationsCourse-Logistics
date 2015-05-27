using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Logistics.Domain.Model;

namespace Logistics.Infrastructure.Model
{
	public class NotificationMap : ClassMap<Notification>
	{
		public NotificationMap()
		{
			Id (x => x.Id);
			Map (x => x.ShortValue);
			Map (x => x.FullValue);
			References (x => x.Order).LazyLoad();
			References (x => x.User).LazyLoad();
			Map (x => x.NotificationType);
		}
	} 
}

