using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.MutedText;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart Design muted text.
/// A muted text is a &lt;p&gt; with css class u-text-muted.
/// </summary>
[HtmlTargetElement(TagNames.MutedTextTagName)]
public class MutedTextTagHelper : TagHelper
{
    private const string TextAttributeName = "text";

    private readonly IMutedTextHtmlGenerator _mutedTextHtmlGenerator;

    /// <summary>
    /// Text to be rendered by the Tag Helper.
    /// </summary>
    [HtmlAttributeName(TextAttributeName)]
    public string? Text { get; set; }

    /// <summary>
    /// Creates a new <see cref="MutedTextTagHelper"/>.
    /// </summary>
    /// <param name="mutedTextHtmlGenerator">The <see cref="IMutedTextHtmlGenerator"/>.</param>
    public MutedTextTagHelper(IMutedTextHtmlGenerator mutedTextHtmlGenerator)
    {
        _mutedTextHtmlGenerator = mutedTextHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var mutedText = _mutedTextHtmlGenerator.GenerateMutedText(Text);

        output.TagName = mutedText.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.ClearAndMergeAttributes(mutedText);
        output.Content.SetHtmlContent(mutedText.InnerHtml);
    }
}
