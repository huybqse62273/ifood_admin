using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface IAccountService
    {
        void createAccount(Account obj);
        void editAccount(Account obj);
        void deleteAccount(int id);
        Account GetByUserId(string UserId);
        IEnumerable<Account> GetAll();
        void SaveChange();
    }
    public class AccountService : IAccountService
    {
        #region Field
        private readonly IAccountRepository AccountRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public AccountService(IAccountRepository AccountRepository, IUnitOfWork unitOfWork)
        {
            this.AccountRepository = AccountRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createAccount(Account obj)
        {
            try
            {
                AccountRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteAccount(int id)
        {
            Account Account = AccountRepository.GetById(id);
            AccountRepository.Delete(Account);
            SaveChange();
        }

        public void editAccount(Account obj)
        {
            AccountRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Account> GetAll()
        {
            IEnumerable<Account> items = AccountRepository.Get();
            return items;
        }

        public Account GetByUserId(string UserId)
        {
            var item = AccountRepository.GetByUserId(UserId);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}