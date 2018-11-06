using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IOrderProductService
    {
        void createOrderProduct(OrderProduct obj);
        void editOrderProduct(OrderProduct obj);
        void deleteOrderProduct(int id);
        OrderProduct GetById(int id);
        IEnumerable<OrderProduct> GetAll();
        void SaveChange();
    }
    public class OrderProductService : IOrderProductService
    {
        #region Field
        private readonly IOrderProductRepository OrderProductRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public OrderProductService(IOrderProductRepository OrderProductRepository, IUnitOfWork unitOfWork)
        {
            this.OrderProductRepository = OrderProductRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createOrderProduct(OrderProduct obj)
        {
            try
            {
                OrderProductRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteOrderProduct(int id)
        {
            OrderProduct OrderProduct = OrderProductRepository.GetById(id);
            OrderProductRepository.Delete(OrderProduct);
            SaveChange();
        }

        public void editOrderProduct(OrderProduct obj)
        {
            OrderProductRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<OrderProduct> GetAll()
        {
            IEnumerable<OrderProduct> items = OrderProductRepository.Get();
            return items;
        }

        public OrderProduct GetById(int id)
        {
            var item = OrderProductRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}