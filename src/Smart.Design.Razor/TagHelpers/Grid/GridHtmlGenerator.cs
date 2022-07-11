using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Grid;

/// <summary>
/// Implementation of <see cref="IGridHtmlGenerator"/>.
/// </summary>
public class GridHtmlGenerator : IGridHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateGrid()
    {
        var grid = new TagBuilder("div");
        grid.AddCssClass("o-grid");

        return grid;
    }

    /// <inheritdoc />
    public TagBuilder GenerateColumn(int width)
    {
        var tagBuilder = new TagBuilder("div");
        if (width is < 1 or > 24)
        {
            throw new IndexOutOfRangeException("Width must be between 1 and 12");
        }

        tagBuilder.AddCssClass($"o-grid-col-{width}");

        return tagBuilder;
    }
}
