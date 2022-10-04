using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.TableOfContent;

/// <summary>
/// Create the grid row  in a table header.
/// To use in conjunction with <see cref="GridListTagHelper"/>
/// </summary>
public class TableOfContentGenerator : ITableOfContentGenerator
{
    public TagBuilder GenerateListOfItems(List<string> titles)
    {
        var list = new TagBuilder("ol");
        list.AddCssClass("c-table-of-content__nav relativeWidth stickyPosition");

        int i = 1;
        foreach (var title in titles)
        {
            var li = new TagBuilder("li");

            var link = new TagBuilder("a");
            link.AddCssClass("c-table-of-content__nav__item");
            link.Attributes["href"] = $"#section_{i}";
            link.InnerHtml.Append(title);

            li.InnerHtml.AppendHtml(link);
            list.InnerHtml.AppendHtml(li);

            i++;
        }

        var div = new TagBuilder("div");
        div.AddCssClass("current-state");
        div.Attributes["aria-hidden"] = "true";

        list.InnerHtml.AppendHtml(div);

        return list;
    }
}
