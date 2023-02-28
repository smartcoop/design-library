using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Form;

public interface IFormHtmlGenerator
{
    /// <summary>
    /// Generate a &lt;form&gt; compliant with Smart design.
    /// </summary>
    /// <param name="id">The id of the &lt;form&gt;</param>
    /// <param name="layout">The layout to be applied.</param>
    /// <param name="content">The HTML content inside the &lt;form&gt;</param>
    /// <param name="method">The HTTP <see cref="FormMethod"/> to submit the form with.</param>
    /// <returns>An instance of a form.</returns>
    TagBuilder GenerateForm(string? id, FormLayout layout, IHtmlContent content, FormMethod method = default);
}
