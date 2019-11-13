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
    public class EntityToDTOProfile : Profile
    {
        public override string ProfileName
        {
            get { return "EntityToDTOProfile"; }
        }

        public EntityToDTOProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<Musician, MusicianDTO>();
            CreateMap<MusicInstrument, MusicInstrumentDTO>();
            CreateMap<Order, OrderDTO>();
        }
    }
}
