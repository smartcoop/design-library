using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Grid;

/// <summary>
/// <see cref="ITagHelper" /> implementation of a Smart design column inside a Smart design grid.
/// The grid component is supposed to be a direct child of the smart grid.
/// The component has <c>width</c> attributes.
/// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.GridColumnTagName)]
public class GridColumnTagHelper : TagHelper
{
    private readonly IGridHtmlGenerator _gridHtmlGenerator;
    private const string WidthAttributeName = "width";

    [HtmlAttributeName(WidthAttributeName)]
    public int Width { get; set; }

    public GridColumnTagHelper(IGridHtmlGenerator gridHtmlGenerator)
    {
        _gridHtmlGenerator = gridHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var column = _gridHtmlGenerator.GenerateColumn(Width);
        output.TagName = column.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.Clear();
        output.MergeAttributes(column);
    }
}
