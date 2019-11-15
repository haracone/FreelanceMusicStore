using System;
using System.Collections.Generic;

namespace BLL.FreelanceMusicStore.EntityDTO
{
    public class MusicianDTO
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public ApplicationUserDTO ApplicationUserDTO { get; set; }
        public ICollection<MusicInstrumentDTO> MusicInstrumentDTO { get; set; }
        public ICollection<OrderDTO> OrdersDTO { get; set; }
    }
}
