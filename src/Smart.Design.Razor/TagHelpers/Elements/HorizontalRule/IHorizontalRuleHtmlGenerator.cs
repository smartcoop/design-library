using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Elements.HorizontalRule;

/// <summary>
/// Contract to generates horizontal rule HTMl.
/// </summary>
public interface IHorizontalRuleHtmlGenerator
{

    /// <summary>
    /// Generate a &lt;hr&gt; that is compliant with Smart design
    /// More information can be seen <see href="https://sesign.smart.coop">here</see>.
    /// </summary>
    /// <returns></returns>
    TagBuilder GenerateHorizontalRule();
}
