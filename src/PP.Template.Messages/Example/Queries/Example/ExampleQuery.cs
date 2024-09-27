using MediatR;

namespace PP.Template.Messages.Example.Queries.Example
{
    public record ExampleQuery() : IRequest<ExampleResponse>
    {
        public required int Id { get; set; }
    }
}
