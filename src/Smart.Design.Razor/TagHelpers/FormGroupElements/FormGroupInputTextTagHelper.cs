using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Elements.Input;

namespace Smart.Design.Razor.TagHelpers.FormGroupElements;

/// <summary>
/// <see cref="BaseSmartFormGroupTagHelper" /> implementation with a <see cref="FormGroupInputTextTagHelper" />.
/// </summary>
[HtmlTargetElement(TagNames.FormGroupInputTextTagName)]
public class FormGroupInputTextTagHelper : BaseSmartFormGroupTagHelper
{
    private readonly IInputHtmlGenerator _inputHtmlGenerator;
    private const string PlaceHolderAttributeName = "placeholder";

    [HtmlAttributeName(PlaceHolderAttributeName)]
    public string? PlaceHolder { get; set; }

    public FormGroupInputTextTagHelper(IFormGroupHtmlGenerator htmlGenerator, IInputHtmlGenerator inputHtmlGenerator) : base(htmlGenerator)
    {
        _inputHtmlGenerator = inputHtmlGenerator;
    }

    public override TagBuilder GenerateFormGroupControl()
    {
        return _inputHtmlGenerator.GenerateInputText(ViewContext, Id, Name, PlaceHolder, Value, For);
    }
}
