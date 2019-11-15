using System;

namespace BLL.FreelanceMusicStore.EntityDTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public Guid ClientId;
        public int? MusicianId;
        public string MusicDescription;
        public Guid MusicInstrumentId { get; set; }
        public decimal? Price { get; set; }
        public MusicInstrumentDTO MusicInstrument{ get; set; }
        public ClientDTO Client{ get; set; }
        public MusicianDTO Musician { get; set; }
    }
}
