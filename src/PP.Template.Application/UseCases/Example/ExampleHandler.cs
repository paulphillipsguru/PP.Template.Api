namespace PP.Template.Application.UseCases.Example;
public class ExampleHandler(IApplicationDbContext dbContext) : IRequestHandler<ExampleQuery, ExampleResponse>
{
    public async Task<ExampleResponse> Handle(ExampleQuery request, CancellationToken cancellationToken)
    {
        var dummyRecord = dbContext.Example.First();

        return await Task.FromResult(new ExampleResponse() { Id = dummyRecord.Id, Name = dummyRecord.Name });
    }
}
