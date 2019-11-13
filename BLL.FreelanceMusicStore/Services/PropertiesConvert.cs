using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.FreelanceMusicStore.Interfaces;

namespace BLL.FreelanceMusicStore.Services
{
    public class PropertiesConvert<From, To>
    {
        public static To AllPropertiesConvert(From entity)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<From, To>(); });

            IMapper iMapper = config.CreateMapper();
            var source = entity;
            var newEntity = iMapper.Map<From, To>(source);

            return newEntity;
        }
    }
}
