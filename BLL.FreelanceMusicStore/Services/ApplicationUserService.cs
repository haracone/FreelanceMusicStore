using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Services {
    public class ApplicationUserService : IApplicationUserService {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ApplicationUserService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServerRequest> CreateAsync(ApplicationUserDTO userDTO) {
            ServerRequest serverRequest = new ServerRequest();
            try {
                ApplicationUser user = await _unitOfWork.ApplicationUserManager.FindByEmailAsync(userDTO.Email);
                if (user == null) {
                    user = _mapper.Map<ApplicationUserDTO, ApplicationUser>(userDTO);
                    await _unitOfWork.ApplicationUserManager.CreateAsync(user, userDTO.Password);
                    await _unitOfWork.ApplicationUserManager.AddToRoleAsync(user.Id, userDTO.Role.Name);
                    await _unitOfWork.SaveAsync();
                    return serverRequest;
                }
                else {
                    return serverRequest;
                }
            }
            catch {
                serverRequest.ErrorOccured = true;
                serverRequest.Message = "Error was occured when you try to create new user";
                return serverRequest;
            }
        }

        public Task<ApplicationUser> GetUser(string email, string password) {
            return _unitOfWork.ApplicationUserManager.FindAsync(email, password);
        }

        public Task<ClaimsIdentity> CreateIdentity(ApplicationUser user, string autentificationType) {
            return _unitOfWork.ApplicationUserManager.CreateIdentityAsync(user, autentificationType);
        }

        public ApplicationUser GetUserById(Guid guid) {
            return _unitOfWork.ApplicationUserManager.FindById<ApplicationUser, Guid>(guid);
        }

        public async Task ChangeName(ApplicationUser user, string name, string surname) {
            user.Name = name;
            user.Surname = surname;
            await _unitOfWork.SaveAsync();
        }
    }
}
