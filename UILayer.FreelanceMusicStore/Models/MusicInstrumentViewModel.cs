using System;
using System.Collections.Generic;

namespace TestProject.Models {
    public class MusicInstrumentViewModel {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<MusicianViewModel> musicianViewModels { get; set; }
    }
}