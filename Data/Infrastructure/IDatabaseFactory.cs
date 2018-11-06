using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        OtakuStore Get();
    }
}