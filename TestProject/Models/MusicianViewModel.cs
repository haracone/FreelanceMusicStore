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
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public virtual ApplicationUserViewModel ApplicationUserViewModel { get; set; }
        public virtual ICollection<MusicInstrumentViewModel> MusicInstrumentViewModel { get; set; }
        public virtual ICollection<OrderViewModel> OrdersViewModel { get; set; }
    }
}