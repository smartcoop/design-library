using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.GlobalBanner;

/// <summary>
/// Smart Design global banner implementation.
/// The global banner is a system-wide banner, which shows up at the top of the page.
/// Documentation is available <see href="">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.GlobalBannerTagName)]
public class GlobalBannerTagHelper : TagHelper
{
    private const string LabelAttributeName = "label";
    private const string TypeAttributeName = "type";

    private readonly IGlobalBannerHtmlGenerator _globalBannerHtmlGenerator;

    /// <summary>
    /// The message displayed.
    /// </summary>
    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    /// <summary>
    /// Style of the global banner.
    /// </summary>
    [HtmlAttributeName(TypeAttributeName)]
    public GlobalBannerType Type { get; set; }

    /// <summary>
    /// Creates a new <see cref="GlobalBannerTagHelper"/>.
    /// </summary>
    /// <param name="globalBannerHtmlGenerator">The services that will serves the HTML for <see cref="GlobalBannerTagHelper"/>.</param>
    public GlobalBannerTagHelper(IGlobalBannerHtmlGenerator globalBannerHtmlGenerator)
    {
        _globalBannerHtmlGenerator = globalBannerHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var global = _globalBannerHtmlGenerator.GenerateGlobalBanner(Type, Label);

        output.ClearAllAttributes();
        output.TagName = global.TagName;
        output.MergeAttributes(global);

        output.Content.SetHtmlContent(global.InnerHtml);
    }
}
