using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IOrderService
    {
        void createOrder(Order obj);
        void editOrder(Order obj);
        void deleteOrder(int id);
        Order GetById(int id);
        IEnumerable<Order> GetAll();
        void SaveChange();
    }
    public class OrderService : IOrderService
    {
        #region Field
        private readonly IOrderRepository OrderRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public OrderService(IOrderRepository OrderRepository, IUnitOfWork unitOfWork)
        {
            this.OrderRepository = OrderRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createOrder(Order obj)
        {
            try
            {
                OrderRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteOrder(int id)
        {
            Order Order = OrderRepository.GetById(id);
            OrderRepository.Delete(Order);
            SaveChange();
        }

        public void editOrder(Order obj)
        {
            OrderRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Order> GetAll()
        {
            IEnumerable<Order> items = OrderRepository.Get();
            return items;
        }

        public Order GetById(int id)
        {
            var item = OrderRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}