using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using FluentValidation;
using Smart.Design.HtmlGenerator.CommandOptions;
using Smart.Design.HtmlGenerator.Models;
using Smart.Design.HtmlGenerator.Models.Validations;
using Smart.Design.HtmlGenerator.UseCases;

namespace Smart.Design.HtmlGenerator;

public class CommandLineParser
{
    private readonly string[] _args;

    public CommandLineParser(string[] _args)
    {
        this._args = _args;
    }

    public CommandResponse Run()
    {
        var result = Parser.Default.ParseArguments<ListingOptions, GenerateOptions>(_args)
            .MapResult(
                (ListingOptions listOptions) => ListComponentsByCategory(listOptions),
                (GenerateOptions generateOptions) => GeneratePlainHtml(generateOptions), HandleParseError);
        return result;
    }

    private CommandResponse GeneratePlainHtml(GenerateOptions generateOptions)
    {
        var validator = new GenerateOptionsValidator();
        var validationModel = validator.Validate(generateOptions);
        if (!validationModel.IsValid)
        {
            CommandResponse commandResponse = new();
            validationModel.Errors.ForEach(error =>
                commandResponse.AddError(new ValidationException(error.ErrorMessage)));
            return commandResponse;
        }

        var useCase = new GenerateUseCase(generateOptions);
        return useCase.Run();
    }

    private CommandResponse ListComponentsByCategory(ListingOptions listingOptions)
    {
        var listingUseCase = new ListingUseCase(listingOptions);
        return listingUseCase.Run();
    }

    private static CommandResponse HandleParseError(IEnumerable<Error> errors)
    {
        CommandResponse commandResponse = new();
        errors.ToList().ForEach(error =>
            commandResponse.AddError(new Exception(error.ToString())));
        return commandResponse;
    }
}
