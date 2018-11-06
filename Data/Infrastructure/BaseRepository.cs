using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;

namespace Data.Infrastructure
{
    public abstract class BaseRepository<T> where T : class
    {
        private OtakuStore dataContext;
        private readonly IDbSet<T> dbset;
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        protected OtakuStore DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public BaseRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }
        public virtual IEnumerable<T> Get()
        {
            IEnumerable<T> objects = dbset;
            return objects;
        }

        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetByUserId(string userId)
        {
            return dbset.Find(userId);
        }
    }
}