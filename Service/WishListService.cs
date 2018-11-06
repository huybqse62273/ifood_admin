using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IWishListService
    {
        void createWishList(WishList obj);
        void editWishList(WishList obj);
        void deleteWishList(int id);
        WishList GetById(int id);
        IEnumerable<WishList> GetAll();
        void SaveChange();
    }
    public class WishListService : IWishListService
    {
        #region Field
        private readonly IWishListRepository WishListRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public WishListService(IWishListRepository WishListRepository, IUnitOfWork unitOfWork)
        {
            this.WishListRepository = WishListRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createWishList(WishList obj)
        {
            try
            {
                WishListRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteWishList(int id)
        {
            WishList WishList = WishListRepository.GetById(id);
            WishListRepository.Delete(WishList);
            SaveChange();
        }

        public void editWishList(WishList obj)
        {
            WishListRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<WishList> GetAll()
        {
            IEnumerable<WishList> items = WishListRepository.Get();
            return items;
        }

        public WishList GetById(int id)
        {
            var item = WishListRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}