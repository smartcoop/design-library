using System;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.InputGroup;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart Design Input Group.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-input-group.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.InputGroupTagName)]
public class InputGroupTagHelper : BaseTagHelper
{
    private readonly IInputGroupHtmlGenerator _inputGroupHtmlGenerator;
    private const string AlignmentAttributeName = "align";
    private const string ForAttributeName = "asp-for";
    private const string GroupedTextAttributeName = "grouped-text";
    private const string IconAttributeName = "icon";
    private const string PlaceholderAttributeName = "placeholder";
    private const string ValueAttributeName = "value";

    /// <summary>
    /// Creates a new <see cref="InputGroupTagHelper"/>.
    /// </summary>
    /// <param name="inputGroupHtmlGenerator"></param>
    public InputGroupTagHelper(IInputGroupHtmlGenerator inputGroupHtmlGenerator)
    {
        _inputGroupHtmlGenerator = inputGroupHtmlGenerator;
    }
    /// <summary>
    /// Alignment of the grouped text/icon.
    /// </summary>
    [HtmlAttributeName(AlignmentAttributeName)]
    public Alignment Alignment { get; set; }

    /// <summary>
    /// <see cref="ModelExpression"/> associated with <see cref="InputGroupTagHelper"/>.
    /// </summary>
    [HtmlAttributeName(ForAttributeName)]
    public ModelExpression? For { get ; set ; }

    /// <summary>
    /// Text of the Input group.
    /// </summary>
    [HtmlAttributeName(GroupedTextAttributeName)]
    public string? GroupedText { get; set; }

    /// <summary>
    /// Icon of the Input group.
    /// </summary>
    [HtmlAttributeName(IconAttributeName)]
    public Image.Image Icon { set; get; }

    /// <summary>
    /// Placeholder of the input group.
    /// </summary>
    [HtmlAttributeName(PlaceholderAttributeName)]
    public string? Placeholder { get; set; }

    /// <summary>
    /// Value of the input group.
    /// </summary>
    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!string.IsNullOrWhiteSpace(GroupedText) && Icon != Image.Image.None)
        {
            throw new InvalidOperationException("input group cannot have and icon and a grouped text set");
        }

        var inputGroup = _inputGroupHtmlGenerator.GenerateInputGroup(
            viewContext: ViewContext,
            id: Id,
            name: Name,
            placeholder: Placeholder,
            value: Value,
            @for: For,
            alignment: Alignment,
            icon: Icon,
            text: GroupedText);

        output.ClearAllAttributes();
        output.TagName = inputGroup.TagName;
        output.MergeAttributes(inputGroup);
        output.TagMode = TagMode.StartTagAndEndTag;

        output.Content.SetHtmlContent(inputGroup.InnerHtml);
    }
}
