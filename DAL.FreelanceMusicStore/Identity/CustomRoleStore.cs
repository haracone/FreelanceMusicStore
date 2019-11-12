using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.FreelanceMusicStore.Identity;

namespace DAL.FreelanceMusicStore.Identity
{
    public class CustomRoleStore : RoleStore<CustomRole, Guid, CustomUserRole>
    {
        public CustomRoleStore(DbContext context) : base(context)
        {
        }
    }
}
