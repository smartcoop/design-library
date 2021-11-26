using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using Smart.Design.Razor.TagHelpers.Html;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Smart.Design.Console
{
    /// <summary>
    ///     CLI for generating html code from custom tag helpers
    /// </summary>
    public class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
            CommandLineParser commandLineParser = new(args);
            var commandResponse = commandLineParser.ExecuteCommandWithArguments();
            logger.Info(commandResponse.GetResponseMessage());
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(serviceCollection =>
                {
                    serviceCollection
                        .AddTransient<ISmartHtmlGenerator, SmartHtmlGenerator>()
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
}
