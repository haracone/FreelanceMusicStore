using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;

namespace TestProject.Models
{
    public class MusicianViewModel
    {
        public Guid Id { get; set; }
        public Guid Guid { get; set; }
        public ApplicationUserViewModel ApplicationUserViewModel { get; set; }
        public ICollection<MusicInstrumentViewModel> MusicInstrumentViewModel { get; set; }
        public ICollection<OrderViewModel> OrdersViewModel { get; set; }
    }
}