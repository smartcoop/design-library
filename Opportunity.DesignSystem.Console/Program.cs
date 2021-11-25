using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using Opportunity.DesignSystem.Console.Models;
using Opportunity.DesignSystem.Console.Models.Validations;
using Opportunity.DesignSystem.Console.Options;
using Opportunity.DesignSystem.Console.UseCases;
using Smart.Design.Razor.TagHelpers.Html;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Opportunity.DesignSystem.Console
{
    /// <summary>
    ///     CLI for generating html code from custom tag helpers
    /// </summary>
    public class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            CommandResponse result = Parser.Default.ParseArguments<ListOptions, GenerateOptions>(args)
                .MapResult(
                    (ListOptions optionArguments) =>
                    {
                        var listingUseCase = new ListingUseCase(optionArguments);
                        return listingUseCase.Run();
                    },
                    (GenerateOptions optionArgument) =>
                    {
                        var validator = new GenerateOptionsValidator();
                        var validationModel = validator.Validate(optionArgument);
                        CommandResponse commandResponse = new();
                        if (!validationModel.IsValid)
                        {
                            validationModel.Errors.ForEach(error =>
                                commandResponse.AddError(new ValidationException(error.ErrorMessage)));
                            return commandResponse;
                        }
                        var useCase = new GenerateUseCase(optionArgument);
                        return useCase.Run();
                    }, HandleParseError);

            logger.Info(result.GetResponseMessage());
            return host.RunAsync();
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

        private static CommandResponse HandleParseError(IEnumerable<Error> errors)
        {
            CommandResponse commandResponse = new();
            errors.ToList().ForEach(error =>
                commandResponse.AddError(new Exception(error.ToString())));
            return commandResponse;
        }
    }
}
