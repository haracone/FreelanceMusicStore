﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestProject.Startup))]
namespace TestProject {
    public partial class Startup {
        public void ConfigureServices(IServiceCollection services) {
        }

        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
