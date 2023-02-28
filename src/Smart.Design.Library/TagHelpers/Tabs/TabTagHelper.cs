using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Tabs;

/// <summary>
/// Implementation of the Smart design tab.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-tabs.html#">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.Tabs)]
public class TabTagHelper : TagHelper
{
    private const string BorderedAttributeName = "bordered";

    private readonly ITabsHtmlGenerator _tabsHtmlGenerator;

    [HtmlAttributeName(BorderedAttributeName)]
    public bool Bordered { get; set; }

    public TabTagHelper(ITabsHtmlGenerator tabsHtmlGenerator)
    {
        _tabsHtmlGenerator = tabsHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var smartTab = _tabsHtmlGenerator.GenerateTab(Bordered);

        output.TagName = smartTab.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAllAttributes();
        output.MergeAttributes(smartTab);
    }
}
