using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Elevation;

[HtmlTargetElement(TagNames.ElevationTagName)]
public class ElevationTagHelper : TagHelper
{
    private const string ElevationAttributeName = "elevation";

    private readonly IElevationHtmlGenerator _elevationHtmlGenerator;

    [HtmlAttributeName(ElevationAttributeName)]
    public ElevationSize Elevation { get; set; } = ElevationSize.Medium;

    public ElevationTagHelper(IElevationHtmlGenerator elevationHtmlGenerator)
    {
        _elevationHtmlGenerator = elevationHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var elevator = _elevationHtmlGenerator.GenerateElevation(Elevation);

        output.TagName = elevator.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAllAttributes();
        output.MergeAttributes(elevator);
    }
}
