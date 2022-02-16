using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Smart.Design.Razor.TagHelpers.ValidationMessage;

/// <summary>
/// Renders every validation error messages for a given <see cref="ModelExpression"/> from the <c>ModelState</c>.
/// The generated HTML uses the style of the Smart Design.
/// See documentation <see href="https://design.smart.coop/development/docs/o-form-group.html#component-05-o-form-validation">here</see> for more information.
/// If there no error messages found, the tag will not be rendered.
/// </summary>
[HtmlTargetElement(TagNames.ValidationMessageTagName)]
public class ValidationMessageTagHelper : TagHelper
{
    private const string ForAttributeName = "asp-for";

    private readonly IValidationMessageHtmlGenerator _validationMessageHtmlGenerator;

    [HtmlAttributeName(ForAttributeName)]
    public ModelExpression? For { get; set; }

    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext? ViewContext { get; set; }

    public ValidationMessageTagHelper(IValidationMessageHtmlGenerator validationMessageHtmlGenerator)
    {
        _validationMessageHtmlGenerator = validationMessageHtmlGenerator;
    }

    public override void Init(TagHelperContext context)
    {
        if (ViewContext is null)
        {
            throw new InvalidOperationException($"ViewContext cannot be null");
        }

        if (For?.Name is null)
        {
            throw new InvalidOperationException($"{ForAttributeName} must be set to use the {TagNames.ValidationMessageTagName} component.");
        }
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // Doing so will render nothing.
        // That way only errors will be rendered in the HTML page.
        output.SuppressOutput();
        var errors = _validationMessageHtmlGenerator.GenerateValidationMessage(ViewContext!, For);

        if (errors is not null)
        {
            output.Content.SetHtmlContent(errors);
        }
    }
}
