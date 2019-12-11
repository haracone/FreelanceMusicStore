using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using DAL.FreelanceMusicStore.Identity;
using Domain.FreelanceMusicStore.Entities;

namespace TestProject.Mapper {
    public class DTOToEntityProfile : Profile {
        public override string ProfileName {
            get { return "DTOToEntityProfile"; }
        }

        public DTOToEntityProfile() {
            CreateMap<ClientDTO, Client>();
            CreateMap<MusicianDTO, Musician>();
            CreateMap<MusicInstrumentDTO, MusicInstrument>();
            CreateMap<OrderDTO, Order>();
            CreateMap<ApplicationUserDTO, ApplicationUser>();
            CreateMap<CommentDTO, Comment>();
            CreateMap<CustomRoleDTO, CustomRole>();
        }
    }
}
