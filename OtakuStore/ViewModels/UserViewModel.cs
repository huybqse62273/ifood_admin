using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Data;

namespace OtakuStore.ViewModels
{
    public class UserViewModel
    {
        public IPagedList<Account> accounts { get; set; } 
    }
}