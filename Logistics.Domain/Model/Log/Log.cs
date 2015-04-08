using System;

namespace Logistics.Domain.Model
{
	public class Log
	{
		public uint Id { get; set; }
		public String Value { get; set; }
		public DateTime CreatedAt { get; set; }
		public User User { get; set; }
	}
}

