using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Elements.Textarea;

[HtmlTargetElement(TagNames.TextareaTagName)]
public class TextareaTagHelper : BaseTagHelper
{
    private readonly ITextareaHtmlGenerator _textareaHtmlGenerator;
    private const string AspForNameAttribute = "asp-for";
    private const string RowsAttributeName = "rows";
    private const string TextareaSizeAttributeName = "textarea-size";

    [HtmlAttributeName(RowsAttributeName)]
    public int? Rows { get; set; }

    [HtmlAttributeName(TextareaSizeAttributeName)]
    public TextAreaSize TextareaSize { get; set; }

    [HtmlAttributeName(AspForNameAttribute)]
    public ModelExpression? For { get; set; }

    public TextareaTagHelper(ITextareaHtmlGenerator textareaHtmlGenerator)
    {
        _textareaHtmlGenerator = textareaHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.ClearAllAttributes();

        var textarea = _textareaHtmlGenerator.GenerateSmartTextArea(Id, Name, Rows, TextareaSize, For);

        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = textarea.TagName;

        output.MergeAttributes(textarea);

        if (textarea.HasInnerHtml)
        {
            output.Content.SetHtmlContent(textarea.InnerHtml);
        }
    }
}
