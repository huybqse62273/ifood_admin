using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class ManufactorRepository : BaseRepository<Manufactor>, IManufactorRepository
    {
        public ManufactorRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IManufactorRepository : IRepository<Manufactor>
    {

    }
}
