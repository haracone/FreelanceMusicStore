using BLL.FreelanceMusicStore.EntityDTO;
using DAL.FreelanceMusicStore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IRoleService
    {
        List<CustomRole> GetAllRoles();
        Task<CustomRole> GetRoleByName(string name);
        Task CreateRoleAsync(CustomRoleDTO customRoleDTO);
    }
}
