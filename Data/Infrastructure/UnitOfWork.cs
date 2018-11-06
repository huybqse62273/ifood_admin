using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Data.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private OtakuStore dataContext;
        protected OtakuStore DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }
        public void Commit()
        {
            DataContext.Commit();
        }
    }
}