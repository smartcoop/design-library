using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.MutedText;

/// <inheritdoc />
public class MutedTextHtmlGenerator : IMutedTextHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateMutedText(string? text)
    {
        var mutedText = new TagBuilder("p");
        mutedText.AddCssClass("u-text-muted");

        if (!string.IsNullOrWhiteSpace(text))
        {
            mutedText.InnerHtml.SetContent(text);
        }

        return mutedText;
    }
}
