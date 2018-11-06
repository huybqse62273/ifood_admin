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
    public interface IWebsiteAttributeService
    {
        void createWebsiteAttribute(WebsiteAttribute obj);
        void editWebsiteAttribute(WebsiteAttribute obj);
        void deleteWebsiteAttribute(int id);
        WebsiteAttribute GetById(int id);
        IEnumerable<WebsiteAttribute> GetAll();
        void SaveChange();
    }
    public class WebsiteAttributeService : IWebsiteAttributeService
    {
        #region Field
        private readonly IWebsiteAttributeRepository WebsiteAttributeRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public WebsiteAttributeService(IWebsiteAttributeRepository WebsiteAttributeRepository, IUnitOfWork unitOfWork)
        {
            this.WebsiteAttributeRepository = WebsiteAttributeRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createWebsiteAttribute(WebsiteAttribute obj)
        {
            try
            {
                WebsiteAttributeRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteWebsiteAttribute(int id)
        {
            WebsiteAttribute WebsiteAttribute = WebsiteAttributeRepository.GetById(id);
            WebsiteAttributeRepository.Delete(WebsiteAttribute);
            SaveChange();
        }

        public void editWebsiteAttribute(WebsiteAttribute obj)
        {
            WebsiteAttributeRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<WebsiteAttribute> GetAll()
        {
            IEnumerable<WebsiteAttribute> items = WebsiteAttributeRepository.Get();
            return items;
        }

        public WebsiteAttribute GetById(int id)
        {
            var item = WebsiteAttributeRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}
