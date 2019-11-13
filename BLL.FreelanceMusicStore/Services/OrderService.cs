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

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<OrderDTO> GetAll()
        {
            var orderDTO = _unitOfWork.Orders.GetAll();
            List<OrderDTO> orderCollection = new List<OrderDTO>();
            foreach (var order in orderDTO)
            {
                /*orderCollection.Add(ConvertEntityToDTO(order));*/
                orderCollection.Add(PropertiesConvert<Order, OrderDTO>.AllPropertiesConvert(order));
            }
            return orderCollection.AsQueryable();
        }

        public void CreateOrder(OrderDTO orderDTO)
        {
            /*Order order = ConvertDTOToEntity(orderDTO);*/
            Order order = PropertiesConvert<OrderDTO, Order>.AllPropertiesConvert(orderDTO);
            _unitOfWork.Orders.Create(order);
            _unitOfWork.SaveAsync();
        }
    }
}
