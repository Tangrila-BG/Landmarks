﻿using System.Web.Mvc;

namespace DeltaDucks.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                namespaces: new [] { "DeltaDucks.Web.Areas.Admin.Controllers" },
                name:"Admin_default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}