using Data.Infrastructure;
using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAnimeService
    {
        void createAnime(Anime obj);
        void editAnime(Anime obj);
        void deleteAnime(int id);
        Anime GetById(int id);
        IEnumerable<Anime> GetAll();
        void SaveChange();
    }
    public class AnimeService : IAnimeService
    {
        #region Field
        private readonly IAnimeRepository AnimeRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public AnimeService(IAnimeRepository AnimeRepository, IUnitOfWork unitOfWork)
        {
            this.AnimeRepository = AnimeRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createAnime(Anime obj)
        {
            try
            {
                AnimeRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteAnime(int id)
        {
            Anime Anime = AnimeRepository.GetById(id);
            AnimeRepository.Delete(Anime);
            SaveChange();
        }

        public void editAnime(Anime obj)
        {
            AnimeRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Anime> GetAll()
        {
            IEnumerable<Anime> items = AnimeRepository.Get();
            return items;
        }

        public Anime GetById(int id)
        {
            var item = AnimeRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}
