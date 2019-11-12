using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.EntityDTO
{ 
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClientId;
        public int? MusicianId;
        public string MusicDescription;
        public decimal? Price { get; set; }
        public virtual MusicInstrumentDTO MusicInstrumentDTO { get; set; }
        public virtual ClientDTO ClientDTO { get; set; }
        public virtual MusicianDTO MusicianDTO { get; set; }
    }
}
