using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IBlogImageService
    {
        void createBlogImage(BlogImage obj);
        void editBlogImage(BlogImage obj);
        void deleteBlogImage(int id);
        BlogImage GetById(int id);
        IEnumerable<BlogImage> GetAll();
        void SaveChange();
    }
    public class BlogImageService : IBlogImageService
    {
        #region Field
        private readonly IBlogImageRepository BlogImageRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public BlogImageService(IBlogImageRepository BlogImageRepository, IUnitOfWork unitOfWork)
        {
            this.BlogImageRepository = BlogImageRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createBlogImage(BlogImage obj)
        {
            try
            {
                BlogImageRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteBlogImage(int id)
        {
            BlogImage BlogImage = BlogImageRepository.GetById(id);
            BlogImageRepository.Delete(BlogImage);
            SaveChange();
        }

        public void editBlogImage(BlogImage obj)
        {
            BlogImageRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<BlogImage> GetAll()
        {
            IEnumerable<BlogImage> items = BlogImageRepository.Get();
            return items;
        }

        public BlogImage GetById(int id)
        {
            var item = BlogImageRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}