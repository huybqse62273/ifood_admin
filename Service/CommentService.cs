using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface ICommentService
    {
        void createComment(Comment obj);
        void editComment(Comment obj);
        void deleteComment(int id);
        Comment GetById(int id);
        IEnumerable<Comment> GetAll();
        void SaveChange();
    }
    public class CommentService : ICommentService
    {
        #region Field
        private readonly ICommentRepository CommentRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public CommentService(ICommentRepository CommentRepository, IUnitOfWork unitOfWork)
        {
            this.CommentRepository = CommentRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createComment(Comment obj)
        {
            try
            {
                CommentRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteComment(int id)
        {
            Comment Comment = CommentRepository.GetById(id);
            CommentRepository.Delete(Comment);
            SaveChange();
        }

        public void editComment(Comment obj)
        {
            CommentRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Comment> GetAll()
        {
            IEnumerable<Comment> items = CommentRepository.Get();
            return items;
        }

        public Comment GetById(int id)
        {
            var item = CommentRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}