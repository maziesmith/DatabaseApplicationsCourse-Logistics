using FluentNHibernate.Mapping;

namespace Logistics.Infrastructure.Mappings.User
{
	public class UserMap : ClassMap<Domain.Model.Entities.User.User>
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

