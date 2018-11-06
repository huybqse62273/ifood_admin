using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IBlogService
    {
        void createBlog(Blog obj);
        void editBlog(Blog obj);
        void deleteBlog(int id);
        Blog GetById(int id);
        IEnumerable<Blog> GetAll();
        void SaveChange();
    }
    public class BlogService : IBlogService
    {
        #region Field
        private readonly IBlogRepository BlogRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public BlogService(IBlogRepository BlogRepository, IUnitOfWork unitOfWork)
        {
            this.BlogRepository = BlogRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createBlog(Blog obj)
        {
            try
            {
                BlogRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteBlog(int id)
        {
            Blog Blog = BlogRepository.GetById(id);
            BlogRepository.Delete(Blog);
            SaveChange();
        }

        public void editBlog(Blog obj)
        {
            BlogRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Blog> GetAll()
        {
            IEnumerable<Blog> items = BlogRepository.Get();
            return items;
        }

        public Blog GetById(int id)
        {
            var item = BlogRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}