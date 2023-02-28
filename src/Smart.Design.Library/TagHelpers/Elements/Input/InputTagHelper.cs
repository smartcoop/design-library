using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;

namespace Smart.Design.Library.TagHelpers.Elements.Input;

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

    /// <summary>
    /// HTML Value of the Input.
    /// </summary>
    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    /// <summary>
    /// Associated <see cref="ModelExpression"/> with the Input.
    /// </summary>
    [HtmlAttributeName(AspForNameAttribute)]
    public ModelExpression? For { get; set; }

    /// <summary>
    /// Creates a new <see cref="InputTagHelper"/>.
    /// </summary>
    /// <param name="inputHtmlGenerator"></param>
    public InputTagHelper(IInputHtmlGenerator inputHtmlGenerator)
    {
        _inputHtmlGenerator = inputHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        var input = _inputHtmlGenerator.GenerateInputText(ViewContext, Id, Name, Placeholder, Value, For);

        output.TagName = input.TagName;
        output.MergeAttributes(input);
        output.TagMode = TagMode.SelfClosing;
    }
}
