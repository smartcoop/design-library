using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Citation;

/// <summary>
/// Generate citation component.
/// </summary
public interface ICitationHtmlGenerator
{
    /// <summary>
    /// Generates a citation paragraph with title and text from a <see cref="title"/> and a <see cref="content"/>
    /// </summary>
    /// <param name="title">Title of the citation</param>
    /// <param name="content">Text of the citation</param>
    /// <returns></returns>
    TagBuilder GenerateCitation(string title, string content);
}
