using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.FreelanceMusicStore.Entities;
using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore;
using DAL.FreelanceMusicStore.Interfaces;

namespace BLL.FreelanceMusicStore.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OrderDTO ConvertEntityToDTO(Order order)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Order, OrderDTO>(); });

            IMapper iMapper = config.CreateMapper();
            var source = order;
            var DTO = iMapper.Map<Order, OrderDTO>(source);

            return DTO;
        }

        public Order ConvertDTOToEntity(OrderDTO order)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<OrderDTO, Order>(); });

            IMapper iMapper = config.CreateMapper();
            var source = order;
            var entity = iMapper.Map<OrderDTO, Order>(source);

            return entity;
        }


        public IQueryable<OrderDTO> GetAll()
        {
            var orderDTO = _unitOfWork.Orders.GetAll();
            List<OrderDTO> orderCollection = new List<OrderDTO>();
            foreach (var order in orderDTO)
                orderCollection.Add(ConvertEntityToDTO(order));
            return orderCollection.AsQueryable();
        }

        public void CreateOrder(OrderDTO orderDTO)
        {
            Order order = ConvertDTOToEntity(orderDTO);
            _unitOfWork.Orders.Create(order);
            _unitOfWork.SaveAsync();
        }
    }
}
