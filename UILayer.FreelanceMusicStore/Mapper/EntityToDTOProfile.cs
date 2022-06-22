﻿using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;

namespace TestProject.Mapper {
    public class EntityToDTOProfile : Profile {
        public override string ProfileName {
            get { return "EntityToDTOProfile"; }
        }

        public EntityToDTOProfile() {
            CreateMap<Client, ClientDTO>();
            CreateMap<Musician, MusicianDTO>();
            CreateMap<MusicInstrument, MusicInstrumentDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Comment, CommentDTO>();
        }
    }
}