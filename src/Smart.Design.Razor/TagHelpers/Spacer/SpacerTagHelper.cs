using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Spacer;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart Design Spacer.
/// The Smart Design Spacer is a component that exposes the possibility of add margin around it.
/// The Smart Design Spacer supports adding margin at the top and bottom and on left and right.
/// </summary>
[HtmlTargetElement(TagNames.Spacer)]
public class SpacerTagHelper : TagHelper
{
    private readonly ISpacerHtmlGenerator _spacerHtmlGenerator;

    public Size All { get; set; }

    public Size Left { get; set; }

    public Size Top  { get; set; }

    public Size Right { get; set; }

    public Size Bottom { get; set; }

    public SpacerTagHelper(ISpacerHtmlGenerator spacerHtmlGenerator)
    {
        _spacerHtmlGenerator = spacerHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var spacer = _spacerHtmlGenerator.GenerateSpacer(All, Left, Top, Right, Bottom);

        output.ClearAndMergeAttributes(spacer);
        output.TagName = spacer.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}
