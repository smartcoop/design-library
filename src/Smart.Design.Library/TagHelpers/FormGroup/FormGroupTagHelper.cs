using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.FormGroup;

[HtmlTargetElement(TagNames.FormGroupTagName)]
public class FormGroupTagHelper : TagHelper
{
    private readonly IFormGroupHtmlGenerator _formGroupHtmlGenerator;
    private const string LabelAttributeName = "label";
    private const string HelperTextAttributeName = "helper-text";
    private const string RequiredAttributeName = "required";

    [HtmlAttributeName(HelperTextAttributeName)]
    public string? HelperText { get; set; }

    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    [HtmlAttributeName(RequiredAttributeName)]
    public bool? Required { get; set; }

    public FormGroupTagHelper(IFormGroupHtmlGenerator formGroupHtmlGenerator)
    {
        _formGroupHtmlGenerator = formGroupHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.ClearAllAttributes();
        var formGroup = _formGroupHtmlGenerator.GenerateFormGroup();
        output.TagName = formGroup.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.MergeAttributes(formGroup);

        output.PreContent.SetHtmlContent(_formGroupHtmlGenerator.GenerateFormGroupLabel(Label, null, Required));

        if (!string.IsNullOrWhiteSpace(HelperText))
        {
            output.PostContent.SetHtmlContent(_formGroupHtmlGenerator.GenerateFormGroupHelperText(HelperText));
        }
    }
}
