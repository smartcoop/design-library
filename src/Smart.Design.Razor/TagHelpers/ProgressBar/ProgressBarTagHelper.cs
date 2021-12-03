using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.ProgressBar;

/// <summary>
/// Implementation of Smart design progress bar.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-progress-bar.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.ProgressBar)]
public class ProgressBarTagHelper : TagHelper
{
    private readonly IProgressBarHtmlGenerator _progressBarHtmlGenerator;
    private const string ProgressAttributeName = "progress";

    [HtmlAttributeName(ProgressAttributeName)]
    public int Progress { get; set; }

    public ProgressBarTagHelper(IProgressBarHtmlGenerator progressBarHtmlGenerator)
    {
        _progressBarHtmlGenerator = progressBarHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var progressBar = _progressBarHtmlGenerator.GenerateProgressBar(Progress);

        output.TagName = progressBar.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.ClearAndMergeAttributes(progressBar);
    }
}
