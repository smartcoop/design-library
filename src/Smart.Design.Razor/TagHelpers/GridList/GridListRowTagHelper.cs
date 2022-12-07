using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.GridList;

/// <summary>
/// <see cref="ITagHelper" /> Create the grid data in a table body.
/// To use inside a <see cref="GridListTagHelper"/>
/// </summary>
[HtmlTargetElement(TagNames.GridlistRowTagName, ParentTag = TagNames.GridlistTagName)]
public class GridListRowTagHelper : BaseTagHelper
{
    /// <summary>
    /// Length of one row of the table.
    /// The default will resolve to the total number of elements inside the tbody.
    /// </summary>
    public int? RowLength { get; set; }

    /// <summary>
    /// Allows to select a custom column separator.
    /// The default separator is a Newline.
    /// </summary>
    public string ColumnSeparator { get; set; } = Environment.NewLine;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var rowData = new TagBuilder("tr");
        var rowContent = (await output.GetChildContentAsync()).GetContent();
        if (!string.IsNullOrWhiteSpace(rowContent))
        {
            var rowItems = new Queue<string>(rowContent.Split(ColumnSeparator).Where(txt => !string.IsNullOrWhiteSpace(txt)));
            var rowLength = RowLength ?? rowItems.Count;

            var maxColumnNumber = Math.Max(1, rowItems.Count / rowLength);
            for (var columnNumber = 0; columnNumber < maxColumnNumber; columnNumber++)
            {
                var maxRowNumber = Math.Max(rowLength, maxColumnNumber);
                for (var rowNumber = 0; rowNumber < maxRowNumber; rowNumber++)
                {
                    var rowCell = new TagBuilder("td");
                    if (rowNumber < rowLength && rowItems.TryDequeue(out var item))
                    {
                        rowCell.InnerHtml.AppendHtml(item);
                    }
                    else
                    {
                        var emptyDiv = new TagBuilder("div");
                        rowCell.InnerHtml.AppendHtml(emptyDiv);
                    }

                    rowData.InnerHtml.AppendHtml(rowCell);
                }
            }
        }

        output.MergeAttributes(rowData);
        output.TagName = rowData.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(rowData.InnerHtml);
    }
}
