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
        IMusicInstrumentService _musicInstrumentService;
        public OrderViewModel()
        {
        }

        public OrderViewModel(IMusicInstrumentService musicInstrumentService)
        {
            _musicInstrumentService = musicInstrumentService;
            var instruments = musicInstrumentService.GetAll();
            ICollection<MusicInstrumentViewModel> entity = new List<MusicInstrumentViewModel>();
            foreach (var instrument in instruments)
                entity.Add(PropertiesConvert<MusicInstrumentDTO, MusicInstrumentViewModel>.AllPropertiesConvert(instrument));
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
        public virtual string MusicInstrumentName { get; set; }
        public virtual IEnumerable<MusicInstrumentViewModel> MusicInstrumentViewModel { get; set; }
        public virtual ClientViewModel ClientViewModel { get; set; }
        public virtual MusicianViewModel MusicianViewModel { get; set; }
    }
}