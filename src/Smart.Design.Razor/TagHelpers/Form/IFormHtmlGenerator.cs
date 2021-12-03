using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Form;

public interface IFormHtmlGenerator
{
    /// <summary>
    /// Generate a &lt;form&gt; compliant with Smart design.
    /// </summary>
    /// <param name="layout">The layout to be applied.</param>
    /// <param name="content"></param>
    /// <returns>An instance of a form.</returns>
    TagBuilder GenerateForm(FormLayout layout, IHtmlContent content);
}
