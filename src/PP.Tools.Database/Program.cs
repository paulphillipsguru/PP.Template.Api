using Microsoft.Extensions.Hosting;
using PP.Tools.Database;
using PP.Template.Infrastructure.Database;

var builder = Host.CreateDefaultBuilder(args);
string  action = Actions.Up;
long version = 0;
if (args.Length >=2)
{
    action = args[0].ToLower();
    if (action == Actions.Down)
    {
        if (!long.TryParse(args[1], out version))
        {
            Console.WriteLine($"Invalid argument, when using {Actions.Down} command, must supply a valid version number.");
            Environment.Exit(-1);
        }
    }
}

builder.ConfigureServices((context, services) =>
{
    if (action == Actions.Up)
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
