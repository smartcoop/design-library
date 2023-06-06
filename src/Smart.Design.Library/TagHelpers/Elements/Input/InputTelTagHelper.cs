using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Extensions;
using TagNames = Smart.Design.Library.TagHelpers.Constants.TagNames;

namespace Smart.Design.Library.TagHelpers.Elements.Input;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart Input tel.
/// </summary>
[HtmlTargetElement(TagNames.InputTelName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class InputTelTagHelper: BaseTagHelper
{
    private const string AspForAttributeName = "asp-for";
    private const string PlaceholderAttributeName = "placeholder";
    private const string ValueAttributeName = "value";
    private const string PhoneTypeAttributeName = "phoneType";

    private readonly IInputHtmlGenerator _inputHtmlGenerator;

    /// <summary>
    /// Associated <see cref="ModelExpression"/> with the Input.
    /// </summary>
    [HtmlAttributeName(AspForAttributeName)]
    public ModelExpression? For { get; set; }

    /// <summary>
    /// HTML Value of the Input.
    /// </summary>
    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    /// <summary>
    /// HTML placeboder of the value of the Input.
    /// </summary>
    [HtmlAttributeName(PlaceholderAttributeName)]
    public string? Placeholder { get; set; }

    /// <summary>
    /// Phone type is the type of the phone you want. Fix or mobile.
    /// </summary>
    [HtmlAttributeName(PhoneTypeAttributeName)]
    public PhoneType? PhoneType { get; set; }


    /// <summary>
    /// Creates a new <see cref="InputTelTagHelper"/>.
    /// </summary>
    /// <param name="smartHtmlGenerator">The <see cref="IInputHtmlGenerator"/>.</param>
    public InputTelTagHelper(IInputHtmlGenerator smartHtmlGenerator)
    {
        _inputHtmlGenerator = smartHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        var input = _inputHtmlGenerator.GenerateInputTel(ViewContext, Id, Name, Placeholder, Value, PhoneType, For);

        output.ClearAndMergeAttributes(input);
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = input.TagName;
        output.Content.SetHtmlContent(input.InnerHtml);
    }
}
