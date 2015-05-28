using System.Linq;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

namespace Logistics.Infrastructure.Mappings
{
	public class NHibernateHelper
	{
		private static ISessionFactory _sessionFactory;

		private static ISessionFactory SessionFactory
		{
			get
			{
				if(_sessionFactory == null)
					_sessionFactory = CreateSessionFactory();

				return _sessionFactory;
			}
		}

		private static ISessionFactory CreateSessionFactory()
		{
            _sessionFactory = Fluently.Configure()
               .Database(
                 MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("databaseConfig"))
               .ShowSql())
               .Mappings(m =>
                m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
               .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
               .BuildSessionFactory();
            return _sessionFactory;
		}

		public static IStatelessSession OpenStatelessSession()
		{
			return SessionFactory.OpenStatelessSession ();
		}

        public static ISession OpenConnection()
        {
            return SessionFactory.OpenSession();
        }

		public static void Insert<T>(T newItem)
		{
            using (var session = NHibernateHelper.OpenConnection()) 
			{
				using (var transaction = session.BeginTransaction ()) 
				{
					session.Save (newItem);
					transaction.Commit ();
				}
			}
		}

		public static IQueryable<T> Read<T>()
		{
            using (var session = NHibernateHelper.OpenConnection())
			{
				return session.Query<T>();
			}
		}

		public static void Update<T>(T newItem)
		{
            using (var session = NHibernateHelper.OpenConnection()) 
			{
				using (var transaction = session.BeginTransaction ()) 
				{
					session.SaveOrUpdate (newItem);
					transaction.Commit ();
				}
			}
		}

		public static void Delete<T>(T Item)
		{
            using (var session = NHibernateHelper.OpenConnection()) 
			{
				using (var transaction = session.BeginTransaction ()) 
				{
					session.Delete(Item);
					transaction.Commit ();
				}
			}
		}
	}
}

