using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.FreelanceMusicStore;

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

        public void CreateMusician(ApplicationUserDTO userDTO)
        {
            var user = _mapper.Map<ApplicationUserDTO, ApplicationUser>(userDTO);
            _unitOfWork.Musicians.Create(new Musician() { ApplicationUser = user, Guid = user.Id});
            _unitOfWork.SaveAsync();
        }

/*        public int FindByGuid(Guid guid)
        {
            context.Musicians.Where(c => c);
        }*/
    }
}

