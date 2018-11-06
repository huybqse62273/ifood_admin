using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IImageRepository : IRepository<Image>
    {

    }
}
