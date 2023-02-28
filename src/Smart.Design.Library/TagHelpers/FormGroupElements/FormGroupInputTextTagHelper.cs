using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Elements.Input;
using Smart.Design.Library.TagHelpers.ValidationMessage;
using TagNames = Smart.Design.Library.TagHelpers.Constants.TagNames;

namespace Smart.Design.Library.TagHelpers.FormGroupElements;

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

    public FormGroupInputTextTagHelper(IFormGroupHtmlGenerator htmlGenerator,
        IValidationMessageHtmlGenerator validationMessageHtmlGenerator,
        IInputHtmlGenerator inputHtmlGenerator) : base(htmlGenerator, validationMessageHtmlGenerator)
    {
        _inputHtmlGenerator = inputHtmlGenerator;
    }

    public override TagBuilder GenerateFormGroupControl()
    {
        return _inputHtmlGenerator.GenerateInputText(ViewContext, Id, Name, PlaceHolder, Value, For);
    }
}
