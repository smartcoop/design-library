using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Razor.TagHelpers.ValidationMessage;

/// <summary>
/// Contract for a services that services HTML to render a Smart Design validation message.
/// </summary>
public interface IValidationMessageHtmlGenerator
{
    /// <summary>
    /// Generates Smart Design error messages from the ModelState where the key is identified by the name of a <see cref="ModelExpression"/>.
    /// </summary>
    /// <param name="viewContext">The <see cref="ViewContext"/> instance for the current scope.</param>
    /// <param name="for">The <see cref="ModelExpression"/> associated to the model to be validated.</param>
    /// <returns>HTML of the error messages as a instance of <see cref="IHtmlContent"/>.
    /// However is no errors are found then <c>null</c> is returned.</returns>
    public IHtmlContent? GenerateValidationMessage(ViewContext viewContext, ModelExpression? @for);
}
