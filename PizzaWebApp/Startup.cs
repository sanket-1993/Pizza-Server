using Microsoft.Owin;
using Owin;
using PizzaWebApp.App_Start;

[assembly: OwinStartup(typeof(PizzaWebApp.App_Start.Startup))]
namespace PizzaWebApp.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }
    }
}