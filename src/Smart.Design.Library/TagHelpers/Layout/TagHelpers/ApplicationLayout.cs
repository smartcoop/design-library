using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Layout.TagHelpers;

[HtmlTargetElement(TagNames.ApplicationLayout)]
public class ApplicationLayout : TagHelper
{
    private readonly IHtmlLayoutGenerator _htmlLayoutGenerator;

    public ApplicationLayout(IHtmlLayoutGenerator htmlLayoutGenerator)
    {
        _htmlLayoutGenerator = htmlLayoutGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var appLayout = _htmlLayoutGenerator.GenerateApplicationLayout();

        output.ClearAndMergeAttributes(appLayout);
        output.TagName = output.TagName;
        output.TagMode = output.TagMode = TagMode.StartTagAndEndTag;
    }
}
