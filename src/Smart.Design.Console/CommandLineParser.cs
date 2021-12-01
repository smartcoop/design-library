// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using FluentValidation;
using Smart.Design.Console.CommandOptions;
using Smart.Design.Console.Models;
using Smart.Design.Console.Models.Validations;
using Smart.Design.Console.UseCases;

namespace Smart.Design.Console
{
    public class CommandLineParser
    {
        private readonly string[] _args;

        public CommandLineParser(string[] _args)
        {
            this._args = _args;
        }

        public CommandResponse ExecuteCommandWithArguments()
        {
            CommandResponse result = Parser.Default.ParseArguments<ListingOptions, GenerateOptions>(_args)
                .MapResult(
                    (ListingOptions listOptions) => ListComponentsFromArguments(listOptions),
                    (GenerateOptions generateOptions) => GeneratePlainHtmlFromArguments(generateOptions), HandleParseError);
            return result;
        }

        private  CommandResponse GeneratePlainHtmlFromArguments(GenerateOptions generateOptions)
        {
            var validator = new GenerateOptionsValidator();
            var validationModel = validator.Validate(generateOptions);
            CommandResponse commandResponse = new();
            if (!validationModel.IsValid)
            {
                validationModel.Errors.ForEach(error =>
                    commandResponse.AddError(new ValidationException(error.ErrorMessage)));
                return commandResponse;
            }

            var useCase = new GenerateUseCase(generateOptions);
            return useCase.Run();
        }

        private  CommandResponse ListComponentsFromArguments(ListingOptions listingOptions)
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
}
