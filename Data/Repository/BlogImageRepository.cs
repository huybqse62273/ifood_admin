using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class BlogImageRepository : BaseRepository<BlogImage>, IBlogImageRepository
    {
        public BlogImageRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IBlogImageRepository : IRepository<BlogImage>
    {

    }
}
