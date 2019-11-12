using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Identity;
using BLL.FreelanceMusicStore.Interfaces;

namespace BLL.FreelanceMusicStore.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomRole> GetAllRoles()
        {
            return _unitOfWork.ApplicationRoleManager.Roles.Where(role => role.Name != "Admin").ToList();
        }

        public Task<CustomRole> GetRoleByName(string name)
        {
            return _unitOfWork.ApplicationRoleManager.FindByNameAsync(name);
        }
    }
}
