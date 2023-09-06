using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    /// <summary>
    /// Get or sets the <see cref="Microsoft.AspNetCore.Mvc.Rendering.ViewContext"/> of the executing view.
    /// </summary>
    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext? ViewContext { get; set; }

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
        base.Process(context, output);

        var inputNumber = _smartHtmlGenerator.GenerateInputNumber(ViewContext, Id, Name, Value,Placeholder, For);

        output.TagName = inputNumber.TagName;
        output.TagMode = TagMode.SelfClosing;

        output.ClearAllAttributes();
        output.MergeAttributes(inputNumber);
    }
}
