using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IOrderService
    {
        IQueryable<OrderDTO> GetAll();
        void CreateOrder(OrderDTO orderDTO);
    }
}
