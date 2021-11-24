using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.IconList
{
    /// <summary>
    /// Implementation of an smart design icon list.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-icon-list.html">here</see>.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartIconListTagName)]
    public class SmartIconListTagHelper : TagHelper
    {
        private readonly ISmartIconListHtmlGenerator _smartIconListHtmlGenerator;

        public SmartIconListTagHelper(ISmartIconListHtmlGenerator smartIconListHtmlGenerator)
        {
            _smartIconListHtmlGenerator = smartIconListHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var iconList = _smartIconListHtmlGenerator.GenerateIconList();

            output.ClearAllAttributes();
            output.TagName = "ul";
            output.AddClass("c-icon-list", HtmlEncoder.Default);
        }
    }
}
