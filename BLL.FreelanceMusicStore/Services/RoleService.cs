using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Identity;
using DAL.FreelanceMusicStore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Services {
    public class RoleService : IRoleService {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<CustomRole> GetAllRoles() {
            return _unitOfWork.ApplicationRoleManager.Roles.Where(role => role.Name != "Admin").ToList();
        }

        public Task<CustomRole> GetRoleByName(string name) {
            return _unitOfWork.ApplicationRoleManager.FindByNameAsync(name);
        }

        public async Task CreateRoleAsync(CustomRoleDTO customRoleDTO) {
            var customeRole = _mapper.Map<CustomRoleDTO, CustomRole>(customRoleDTO);
            await _unitOfWork.ApplicationRoleManager.CreateAsync(customeRole);
            await _unitOfWork.SaveAsync();
        }
    }
}
