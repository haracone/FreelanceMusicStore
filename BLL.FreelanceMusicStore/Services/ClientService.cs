using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;

namespace BLL.FreelanceMusicStore.Services
{
    class ClientService
    {
        public ClientDTO ConvertEntityToDTO(Client instrument)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Client, ClientDTO>(); });

            IMapper iMapper = config.CreateMapper();
            var source = instrument;
            var DTO = iMapper.Map<Client, ClientDTO>(source);

            return DTO;
        }
    }
}
