using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public IQueryable<OrderDTO> GetAll()
        {
            var orderDTO = _unitOfWork.Orders.GetAll();
            List<OrderDTO> orderCollection = new List<OrderDTO>();
            foreach (var order in orderDTO)
            {
                orderCollection.Add(_mapper.Map<Order, OrderDTO>(order));
            }
            return orderCollection.AsQueryable();
        }

        public void CreateOrder(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            _unitOfWork.Orders.Create(order);
            _unitOfWork.SaveAsync();
        }
    }
}
