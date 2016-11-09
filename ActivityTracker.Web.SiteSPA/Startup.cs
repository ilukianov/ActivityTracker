using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ActivityTracker.Web.SiteSPA.Startup))]

namespace ActivityTracker.Web.SiteSPA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

/*        private void ConfigureServices(IServiceCollection services)
        {
            
        }*/
    }
}
