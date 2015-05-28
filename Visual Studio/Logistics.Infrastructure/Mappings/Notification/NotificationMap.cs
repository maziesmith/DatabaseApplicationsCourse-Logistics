using FluentNHibernate.Mapping;

namespace Logistics.Infrastructure.Mappings.Notification
{
	public class NotificationMap : ClassMap<Domain.Model.Entities.Notification.Notification>
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

