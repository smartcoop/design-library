using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Icon;
using Smart.Design.Library.TagHelpers.InputGroup;
using Smart.Design.Library.TagHelpers.ValidationMessage;
using TagNames = Smart.Design.Library.TagHelpers.Constants.TagNames;

namespace Smart.Design.Library.TagHelpers.FormGroupElements;

/// <summary>
/// <see cref="BaseSmartFormGroupTagHelper"/> implementation with a <see cref="FormGroupInputGroup" />.
/// </summary>
[HtmlTargetElement(TagNames.FormGroupInputGroupTagName)]
public class FormGroupInputGroup : BaseSmartFormGroupTagHelper
{
    private readonly IInputGroupHtmlGenerator _inputGroupHtmlGenerator;
    private const string AlignmentAttributeName = "alignment";
    private const string GroupedTextAttributeName = "grouped-text";
    private const string IconAttributeName = "icon";
    private const string PlaceholderAttributeName = "placeholder";

    [HtmlAttributeName(PlaceholderAttributeName)]
    public string? Placeholder { get; set; }

    [HtmlAttributeName(IconAttributeName)]
    public Image.Image Icon { get; set; }

    [HtmlAttributeName(GroupedTextAttributeName)]
    public string? GroupedText { get; set; }

    [HtmlAttributeName(AlignmentAttributeName)]
    public Alignment Alignment { get; set; }

    public FormGroupInputGroup(IFormGroupHtmlGenerator htmlGenerator,
        IValidationMessageHtmlGenerator validationMessageHtmlGenerator,
        IInputGroupHtmlGenerator inputGroupHtmlGenerator) : base(htmlGenerator, validationMessageHtmlGenerator)
    {
        _inputGroupHtmlGenerator = inputGroupHtmlGenerator;
    }

    public override void Init(TagHelperContext context)
    {
        base.Init(context);

        if (!string.IsNullOrWhiteSpace(GroupedText) && Icon != Image.Image.None)
        {
            throw new InvalidOperationException("input group cannot have and icon and a grouped text set");
        }
    }

    public override TagBuilder GenerateFormGroupControl()
    {
        return _inputGroupHtmlGenerator.GenerateInputGroup(ViewContext, Id, Name, Placeholder, Value, For, Alignment, Icon, GroupedText);
    }
}
