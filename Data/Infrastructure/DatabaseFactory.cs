using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private OtakuStore dataContext;
        public OtakuStore Get()
        {
            return dataContext ?? (dataContext = new OtakuStore());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}