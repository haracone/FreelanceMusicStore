using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;

namespace TestProject.Mapper
{
    public class DTOToEntityProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DTOToEntityProfile"; }
        }

        public DTOToEntityProfile()
        {
            CreateMap<ClientDTO, Client>();
            CreateMap<MusicianDTO, Musician>();
            CreateMap<MusicInstrumentDTO, MusicInstrument>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
