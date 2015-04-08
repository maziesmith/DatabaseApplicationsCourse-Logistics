using System;

namespace Logistics.Domain.Model
{
	public class Notification
	{
		public uint Id { get; set; }
		public string ShortValue { get; set; }
		public string FullValue { get; set; }
		public Order Order { get; set; } 
		public User User { get; set; } 
		public NotificationType NotificationType { get; set; }
	}
}

