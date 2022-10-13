using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Buttons.ButtonBackToTop;

public interface IButtonBackToTopHtmlGenerator
{
    /// <summary>
    /// Generate a back to top button with a <see cref="label"/> string
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    TagBuilder GenerateButtonBackToTop(string label);
}
