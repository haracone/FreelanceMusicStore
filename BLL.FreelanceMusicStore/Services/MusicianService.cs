using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.FreelanceMusicStore;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Services
{
    public class MusicianService : IMusicianService
    {
        EF6DBContext context = new EF6DBContext();
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;       

        public MusicianService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServerRequest> CreateMusician(ApplicationUserDTO userDTO)
        {
            ServerRequest serverRequest = new ServerRequest();
            try
            {
                var user = _mapper.Map<ApplicationUserDTO, ApplicationUser>(userDTO);
                _unitOfWork.Musicians.Create(new Musician() { Id = user.Id, Guid = user.Id });
                await _unitOfWork.SaveAsync();
                return serverRequest;
            }
            catch
            {
                serverRequest.ErrorOccured = true;
                serverRequest.Message = "Error was occcured when you try create new musician";
                return serverRequest;
            }
        }

        public MusicianDTO GetMusicianById(Guid id)
        {
            return _mapper.Map<Musician, MusicianDTO>(_unitOfWork.Musicians.GetById(id));
        }

        public async Task AddMusicInstrumentsToMusician(ICollection<MusicInstrumentDTO> musicInstrumentDTOs, Guid guid)
        {
            var musician = _unitOfWork.Musicians.GetById(guid);
            if (musician.MusicInstrument == null)
            {
                musician.MusicInstrument = new List<MusicInstrument>();
            }
            foreach (var musicInstrumentDTO in musicInstrumentDTOs)
            {
                var mi = _unitOfWork.MusicInstruments.GetById(musicInstrumentDTO.Id);
                musician.MusicInstrument.Add(mi);
            }
            _unitOfWork.Musicians.Update(musician);
            await _unitOfWork.SaveAsync();
        }
    }
}

