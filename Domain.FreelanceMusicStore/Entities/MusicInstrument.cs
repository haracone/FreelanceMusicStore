using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.FreelanceMusicStore.Entities {
    public class MusicInstrument {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Musician> Musicians { get; set; }
    }
}
