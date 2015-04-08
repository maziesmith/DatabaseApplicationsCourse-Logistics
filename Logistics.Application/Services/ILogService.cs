using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Application.Services
{
	public interface ILogService
	{
		void AddLog(Log log ,User user);
		void DeleteLog(Log log);
		Log GetLog(uint id);
		IList<Log> GetAllLogs();
	}
}

