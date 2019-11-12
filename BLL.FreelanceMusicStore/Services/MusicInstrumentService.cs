using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;

namespace BLL.FreelanceMusicStore.Services
{
    class MusicInstrumentService
    {
        public MusicInstrumentDTO ConvertEntityToDTO(MusicInstrument instrument)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<MusicInstrument, MusicInstrumentDTO>(); });

            IMapper iMapper = config.CreateMapper();
            var source = instrument;
            var DTO = iMapper.Map<MusicInstrument, MusicInstrumentDTO>(source);
                
            return DTO;
        }
    }
}
