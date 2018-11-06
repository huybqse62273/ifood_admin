using Data.Infrastructure;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {

    }
}
