﻿using System.Web;
using System.Web.Mvc;

namespace ActivityTracker.Web.SiteSPA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}