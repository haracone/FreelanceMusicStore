using DAL.FreelanceMusicStore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<CustomRole> GetAllRoles();
        Task<CustomRole> GetRoleByName(string name);
    }
}
