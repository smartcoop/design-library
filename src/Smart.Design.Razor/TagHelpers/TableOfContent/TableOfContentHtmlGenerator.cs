using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.TableOfContent;

/// <summary>
/// Create the grid row  in a table header.
/// To use in conjunction with <see cref="GridListTagHelper"/>
/// </summary>
public class TableOfContentHtmlGenerator : ITableOfContentHtmlGenerator
{
    public TagBuilder GenerateListOfItems(List<string> titles)
    {
        var list = new TagBuilder("ol");
        list.AddCssClass("c-table-of-content__nav relativeWidth stickyPosition");

        for (var i = 0; i < titles.Count; i++)
        {
            var li = new TagBuilder("li");

            if (i == 0)
            {
                li.Attributes["aria-selected"] = "true";
            }

            var link = new TagBuilder("a");
            link.AddCssClass("c-table-of-content__nav__item");
            link.Attributes["href"] = $"#section_{i + 1}";
            link.InnerHtml.Append(titles[i]);

            li.InnerHtml.AppendHtml(link);
            list.InnerHtml.AppendHtml(li);
        }

        var div = new TagBuilder("div");
        div.AddCssClass("current-state");
        div.Attributes["aria-hidden"] = "true";

        list.InnerHtml.AppendHtml(div);

        return list;
    }
}
