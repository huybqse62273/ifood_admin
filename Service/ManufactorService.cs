using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IManufactorService
    {
        void createManufactor(Manufactor obj);
        void editManufactor(Manufactor obj);
        void deleteManufactor(int id);
        Manufactor GetById(int id);
        IEnumerable<Manufactor> GetAll();
        void SaveChange();
    }
    public class ManufactorService : IManufactorService
    {
        #region Field
        private readonly IManufactorRepository ManufactorRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ManufactorService(IManufactorRepository ManufactorRepository, IUnitOfWork unitOfWork)
        {
            this.ManufactorRepository = ManufactorRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createManufactor(Manufactor obj)
        {
            try
            {
                ManufactorRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteManufactor(int id)
        {
            Manufactor Manufactor = ManufactorRepository.GetById(id);
            ManufactorRepository.Delete(Manufactor);
            SaveChange();
        }

        public void editManufactor(Manufactor obj)
        {
            ManufactorRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Manufactor> GetAll()
        {
            IEnumerable<Manufactor> items = ManufactorRepository.Get();
            return items;
        }

        public Manufactor GetById(int id)
        {
            var item = ManufactorRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}