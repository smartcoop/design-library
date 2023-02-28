using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.IconList;

/// <summary>
/// Implementation of an Smart design icon list.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-icon-list.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.IconListTagName)]
public class IconListTagHelper : TagHelper
{
    private readonly IIconListHtmlGenerator _iconListHtmlGenerator;

    public IconListTagHelper(IIconListHtmlGenerator iconListHtmlGenerator)
    {
        _iconListHtmlGenerator = iconListHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var iconList = _iconListHtmlGenerator.GenerateIconList();

        output.ClearAllAttributes();
        output.TagName = iconList.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.ClearAndMergeAttributes(iconList);
    }
}
