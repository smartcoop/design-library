using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Layout.TagHelpers;

[HtmlTargetElement(TagNames.ApplicationLayoutSidebar)]
public class ApplicationLayoutSidebarTagHelper : TagHelper
{
    private readonly IHtmlLayoutGenerator _htmlLayoutGenerator;

    public ApplicationLayoutSidebarTagHelper(IHtmlLayoutGenerator htmlLayoutGenerator)
    {
        _htmlLayoutGenerator = htmlLayoutGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var sideBar = _htmlLayoutGenerator.GenerateSideBar();

        output.TagName = sideBar.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.ClearAndMergeAttributes(sideBar);
    }
}
