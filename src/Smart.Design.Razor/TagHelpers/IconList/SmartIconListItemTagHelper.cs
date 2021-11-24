using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.IconList
{
    [HtmlTargetElement(TagNames.SmartIconListItemTagName, ParentTag = TagNames.SmartIconListTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SmartIconListItemTagHelper : TagHelper
    {
        private const string IconAttributeName = "icon";
        private const string LabelAttributeName = "label";

        private readonly ISmartIconListHtmlGenerator _smartIconListHtmlGenerator;

        [HtmlAttributeName(IconAttributeName)]
        public Icon Icon { get; set; }

        [HtmlAttributeName(LabelAttributeName)]
        public string Label { get; set; }

        public SmartIconListItemTagHelper(ISmartIconListHtmlGenerator smartIconListHtmlGenerator)
        {
            _smartIconListHtmlGenerator = smartIconListHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var iconListItem = _smartIconListHtmlGenerator.GenerateIconListItem(Icon, Label);

            output.TagMode = TagMode.StartTagAndEndTag;
            output.ClearAndMergeAttributes(iconListItem);
            output.Content.SetHtmlContent(iconListItem.InnerHtml);
        }
    }
}
