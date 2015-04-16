using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Logistics.Domain.Model
{
	public class LogMap : ClassMap<Log>
	{
		public LogMap()
		{
			Id (x => x.Id);
			Map (x => x.Value);
			Map (x => x.CreatedAt);
			References (x => x.User).Not.Nullable();
		}
	} 
}

