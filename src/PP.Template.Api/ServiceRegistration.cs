using PP.Template.Api.Models.Example;

namespace PP.Template.Api;
public static class ServiceRegistration
{
    public static void UseTemplate(this WebApplication app)
    {
        app.MapPost("/Example", async (IMediator mediator, NewExampleModel newExampleModel) => {
            var command = newExampleModel.MapToCommand();
            var result = await mediator.Send(command);
            return result;
        });

        app.MapGet("/Example", async (IMediator mediator) => {
            var result = await mediator.Send(new ExampleQuery() { Id =1 });
            return Results.Ok(result);
        });
    }
}
