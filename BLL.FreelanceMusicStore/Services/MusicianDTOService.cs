using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;

namespace BLL.FreelanceMusicStore.Services
{
    class MusicianDTOService
    {
        public MusicianDTO ConvertEntityToDTO(Musician instrument)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Musician, MusicianDTO>(); });

            IMapper iMapper = config.CreateMapper();
            var source = instrument;
            var DTO = iMapper.Map<Musician, MusicianDTO>(source);

            return DTO;
        }
    }
}
