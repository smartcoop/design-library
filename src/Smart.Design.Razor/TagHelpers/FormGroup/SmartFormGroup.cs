using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.FormGroup
{
    [HtmlTargetElement(TagNames.FormGroupTagName)]
    public class SmartFormGroupTagHelper : TagHelper
    {
        private const string LabelAttributeName = "label";
        private const string HelperTextAttributeName = "helper-text";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(HelperTextAttributeName)]
        public string HelperText { get; set; }

        [HtmlAttributeName(LabelAttributeName)]
        public string Label { get; set; }

        public SmartFormGroupTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;

            var formGroup = _smartHtmlGenerator.GenerateFormGroup();

            output.ClearAndMergeAttributes(formGroup);

            output.PreContent.SetHtmlContent(_smartHtmlGenerator.GenerateFormGroupLabel(Label, null));
            output.PostContent.SetHtmlContent(_smartHtmlGenerator.GenerateFormGroupHelperText(HelperText));
        }
    }
}
