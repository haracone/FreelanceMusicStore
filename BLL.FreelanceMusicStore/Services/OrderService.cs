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
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<OrderDTO> GetAll()
        {
            var orderDTO = _unitOfWork.Orders.GetAll();
            List<OrderDTO> orderCollection = new List<OrderDTO>();
            foreach (var order in orderDTO)
            {
                orderCollection.Add(_mapper.Map<Order, OrderDTO>(order));
            }
            return orderCollection.ToList();
        }

        public async Task<ServerRequest> CreateOrder(OrderDTO orderDTO)
        {
            ServerRequest serverRequest = new ServerRequest();
            try
            {
                Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
                _unitOfWork.Orders.Create(order);
                await _unitOfWork.SaveAsync();
                return serverRequest;
            }
            catch
            {
                serverRequest.ErrorOccured = true;
                serverRequest.Message = "Error was occcured when you try create new order";
                return serverRequest;
            }
        }

        public async Task<ServerRequest> UpdateOrder(OrderDTO orderDTO)
        {
            ServerRequest serverRequest = new ServerRequest();
            try
            {
                _unitOfWork.Orders.Update(_mapper.Map<OrderDTO, Order>(orderDTO));
                await _unitOfWork.SaveAsync();
                return serverRequest;
            }
            catch
            {
                serverRequest.ErrorOccured = true;
                serverRequest.Message = "Error was occcured when you try update order";
                return serverRequest;
            }
        }
    }
}
