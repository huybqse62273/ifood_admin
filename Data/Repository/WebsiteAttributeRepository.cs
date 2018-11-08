﻿using Data.Infrastructure;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class WebsiteAttributeRepository : BaseRepository<WebsiteAttribute>, IWebsiteAttributeRepository
    {
        public WebsiteAttributeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IWebsiteAttributeRepository : IRepository<WebsiteAttribute>
    {

    }
}