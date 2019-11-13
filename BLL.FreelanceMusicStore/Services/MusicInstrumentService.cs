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
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public MusicInstrumentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ICollection<MusicInstrumentDTO> GetAll()
        {
            var instruments = _unitOfWork.MusicInstruments.GetAll();
            ICollection<MusicInstrumentDTO> entity = new List<MusicInstrumentDTO>();
            foreach (var instrument in instruments)
            {
                entity.Add(_mapper.Map<MusicInstrument, MusicInstrumentDTO>(instrument));                
            }
            return entity;
        }
    }
}
