using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Elevation;

public interface IElevationHtmlGenerator
{
    /// <summary>
    /// Generates an elevated card with shadows.
    /// </summary>
    /// <param name="elevation">Size of the elevation</param>
    /// <returns>A instance of an elevator.</returns>
    TagBuilder GenerateElevation(ElevationSize elevation);
}
