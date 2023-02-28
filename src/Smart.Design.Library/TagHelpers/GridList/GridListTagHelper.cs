using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;

namespace Smart.Design.Library.TagHelpers.GridList;

/// <summary>
/// <see cref="ITagHelper" /> implementation of a Smart design &lt;grid-list&gt;.
/// </summary>
[HtmlTargetElement(TagNames.GridlistTagName)]
[RestrictChildren(TagNames.GridlistRowTagName)]
public class GridListTagHelper : BaseTagHelper
{
    private readonly IGridListHeaderHtmlGenerator _headerGenerator;

    /// <summary>
    /// Title list of the different column of the table.
    /// </summary>
    public List<string> Titles { get; set; }

    public GridListTagHelper(IGridListHeaderHtmlGenerator headerGenerator)
    {
        _headerGenerator = headerGenerator;
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

        table.InnerHtml.SetHtmlContent(_headerGenerator.GenerateHeader(Titles));
        var body = new TagBuilder("tbody");
        body.InnerHtml.AppendHtml((await output.GetChildContentAsync()).GetContent());

        table.InnerHtml.AppendHtml(body);
        padding.InnerHtml.AppendHtml(table);
        scroll.InnerHtml.AppendHtml(padding);
        wrapper.InnerHtml.AppendHtml(scroll);

        output.MergeAttributes(wrapper);
        output.TagName = wrapper.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(wrapper.InnerHtml);
    }
}
