using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;


namespace Smart.Design.Razor.TagHelpers.Titles.PageTitle;

[HtmlTargetElement(TagNames.PageTitleTagName)]
public class PageTitleTagHelper : TagHelper
{
    private readonly IPageTitleHtmlGenerator _pageTitleGenerator;

    /// <summary>
    /// Title of the page.
    /// </summary>
    public string Title { get; set; }

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
        var pageTitleblock = new TagBuilder("div");
        pageTitleblock.AddCssClass("c-navbar u-position-fixed main-title");

        pageTitleblock.InnerHtml.SetHtmlContent(_pageTitleGenerator.GeneratePageTitleItem(Title));

        output.MergeAttributes(pageTitleblock);
        output.TagName = pageTitleblock.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(pageTitleblock.InnerHtml);
    }
}
