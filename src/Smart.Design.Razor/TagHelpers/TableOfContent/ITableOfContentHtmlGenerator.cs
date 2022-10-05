using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.TableOfContent;

/// <summary>
/// Generate a table of content from a list of chapters.
/// </summary>
public interface ITableOfContentHtmlGenerator
{
    /// <summary>
    /// Generate a numbered list of main chapters' titles from a <see cref="titles"/> list
    /// </summary>
    /// <param name="titles">The list of chapters</param>
    /// <returns></returns>
    TagBuilder GenerateListOfItems(List<string> titles);
}
