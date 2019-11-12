using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.FreelanceMusicStore.Identity;
using DAL.FreelanceMusicStore.Interfaces;

namespace DAL.FreelanceMusicStore.Identity
{
    public class RoleRepository
    {
        private ApplicationRoleManager _manager;
        public RoleRepository(ApplicationRoleManager manager)
        {
            _manager = manager;
        }

        public Task<CustomRole> GetByName(string name)
        {
            return _manager.FindByNameAsync(name);
        }

        public Task<CustomRole> GetById(Guid guid)
        {
            return _manager.FindByIdAsync(guid);
        }

        public IEnumerable<CustomRole> GetAll()
        {
            return _manager.Roles.ToList(); 
        }

        public void Create(CustomRole role)
        {
            role.Id = Guid.NewGuid();
            _manager.CreateAsync(role);
        }
    }
}
