using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL.FreelanceMusicStore.Services
{
    public class ClientService : IClientService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateClient(ApplicationUserDTO userDTO)
        {
            var user = _mapper.Map<ApplicationUserDTO, ApplicationUser>(userDTO);
            _unitOfWork.Clients.Create(new Client() { ApplicationUser = user, Guid = user.Id});
            _unitOfWork.SaveAsync();
        }
    }
}
