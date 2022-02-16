using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.ValidationMessage;

public class ValidationMessageHtmlHtmlGenerator : IValidationMessageHtmlGenerator
{
    public IHtmlContent? GenerateValidationMessage(ViewContext viewContext, ModelExpression? @for)
    {
        if (@for?.Name is null)
            return default;

        var container = new TagBuilder("div");

        var errors = viewContext.GetModelErrorsByKey(@for.Name);

        if (errors.Count <= 0)
            return default;

        foreach (var error in errors)
        {
            var divError = new TagBuilder("div");
            divError.AddCssClass("c-form-help-text");
            divError.AddCssClass("c-form-help-text--error");
            divError.InnerHtml.Append(error.ErrorMessage);

            container.InnerHtml.AppendHtml(divError);
        }

        return container.InnerHtml;
    }
}
