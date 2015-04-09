using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using Logistics.Domain.Model;
using Logistics.Domain.Repositories;
using Logistics.Domain;

namespace Logistics.Infrastructure
{
	public class NLogRepository  : ILogRepository
	{
		public NLogRepository ()
		{

		}
			
		public void Insert (Log log)
		{
			using (var session = NHibernateHelper.OpenSession ()) 
			{
				using (var transaction = session.BeginTransaction ()) 
				{
					var newLog = new Log {
						Value = log.Value,
						CreatedAt = DateTime.Now,
						User = log.User
					};
					session.Save (newLog);
					transaction.Commit ();
				}
			}
		}

		public void Delete (uint id)
		{
			throw new NotImplementedException ();
		}

		public Log Find (uint id)
		{
			throw new NotImplementedException ();
		}

		public IList<Log> FindAll ()
		{
			throw new NotImplementedException ();
		}
	}
}

