﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.EntityDTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public virtual ApplicationUserDTO ApplicationUserDTO { get; set; }
        public virtual ICollection<OrderDTO> OrdersDTO { get; set; }
    }
}
