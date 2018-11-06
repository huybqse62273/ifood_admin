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
    public interface IMessageSendingService
    {
        void createMessageSending(MessageSending obj);
        void editMessageSending(MessageSending obj);
        void deleteMessageSending(int id);
        MessageSending GetById(int id);
        IEnumerable<MessageSending> GetAll();
        void SaveChange();
    }
    public class MessageSendingService : IMessageSendingService
    {
        #region Field
        private readonly IMessageSendingRepository MessageSendingRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public MessageSendingService(IMessageSendingRepository MessageSendingRepository, IUnitOfWork unitOfWork)
        {
            this.MessageSendingRepository = MessageSendingRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createMessageSending(MessageSending obj)
        {
            try
            {
                MessageSendingRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteMessageSending(int id)
        {
            MessageSending MessageSending = MessageSendingRepository.GetById(id);
            MessageSendingRepository.Delete(MessageSending);
            SaveChange();
        }

        public void editMessageSending(MessageSending obj)
        {
            MessageSendingRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<MessageSending> GetAll()
        {
            IEnumerable<MessageSending> items = MessageSendingRepository.Get();
            return items;
        }

        public MessageSending GetById(int id)
        {
            var item = MessageSendingRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}
