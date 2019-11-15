using System;
using System.Collections.Generic;

namespace BLL.FreelanceMusicStore.EntityDTO
{
    public class ClientDTO
    {
        public Guid Id { get; set; }
        public Guid Guid { get; set; }

        public ApplicationUserDTO ApplicationUserDTO { get; set; }
        public ICollection<OrderDTO> OrdersDTO { get; set; }
    }
}
