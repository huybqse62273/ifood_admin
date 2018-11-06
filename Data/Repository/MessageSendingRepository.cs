using Data.Infrastructure;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{

    public class MessageSendingRepository : BaseRepository<MessageSending>, IMessageSendingRepository
    {
        public MessageSendingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }

    public interface IMessageSendingRepository : IRepository<MessageSending>
    {

    }
}
