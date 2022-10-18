using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.SideMenu;

/// <summary>
/// Create side menu.
/// To use in conjunction with <see cref="SideMenuTagHelper"/>
/// </summary>
public class SideMenuHtmlGenerator : ISideMenuHtmlGenerator
{
    /// <inheritdoc/>
    public TagBuilder GenerateListOfItems(Dictionary<string, string> labelAndLinks)
    {
        var ul = new TagBuilder("ul");
        ul.AddCssClass("c-side-menu");

        foreach (KeyValuePair<string, string> item in labelAndLinks)
        {
            var li = new TagBuilder("li");
            li.AddCssClass("c-side-menu__item");

            var link = new TagBuilder("a");
            link.AddCssClass("c-side-menu__link");
            link.Attributes["href"] = item.Value;
            link.InnerHtml.Append(item.Key);

            li.InnerHtml.AppendHtml(link);
            ul.InnerHtml.AppendHtml(li);
        }

        return ul;
    }
}
