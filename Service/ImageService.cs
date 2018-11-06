using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IImageService
    {
        void createImage(Image obj);
        void editImage(Image obj);
        void deleteImage(int id);
        Image GetById(int id);
        IEnumerable<Image> GetAll();
        void SaveChange();
    }
    public class ImageService : IImageService
    {
        #region Field
        private readonly IImageRepository ImageRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ImageService(IImageRepository ImageRepository, IUnitOfWork unitOfWork)
        {
            this.ImageRepository = ImageRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createImage(Image obj)
        {
            try
            {
                ImageRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteImage(int id)
        {
            Image Image = ImageRepository.GetById(id);
            ImageRepository.Delete(Image);
            SaveChange();
        }

        public void editImage(Image obj)
        {
            ImageRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Image> GetAll()
        {
            IEnumerable<Image> items = ImageRepository.Get();
            return items;
        }

        public Image GetById(int id)
        {
            var item = ImageRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}