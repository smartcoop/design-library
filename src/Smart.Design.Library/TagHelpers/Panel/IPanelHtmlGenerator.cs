using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Panel;

/// <summary>
/// Generates Smart Panel HTML.
/// </summary>
public interface IPanelHtmlGenerator
{
    /// <summary>
    /// Generate a &lt;div&gt; that represents a panel and is compliant with Smart design.
    /// A panel is composed of two things: a header and a body.
    /// The header is a string while the body is HTML.
    /// </summary>
    /// <param name="header">The header of the panel.</param>
    /// <param name="body">The content of the panel. This can be any HTML.</param>
    /// <returns>A instance of a &lt;div&gt; that represents a panel.</returns>
    TagBuilder GeneratePanel(string? header, IHtmlContent body);
}
