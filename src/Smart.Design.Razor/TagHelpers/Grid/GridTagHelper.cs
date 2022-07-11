using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Grid;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart design grid.
/// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.GridTagName)]
public class GridTagHelper : TagHelper
{
    private readonly IGridHtmlGenerator _gridHtmlGenerator;

    /// <summary>
    /// Creates a new <see cref="GridTagHelper"/>.
    /// </summary>
    /// <param name="gridHtmlGenerator">The <see cref="IGridHtmlGenerator"/>.</param>
    public GridTagHelper(IGridHtmlGenerator gridHtmlGenerator)
    {
        _gridHtmlGenerator = gridHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var grid = _gridHtmlGenerator.GenerateGrid();
        output.TagName = grid.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.MergeAttributes(grid);
    }
}
