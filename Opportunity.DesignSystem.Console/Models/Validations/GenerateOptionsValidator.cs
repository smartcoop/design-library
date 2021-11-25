// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Linq;
using FluentValidation;
using Opportunity.DesignSystem.Console.Options;

namespace Opportunity.DesignSystem.Console.Models.Validations
{
    public class GenerateOptionsValidator : AbstractValidator<GenerateOptions>
    {
        public GenerateOptionsValidator()
        {
            RuleFor(options => options.DesignElementName)
                .Must(elementName =>
                {
                    var customTagHelpersCollection = new CustomTagHelperCollections();
                    return customTagHelpersCollection.Names.Contains(elementName);
                })
                .WithMessage(errorMessage => "Can't find the name indicated among the existing components");
        }
    }
}
