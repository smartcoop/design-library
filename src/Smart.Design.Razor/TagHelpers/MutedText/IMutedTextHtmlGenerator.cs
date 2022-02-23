using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.MutedText;

public interface IMutedTextHtmlGenerator
{
    /// <summary>
    /// Generates a Smart Design muted text
    /// </summary>
    /// <param name="text">The text to be rendered.</param>
    /// <returns>A instance of the Smart Design muted text.</returns>
    TagBuilder GenerateMutedText(string? text);
}
