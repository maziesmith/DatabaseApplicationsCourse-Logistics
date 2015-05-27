using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using Logistics.Domain.Model;
using Logistics.Domain.Repositories;
using Logistics.Domain;

namespace Logistics.Infrastructure.NRepositories
{
	public class LogRepository  : ILogRepository
	{
		public LogRepository ()
		{
		
		}

		public void Insert (Log log)
		{
			NHibernateHelper.Insert (log);
		}

		public void Update (Log log)
		{
			NHibernateHelper.Update (log);
		}

		public void Delete (int id)
		{
			Log log = Find (id);
			NHibernateHelper.Delete (log);
		}

		public Log Find (int id)
		{
			return FindAll().FirstOrDefault(l => l.Id == id);
		}

		public IList<Log> FindAll ()
		{
			return NHibernateHelper.Read<Log>().ToList();
		}
	}
}

