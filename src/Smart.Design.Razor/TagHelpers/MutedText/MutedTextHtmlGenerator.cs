using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.MutedText;

public class MutedTextHtmlGenerator : IMutedTextHtmlGenerator
{
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