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
		public void Insert (Log log)
		{
			NHibernateHelper.Insert (log);
		}

		public void Update (Log log)
		{

		}

		public void Delete (uint id)
		{
			Log log = Find (id);
			NHibernateHelper.Delete (log);
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

