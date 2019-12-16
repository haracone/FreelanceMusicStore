using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TestProject.Models {
    public class OrderViewModel {
        public OrderViewModel() {
            Id = Guid.NewGuid();
        }

        public OrderViewModel(IEnumerable<MusicInstrumentViewModel> entity) {

            MusicInstrumentViewModel = entity;
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid? MusicianId { get; set; }
        [Required]
        [Display(Name = "Description of the music")]
        public string MusicDescription { get; set; }
        public decimal? Price { get; set; }
        [Required]
        [Display(Name = "Music Instrument")]
        public Guid MusicInstrumentId { get; set; }
        public MusicInstrumentViewModel MusicInstrument { get; set; }
        public IEnumerable<MusicInstrumentViewModel> MusicInstrumentViewModel { get; set; }
        public ClientViewModel Client { get; set; }
        public MusicianViewModel Musician { get; set; }
    }
}