using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Smart.Design.Razor.TagHelpers.Pagination;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart Design Pagination.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-pagination.html">here</see>.
/// </summary>
[HtmlTargetElement(TagName)]
public class PaginationHelper : TagHelper
{
    private const string TagName = "smart-pagination";

    private readonly ISmartPaginationHtmlGenerator _smartPaginationHtmlGenerator;

    [HtmlAttributeName("pagination-settings")]
    public PaginationSettings Settings { get; set; } = null!;

    public PaginationHelper(ISmartPaginationHtmlGenerator smartPaginationHtmlGenerator)
    {
        ArgumentNullException.ThrowIfNull(smartPaginationHtmlGenerator);
        _smartPaginationHtmlGenerator = smartPaginationHtmlGenerator;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var pagination = await _smartPaginationHtmlGenerator.GenerateSmartPaginationAsync(Settings);

        output.TagName = pagination.TagName;

        output.Content.AppendHtml(pagination.InnerHtml);
        output.MergeAttributes(pagination);
    }
}
