using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Elements.HorizontalRule;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart design &lt;hr /&gt; element.
/// </summary>
[HtmlTargetElement(TagNames.HorizontalRuleTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class HorizontalRuleTagHelper : TagHelper
{
    private readonly IHorizontalRuleHtmlGenerator _htmlGenerator;

    /// <summary>
    /// Creates a new <see cref="HorizontalRuleTagHelper"/>.
    /// </summary>
    /// <param name="htmlGenerator">The <see cref="IHorizontalRuleHtmlGenerator"/>.</param>
    public HorizontalRuleTagHelper(IHorizontalRuleHtmlGenerator htmlGenerator)
    {
        _htmlGenerator = htmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var hr = _htmlGenerator.GenerateHorizontalRule();
        output.TagName = hr.TagName;
        output.TagMode = TagMode.SelfClosing;
        output.MergeAttributes(hr);
    }
}
