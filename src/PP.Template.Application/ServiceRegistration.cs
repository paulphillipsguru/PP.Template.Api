namespace PP.Template.Application;
public static class ServiceRegistration
{
    public static void RegisterTemplateApplication(this IServiceCollection services) {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly, typeof(ITemplateMarker).Assembly);
        });
    }
}
