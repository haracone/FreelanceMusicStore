using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.FreelanceMusicStore.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Client")]
        public int ClientId;
        [ForeignKey("Musician")]
        public int? MusicianId;
        public string MusicDescription;

        public virtual MusicInstrument MusicInstrument { get; set; }
        public virtual Client Client { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
