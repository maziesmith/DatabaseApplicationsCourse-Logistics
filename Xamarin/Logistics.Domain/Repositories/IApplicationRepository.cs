using System;
using Logistics.Domain.Model;
using System.Collections.Generic;

namespace Logistics.Domain.Repositories
{
	public interface IApplicationRepository
	{
		void Insert(ApplicationModule application);

		void Delete(uint id);

		ApplicationModule Find(uint id);

		IList<ApplicationModule> FindAll();
	}
}

