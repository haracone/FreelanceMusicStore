using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;
using DAL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore;
using System.Threading.Tasks;
using DAL.FreelanceMusicStore.Identity;
using BLL.FreelanceMusicStore.Interfaces;


namespace BLL.FreelanceMusicStore.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public ApplicationUserDTO ConvertEntityToDTO(ApplicationUser instrument)
        {           
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ApplicationUser, ApplicationUserDTO>(); });

            IMapper iMapper = config.CreateMapper();
            var source = instrument;
            var DTO = iMapper.Map<ApplicationUser, ApplicationUserDTO>(source);
            return DTO;            
        }

        public async Task Create(ApplicationUserDTO userDTO)
        {
            ApplicationUser user = await _unitOfWork.ApplicationUserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDTO.Email, UserName = userDTO.Email};
                await _unitOfWork.ApplicationUserManager.CreateAsync(user, userDTO.Password);
/*                await _unitOfWork.ApplicationUserManager.AddToRoleAsync(user.Id, userDTO.Role.Name);*/
                _unitOfWork.SaveAsync();
            }
            else
            {
                return;
            }
        }
    }
}
