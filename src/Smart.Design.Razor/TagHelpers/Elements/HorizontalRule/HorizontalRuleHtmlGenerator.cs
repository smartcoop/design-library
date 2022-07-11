using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Elements.HorizontalRule;

/// <summary>
/// Generates HTML for Smart Design Horizontal Rules.
/// </summary>
public class HorizontalRuleHtmlGenerator : IHorizontalRuleHtmlGenerator
{

    /// <inheritdoc />
    public TagBuilder GenerateHorizontalRule()
    {
        var hr = new TagBuilder("hr");
        hr.AddCssClass("c-hr");
        return hr;
    }
}
