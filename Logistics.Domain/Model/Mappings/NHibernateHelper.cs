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
using NHibernate.Linq;


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
			if (File.Exists(DbFile))
				File.Delete(DbFile);

			new SchemaExport(config)
				.Create(false, true);
		}

		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession ();
		}

		public static void Insert<T>(T newItem)
		{
			using (var session = NHibernateHelper.OpenSession ()) 
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
			using (var session = NHibernateHelper.OpenSession())
			{
				return session.Query<T>();
			}
		}

		public static void Update<T>(T newItem)
		{
			using (var session = NHibernateHelper.OpenSession ()) 
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
			using (var session = NHibernateHelper.OpenSession ()) 
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

