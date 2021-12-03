using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Elements.HorizontalRule;

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
