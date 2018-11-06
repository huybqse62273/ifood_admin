using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Infrastructure;

namespace Service
{
    public interface ITagService
    {
        void createTag(Tag obj);
        void editTag(Tag obj);
        void deleteTag(int id);
        Tag GetById(int id);
        IEnumerable<Tag> GetAll();
        void SaveChange();
    }
    public class TagService : ITagService
    {
        #region Field
        private readonly ITagRepository TagRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public TagService(ITagRepository TagRepository, IUnitOfWork unitOfWork)
        {
            this.TagRepository = TagRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public void createTag(Tag obj)
        {
            try
            {
                TagRepository.Add(obj);
                SaveChange();
            }
            catch
            {

            }
        }

        public void deleteTag(int id)
        {
            Tag Tag = TagRepository.GetById(id);
            TagRepository.Delete(Tag);
            SaveChange();
        }

        public void editTag(Tag obj)
        {
            TagRepository.Update(obj);
            SaveChange();
        }

        public IEnumerable<Tag> GetAll()
        {
            IEnumerable<Tag> items = TagRepository.Get();
            return items;
        }

        public Tag GetById(int id)
        {
            var item = TagRepository.GetById(id);
            return item;
        }

        public void SaveChange()
        {
            unitOfWork.Commit();
        }
    }
}