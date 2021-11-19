using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Toolbar
{
    /// <summary>
    /// <see cref="ITagHelper"/> implementation of the smart design button toolbar.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-button-toolbar.html">here</see>
    /// </summary>
    [HtmlTargetElement(TagNames.SmartButtonToolbarTagName)]
    public class SmartButtonToolbarTagHelper : TagHelper
    {
        private const string LayoutAttributeName = "layout";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(LayoutAttributeName)]
        public ButtonToolbarLayout Layout { get; set; }

        public bool IsCompact { get; set; }

        public SmartButtonToolbarTagHelper (ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var toolbar = _smartHtmlGenerator.GenerateSmartButtonToolbar(Layout, IsCompact);

            output.TagName = toolbar.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Clear();
            output.MergeAttributes(toolbar);
        }
    }
}
