using PP.Template.Application.Mapping;
using PP.Template.Messages.Example.Commands.Example;

namespace PP.Template.Application.UseCases.Example.Commands
{
    internal class AddNewExampleHandler(IApplicationDbContext dbContext) : IRequestHandler<AddNewExampleCommand, long>
    {
        public async Task<long> Handle(AddNewExampleCommand request, CancellationToken cancellationToken)
        {
            var entity = request.MapToEntity();
            var result = await dbContext.Example.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            
            return entity.Id;
        }
    }
}
