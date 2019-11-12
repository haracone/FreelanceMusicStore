using Microsoft.AspNet.Identity.EntityFramework;
using System;
using Domain.FreelanceMusicStore.Identity;

namespace DAL.FreelanceMusicStore.Identity
{
    public class CustomRole : IdentityRole<Guid, CustomUserRole>
    {
    }
}
