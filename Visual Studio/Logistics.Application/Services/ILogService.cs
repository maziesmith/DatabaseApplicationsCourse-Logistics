using System;
using Logistics.Domain.Model;
using System.Collections.Generic;
using Logistics.Domain.Model.Entities.Log;
using Logistics.Domain.Model.Entities.User;

namespace Logistics.Application.Services
{
	public interface ILogService
	{
		void AddLog(Log log ,User user);
		void DeleteLog(Log log);
		Log GetLog(int id);
		IList<Log> GetAllLogs();
	}
}

