using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.FormGroup;

[HtmlTargetElement(TagNames.FormGroupTagName)]
public class FormGroupTagHelper : TagHelper
{
    private readonly IFormGroupHtmlGenerator _formGroupHtmlGenerator;
    private const string LabelAttributeName = "label";
    private const string HelperTextAttributeName = "helper-text";

    [HtmlAttributeName(HelperTextAttributeName)]
    public string? HelperText { get; set; }

    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    public FormGroupTagHelper(IFormGroupHtmlGenerator formGroupHtmlGenerator)
    {
        _formGroupHtmlGenerator = formGroupHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.ClearAllAttributes();
        output.TagMode = TagMode.StartTagAndEndTag;

        var formGroup = _formGroupHtmlGenerator.GenerateFormGroup();

        output.MergeAttributes(formGroup);

        output.PreContent.SetHtmlContent(_formGroupHtmlGenerator.GenerateFormGroupLabel(Label, null));
        output.PostContent.SetHtmlContent(_formGroupHtmlGenerator.GenerateFormGroupHelperText(HelperText!));
    }
}
