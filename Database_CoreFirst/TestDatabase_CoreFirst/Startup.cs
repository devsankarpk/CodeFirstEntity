using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestDatabase_CoreFirst.Startup))]
namespace TestDatabase_CoreFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
