using Domain.FreelanceMusicStore.Entities;
using Domain.FreelanceMusicStore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace DAL.FreelanceMusicStore.Identity {
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim> {
        public CustomUserStore(DbContext context) : base(context) {
        }
    }
}
