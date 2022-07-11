using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.ValidationMessage;

/// <summary>
/// Generates HTML for Smart Design validation messages.
/// </summary>
public class ValidationMessageHtmlGenerator : IValidationMessageHtmlGenerator
{
    /// <inheritdoc cref="IValidationMessageHtmlGenerator" />
    public IHtmlContent? GenerateValidationMessage(ViewContext viewContext, ModelExpression? @for)
    {
        if (@for?.Name is null)
        {
            return default;
        }

        var container = new TagBuilder("div");

        var errors = viewContext.GetModelErrorsByKey(@for.Name);

        if (errors.Count <= 0)
        {
            return default;
        }

        foreach (var error in errors)
        {
            container.InnerHtml.AppendHtml(NewErrorDiv(error));
        }

        return container.InnerHtml;
    }

    private static TagBuilder NewErrorDiv(ModelError error)
    {
        var divError = new TagBuilder("div");
        divError.AddCssClass("c-form-help-text");
        divError.AddCssClass("c-form-help-text--error");
        divError.InnerHtml.Append(error.ErrorMessage);

        return divError;
    }
}
