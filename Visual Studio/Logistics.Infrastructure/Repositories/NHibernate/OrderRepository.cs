using System.Collections.Generic;
using System.Linq;
using Logistics.Domain.Model.Entities.Order;
using Logistics.Domain.Model.Entities.User;
using Logistics.Domain.Repositories;
using Logistics.Infrastructure.Mappings;
using NHibernate.Linq;

namespace Logistics.Infrastructure.Repositories.NHibernate
{
	public class OrderRepository : IOrderRepository
	{
		public OrderRepository ()
		{

		}

		public void Insert (Order order)
		{
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(order);
                    tx.Commit();
                }
            }
        }

		public void Update (Order order)
		{
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(order);
                    tx.Commit();
                }
            }
		}

		public void Delete (int id)
		{
            Order order = Find(id);
            using (var session = NHibernateHelper.OpenConnection())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(order);
                    tx.Commit();
                }
            }
		}

		public Order Find (int id)
		{
			return FindAll().FirstOrDefault(o => o.Id == id);
		}

        public IList<Order> FindAll()
        {
            using (var session = NHibernateHelper.OpenConnection())
            {
                return session.Query<Order>().ToList();
            }
        }

        public IQueryable<Order> FindAllQuery()
        {
            using (var session = NHibernateHelper.OpenConnection())
            {
                return session.Query<Order>();
            }
        }

		public IList<Order> FindAllForUser (User user)
		{
			return FindAll().Where(o => (o.Driver == user || o.Client == user)).ToList();
		}
	}
}

