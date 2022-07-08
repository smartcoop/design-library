using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.ValidationMessage;

namespace Smart.Design.Razor.TagHelpers.Base;

/// <summary>
/// Abstract base class <see cref="ITagHelper" /> to render Smart design form groups with asp-for, helper-text , label, value, value attributes.
/// Inheriting this class imposes to implement the content of the form group control(s) programatically.
/// More information can be see <see href="https://design.smart.coop/development/docs/o-form-group.html">here</see>.
/// </summary>
[HtmlTargetElement(TagStructure = TagStructure.NormalOrSelfClosing)]
public abstract class BaseSmartFormGroupTagHelper : BaseTagHelper
{
    private const string ForAttributeName = "asp-for";
    private const string HelperTextAttributeName = "helper-text";
    private const string LabelAttributeName = "label";
    private const string ValueAttributeName = "value";

    private readonly IValidationMessageHtmlGenerator _validationMessageHtmlGenerator;

    protected readonly IFormGroupHtmlGenerator FormGroupHtmlGenerator;

    [HtmlAttributeName(HelperTextAttributeName)]
    public string? HelperText { get; set; }

    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    [HtmlAttributeName(ForAttributeName)]
    public ModelExpression? For { get; set; }

    public abstract TagBuilder GenerateFormGroupControl();

    protected BaseSmartFormGroupTagHelper(IFormGroupHtmlGenerator formGroupHtmlGenerator, IValidationMessageHtmlGenerator validationMessageHtmlGenerator)
    {
        _validationMessageHtmlGenerator = validationMessageHtmlGenerator;
        FormGroupHtmlGenerator      = formGroupHtmlGenerator;
    }

    public override void Init(TagHelperContext context)
    {
        if (string.IsNullOrWhiteSpace(Id))
        {
            Id = context.UniqueId;
        }

        if (!string.IsNullOrWhiteSpace(For?.Name))
        {
            Name = For.Name;
        }
        else if (string.IsNullOrWhiteSpace(Name))
        {
            Name = Id;
        }
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var formGroupControl = GenerateFormGroupControl();

        var formGroup = FormGroupHtmlGenerator.GenerateFormGroup(Id, Name, Label, HelperText, formGroupControl);

        // Retrieves from ModelState potential errors and append them to the form group if there are any.
        var validationMessages = _validationMessageHtmlGenerator.GenerateValidationMessage(ViewContext!, For);

        if (validationMessages is not null)
        {
            formGroup.InnerHtml.AppendHtml(validationMessages);
        }
        output.Attributes.Clear();
        output.TagName = formGroup.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.MergeAttributes(formGroup);

        output.Content.SetHtmlContent(formGroup.InnerHtml);
    }
}
