using AutoMapper;

namespace TestProject.Mapper {
    public class AutoMapperConfiguration {
        static MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.AddProfile<ViewModelToDTOProfile>();
            cfg.AddProfile<DTOToEntityProfile>();
            cfg.AddProfile<EntityToDTOProfile>();
            cfg.AddProfile<DTOToViewModelProfile>();
        });

        public static IMapper mapper = config.CreateMapper();

        public AutoMapperConfiguration() {
            config.AssertConfigurationIsValid();
        }
    }
}