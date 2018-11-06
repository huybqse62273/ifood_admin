using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class ProductTagRepository : BaseRepository<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IProductTagRepository : IRepository<ProductTag>
    {

    }
}
