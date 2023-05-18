﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Trial;
namespace Trial
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            /* RouteConfig.RegisterRoutes(RouteTable.Routes);*/
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            UnityConfig.RegisterComponents();            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }               
    }
}
