using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Data.Model;

namespace OtakuStore.ViewModels
{
    public class MessageSendingViewModel
    {
        public IPagedList<MessageSending> listMessage { get; set; }
    }
}