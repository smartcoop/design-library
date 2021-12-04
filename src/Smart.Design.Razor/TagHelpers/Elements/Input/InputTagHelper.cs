using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Elements.Input;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart design &lt;input&gt; with <c>asp-for</c>, <c>placeholder</c>, <c>value</c> attributes.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-input.html">here</see>.
/// <para>
/// <term>Remark</term>This class inherits from <see cref="BaseTagHelper" />
/// </para>
/// </summary>
[HtmlTargetElement(TagNames.InputTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class InputTagHelper : BaseTagHelper
{
    private const string AspForNameAttribute = "asp-for";
    private const string PlaceholderAttributeName = "placeholder";
    private const string ValueAttributeName = "value";

    private readonly IInputHtmlGenerator _inputHtmlGenerator;

    [HtmlAttributeName(PlaceholderAttributeName)]
    public string? Placeholder { get; set; }

    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    [HtmlAttributeName(AspForNameAttribute)]
    public ModelExpression? For { get; set; }

    public InputTagHelper(IInputHtmlGenerator inputHtmlGenerator)
    {
        _inputHtmlGenerator = inputHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        var input = _inputHtmlGenerator.GenerateInputText(ViewContext, Id, Name, Placeholder, Value, For);

        output.TagName = input.TagName;
        output.MergeAttributes(input);
        output.TagMode = TagMode.SelfClosing;
    }
}
