using System;
using System.Collections.Generic;

namespace TestProject.Models {
    public class MusicianViewModel {
        public Guid Id { get; set; }
        public Guid Guid { get; set; }
        public ApplicationUserViewModel ApplicationUserViewModel { get; set; }
        public ICollection<MusicInstrumentViewModel> MusicInstrumentViewModel { get; set; }
        public ICollection<OrderViewModel> OrdersViewModel { get; set; }
    }
}