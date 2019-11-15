using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Identity;
using DAL.FreelanceMusicStore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CustomRole> GetAllRoles()
        {
            return _unitOfWork.ApplicationRoleManager.Roles.Where(role => role.Name != "Admin").ToList();
        }

        public Task<CustomRole> GetRoleByName(string name)
        {
            return _unitOfWork.ApplicationRoleManager.FindByNameAsync(name);
        }
    }
}
