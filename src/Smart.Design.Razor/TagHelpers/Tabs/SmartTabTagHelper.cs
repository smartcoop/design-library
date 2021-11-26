using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Tabs
{
    /// <summary>
    /// Implementation of the smart design tab.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-tabs.html#">here</see>.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartTabs)]
    public class SmartTabTagHelper : TagHelper
    {
        private const string BorderedAttributeName = "bordered";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(BorderedAttributeName)]
        public bool Bordered { get; set; }

        public SmartTabTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var smartTab = _smartHtmlGenerator.GenerateSmartTab(Bordered);

            output.TagName = smartTab.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAndMergeAttributes(smartTab);
        }
    }
}
