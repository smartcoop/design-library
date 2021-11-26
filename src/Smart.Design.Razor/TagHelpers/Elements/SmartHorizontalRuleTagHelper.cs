using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Elements
{
    /// <summary>
    /// <see cref="ITagHelper" /> implementation of the smart design &lt;hr /&gt; element.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartHorizontalRuleTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SmartHorizontalRuleTagHelper : TagHelper
    {
        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        public SmartHorizontalRuleTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var hr = _smartHtmlGenerator.GenerateHorizontalRule();
            output.TagName = hr.TagName;
            output.TagMode = TagMode.SelfClosing;
            output.ClearAndMergeAttributes(hr);
        }
    }
}
