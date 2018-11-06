using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class WishListRepository : BaseRepository<WishList>, IWishListRepository
    {
        public WishListRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IWishListRepository : IRepository<WishList>
    {

    }
}
