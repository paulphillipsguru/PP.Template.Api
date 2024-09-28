namespace PP.Template.Application.UseCases.Example.Queries;
public class GetFirstExampleHandler(IApplicationDbContext dbContext) : IRequestHandler<ExampleQuery, ExampleResponse>
{
    public async Task<ExampleResponse> Handle(ExampleQuery request, CancellationToken cancellationToken)
    {
        var dummyRecord = dbContext.Example.First();

        return await Task.FromResult(new ExampleResponse() { Id = dummyRecord.Id, Name = dummyRecord.Name });
    }
}
