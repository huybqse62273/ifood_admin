using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IDiscountService
    {
        void createDiscount(Discount obj);
        void editDiscount(Discount obj);
        void deleteDiscount(int id);
        Discount GetById(int id);
        IEnumerable<Discount> GetAll();
        void SaveChange();
    }
    public class DiscountService : IDiscountService
    {
        #region Field
        private readonly IDiscountRepository DiscountRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public DiscountService(IDiscountRepository DiscountRepository, IUnitOfWork unitOfWork)
        {
            this.DiscountRepository = DiscountRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createDiscount(Discount obj)
        {
            try
            {
                DiscountRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteDiscount(int id)
        {
            Discount Discount = DiscountRepository.GetById(id);
            DiscountRepository.Delete(Discount);
            SaveChange();
        }

        public void editDiscount(Discount obj)
        {
            DiscountRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Discount> GetAll()
        {
            IEnumerable<Discount> items = DiscountRepository.Get();
            return items;
        }

        public Discount GetById(int id)
        {
            var item = DiscountRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}