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
    public interface ICategoryService
    {
        void createCategory(Category obj);
        void editCategory(Category obj);
        void deleteCategory(int id);
        Category GetById(int id);
        IEnumerable<Category> GetAll();
        void SaveChange();
    }
    public class CategoryService : ICategoryService
    {
        #region Field
        private readonly ICategoryRepository CategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public CategoryService(ICategoryRepository CategoryRepository, IUnitOfWork unitOfWork)
        {
            this.CategoryRepository = CategoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createCategory(Category obj)
        {
            try
            {
                CategoryRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteCategory(int id)
        {
            Category Category = CategoryRepository.GetById(id);
            CategoryRepository.Delete(Category);
            SaveChange();
        }

        public void editCategory(Category obj)
        {
            CategoryRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> items = CategoryRepository.Get();
            return items;
        }

        public Category GetById(int id)
        {
            var item = CategoryRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}
