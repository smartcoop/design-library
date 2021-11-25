using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Elements
{
    /// <summary>
    /// <see cref="ITagHelper" /> implementation of the smart design &lt;input&gt; with <c>asp-for</c>, <c>placeholder</c>, <c>value</c> attributes.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-input.html">here</see>.
    /// <para>
    /// <term>Remark</term>This class inherits from <see cref="BaseTagHelper" />
    /// </para>
    /// </summary>
    [HtmlTargetElement(TagNames.SmartInputTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SmartInputTagHelper : BaseTagHelper
    {
        private const string AspForNameAttribute = "asp-for";
        private const string PlaceholderAttributeName = "placeholder";
        private const string ValueAttributeName = "value";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(PlaceholderAttributeName)]
        public string Placeholder { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        [HtmlAttributeName(AspForNameAttribute)]
        public ModelExpression For { get; set; }

        public SmartInputTagHelper(ISmartHtmlGenerator smartHtmlGenerator) : base(smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            var input = _smartHtmlGenerator.GenerateSmartInputText(ViewContext, Id, Name, Placeholder, Value, For);

            output.TagName = input.TagName;
            output.MergeAttributes(input);
            output.TagMode = TagMode.SelfClosing;
        }
    }
}
