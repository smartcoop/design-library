using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.FormGroupElements
{
    /// <summary>
    /// <see cref="BaseSmartFormGroupTagHelper"/> implementation with a <see cref="SmartTextareaTagHelper" />.    /// </summary>
    [HtmlTargetElement(TagNames.SmartFormGroupTextArea)]
    public class SmartFormGroupTextAreaTagHelper : BaseSmartFormGroupTagHelper
    {
        private const string RowsAttributeName = "rows";
        private const string SizeAttributeName = "size";

        public SmartFormGroupTextAreaTagHelper(ISmartHtmlGenerator htmlGenerator) : base(htmlGenerator)
        {
        }

        [HtmlAttributeName(SizeAttributeName)] public TextAreaSize TextareaSize { get; set; }

        /// <summary>
        ///     Number of textarea rows.
        /// </summary>
        [HtmlAttributeName(RowsAttributeName)]
        public int? Rows { get; set; }

        public override TagBuilder GenerateFormGroupControl()
        {
            return HtmlGenerator.GenerateSmartTextArea(Id, Name, Rows, TextareaSize, For);
        }
    }
}
