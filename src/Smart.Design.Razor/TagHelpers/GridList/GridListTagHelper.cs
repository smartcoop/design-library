using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Elements.Button;
using Smart.Design.Razor.TagHelpers.Form;
using Smart.Design.Razor.TagHelpers.Grid;

namespace Smart.Design.Razor.TagHelpers.GridList;

/// <summary>
/// <see cref="ITagHelper" /> implementation of a Smart design &lt;grid-list&gt;.
/// </summary>
[HtmlTargetElement(TagNames.GridlistTagName)]
// [RestrictChildren(TagNames.GridlistRowTagName)]
public class GridListTagHelper : BaseTagHelper
{
    private readonly IGridListHeaderGenerator _listHeaderGenerator;
    private readonly IGridListBodyGenerator _bodyGenerator;
    public List<string> Titles { get; set; }
    public int? RowLength { get; set; }

    public string ColumnSeparator { get; set; } = Environment.NewLine;

    public GridListTagHelper(IGridListHeaderGenerator listHeaderGenerator, IGridListBodyGenerator bodyGenerator)
    {
        _listHeaderGenerator = listHeaderGenerator;
        _bodyGenerator = bodyGenerator;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var wrapper = new TagBuilder("div");
        wrapper.AddCssClass("u-scroll-wrapper");
        var scroll = new TagBuilder("div");
        scroll.AddCssClass("u-scroll-wrapper-body");
        var padding = new TagBuilder("div");
        padding.AddCssClass("u-padding-horizontal-s");
        var table = new TagBuilder("table");
        table.AddCssClass("c-table c-table--styled js-data-table");

        table.InnerHtml.SetHtmlContent(_listHeaderGenerator.GenerateHeader(Titles));
        var body = (await output.GetChildContentAsync()).GetContent();
        table.InnerHtml.AppendHtml(_bodyGenerator.GenerateBody(RowLength ?? Titles.Count, body, ColumnSeparator));

        padding.InnerHtml.AppendHtml(table);
        scroll.InnerHtml.AppendHtml(padding);
        wrapper.InnerHtml.AppendHtml(scroll);

        output.MergeAttributes(wrapper);
        output.TagName = wrapper.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(wrapper.InnerHtml);
    }
}

public interface IGridListHeaderGenerator
{
    TagBuilder GenerateHeader(List<string> titles);
}

public class GridListHeaderGenerator : IGridListHeaderGenerator
{
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

public class GridListBodyGenerator : IGridListBodyGenerator
{
    public TagBuilder GenerateBody(int rowLength, string? output, string columnSeparator)
    {
        var body = new TagBuilder("tbody");

        if (!string.IsNullOrWhiteSpace(output))
        {
            var rowItems = new Queue<string>(output.Split(columnSeparator).Where(txt => !string.IsNullOrWhiteSpace(txt)));
            var maxColumnNumber = Math.Max(1, rowItems.Count / rowLength);
            for (var columnNumber = 0; columnNumber < maxColumnNumber; columnNumber++)
            {
                var rowTable = new TagBuilder("tr");
                var maxRowNumber = Math.Max(rowLength, maxColumnNumber);
                for (var rowNumber = 0; rowNumber < maxRowNumber; rowNumber++)
                {
                    var rowCell = new TagBuilder("td");
                    if (rowNumber < rowLength && rowItems.TryDequeue(out var item))
                    {
                        rowCell.InnerHtml.AppendHtml(item.Trim());
                    }
                    else
                    {
                        var emptyDiv = new TagBuilder("div");
                        rowCell.InnerHtml.AppendHtml(emptyDiv);
                    }

                    rowTable.InnerHtml.AppendHtml(rowCell);
                }

                body.InnerHtml.AppendHtml(rowTable);
            }
        }

        return body;
    }
}

public interface IGridListBodyGenerator
{
    TagBuilder GenerateBody(int rowLength, string? output, string columnSeparator);
}
