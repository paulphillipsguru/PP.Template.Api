namespace PP.Template.Api;
public static class ServiceRegistration
{
    public static void UseTemplate(this WebApplication app)
    {
        app.MapGet("/", async (IMediator mediator) => {
            var result = await mediator.Send(new ExampleQuery() { Id =1 });
            return Results.Ok(result);
        });
    }
}
