using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Tabs
{
    [HtmlTargetElement(TagNames.SmartTabsSection)]
    public class SmartTabSectionTagHelper : TagHelper
    {
        private readonly ISmartHtmlGenerator _smartHtmlGenerator;
        private const string IdAttributeName = "id";

        [HtmlAttributeName(IdAttributeName)]
        public string Id { get; set; }

        public SmartTabSectionTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tabsSection = _smartHtmlGenerator.GenerateSmartTabSection(Id);

            output.TagName = tabsSection.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAndMergeAttributes(tabsSection);
        }
    }
}
