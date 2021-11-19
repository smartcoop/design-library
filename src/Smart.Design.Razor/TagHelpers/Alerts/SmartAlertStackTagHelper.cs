using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Alerts
{
    [HtmlTargetElement(TagNames.SmartAlertStack, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SmartAlertStackTagHelper : TagHelper
    {
        private const string IconAttributeName = "icon";
        private const string MessageAttributeName = "message";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(IconAttributeName)]
        public Icon Icon { get; set; }

        [HtmlAttributeName(MessageAttributeName)]
        public string Message { get; set; }

        public SmartAlertStackTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var alertStack = _smartHtmlGenerator.GenerateAlertStack(Icon, Message);

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAndMergeAttributes(alertStack);

            output.Content.SetHtmlContent(alertStack);
        }
    }
}
