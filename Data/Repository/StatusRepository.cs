using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IStatusRepository : IRepository<Status>
    {

    }
}
