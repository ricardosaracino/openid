using Microsoft.Owin;
using Owin;
using ESorWebApi;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace ESorWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}