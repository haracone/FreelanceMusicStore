﻿namespace BLL.FreelanceMusicStore.EntityDTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClientId;
        public int? MusicianId;
        public string MusicDescription;
        public int MusicInstrumentId { get; set; }
        public decimal? Price { get; set; }
        public MusicInstrumentDTO MusicInstrument{ get; set; }
        public ClientDTO Client{ get; set; }
        public MusicianDTO Musician { get; set; }
    }
}
