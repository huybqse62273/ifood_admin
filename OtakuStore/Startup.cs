﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web;
using Data;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(OtakuStore.Startup))]

namespace OtakuStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
        }

    }
}
