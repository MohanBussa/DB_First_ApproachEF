﻿using System.Web;
using System.Web.Mvc;

namespace Swagger_Application_DBFirst
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
