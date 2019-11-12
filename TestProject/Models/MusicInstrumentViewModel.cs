using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;

namespace TestProject.Models
{
    public class MusicInstrumentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MusicInstrumentViewModel ConvertDTOTOViewModel(MusicInstrumentDTO instrument)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<MusicInstrumentDTO, MusicInstrumentViewModel>(); });

            IMapper iMapper = config.CreateMapper();
            var source = instrument;
            var viewModel = iMapper.Map<MusicInstrumentDTO, MusicInstrumentViewModel>(source);

            return viewModel;
        }
    }
}