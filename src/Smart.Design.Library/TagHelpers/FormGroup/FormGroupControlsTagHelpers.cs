using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.FormGroup;

[HtmlTargetElement(TagNames.FormGroupControlsTagName, ParentTag = TagNames.FormGroupTagName)]
public class FormGroupControlsTagHelpers : TagHelper
{
    private readonly IFormGroupHtmlGenerator _formGroupHtmlGenerator;

    public FormGroupControlsTagHelpers(IFormGroupHtmlGenerator formGroupHtmlGenerator)
    {
        _formGroupHtmlGenerator = formGroupHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.ClearAllAttributes();
        var formGroupControls = _formGroupHtmlGenerator.GenerateFormGroupControlsContainer();
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = formGroupControls.TagName;

        output.MergeAttributes(formGroupControls);
    }
}
