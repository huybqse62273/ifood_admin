using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IOrderRepository : IRepository<Order>
    {

    }
}
