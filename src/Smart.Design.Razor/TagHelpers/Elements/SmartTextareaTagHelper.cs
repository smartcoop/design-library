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

        public SmartTextareaTagHelper(ISmartHtmlGenerator smartHtmlGenerator) : base(smartHtmlGenerator)
        {
        }

        [HtmlAttributeName(RowsAttributeName)] public int? Rows { get; set; }

        [HtmlAttributeName(TextareaSizeAttributeName)]
        public TextAreaSize TextareaSize { get; set; }

        [HtmlAttributeName(AspForNameAttribute)]
        public ModelExpression For { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.ClearAllAttributes();

            var directContent = await output.GetChildContentAsync();

            var textarea = HtmlGenerator.GenerateSmartTextArea(Id, Name, directContent, Rows, TextareaSize, For);

            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = textarea.TagName;

            output.MergeAttributes(textarea);
            output.Content.SetHtmlContent(textarea.InnerHtml);
        }
    }
}
