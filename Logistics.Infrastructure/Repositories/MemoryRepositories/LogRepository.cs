using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using Logistics.Domain.Model;
using Logistics.Domain.Repositories;

namespace Logistics.Infrastructure.Repositories
{
	public class LogRepository : ILogRepository
	{
		private List<Log> logs  = new List<Log>();

		public LogRepository ()
		{
			logs = new List<Log>
			{
				new Log {
					Value = "Ola",
					CreatedAt = DateTime.Now
				}
			};
		}
			
		public void Insert (Log log)
		{
			logs.Add(log);
		}

		public void Update(Log log)
		{
			var oldLog = logs.FirstOrDefault(l => l.Id == log.Id);
			oldLog.Value = log.Value;
			oldLog.CreatedAt = log.CreatedAt;
			oldLog.User = log.User;
		}

		public void Delete (uint id)
		{
			logs.Remove(logs.Find(n => n.Id == id));
		}

		public Log Find (uint id)
		{
			return logs.FirstOrDefault(n => n.Id == id);
		}

		public IList<Log> FindAll ()
		{
			return logs;
		}
	}
}

