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

        public int Id { get; set; }
        public int ClientId;
        public int? MusicianId;
        [Required]
        [Display(Name = "Music's description")]
        public string MusicDescription { get; set; }
        public decimal? Price { get; set; }
        [Required]
        [Display(Name = "Music Instrument")]
        public virtual int MusicInstrumentId { get; set; }
        public virtual IEnumerable<MusicInstrumentViewModel> MusicInstrumentViewModel { get; set; }
        public virtual ClientViewModel ClientViewModel { get; set; }
        public virtual MusicianViewModel MusicianViewModel { get; set; }
    }
}