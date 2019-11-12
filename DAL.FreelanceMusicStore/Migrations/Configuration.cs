using DAL.FreelanceMusicStore.Identity;

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
            RoleRepository roleRepository = new RoleRepository(roleManager);
            roleRepository.Create(new CustomRole() { Name = "Admin"});
            roleRepository.Create(new CustomRole() { Name = "Client" });
            roleRepository.Create(new CustomRole() { Name = "Musician" });
            context.SaveChanges();
        }
    }
}
