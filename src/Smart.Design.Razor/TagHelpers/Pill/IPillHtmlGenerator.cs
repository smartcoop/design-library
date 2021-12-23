using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Pill;

public interface IPillHtmlGenerator
{
    /// <summary>
    /// Generates a Smart Design pill.
    /// A pill may have a circle, label and a status that determine its look and feel.
    /// </summary>
    /// <param name="withCircle">If the pill should come with or not a circle.</param>
    /// <param name="label">The text displayed within the pill.</param>
    /// <param name="pillStatus">Skin of the pill.</param>
    /// <returns></returns>
    public TagBuilder GeneratePill(bool withCircle, string? label, PillStatus pillStatus);
}
