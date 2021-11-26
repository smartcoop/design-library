using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Card
{
    [HtmlTargetElement(TagNames.SmartElevatedCardTagName)]
    public class SmartElevatedCard : TagHelper
    {
        private const string ElevationAttributeName = "elevation";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(ElevationAttributeName)]
        public ElevationSize Elevation { get; set; } = ElevationSize.Medium;

        public SmartElevatedCard(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var elevator = _smartHtmlGenerator.GenerateElevation(Elevation);

            output.TagName = elevator.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAndMergeAttributes(elevator);
        }
    }
}
