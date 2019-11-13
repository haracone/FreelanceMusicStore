using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IApplicationUserService
    {
        Task CreateAsync(ApplicationUserDTO DTO);
        Task<ApplicationUser> GetUser(string email, string password);
        Task<ClaimsIdentity> CreateIdentity(ApplicationUser user, string autentificationType);
    }
}
