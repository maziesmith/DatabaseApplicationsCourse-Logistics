using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using NHibernate.Cfg;
using System.IO;
using NHibernate.Tool.hbm2ddl;


namespace Logistics.Domain
{
	public class NHibernateHelper
	{
		private const string DbFile = "Logistics.db";

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
			return Fluently.Configure()
				.Database(SQLiteConfiguration.Standard
					.UsingFile(DbFile)
					.ShowSql()
				)
				.Mappings( m => 
					m.FluentMappings.AddFromAssembly( Assembly.GetExecutingAssembly() ))
				.ExposeConfiguration(BuildSchema)
				.BuildSessionFactory();
		}

		private static void BuildSchema(Configuration config)
		{
			// delete the existing db on each run
			if (File.Exists(DbFile))
				File.Delete(DbFile);

			// this NHibernate tool takes a configuration (with mapping info in)
			// and exports a database schema from it
			new SchemaExport(config)
				.Create(false, true);
		}

		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession ();
		}
	}
}

