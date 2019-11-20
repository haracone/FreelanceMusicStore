using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<ServerRequest> CreateClient(ApplicationUserDTO userDTO)
        {
            ServerRequest serverRequest = new ServerRequest();
            try
            {
                var user = _mapper.Map<ApplicationUserDTO, ApplicationUser>(userDTO);
                _unitOfWork.Clients.Create(new Client { Id = user.Id, Guid = user.Id });
                await _unitOfWork.SaveAsync();
                serverRequest.ErrorOccured = false;
                return serverRequest;
            }
            catch
            {
                serverRequest.ErrorOccured = true;
                serverRequest.Message = "Error was occcured when you try create new client";
                return serverRequest;
            }
        }

        public ClientDTO GetClientById(Guid guid)
        {
            return _mapper.Map<Client, ClientDTO>(_unitOfWork.Clients.GetById(guid));
        }
    }
}
