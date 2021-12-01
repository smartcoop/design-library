using System.Linq;
using FluentValidation;
using Smart.Design.HtmlGenerator.CommandOptions;
using Smart.Design.RazorView;

namespace Smart.Design.HtmlGenerator.Models.Validations;

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
            .WithMessage(errorMessage => "Can't find the name indicated among the existing design components");
    }
}
