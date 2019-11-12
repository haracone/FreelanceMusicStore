using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;

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
            MusicInstrumentViewModel musicInstrument = new MusicInstrumentViewModel();
            _musicInstrumentService = musicInstrumentService;
            var instruments = musicInstrumentService.GetAll();
            ICollection<MusicInstrumentViewModel> entity = new List<MusicInstrumentViewModel>();
            foreach (var instrument in instruments)
                entity.Add(musicInstrument.ConvertDTOTOViewModel(instrument));
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
        public string MusicInstrumentName { get; set; }

        public virtual IEnumerable<MusicInstrumentViewModel> MusicInstrumentViewModel { get; set; }
        public virtual ClientViewModel ClientViewModel { get; set; }
        public virtual MusicianViewModel MusicianViewModel { get; set; }

        public OrderViewModel ConvertDTOTOViewModel(OrderDTO instrument)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<OrderDTO, OrderViewModel>(); });

            IMapper iMapper = config.CreateMapper();
            var source = instrument;
            var viewModel = iMapper.Map<OrderDTO, OrderViewModel>(source);

            return viewModel;
        }
    }
}