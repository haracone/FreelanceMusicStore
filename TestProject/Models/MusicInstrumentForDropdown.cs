using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;

namespace TestProject.Models
{
    public class MusicInstrumentForDropdown
    {
        public IEnumerable<MusicInstrumentViewModel> MusicInstuments { get; set; }
        public Guid MusicInstrumentId { get; set; }
    }
}