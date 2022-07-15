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

    /// <summary>
    /// Margin to apply around the <see cref="SpacerTagHelper"/>.
    /// </summary>
    public Size All { get; set; }

    /// <summary>
    /// Margin to apply on the left of the <see cref="SpacerTagHelper"/>.
    /// </summary>
    public Size Left { get; set; }

    /// <summary>
    /// Margin to apply on the top of the <see cref="SpacerTagHelper"/>.
    /// </summary>
    public Size Top  { get; set; }

    /// <summary>
    /// Margin to apply on the right of the <see cref="SpacerTagHelper"/>.
    /// </summary>
    public Size Right { get; set; }

    /// <summary>
    /// Margin to apply on the bottom of the <see cref="SpacerTagHelper"/>.
    /// </summary>
    public Size Bottom { get; set; }

    /// <summary>
    /// Creates a <
    /// </summary>
    /// <param name="spacerHtmlGenerator">Smart Spacer HTML generator.</param>
    public SpacerTagHelper(ISpacerHtmlGenerator spacerHtmlGenerator)
    {
        _spacerHtmlGenerator = spacerHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var spacer = _spacerHtmlGenerator.GenerateSpacer(All, Left, Top, Right, Bottom);

        output.ClearAndMergeAttributes(spacer);
        output.TagName = spacer.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}
