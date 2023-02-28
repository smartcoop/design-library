using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.Badge;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart design badge.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-badge.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.BadgeTagName)]
public class BadgeTagHelper : TagHelper
{
    private const string IconAttributeName = "icon";
    private const string SizeAttributeName = "size";
    private const string StyleAttributeName = "badge-style";
    private const string SublineAttributeName = "subline";
    private const string TitleAttributeName = "title";

    private readonly IBadgeHtmlGenerator _badgeHtmlGenerator;

    [HtmlAttributeName(SizeAttributeName)]
    public BadgeSize Size { get; set; }

    [HtmlAttributeName(StyleAttributeName)]
    public BadgeStyle Style { get; set; }

    [HtmlAttributeName(IconAttributeName)]
    public Image Icon { get; set; }

    [HtmlAttributeName(SublineAttributeName)]
    public string? Subline { get; set; }

    [HtmlAttributeName(TitleAttributeName)]
    public string? Title { get; set; }

    public BadgeTagHelper(IBadgeHtmlGenerator badgeHtmlGenerator)
    {
        _badgeHtmlGenerator = badgeHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var badge = _badgeHtmlGenerator.GenerateSmartBadge(Style, Icon, Size, Title, Subline);

        output.ClearAndMergeAttributes(badge);

        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = badge.TagName;

        output.Content.SetHtmlContent(badge.InnerHtml);
    }
}
