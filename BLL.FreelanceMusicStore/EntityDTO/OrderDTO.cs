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
        public virtual MusicInstrumentDTO MusicInstrument{ get; set; }
        public ClientDTO Client{ get; set; }
        public MusicianDTO Musician { get; set; }
    }
}
