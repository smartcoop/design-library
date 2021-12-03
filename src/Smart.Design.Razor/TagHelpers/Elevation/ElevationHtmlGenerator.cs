using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Elevation;

public class ElevationHtmlGenerator : IElevationHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateElevation(ElevationSize elevation)
    {
        var div = new TagBuilder("div");
        div.AddCssClass($"u-shadow-{(int) elevation}");
        return div;
    }
}
