﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ConfigCenter.Common;

namespace ConfigCenter.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ObjectMapping.Init();
            new AppHost().Init();
        }
    }
}
