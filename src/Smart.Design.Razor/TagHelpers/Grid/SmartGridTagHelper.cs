using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Grid
{
    /// <summary>
    /// <see cref="ITagHelper"/> implementation of the smart design grid.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartGridTagName)]
    public class SmartGridTagHelper : TagHelper
    {
        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        public SmartGridTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var grid = _smartHtmlGenerator.GenerateSmartGrid();

            output.TagName = grid.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAndMergeAttributes(grid);
        }
    }
}
