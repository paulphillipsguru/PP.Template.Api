using PP.Template.Api.Models.Example;
using PP.Template.Messages.Example.Commands.Example;

namespace PP.Template.Api.Mapping
{
    public static class Mapping
    {
        public static IMapper Mapper { get; set; }
        static Mapping()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewExampleModel, AddNewExampleCommand>();
            });

            Mapper = configuration.CreateMapper();
        }

        public static AddNewExampleCommand MapToCommand(this NewExampleModel model) => Mapper.Map<AddNewExampleCommand>(model);
    }
}
