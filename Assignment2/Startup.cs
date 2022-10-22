using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(Assignment2.Startup))]
namespace Assignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            MvcHandler.DisableMvcResponseHeader = true;

        }
    }
}
