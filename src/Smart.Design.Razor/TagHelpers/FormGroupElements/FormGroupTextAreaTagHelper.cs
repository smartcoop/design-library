using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Elements.Textarea;

namespace Smart.Design.Razor.TagHelpers.FormGroupElements;

/// <summary>
/// <see cref="BaseSmartFormGroupTagHelper"/> implementation with a <see cref="TextareaTagHelper" />.
/// </summary>
[HtmlTargetElement(Constants.TagNames.FormGroupTextArea)]
public class FormGroupTextAreaTagHelper : BaseSmartFormGroupTagHelper
{
    private readonly ITextareaHtmlGenerator _textareaHtmlGenerator;
    private const string RowsAttributeName = "rows";
    private const string SizeAttributeName = "size";

    [HtmlAttributeName(SizeAttributeName)]
    public TextAreaSize TextareaSize { get; set; }

    /// <summary>
    /// Number of textarea rows.
    /// </summary>
    [HtmlAttributeName(RowsAttributeName)]
    public int? Rows { get; set; }

    public FormGroupTextAreaTagHelper(IFormGroupHtmlGenerator htmlGenerator, ITextareaHtmlGenerator textareaHtmlGenerator) : base(htmlGenerator)
    {
        _textareaHtmlGenerator = textareaHtmlGenerator;
    }

    public override TagBuilder GenerateFormGroupControl()
    {
        return _textareaHtmlGenerator.GenerateSmartTextArea(Id, Name, Rows, TextareaSize, For);
    }
}
