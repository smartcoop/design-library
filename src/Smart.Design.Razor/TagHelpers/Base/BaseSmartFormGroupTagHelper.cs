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

    /// <summary>
    /// The <see cref="IFormGroupHtmlGenerator"/> used by <see cref="BaseSmartFormGroupTagHelper"/>.
    /// It is exposed to classes inheriting from <see cref="BaseSmartFormGroupTagHelper"/>.
    /// </summary>
    protected readonly IFormGroupHtmlGenerator FormGroupHtmlGenerator;

    /// <summary>
    /// Form group helper text.
    /// </summary>
    [HtmlAttributeName(HelperTextAttributeName)]
    public string? HelperText { get; set; }

    /// <summary>
    /// Form group's label.
    /// </summary>
    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    /// <summary>
    /// Form group value.
    /// </summary>
    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    /// <summary>
    /// ModelExpression for the tag helper.
    /// </summary>
    [HtmlAttributeName(ForAttributeName)]
    public ModelExpression? For { get; set; }

    /// <summary>
    /// Generates the HTML to be put inside the from group controls &lt;div&gt;.
    /// </summary>
    /// <returns>The HTML to be put inside the from group controls &lt;div&gt;.</returns>
    public abstract TagBuilder GenerateFormGroupControl();

    /// <summary>
    /// Creates a new <see cref="BaseSmartFormGroupTagHelper"/>?
    /// </summary>
    /// <param name="formGroupHtmlGenerator"></param>
    /// <param name="validationMessageHtmlGenerator"></param>
    protected BaseSmartFormGroupTagHelper(IFormGroupHtmlGenerator formGroupHtmlGenerator, IValidationMessageHtmlGenerator validationMessageHtmlGenerator)
    {
        _validationMessageHtmlGenerator = validationMessageHtmlGenerator;
        FormGroupHtmlGenerator = formGroupHtmlGenerator;
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
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
