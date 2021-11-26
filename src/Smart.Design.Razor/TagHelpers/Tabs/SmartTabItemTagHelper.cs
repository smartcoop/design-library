using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Tabs
{
    /// <summary>
    /// <see cref="ITagHelper" /> implementation of the smart design tab item.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-tabs.html">here</see>.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartTabsItem, ParentTag = TagNames.SmartTabsItems)]
    public class SmartTabItemTagHelper : TagHelper
    {
        private const string LabelAttributeName = "label";
        private const string RefAttributeName = "href";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(RefAttributeName)]
        public string Ref { get; set; }

        [HtmlAttributeName(LabelAttributeName)]
        public string Label { get; set; }

        public SmartTabItemTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tabItem = _smartHtmlGenerator.GenerateSmartTabItem(Label, Ref);

            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = tabItem.TagName;

            output.ClearAndMergeAttributes(tabItem);

            output.Content.SetHtmlContent(tabItem.InnerHtml);
        }
    }
}
