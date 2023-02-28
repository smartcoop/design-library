using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Smart.Design.HtmlGenerator;
using Smart.Design.HtmlGenerator.Managers;
using Smart.Design.Library.Extensions;


Host
    .CreateDefaultBuilder(args)
    .ConfigureServices(serviceCollection =>
    {
        serviceCollection
            .AddHostedService(_ => new HostApplicationLifetimeEventsHostedService(args))
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
    })
    .Build()
    .RunAsync();
