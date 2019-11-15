using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
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

        public async Task CreateOrder(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            _unitOfWork.Orders.Create(order);
            await _unitOfWork.SaveAsync();
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {

            _unitOfWork.Orders.Update(_mapper.Map<OrderDTO, Order>(orderDTO));
            _unitOfWork.SaveAsync();
        }
    }
}
