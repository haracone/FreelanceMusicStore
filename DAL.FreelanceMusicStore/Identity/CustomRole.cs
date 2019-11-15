using Domain.FreelanceMusicStore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace DAL.FreelanceMusicStore.Identity
{
    public class CustomRole : IdentityRole<Guid, CustomUserRole>
    {
    }
}
