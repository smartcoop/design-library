using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.FormGroup
{
    [HtmlTargetElement(TagNames.FormGroupControlsTagName, ParentTag = TagNames.FormGroupTagName)]
    public class SmartFormGroupControlsTagHelpers : TagHelper
    {
        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        public SmartFormGroupControlsTagHelpers(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var formGroupControls = _smartHtmlGenerator.GenerateFormGroupControlsContainer();
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = formGroupControls.TagName;

            output.ClearAndMergeAttributes(formGroupControls);
        }
    }
}