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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<MusicianViewModel> musicianViewModels { get; set; }
    }
}