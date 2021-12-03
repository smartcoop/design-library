using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Grid;

public interface IGridHtmlGenerator
{
    /// <summary>
    /// Generates a &lt;div&gt; that is a Smart design grid.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
    /// </summary>
    /// <returns>An instance of the grid.</returns>
    TagBuilder GenerateGrid();

    /// <summary>
    /// Generates a column for the Smart grid.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
    /// </summary>
    /// <param name="width">The width of the column.</param>
    /// <returns>An instance of a column.</returns>
    TagBuilder GenerateColumn(int width);
}
