using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.SideMenu;

/// <summary>
/// Generate a side menu from a list of links.
/// </summary>
public interface ISideMenuHtmlGenerator
{
    /// <summary>
    /// Generate a list of navigation items from a <see cref="labelAndLinks"/> dictionnary
    /// </summary>
    /// <param name="labelAndLinks">The list of navigation items with a title and a link</param>
    /// <returns></returns>
    TagBuilder GenerateListOfItems(Dictionary<string, string> labelAndLinks);
}
