using System;
using System.Collections.Generic;

namespace BLL.FreelanceMusicStore.EntityDTO {
    public class MusicInstrumentDTO {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<MusicianDTO> MusiciansDTO { get; set; }
    }
}
