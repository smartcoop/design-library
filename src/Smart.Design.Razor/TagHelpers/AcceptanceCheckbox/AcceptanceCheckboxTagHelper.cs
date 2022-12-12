using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;


namespace Smart.Design.Razor.TagHelpers.AcceptanceCheckbox;

[HtmlTargetElement(TagNames.AcceptanceCheckboxTagName, TagStructure = TagStructure.WithoutEndTag)]
public class AcceptanceCheckboxTagHelper : TagHelper
{
    private readonly IAcceptanceCheckboxHtmlGenerator _acceptanceCheckboxGenerator;

    /// <summary>
    /// Label of the acceptance Checkbox.
    /// </summary>
    public string Label { get; set; } = null!;

    /// <summary>
    /// Style of the acceptance Checkbox.
    /// </summary>
    public AcceptanceCheckboxStyle Style { get; set; }

    /// <summary>
    /// Language of label.
    /// </summary>
    public string CurrentLanguage { get; set; } = null!;

    /// <summary>
    /// Creates a new <see cref="acceptanceCheckboxHtmlGenerator"/>.
    /// </summary>
    /// <param name="acceptanceCheckboxHtmlGenerator">The service that generates Smart Design message.</param>
    public AcceptanceCheckboxTagHelper(IAcceptanceCheckboxHtmlGenerator acceptanceCheckboxHtmlGenerator)
    {
        _acceptanceCheckboxGenerator = acceptanceCheckboxHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (string.IsNullOrWhiteSpace(Label))
        {
            throw new MissingFieldException(nameof(AcceptanceCheckboxTagHelper), nameof(Label));
        }

        var acceptanceCheckboxBlock = new TagBuilder("div");
        acceptanceCheckboxBlock.AddCssClass($"c-panel--{Style.ToString().ToLowerInvariant()} u-padding-l u-padding-horizontal-xl c-panel--border-r-sm");
        acceptanceCheckboxBlock.Attributes["id"] = "acceptation";

        acceptanceCheckboxBlock.InnerHtml.SetHtmlContent(_acceptanceCheckboxGenerator.GenerateAcceptanceCheckbox(Label, Style, CurrentLanguage));

        output.MergeAttributes(acceptanceCheckboxBlock);
        output.TagName = acceptanceCheckboxBlock.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(acceptanceCheckboxBlock.InnerHtml);
    }
}
