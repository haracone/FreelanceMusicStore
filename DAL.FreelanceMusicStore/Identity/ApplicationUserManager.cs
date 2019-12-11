using Domain.FreelanceMusicStore.Entities;
using Microsoft.AspNet.Identity;
using System;

namespace DAL.FreelanceMusicStore.Identity {
    public class ApplicationUserManager : UserManager<ApplicationUser, Guid> {
        public ApplicationUserManager(IUserStore<ApplicationUser, Guid> store) : base(store) {
        }
    }
}
