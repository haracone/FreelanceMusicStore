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

        public ICollection<MusicInstrumentDTO> GetAll()
        {
            var instruments = _unitOfWork.MusicInstruments.GetAll();
            ICollection<MusicInstrumentDTO> entity = new List<MusicInstrumentDTO>();
            foreach (var instrument in instruments)
                entity.Add(PropertiesConvert<MusicInstrument, MusicInstrumentDTO>.AllPropertiesConvert(instrument));
            return entity;
        }
    }
}
