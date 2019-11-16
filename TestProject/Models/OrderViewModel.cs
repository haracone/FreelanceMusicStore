using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using BLL.FreelanceMusicStore.Services;

namespace TestProject.Models
{
    public class OrderViewModel
    {
        private IMusicInstrumentService _musicInstrumentService;
        private IMapper _mapper;
        public OrderViewModel()
        {
            Id = Guid.NewGuid();
        }

        public OrderViewModel(IMusicInstrumentService musicInstrumentService, IMapper mapper)
        {
            _mapper = mapper;
            _musicInstrumentService = musicInstrumentService;
            var instruments = musicInstrumentService.GetAll();
            ICollection<MusicInstrumentViewModel> entity = new List<MusicInstrumentViewModel>();
            foreach (var instrument in instruments)
                entity.Add(_mapper.Map<MusicInstrumentDTO, MusicInstrumentViewModel>(instrument));
            MusicInstrumentViewModel = entity;
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid? MusicianId { get; set; }
        [Required]
        [Display(Name = "Music's description")]
        public string MusicDescription { get; set; }
        public decimal? Price { get; set; }
        [Required]
        [Display(Name = "Music Instrument")]
        public Guid MusicInstrumentId { get; set; }
        public MusicInstrumentViewModel MusicInstrument{ get; set; }
        public IEnumerable<MusicInstrumentViewModel> MusicInstrumentViewModel { get; set; }
        public ClientViewModel Client{ get; set; }
        public MusicianViewModel Musician{ get; set; }
    }
}