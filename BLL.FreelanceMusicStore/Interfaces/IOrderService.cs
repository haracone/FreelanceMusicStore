using BLL.FreelanceMusicStore.EntityDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces {
    public interface IOrderService {
        List<OrderDTO> GetAll();
        Task<ServerRequest> CreateOrder(OrderDTO orderDTO);
        Task<ServerRequest> UpdateOrder(OrderDTO orderDTO);
        List<OrderDTO> GetOrderByClientId(Guid guid);
    }
}
