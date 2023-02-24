using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smart.Design.Console.Generator;


var hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        hostContext.Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        services.AddSingleton<SmartPanelGenerator>();
        services.Configure<Settings>(hostContext.Configuration.GetSection(Settings.Section));
    })
    .Start();

var generator = hostBuilder.Services.GetRequiredService<SmartPanelGenerator>();
generator.Generate();
