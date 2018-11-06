using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class FAQRepository : BaseRepository<FAQ>, IFAQRepository
    {
        public FAQRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IFAQRepository : IRepository<FAQ>
    {

    }
}
