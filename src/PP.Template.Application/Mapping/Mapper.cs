using PP.Template.Messages.Example.Commands.Example;

namespace PP.Template.Application.Mapping
{

    public static class Mapping
    {
        public static IMapper Mapper { get; set; }
        static Mapping()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddNewExampleCommand, ExampleEntity>();
            });

            Mapper = configuration.CreateMapper();
        }

        public static ExampleEntity MapToEntity(this AddNewExampleCommand model) => Mapper.Map<ExampleEntity>(model);
    }
}
