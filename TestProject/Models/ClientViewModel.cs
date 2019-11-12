using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;

namespace TestProject.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public virtual ApplicationUserViewModel ApplicationUserViewModel { get; set; }
        public virtual ICollection<OrderViewModel> OrdersViewModel { get; set; }

        public ClientViewModel ConvertDTOTOViewModel(ClientDTO instrument)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ClientDTO, ClientViewModel>(); });

            IMapper iMapper = config.CreateMapper();
            var source = instrument;
            var viewModel = iMapper.Map<ClientDTO, ClientViewModel>(source);

            return viewModel;
        }
    }
}