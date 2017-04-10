using DeltaDucks.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DeltaDucks.Web;

namespace DeltaDucks.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Initialize database 
            new DeltaDucksContext().Database.Initialize(true);
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DeltaDucksContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac Config 
            Bootstrapper.Run();
        }
    }
}
