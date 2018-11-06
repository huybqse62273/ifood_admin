using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface INotificationRepository : IRepository<Notification>
    {

    }
}
