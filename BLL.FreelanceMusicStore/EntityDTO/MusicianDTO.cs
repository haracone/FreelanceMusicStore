using System;
using System.Collections.Generic;
using System.Web;

namespace BLL.FreelanceMusicStore.EntityDTO
{
    public class MusicianDTO
    {
        public Guid Id { get; set; }
        public Guid Guid { get; set; }

        public HttpPostedFileBase PostedFile { get; set; }
        public ApplicationUserDTO ApplicationUserDTO { get; set; }
        public ICollection<MusicInstrumentDTO> MusicInstrumentDTO { get; set; }
        public ICollection<OrderDTO> OrdersDTO { get; set; }
    }
}
