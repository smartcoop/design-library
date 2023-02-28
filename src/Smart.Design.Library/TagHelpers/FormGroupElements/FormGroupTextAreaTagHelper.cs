using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Elements.Textarea;
using Smart.Design.Library.TagHelpers.ValidationMessage;

namespace Smart.Design.Library.TagHelpers.FormGroupElements;

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

    public FormGroupTextAreaTagHelper(IFormGroupHtmlGenerator htmlGenerator,
        IValidationMessageHtmlGenerator validationMessageHtmlGenerator,
        ITextareaHtmlGenerator textareaHtmlGenerator) : base(htmlGenerator, validationMessageHtmlGenerator)
    {
        _textareaHtmlGenerator = textareaHtmlGenerator;
    }

    public override TagBuilder GenerateFormGroupControl()
    {
        return _textareaHtmlGenerator.GenerateSmartTextArea(ViewContext, Id, Name, Rows, TextareaSize, For);
    }
}
