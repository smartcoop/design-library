using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Widgets
{
    [HtmlTargetElement(TagNames.SmartBannerTagName)]
    public class GlobalBannerTagHelper : TagHelper
    {
        private const string LabelAttributeName = "label";
        private const string TypeAttributeName = "type";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(LabelAttributeName)]
        public string Label { get; set; }

        [HtmlAttributeName(TypeAttributeName)]
        public GlobalBannerType Type { get; set; }

        public GlobalBannerTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var global = _smartHtmlGenerator.GenerateGlobalBanner(Type, Label);

            output.TagName = global.TagName;

            output.ClearAndMergeAttributes(global);

            output.Content.SetHtmlContent(global.InnerHtml);
        }
    }
}