using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System;
using AutoMapper;

namespace BLL.FreelanceMusicStore.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ApplicationUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public ApplicationUser GetUserById(Guid guid)
        {
            return _unitOfWork.ApplicationUserManager.FindById<ApplicationUser, Guid>(guid);
        }
    }
}
