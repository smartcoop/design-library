using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.Extensions;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Elements.Checkbox;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart design checkbox.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-checkbox.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.CheckboxTagName)]
public class CheckboxTagHelper : BaseTagHelper
{
    private const string AspForNameAttribute   = "asp-for";
    private const string CheckedAttributeName  = "checked";
    private const string DisabledAttributeName = "disabled";
    private const string LabelAttributeName    = "label";
    private const string ValueAttributeName    = "value";

    private readonly ICheckboxHtmlGenerator _checkboxHtmlGenerator;

    /// <summary>
    /// Determines if the checkbox is checked.
    /// </summary>
    [HtmlAttributeName(CheckedAttributeName)]
    public bool Checked { get; set; }

    /// <summary>
    /// Determines if the checkbox is disabled.
    /// </summary>
    [HtmlAttributeName(DisabledAttributeName)]
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the label of the checkbox.
    /// </summary>
    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the value of the checkbox.
    /// </summary>
    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    /// <summary>
    /// <see cref="ModelExpression"/> for the tag helper.
    /// </summary>
    [HtmlAttributeName(AspForNameAttribute)]
    public ModelExpression? For { get; set; }

    /// <summary>
    /// Creates a new <see cref="CheckboxTagHelper"/>.
    /// </summary>
    /// <param name="checkboxHtmlGenerator">The <see cref="ICheckboxHtmlGenerator"/>.</param>
    public CheckboxTagHelper(ICheckboxHtmlGenerator checkboxHtmlGenerator)
    {
        _checkboxHtmlGenerator = checkboxHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var attributeObjects = this.ListUndefinedTagHelperAttributes(context);
        var inputCheckbox = _checkboxHtmlGenerator.GenerateCheckbox(Id, Name, Value, Label, Disabled, Checked, For, attributeObjects);

        output.TagName = inputCheckbox.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAllAttributes();
        output.MergeAttributes(inputCheckbox);

        output.Content.SetHtmlContent(inputCheckbox.InnerHtml);
    }
}
