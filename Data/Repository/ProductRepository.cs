using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IProductRepository : IRepository<Product>
    {

    }
}
