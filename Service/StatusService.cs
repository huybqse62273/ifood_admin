using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IStatusService
    {
        void createStatus(Status obj);
        void editStatus(Status obj);
        void deleteStatus(int id);
        Status GetById(int id);
        IEnumerable<Status> GetAll();
        void SaveChange();
    }
    public class StatusService : IStatusService
    {
        #region Field
        private readonly IStatusRepository StatusRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public StatusService(IStatusRepository StatusRepository, IUnitOfWork unitOfWork)
        {
            this.StatusRepository = StatusRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createStatus(Status obj)
        {
            try
            {
                StatusRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteStatus(int id)
        {
            Status Status = StatusRepository.GetById(id);
            StatusRepository.Delete(Status);
            SaveChange();
        }

        public void editStatus(Status obj)
        {
            StatusRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Status> GetAll()
        {
            IEnumerable<Status> items = StatusRepository.Get();
            return items;
        }

        public Status GetById(int id)
        {
            var item = StatusRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}