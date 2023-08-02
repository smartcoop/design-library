using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Elements.Input;

[HtmlTargetElement(TagNames.InputNumberTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class InputNumberTagHelper : BaseTagHelper
{
    private readonly IInputHtmlGenerator _smartHtmlGenerator;
    private const string AspForAttributeName = "asp-for";
    private const string ValueAttributeName = "value";
    private const string PlaceholderAttributeName = "placeholder";

    [HtmlAttributeName(AspForAttributeName)]
    public ModelExpression? For { get; set; }

    [HtmlAttributeName(ValueAttributeName)]
    public double? Value { get; set; }

    [HtmlAttributeName(PlaceholderAttributeName)]
    public string? Placeholder { get; set; }

    public InputNumberTagHelper(IInputHtmlGenerator smartHtmlGenerator)
    {
        _smartHtmlGenerator = smartHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var inputNumber = _smartHtmlGenerator.GenerateInputNumber(Id, Name, Value,Placeholder, For);
        output.TagName = inputNumber.TagName;
        output.TagMode = TagMode.SelfClosing;
        output.ClearAllAttributes();
        output.MergeAttributes(inputNumber);
    }
}
