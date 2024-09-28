using Microsoft.AspNetCore.Mvc.Testing;
using PP.Common.Testing;


namespace PP.Template.Api.IntegrationTests
{
    public class CustomAppFactory : IClassFixture<WebApplicationFactory<IPPTemplateApiMarker>>, IAsyncLifetime
    {
        const string ConnectionStringName = "PP.Template.Api:ConnectionString";
        public DatabaseFixture Database { get; set; } = new();

        public async Task InitializeAsync()
        {
            await Database.InitializeAsync();
            Environment.SetEnvironmentVariable(ConnectionStringName, Database.ConnectionString);
        }

        public async Task DisposeAsync()
        {
            await Database.DisposeAsync();
        }
    }
}
