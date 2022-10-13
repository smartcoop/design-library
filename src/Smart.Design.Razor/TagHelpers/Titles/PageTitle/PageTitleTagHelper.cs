using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;


namespace Smart.Design.Razor.TagHelpers.Titles.PageTitle;

[HtmlTargetElement(TagNames.PageTitleTagName, TagStructure = TagStructure.WithoutEndTag)]
public class PageTitleTagHelper : TagHelper
{
    private readonly IPageTitleHtmlGenerator _pageTitleGenerator;

    /// <summary>
    /// Title of the page.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Creates a new <see cref="PageTitleHtmlGenerator"/>.
    /// </summary>
    /// <param name="pageTitleHtmlGenerator">The service that generates Smart Design H1 page Title HTML.</param>
    public PageTitleTagHelper(IPageTitleHtmlGenerator pageTitleHtmlGenerator)
    {
        _pageTitleGenerator = pageTitleHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            throw new MissingFieldException(nameof(PageTitleTagHelper), nameof(Title));
        }

        var pageTitleBlock = new TagBuilder("div");
        pageTitleBlock.AddCssClass("c-navbar u-position-fixed main-title");

        pageTitleBlock.InnerHtml.SetHtmlContent(_pageTitleGenerator.GeneratePageTitleItem(Title));

        output.MergeAttributes(pageTitleBlock);
        output.TagName = pageTitleBlock.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(pageTitleBlock.InnerHtml);
    }
}
