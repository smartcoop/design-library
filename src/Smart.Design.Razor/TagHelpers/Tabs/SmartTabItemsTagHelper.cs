using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Tabs
{
    /// <summary>
    /// <see cref="ITagHelper" /> header containing items of a <see cref="SmartTabTagHelper" />.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-tabs.html#">here</see>.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartTabsItems, ParentTag = TagNames.SmartTabs)]
    public class SmartTabItemsTagHelper : TagHelper
    {
        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        public SmartTabItemsTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var itemsContainer = _smartHtmlGenerator.GenerateSmartTabItemsContainer();

            output.TagName = itemsContainer.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAndMergeAttributes(itemsContainer);
        }
    }
}
