using System;
using Logistics.Infrastructure.Repositories;
using Logistics.Application.Services;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Repositories;

namespace Logistics.Application.Services
{
	public class LogService : ILogService
	{
		private ILogRepository _logRepository;

		public LogService ()
		{
			_logRepository = new LogRepository ();
		}

		public LogService ( ILogRepository logRepository )
		{
			_logRepository = logRepository;
		}

		public void AddLog(Log log ,User user)
		{
			_logRepository.Insert(log);
		}

		public void DeleteLog (Log log)
		{
			_logRepository.Delete (log.Id);
		}

		public Log GetLog (int id)
		{
			return _logRepository.Find (id);
		}
		public IList<Log> GetAllLogs ()
		{
			return _logRepository.FindAll ();
		}
	}
}

