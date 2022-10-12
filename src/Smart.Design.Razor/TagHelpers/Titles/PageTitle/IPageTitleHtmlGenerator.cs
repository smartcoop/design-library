using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Titles.PageTitle;
/// <summary>
/// Generates a H1 page title block with a set title
/// </summary>
public interface IPageTitleHtmlGenerator
{
    /// <summary>
    /// Generate a H1 page title block from a <see cref="title"/> string
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    TagBuilder GeneratePageTitleItem(string title);
}
