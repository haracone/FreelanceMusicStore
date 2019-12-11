using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces {
    public interface IApplicationUserService {
        Task<ServerRequest> CreateAsync(ApplicationUserDTO DTO);
        Task<ApplicationUser> GetUser(string email, string password);
        Task<ClaimsIdentity> CreateIdentity(ApplicationUser user, string autentificationType);
        ApplicationUser GetUserById(Guid guid);
        Task ChangeName(ApplicationUser user, string name, string surname);
    }
}
