using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Smart.Application.Console.Options;
using Smart.Application.Console.UseCases;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Application.Console
{
    /// <summary>
    ///     CLI for generating html code from custom tag helpers
    /// </summary>
    public class Program
    {
        private static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            var result = Parser.Default.ParseArguments<ListOptions, GenerateOptions>(args)
                .WithNotParsed(HandleParseError)
                .WithParsed(options => System.Console.WriteLine("Ok"))
                .MapResult(
                    (ListOptions opts) =>
                    {
                        var useCase = new ListingUseCase(opts);
                        return useCase.Run();
                    },
                    (GenerateOptions opts) =>
                    {
                        var useCase = new GenerateUseCase(opts);
                        return useCase.Run();
                    }, errs => "Can't parse options");
            System.Console.WriteLine(result);
            System.Console.ReadLine();

            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<ISmartHtmlGenerator, SmartHtmlGenerator>()
                        .AddLogging(configure => configure.AddConsole())
                        .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Critical)
                        .AddRazorTemplating());
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            errs.ToList().ForEach(error =>
                System.Console.WriteLine(
                    $"{error.Tag} has {(error.StopsProcessing ? "stopped processing of the app" : "been ignored")}"));
        }
    }
}
