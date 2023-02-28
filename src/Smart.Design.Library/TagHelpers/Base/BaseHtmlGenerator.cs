using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Library.TagHelpers.Base;

/// <summary>
/// Base class for HTML generators.
/// </summary>
public class BaseHtmlGenerator
{

    /// <summary>
    /// Sets <see cref="TagBuilder" />'s name depending on the value of <paramref name="modelExpression" /> and <paramref name="name"/>.
    /// If both <paramref name="modelExpression"/> <see cref="ModelExpression.Name"/> and <paramref name="name"/> are empty or null, the attribute is not set.
    /// <see cref="ModelExpression.Name"/> of <paramref name="modelExpression"/> property has precedence over <paramref name="name" />.
    /// </summary>
    /// <param name="tagBuilder">The <see cref="TagBuilder"/> to which attribute name should be set.</param>
    /// <param name="modelExpression">A <see cref="ModelExpression" /> that can be associated to the <paramref name="tagBuilder" /></param>
    /// <param name="name">Value of the name attribute if specified.</param>
    /// <returns>The attribute name of the input if defined.</returns>
    protected string? AddNameAttribute(TagBuilder tagBuilder, ModelExpression? modelExpression, string? name)
    {
        var attributeName = GetAttributeName(name, modelExpression);
        if (!string.IsNullOrWhiteSpace(attributeName))
        {
            tagBuilder.Attributes["name"] = attributeName;
        }

        return attributeName;
    }

    /// <summary>
    /// Gets the name of <see cref="ModelExpression"/> if defined or fallback to a given value.
    /// </summary>
    /// <param name="name">Value to fallback to.</param>
    /// <param name="modelExpression">The <see cref="ModelExpression"/> associated to a bound property.</param>
    /// <returns>The name of the current Tag Helper.</returns>
    protected string? GetAttributeName(string? name, ModelExpression? modelExpression)
    {
        return !string.IsNullOrWhiteSpace(modelExpression?.Name) ? modelExpression.Name : name;
    }
}
