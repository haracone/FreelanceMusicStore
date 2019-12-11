using BLL.FreelanceMusicStore.EntityDTO;
using System;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces {
    public interface IClientService {
        Task<ServerRequest> CreateClient(ApplicationUserDTO user);
        ClientDTO GetClientById(Guid guid);
    }
}
