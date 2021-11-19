using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Elements
{
    [HtmlTargetElement(TagNames.SmartTextareaTagName)]
    public class SmartTextareaTagHelper : BaseTagHelper
    {
        private const string AspForNameAttribute = "asp-for";
        private const string RowsAttributeName = "rows";
        private const string TextareaSizeAttributeName = "textarea-size";

        [HtmlAttributeName(RowsAttributeName)]
        public int? Rows { get; set; }

        [HtmlAttributeName(TextareaSizeAttributeName)]
        public TextAreaSize TextareaSize { get; set; }

        [HtmlAttributeName(AspForNameAttribute)]
        public ModelExpression For { get; set; }

        public SmartTextareaTagHelper(ISmartHtmlGenerator smartHtmlGenerator) : base(smartHtmlGenerator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var textarea = HtmlGenerator.GenerateSmartTextArea(Id, Name, Rows, TextareaSize, For);

            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = textarea.TagName;

            output.ClearAndMergeAttributes(textarea);

            if (textarea.HasInnerHtml)
            {
                output.Content.SetHtmlContent(textarea.InnerHtml);
            }
        }
    }
}
