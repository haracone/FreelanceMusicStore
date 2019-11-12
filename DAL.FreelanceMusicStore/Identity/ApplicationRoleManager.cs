using Microsoft.AspNet.Identity;
using System;

namespace DAL.FreelanceMusicStore.Identity
{
    public class ApplicationRoleManager : RoleManager<CustomRole, Guid>
    {
        public ApplicationRoleManager(IRoleStore<CustomRole, Guid> store) : base(store)
        {
        }
    }
}
