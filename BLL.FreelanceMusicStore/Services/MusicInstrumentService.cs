using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System.Collections.Generic;

namespace BLL.FreelanceMusicStore.Services
{
    public class MusicInstrumentService : IMusicInstrumentService
    {
        IUnitOfWork _unitOfWork;

        public MusicInstrumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MusicInstrumentDTO ConvertEntityToDTO(MusicInstrument instrument)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<MusicInstrument, MusicInstrumentDTO>(); });

            IMapper iMapper = config.CreateMapper();
            var source = instrument;
            var DTO = iMapper.Map<MusicInstrument, MusicInstrumentDTO>(source);
                
            return DTO;
        }

        public ICollection<MusicInstrumentDTO> GetAll()
        {
            var instruments = _unitOfWork.MusicInstruments.GetAll();
            ICollection<MusicInstrumentDTO> entity = new List<MusicInstrumentDTO>();
            foreach (var instrument in instruments)
                entity.Add(ConvertEntityToDTO(instrument));
            return entity;
        }
    }
}
