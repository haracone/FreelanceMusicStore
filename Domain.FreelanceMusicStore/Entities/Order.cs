using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.FreelanceMusicStore.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Client")]
        public Guid ClientId;
        [ForeignKey("Musician")]
        public int? MusicianId;
        public string MusicDescription { get; set; }
        public decimal? Price { get; set; }
        public Guid MusicInstrumentId { get; set; }

        public virtual MusicInstrument MusicInstrument { get; set; }
        public virtual Client Client { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
