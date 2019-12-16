using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.FreelanceMusicStore.Entities {
    public class Order {
        public Guid Id { get; set; }
        public string MusicDescription { get; set; }
        public decimal? Price { get; set; }

        public Guid ClientId { get; set; }
        [ForeignKey("Musician")]
        public Guid? MusicianId { get; set; }
        [ForeignKey("MusicInstrument")]
        public Guid MusicInstrumentId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Musician Musician { get; set; }
        public virtual MusicInstrument MusicInstrument { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
