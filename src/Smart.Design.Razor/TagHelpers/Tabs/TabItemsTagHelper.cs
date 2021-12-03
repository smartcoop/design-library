using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Tabs;

/// <summary>
/// <see cref="ITagHelper" /> header containing items of a <see cref="TabTagHelper" />.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-tabs.html#">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.TabsItems, ParentTag = TagNames.Tabs)]
public class TabItemsTagHelper : TagHelper
{
    private readonly ITabsHtmlGenerator _tabsHtmlGenerator;

    public TabItemsTagHelper(ITabsHtmlGenerator tabsHtmlGenerator)
    {
        _tabsHtmlGenerator = tabsHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var itemsContainer = _tabsHtmlGenerator.GenerateTabItemsContainer();

        output.TagName = itemsContainer.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAllAttributes();
        output.MergeAttributes(itemsContainer);
    }
}
