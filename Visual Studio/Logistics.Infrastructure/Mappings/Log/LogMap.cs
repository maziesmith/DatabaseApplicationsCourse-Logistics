using FluentNHibernate.Mapping;

namespace Logistics.Infrastructure.Mappings.Log
{
	public class LogMap : ClassMap<Domain.Model.Entities.Log.Log>
	{
		public LogMap()
		{
			Id (x => x.Id);
			Map (x => x.Value);
			Map (x => x.CreatedAt);
			References (x => x.User).Not.Nullable().LazyLoad();
		}
	} 
}

