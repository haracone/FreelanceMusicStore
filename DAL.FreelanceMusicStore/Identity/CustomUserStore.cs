using Microsoft.AspNet.Identity.EntityFramework;
using System;
using DAL.FreelanceMusicStore;
using System.Data.Entity;
using Domain.FreelanceMusicStore.Identity;
using Domain.FreelanceMusicStore.Entities;

namespace DAL.FreelanceMusicStore.Identity
{
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(DbContext context) : base(context)
        {
        }
    }
}
