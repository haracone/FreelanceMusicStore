using System;
using System.Collections.Generic;

namespace TestProject.Models {
    public class MusicInstrumentForDropdown {
        public IEnumerable<MusicInstrumentViewModel> MusicInstuments { get; set; }
        public Guid MusicInstrumentId { get; set; }
    }
}