using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Containers
{
    /// <summary>
    /// <see cref="ITagHelper" /> implementation of a smart design &lt;form&gt;.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartFormAttributeName)]
    public class SmartFormTagHelper : TagHelper
    {
        private const string LayoutAttributeName = "layout";

        private readonly ISmartHtmlGenerator _generator;
        private readonly IHtmlGenerator _htmlGenerator;

        [HtmlAttributeName(LayoutAttributeName)]
        public FormLayout Layout {get; set;}

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public SmartFormTagHelper(ISmartHtmlGenerator generator, IHtmlGenerator htmlGenerator)
        {
            _generator = generator;
            _htmlGenerator = htmlGenerator;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // The framework checks if the form is sending an antiforgery token upon posting.
            // Therefore we need to generate one.
            var generateAntiforgery = _htmlGenerator.GenerateAntiforgery(ViewContext);
            var content = await output.GetChildContentAsync();
            content.AppendHtml(generateAntiforgery);

            var form = _generator.GenerateForm(Layout, content);

            output.MergeAttributes(form);
            output.TagName = form.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(form.InnerHtml);
        }
    }
}
