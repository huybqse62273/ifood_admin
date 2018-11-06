using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface ITypeService
    {
        void createType(Data.Type obj);
        void editType(Data.Type obj);
        void deleteType(int id);
        Data.Type GetById(int id);
        IEnumerable<Data.Type> GetAll();
        void SaveChange();
    }
    public class TypeService : ITypeService
    {
        #region Field
        private readonly ITypeRepository TypeRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public TypeService(ITypeRepository TypeRepository, IUnitOfWork unitOfWork)
        {
            this.TypeRepository = TypeRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createType(Data.Type obj)
        {
            try
            {
                TypeRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteType(int id)
        {
            Data.Type Type = TypeRepository.GetById(id);
            TypeRepository.Delete(Type);
            SaveChange();
        }

        public void editType(Data.Type obj)
        {
            TypeRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Data.Type> GetAll()
        {
            IEnumerable<Data.Type> items = TypeRepository.Get();
            return items;
        }

        public Data.Type GetById(int id)
        {
            var item = TypeRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}