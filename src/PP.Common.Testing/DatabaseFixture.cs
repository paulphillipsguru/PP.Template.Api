using Testcontainers.MsSql;
namespace PP.Common.Testing;

public class DatabaseFixture : IAsyncDisposable
{
    private readonly MsSqlContainer container = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-CU14-ubuntu-22.04")
        .WithName($"PP.IntegrationTests-{Guid.NewGuid()}")
        .WithPassword("Password123")
        .WithPortBinding(1433,true)
        .WithAutoRemove(true)
        .Build();
    
    public string? ConnectionString { get; private set; }

    public async Task InitializeAsync()
    {
        await container.StartAsync();
        ConnectionString = container.GetConnectionString();
    }

    public async ValueTask DisposeAsync()
    {
        await container.StopAsync();
        await container.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}
