using Domain.FreelanceMusicStore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Domain.FreelanceMusicStore.Entities
{
    public class ApplicationUser : IdentityUser<Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
