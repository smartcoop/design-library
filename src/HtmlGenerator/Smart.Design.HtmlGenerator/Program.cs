using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Smart.Design.HtmlGenerator;
using Smart.Design.HtmlGenerator.Managers;
using Smart.Design.Razor.Extensions;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;


var host = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices(serviceCollection =>
    {
        serviceCollection
            .AddSmartDesign()
            .AddTransient<IComponentDiscoverer, ComponentDiscoverer>()
            .AddLogging(loggingBuilder =>
            {
                loggingBuilder
                    .ClearProviders()
                    .SetMinimumLevel(LogLevel.Debug)
                    .AddNLog("nlog.config");
            })
            .AddRazorTemplating();
    }).Build();
CommandLineParser commandLineParser = new(args);
var commandResponse = commandLineParser.Run();

System.Console.WriteLine(commandResponse.GetResponseMessage());
host.Run();

