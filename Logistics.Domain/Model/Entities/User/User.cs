using System;

namespace Logistics.Domain.Model
{
	public class User
	{
		public virtual uint Id { get; protected set; }
		public virtual string Login { get; set; }
		public virtual string Username { get; set; }
		public virtual string Email { get; set; }
		public virtual string EncryptedPassword { get; set; }
		public virtual string PhoneNumber { get; set; }
		public virtual Role Role { get; set; }
		public virtual DateTime CreatedAt { get; set; }
		public virtual DateTime UpdatedAt { get; set; }
		public virtual Notification Notification { get; set; }
		public virtual Log Log { get; set; }
	}
}

