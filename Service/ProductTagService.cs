using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IProductTagService
    {
        void createProductTag(ProductTag obj);
        void editProductTag(ProductTag obj);
        void deleteProductTag(int id);
        ProductTag GetById(int id);
        IEnumerable<ProductTag> GetAll();
        void SaveChange();
    }
    public class ProductTagService : IProductTagService
    {
        #region Field
        private readonly IProductTagRepository ProductTagRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductTagService(IProductTagRepository ProductTagRepository, IUnitOfWork unitOfWork)
        {
            this.ProductTagRepository = ProductTagRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createProductTag(ProductTag obj)
        {
            try
            {
                ProductTagRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteProductTag(int id)
        {
            ProductTag ProductTag = ProductTagRepository.GetById(id);
            ProductTagRepository.Delete(ProductTag);
            SaveChange();
        }

        public void editProductTag(ProductTag obj)
        {
            ProductTagRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<ProductTag> GetAll()
        {
            IEnumerable<ProductTag> items = ProductTagRepository.Get();
            return items;
        }

        public ProductTag GetById(int id)
        {
            var item = ProductTagRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}