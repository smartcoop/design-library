using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Spacer;

/// <summary>
/// Contract interface to generate Smart Design Spacers.
/// </summary>
public interface ISpacerHtmlGenerator
{
    /// <summary>
    /// Generates the HTML of the Smart Design Spacer.
    /// See <see cref="SpacerTagHelper" /> for more information.
    /// </summary>
    /// <param name="all">The margin <see cref="Size"/> to add around the component.</param>
    /// <param name="left">The margin <see cref="Size"/> to add on the left of the component.</param>
    /// <param name="top">The margin <see cref="Size"/> to add at the top of the component.</param>
    /// <param name="right">The margin <see cref="Size"/> to add on the right of the component.</param>
    /// <param name="bottom">The margin <see cref="Size"/> to add at the bottom of the component.</param>
    /// <returns>An instance of the Smart Design spacer.</returns>
    TagBuilder GenerateSpacer(Size all, Size left, Size top, Size right, Size bottom);
}
