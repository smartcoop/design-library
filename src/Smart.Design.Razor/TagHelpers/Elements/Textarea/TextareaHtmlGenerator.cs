using System.Globalization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Razor.TagHelpers.Base;

namespace Smart.Design.Razor.TagHelpers.Elements.Textarea;

public class TextareaHtmlGenerator : BaseHtmlGenerator, ITextareaHtmlGenerator
{

    /// <inheritdoc />
    public TagBuilder GenerateSmartTextArea(string? id, string? name, int? rows, TextAreaSize textareaSize, ModelExpression? @for)
    {
        var textAreaTagBuilder = new TagBuilder("textarea");
        textAreaTagBuilder.AddCssClass("c-textarea");

        if (!string.IsNullOrWhiteSpace(id))
        {
            textAreaTagBuilder.Attributes.Add("id", id);
        }

        AddNameAttribute(textAreaTagBuilder, @for, name);

        if (rows.HasValue)
        {
            textAreaTagBuilder.Attributes.Add("rows", rows.Value.ToString(CultureInfo.InvariantCulture));
        }

        if (textareaSize != TextAreaSize.Unspecified)
        {
            textAreaTagBuilder.AddCssClass($"c-input--h-{textareaSize.ToString().ToLowerInvariant()}");
        }

        if (@for?.Model is string content && !string.IsNullOrWhiteSpace(content))
        {
            textAreaTagBuilder.InnerHtml.SetHtmlContent(content);
        }

        return textAreaTagBuilder;
    }
}
