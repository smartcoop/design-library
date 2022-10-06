using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.TableOfContent;

/// <summary>
/// Implementation of a Smart design table of content.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-table-of-content.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.TableOfContentTagName)]
public class TableOfContentTagHelper : TagHelper
{
    private readonly ITableOfContentHtmlGenerator _tableOfContentGenerator;

    /// <summary>
    /// Title list of table of content items.
    /// </summary>
    public List<string> Titles { get; set; }

    /// <summary>
    /// Creates a new <see cref="TableOfContentTagHelper"/>.
    /// </summary>
    /// <param name="iconHtmlGenerator">The service that generates Smart Design table of content HTML.</param>
    public TableOfContentTagHelper(ITableOfContentHtmlGenerator tableOfContentHtmlGenerator)
    {
        _tableOfContentGenerator = tableOfContentHtmlGenerator;
    }

    /// <inheritdoc />
    public override void  Process(TagHelperContext context, TagHelperOutput output)
    {
        var nav = new TagBuilder("nav");
        nav.AddCssClass("c-table-of-content-navigation fixed");
        nav.Attributes["id"] = "table-of-content-nav";
        nav.Attributes["aria-label"] = "Table of content";
        nav.Attributes["role"] = "navigation";

        nav.InnerHtml.SetHtmlContent(_tableOfContentGenerator.GenerateListOfItems(Titles));

        output.MergeAttributes(nav);
        output.TagName = nav.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(nav.InnerHtml);
    }
}
