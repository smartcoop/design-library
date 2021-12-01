using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Smart.Design.HtmlGenerator.Managers;
using Smart.Design.Razor.Extensions;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
namespace Smart.Design.HtmlGenerator;

/// <summary>
///CLI for generating HTML code from custom tag helpers
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        CommandLineParser commandLineParser = new(args);
        var commandResponse = commandLineParser.Run();

        System.Console.WriteLine(commandResponse.GetResponseMessage());
        host.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
        => Host
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
            });
}
