using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Panel;

public interface IPanelHtmlGenerator
{
    /// <summary>
    /// Generate a &lt;div&gt; that represents a panel and is compliant with Smart design.
    /// A panel is composed of two things: a header and a body.
    /// </summary>
    /// <param name="header">The header of the panel.</param>
    /// <param name="body">The content of the panel. This can be any html.</param>
    /// <returns>A instance of a &lt;div&gt; that represents a panel.</returns>
    TagBuilder GeneratePanel(string? header, IHtmlContent body);
}
