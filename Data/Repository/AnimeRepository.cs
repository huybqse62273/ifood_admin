using Data.Infrastructure;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AnimeRepository : BaseRepository<Anime>, IAnimeRepository
    {
        public AnimeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }

    public interface IAnimeRepository : IRepository<Anime>
    {

    }
}
