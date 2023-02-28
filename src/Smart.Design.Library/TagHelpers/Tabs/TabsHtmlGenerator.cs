using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Tabs;

public class TabsHtmlGenerator : ITabsHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateTab(bool bordered)
    {
        var nav = new TagBuilder("nav");
        nav.AddCssClass("c-tabs");
        if (bordered)
        {
            nav.AddCssClass("c-tabs--border-bottom");
        }

        return nav;
    }

    /// <inheritdoc />
    public TagBuilder GenerateTabItemsContainer()
    {
        return new TagBuilder("ul");
    }

    /// <inheritdoc />
    public TagBuilder GenerateTabItem(string? label, string? @ref)
    {
        var li = new TagBuilder("li");

        // Anchor that references the tab item's content.
        var anchor = new TagBuilder("a");
        anchor.AddCssClass("c-tabs__item");
        anchor.Attributes["href"] = @ref;

        anchor.InnerHtml.SetContent(label!);

        li.InnerHtml.SetHtmlContent(anchor);

        return li;
    }

    public TagBuilder GenerateTabSection(string? id)
    {
        var section = new TagBuilder("div");
        section.AddCssClass("c-tabs__section");

        return section;
    }
}
