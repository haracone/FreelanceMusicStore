using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.FreelanceMusicStore.EntityDTO;
using TestProject.Models;

namespace TestProject.Mapper
{
    public class ViewModelToDTOProfile : Profile
    {
        public override string ProfileName
        {
            get {return "ViewModelToDTOProfile"; }
        }

        public ViewModelToDTOProfile()
        {
            CreateMap<ClientViewModel, ClientDTO>();
            CreateMap<MusicianViewModel, MusicianDTO>();
            CreateMap<MusicInstrumentViewModel, MusicInstrumentDTO>();
            CreateMap<OrderViewModel, OrderDTO>();
            CreateMap<FileViewModel, FileDTO>();
            CreateMap<CommentViewModel, CommentDTO>();
            CreateMap<CustomRoleViewModel, CustomRoleDTO>();
        }
    }
}