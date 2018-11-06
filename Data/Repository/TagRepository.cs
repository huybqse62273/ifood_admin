using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface ITagRepository : IRepository<Tag>
    {

    }
}
