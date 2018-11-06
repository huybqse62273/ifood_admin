using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class TypeRepository : BaseRepository<Type>, ITypeRepository
    {
        public TypeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface ITypeRepository : IRepository<Type>
    {

    }
}
