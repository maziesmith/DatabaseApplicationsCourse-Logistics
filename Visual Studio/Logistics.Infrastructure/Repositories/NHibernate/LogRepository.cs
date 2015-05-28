using System.Collections.Generic;
using System.Linq;
using Logistics.Domain.Model.Entities.Log;
using Logistics.Domain.Repositories;
using Logistics.Infrastructure.Mappings;
using NHibernate.Linq;

namespace Logistics.Infrastructure.Repositories.NHibernate
{
	public class LogRepository  : ILogRepository
	{
		public LogRepository ()
		{
		
		}

		public void Insert (Log log)
		{
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(log);
                    tx.Commit();
                }
            }
		}

		public void Update (Log log)
		{
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(log);
                    tx.Commit();
                }
            }
		}

		public void Delete (int id)
		{
			Log log = Find (id);
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(log);
                    tx.Commit();
                }
            }
		}

		public Log Find (int id)
		{
			return FindAll().FirstOrDefault(l => l.Id == id);
		}

        public IList<Log> FindAll()
        {
            using (var session = NHibernateHelper.OpenConnection())
            {
                return session.Query<Log>().ToList();
            }
        }

        public IQueryable<Log> FindAllQuery()
        {
            using (var session = NHibernateHelper.OpenConnection())
            {
                return session.Query<Log>();
            }
        }
	}
}

