using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;
using DAL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore;
using System.Threading.Tasks;
using DAL.FreelanceMusicStore.Identity;
using BLL.FreelanceMusicStore.Interfaces;
using System.Collections;
using System.Security.Claims;

namespace BLL.FreelanceMusicStore.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async Task CreateAsync(ApplicationUserDTO userDTO)
        {
            ApplicationUser user = await _unitOfWork.ApplicationUserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser() { Email = userDTO.Email, UserName = userDTO.Email};
                await _unitOfWork.ApplicationUserManager.CreateAsync(user, userDTO.Password);
                await _unitOfWork.ApplicationUserManager.AddToRoleAsync(user.Id, userDTO.Role.Name);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                return;
            }
        }

        public Task<ApplicationUser> GetUser(string email, string password)
        {
            return _unitOfWork.ApplicationUserManager.FindAsync(email, password);
        }

        public Task<ClaimsIdentity> CreateIdentity(ApplicationUser user, string autentificationType)
        {
            return _unitOfWork.ApplicationUserManager.CreateIdentityAsync(user, autentificationType);
        }
    }
}
