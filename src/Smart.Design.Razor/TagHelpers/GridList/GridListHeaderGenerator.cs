using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.GridList;

/// <summary>
/// Create the grid row  in a table header.
/// To use in conjunction with <see cref="GridListTagHelper"/>
/// </summary>
public class GridListHeaderGenerator : IGridListHeaderGenerator
{
    /// <inheritdoc/>>
    public TagBuilder GenerateHeader(List<string> titles)
    {
        var header = new TagBuilder("thead");
        foreach (var title in titles)
        {
            var headerItemTagBuilder = GenerateHeaderItem(title);
            header.InnerHtml.AppendHtml(headerItemTagBuilder);
        }

        return header;
    }

    private TagBuilder GenerateHeaderItem(string title)
    {
        var headerTitle = new TagBuilder("th");
        headerTitle.InnerHtml.Append(title);
        return headerTitle;
    }
}
