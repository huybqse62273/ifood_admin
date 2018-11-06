using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Infrastructure;
namespace Data
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface ICommentRepository : IRepository<Comment>
    {

    }
}