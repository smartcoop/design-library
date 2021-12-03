using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.GlobalBanner;

[HtmlTargetElement(TagNames.GlobalBannerTagName)]
public class GlobalBannerTagHelper : TagHelper
{
    private const string LabelAttributeName = "label";
    private const string TypeAttributeName = "type";

    private readonly IGlobalBannerHtmlGenerator _globalBannerHtmlGenerator;

    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    [HtmlAttributeName(TypeAttributeName)]
    public GlobalBannerType Type { get; set; }

    public GlobalBannerTagHelper(IGlobalBannerHtmlGenerator globalBannerHtmlGenerator)
    {
        _globalBannerHtmlGenerator = globalBannerHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var global = _globalBannerHtmlGenerator.GenerateGlobalBanner(Type, Label);

        output.ClearAllAttributes();
        output.TagName = global.TagName;
        output.MergeAttributes(global);

        output.Content.SetHtmlContent(global.InnerHtml);
    }
}