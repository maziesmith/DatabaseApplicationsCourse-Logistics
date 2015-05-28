using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Logistics.Domain.Model.Entities.User
{
	public class User
	{
		public virtual int Id { get; protected set; }

		[StringLengthValidator(1, 50)]
		public virtual string Login { get; set; }

		[StringLengthValidator(1, 50)]
		public virtual string Username { get; set; }

		[RegexValidator(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
		public virtual string Email { get; set; }

		[ContainsCharactersValidator("!@#$%^&*", ContainsCharacters.Any)]
		public virtual string EncryptedPassword { get; set; }

		[TypeConversionValidator(typeof(int))]
		public virtual string PhoneNumber { get; set; }

		[DomainValidator(Role.CLIENT, Role.ADMIN, Role.DRIVER)]
		public virtual Role Role { get; set; }

		public virtual DateTime CreatedAt { get; set; }
		public virtual DateTime UpdatedAt { get; set; }
		public virtual Notification.Notification Notification { get; set; }
		public virtual ISet<Notification.Notification> Notifications { get; set; }
		public virtual Log.Log Log { get; set; }
		public virtual IList<Log.Log> Logs { get; set; }
	}
}

