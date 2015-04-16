using System;

namespace Logistics.Domain.Model
{
	public class Log
	{
		public virtual int Id { get; protected set; }
		public virtual String Value { get; set; }
		public virtual DateTime CreatedAt { get; set; }
		public virtual User User { get; set; }
	}
}

