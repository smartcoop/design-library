using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;

namespace Smart.Design.Library.TagHelpers.Box;

/// <summary>
/// Implementation of a Smart design box.
/// </summary>
[HtmlTargetElement(TagNames.BoxTagName)]
public class BoxTagHelper : TagHelper
{
    private readonly IBoxHtmlGenerator _BoxHtmlGenerator;

    /// <summary>
    /// The box title label
    /// </summary>
    public string TitleLabel { get; set; } = null!;

    /// <summary>
    /// The title
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// The subtitle
    /// </summary>
    public string? Subtitle { get; set; }

    /// <summary>
    /// Dictionnary of labels and values for the content of the box
    /// </summary>
    public Dictionary<string, string> LabelsAndValues { get; set; } = new();

    /// <summary>
    /// Creates a new <see cref="BoxTagHelper"/>.
    /// </summary>
    /// <param name="BoxHtmlGenerator">The service that generates Smart Design box with labels and values.</param>
    public BoxTagHelper(IBoxHtmlGenerator BoxHtmlGenerator)
    {
        _BoxHtmlGenerator = BoxHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (string.IsNullOrEmpty(TitleLabel))
        {
            throw new ArgumentException($"{nameof(TitleLabel)} cannot be empty");
        }
        if (string.IsNullOrEmpty(Title))
        {
            throw new ArgumentException($"{nameof(Title)} cannot be empty");
        }
        if (!LabelsAndValues.Any())
        {
            throw new ArgumentException($"{nameof(LabelsAndValues)} cannot be null or empty");
        }

        var box = _BoxHtmlGenerator.GenerateListOfItems(TitleLabel, Title, Subtitle, LabelsAndValues);
        output.MergeAttributes(box);
        output.TagName = box.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(box.InnerHtml);
    }
}
