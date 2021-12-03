using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Tabs;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart design tab item.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-tabs.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.TabsItem, ParentTag = TagNames.TabsItems)]
public class TabItemTagHelper : TagHelper
{
    private const string LabelAttributeName = "label";
    private const string RefAttributeName = "href";

    private readonly ITabsHtmlGenerator _tabsHtmlGenerator;

    [HtmlAttributeName(RefAttributeName)]
    public string? Ref { get; set; }

    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    public TabItemTagHelper(ITabsHtmlGenerator tabsHtmlGenerator)
    {
        _tabsHtmlGenerator = tabsHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var tabItem = _tabsHtmlGenerator.GenerateTabItem(Label, Ref);

        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = tabItem.TagName;

        output.ClearAndMergeAttributes(tabItem);

        output.Content.SetHtmlContent(tabItem.InnerHtml);
    }
}
