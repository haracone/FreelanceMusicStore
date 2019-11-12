using DAL.FreelanceMusicStore.Identity;
using DAL.FreelanceMusicStore;

namespace DAL.FreelanceMusicStore1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.FreelanceMusicStore.EF6DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.FreelanceMusicStore.EF6DBContext context)
        {
            ApplicationRoleManager roleManager = new ApplicationRoleManager(new CustomRoleStore(context));
            roleManager.CreateAsync(new CustomRole() { Name = "Admin"});
            roleManager.CreateAsync(new CustomRole() { Name = "Client" });
            roleManager.CreateAsync(new CustomRole() { Name = "Musician" });
            context.SaveChanges();
        }
    }
}
