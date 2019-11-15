using BLL.FreelanceMusicStore.EntityDTO;
using System.Collections.Generic;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IOrderService
    {
        List<OrderDTO> GetAll();
        void CreateOrder(OrderDTO orderDTO);
        void UpdateOrder(OrderDTO orderDTO);
    }
}
