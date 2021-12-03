using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Elements.Checkbox;

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

    [HtmlAttributeName(CheckedAttributeName)]
    public bool Checked { get; set; }

    [HtmlAttributeName(DisabledAttributeName)]
    public bool Disabled { get; set; }

    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    [HtmlAttributeName(AspForNameAttribute)]
    public ModelExpression? For { get; set; }

    public CheckboxTagHelper(ICheckboxHtmlGenerator checkboxHtmlGenerator)
    {
        _checkboxHtmlGenerator = checkboxHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var inputCheckbox = _checkboxHtmlGenerator.GenerateCheckbox(Id, Name, Value, Label, Disabled, Checked, For);

        output.TagName = inputCheckbox.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAllAttributes();
        output.MergeAttributes(inputCheckbox);

        output.Content.SetHtmlContent(inputCheckbox.InnerHtml);
    }
}
