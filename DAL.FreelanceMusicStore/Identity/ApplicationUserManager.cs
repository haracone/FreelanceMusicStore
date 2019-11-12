using Domain.FreelanceMusicStore.Entities;
using Domain.FreelanceMusicStore.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace DAL.FreelanceMusicStore.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser, Guid>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, Guid> store) : base(store)
        {
        }
    }
}
