using DAL.FreelanceMusicStore;
using DAL.FreelanceMusicStore.Identity;
using Microsoft.Owin;
using Owin;
using Microsoft.Extensions.DependencyInjection;

[assembly: OwinStartupAttribute(typeof(TestProject.Startup))]
namespace TestProject
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
