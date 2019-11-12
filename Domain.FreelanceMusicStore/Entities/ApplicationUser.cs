using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Domain.FreelanceMusicStore.Identity;

namespace Domain.FreelanceMusicStore.Entities
{
    public class ApplicationUser : IdentityUser<Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
