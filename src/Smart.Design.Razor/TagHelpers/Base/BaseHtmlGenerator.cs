using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Razor.TagHelpers.Base;

public class BaseHtmlGenerator
{
    protected string? GetAttributeName(string? name, ModelExpression? modelExpression)
    {
        return !string.IsNullOrWhiteSpace(modelExpression?.Name) ? modelExpression.Name : name;
    }
}
