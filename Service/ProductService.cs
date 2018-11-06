using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IProductService
    {
        void createProduct(Product obj);
        void editProduct(Product obj);
        void deleteProduct(int id);
        Product GetById(int id);
        IEnumerable<Product> Get();
        void SaveChange();
    }
    public class ProductService : IProductService
    {
        #region Field
        private readonly IProductRepository ProductRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductService(IProductRepository ProductRepository, IUnitOfWork unitOfWork)
        {
            this.ProductRepository = ProductRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createProduct(Product obj)
        {
            try
            {
                ProductRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteProduct(int id)
        {
            Product Product = ProductRepository.GetById(id);
            ProductRepository.Delete(Product);
            SaveChange();
        }

        public void editProduct(Product obj)
        {
            ProductRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Product> Get()
        {
            IEnumerable<Product> items = ProductRepository.Get();
            return items;
        }

        public Product GetById(int id)
        {
            var item = ProductRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}