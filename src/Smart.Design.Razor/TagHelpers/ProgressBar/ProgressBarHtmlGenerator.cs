using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.ProgressBar
{
    public class ProgressBarHtmlGenerator : IProgressBarHtmlGenerator
    {
        /// <inheritdoc />
        public TagBuilder GenerateProgressBar(int progress = 0)
        {
            var progressDecimal = (progress / 100d).ToString("0.##", CultureInfo.InvariantCulture);
            var progressBar = new TagBuilder("div");
            progressBar.AddCssClass("c-progress-bar");
            progressBar.Attributes["style"] = $"--value: {progressDecimal}";
            if (progress >= 100)
            {
                progressBar.AddCssClass("c-progress-bar--success");
            }

            return progressBar;
        }
    }
}
