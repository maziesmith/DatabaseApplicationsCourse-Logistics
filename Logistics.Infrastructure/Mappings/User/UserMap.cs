using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Logistics.Domain.Model;

namespace Logistics.Infrastructure.Model
{
	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			Id (x => x.Id);
			Map (x => x.Username);
			Map (x => x.Email);
			Map (x => x.EncryptedPassword);
			Map (x => x.PhoneNumber);
			Map (x => x.Role).CustomType<int>();
			Map (x => x.CreatedAt);
			Map (x => x.UpdatedAt);
			Map (x => x.Login);
			HasMany (x => x.Notifications).LazyLoad();
			HasMany (x => x.Logs).LazyLoad();
		}
	} 
}

