using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IFAQService
    {
        void createFAQ(FAQ obj);
        void editFAQ(FAQ obj);
        void deleteFAQ(int id);
        FAQ GetById(int id);
        IEnumerable<FAQ> Get();
        void SaveChange();
    }
    public class FAQService : IFAQService
    {
        #region Field
        private readonly IFAQRepository FAQRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public FAQService(IFAQRepository FAQRepository, IUnitOfWork unitOfWork)
        {
            this.FAQRepository = FAQRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createFAQ(FAQ obj)
        {
            try
            {
                FAQRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteFAQ(int id)
        {
            FAQ FAQ = FAQRepository.GetById(id);
            FAQRepository.Delete(FAQ);
            SaveChange();
        }

        public void editFAQ(FAQ obj)
        {
            FAQRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<FAQ> Get()
        {
            IEnumerable<FAQ> items = FAQRepository.Get();
            return items;
        }

        public FAQ GetById(int id)
        {
            var item = FAQRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}