using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Domain.Repositories
{
	public interface ILogRepository
	{
		void Insert(Log log);

		void Delete(uint id);

		void Update(Log log);

		Log Find(uint id);

		IList<Log> FindAll();
	}
}

