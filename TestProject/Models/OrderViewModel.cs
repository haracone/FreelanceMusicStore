using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;

namespace TestProject.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ClientId;
        public int? MusicianId;
        public string MusicDescription;

        public virtual MusicInstrumentViewModel MusicInstrumentViewModel { get; set; }
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