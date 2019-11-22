using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using TestProject.Models;
using System.Linq;

namespace TestProject.Mapper
{
    public class DTOToViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DTOToViewModelProfile"; }
        }

        public DTOToViewModelProfile()
        {
            CreateMap<ClientDTO, ClientViewModel>();
            CreateMap<MusicianDTO, MusicianViewModel>();
            CreateMap<MusicInstrumentDTO, MusicInstrumentViewModel>();
            CreateMap<OrderDTO, OrderViewModel>();
            CreateMap<CommentDTO, CommentViewModel>();
        }
    }
}