using PP.Common.Testing;

namespace PP.Template.Api.IntegrationTests.Fixtures;

public class CustomFixture : IAsyncLifetime
{
    const string ConnectionStringName = "PP.Template.Api:ConnectionString";
    public DatabaseFixture Database { get; set; } = new();
    public ApiIntegrationFactory Factory { get; set; } = new();
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
