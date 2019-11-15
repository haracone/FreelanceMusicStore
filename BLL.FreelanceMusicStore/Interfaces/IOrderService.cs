using BLL.FreelanceMusicStore.EntityDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IOrderService
    {
        List<OrderDTO> GetAll();
        Task CreateOrder(OrderDTO orderDTO);
        void UpdateOrder(OrderDTO orderDTO);
    }
}
