using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.ProgressBar;

public interface IProgressBarHtmlGenerator
{
    /// <summary>
    /// Generates a Smart design progress bar.
    /// </summary>
    /// <param name="progress">The progress value. This should be between 0 et and 100.
    /// A value higher or equals to  100 is considered as done.</param>
    /// <returns>An instance of a Smart design progress bar.</returns>
    TagBuilder GenerateProgressBar(int progress = 0);
}
