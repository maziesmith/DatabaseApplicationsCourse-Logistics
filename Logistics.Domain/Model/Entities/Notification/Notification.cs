using System;

namespace Logistics.Domain.Model
{
	public class Notification
	{
		public virtual uint Id { get; protected set; }
		public virtual string ShortValue { get; set; }
		public virtual string FullValue { get; set; }
		public virtual Order Order { get; set; } 
		public virtual User User { get; set; } 
		public virtual NotificationType NotificationType { get; set; }
	}
}

