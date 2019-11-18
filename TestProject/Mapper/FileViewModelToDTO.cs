using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Files.FreelanceMusicStore.Models;
using BLL.FreelanceMusicStore.EntityDTO;

namespace TestProject.Mapper
{
    public class FileViewModelToDTO : Profile
    {
        public override string ProfileName
        {
            get { return "FileViewModelToDTO"; }
        }

        public FileViewModelToDTO()
        {
            CreateMap<FileViewModel, FileDTO>();
        }
    }
}