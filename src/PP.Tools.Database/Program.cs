using Microsoft.Extensions.Hosting;
using PP.Tools.Database;

var builder = Host.CreateDefaultBuilder(args);
string  action = "up";
long version = 0;
if (args.Length >=2)
{
    action = args[0].ToLower();
    if (action == "down")
    {
        version = Convert.ToInt32(args[1]);
    }
}

builder.ConfigureServices((context, services) =>
{
    if (action == "up")
    {
        services.AddMigrationService(context.Configuration).Up();
    }
    else
    {
        services.AddMigrationService(context.Configuration).Down(version);

    }
    
});

var app = builder.Build();

app.Start();
