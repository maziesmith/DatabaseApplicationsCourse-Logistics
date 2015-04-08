using System;

namespace Logistics.Domain.Model
{
	public class User
	{
		public uint Id { get; set; }
		public string Login { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string EncryptedPassword { get; set; }
		public string PhoneNumber { get; set; }
		public Role Role { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public Notification Notification { get; set; }
		public Log Log { get; set; }
	}
}

