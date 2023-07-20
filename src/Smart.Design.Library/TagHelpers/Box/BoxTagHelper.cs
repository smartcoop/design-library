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
    /// The label of title
    /// </summary>
    public string LabelTitle { get; set; } = null!;

    /// <summary>
    /// The title
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// The sub title
    /// </summary>
    public string? SubTitle { get; set; }

    /// <summary>
    /// Dictionnary of label and Value items for the box
    /// </summary>
    public Dictionary<string, string> LabelAndValues { get; set; } = new();

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
        if (string.IsNullOrEmpty(LabelTitle))
        {
            throw new ArgumentException($"{nameof(LabelTitle)} cannot be empty");
        }
        if (string.IsNullOrEmpty(Title))
        {
            throw new ArgumentException($"{nameof(Title)} cannot be empty");
        }
        if (!LabelAndValues.Any())
        {
            throw new ArgumentException($"{nameof(LabelAndValues)} cannot be null or empty");
        }

        var box = _BoxHtmlGenerator.GenerateListOfItems(LabelTitle, Title, SubTitle, LabelAndValues);
        output.MergeAttributes(box);
        output.TagName = box.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(box.InnerHtml);
    }
}
