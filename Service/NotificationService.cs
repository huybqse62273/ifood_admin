using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface INotificationService
    {
        void createNotification(Notification obj);
        void editNotification(Notification obj);
        void deleteNotification(int id);
        Notification GetById(int id);
        IEnumerable<Notification> GetAll();
        void SaveChange();
    }
    public class NotificationService : INotificationService
    {
        #region Field
        private readonly INotificationRepository NotificationRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public NotificationService(INotificationRepository NotificationRepository, IUnitOfWork unitOfWork)
        {
            this.NotificationRepository = NotificationRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createNotification(Notification obj)
        {
            try
            {
                NotificationRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteNotification(int id)
        {
            Notification Notification = NotificationRepository.GetById(id);
            NotificationRepository.Delete(Notification);
            SaveChange();
        }

        public void editNotification(Notification obj)
        {
            NotificationRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Notification> GetAll()
        {
            IEnumerable<Notification> items = NotificationRepository.Get();
            return items;
        }

        public Notification GetById(int id)
        {
            var item = NotificationRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}