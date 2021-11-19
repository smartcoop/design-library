using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Grid
{
    /// <summary>
    /// <see cref="ITagHelper" /> implementation of a smart design column inside a smart design grid.
    /// The grid component is supposed to be a direct child of the smart grid.
    /// The component has <c>width</c> attributes.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartGridColumnTagName, ParentTag = TagNames.SmartGridTagName)]
    public class SmartGridColumnTagHelper : TagHelper
    {
        private const string WidthAttributeName = "width";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(WidthAttributeName)]
        public int Width { get; set; }

        public SmartGridColumnTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var column = _smartHtmlGenerator.GenerateSmartColumnGrid(Width);
            output.TagName = column.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Clear();
            output.MergeAttributes(column);
        }
    }
}
