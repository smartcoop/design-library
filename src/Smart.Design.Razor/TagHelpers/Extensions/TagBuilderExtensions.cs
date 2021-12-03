using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Smart.Design.Razor.TagHelpers.Extensions;

public static class TagBuilderExtensions
{
    /// <summary>
    /// Merges the attributes from a <see cref="TagHelper" /> element into a <see cref="TagBuilder" />.
    /// Same key are always updated.
    /// </summary>
    /// <param name="tagBuilder">The <see cref="TagBuilder" /> to update.</param>
    /// <param name="tagHelperAttributeList">Attributes to be merged into <paramref name="tagBuilder"/></param>
    public static void MergeAttributes(this TagBuilder tagBuilder, TagHelperAttributeList tagHelperAttributeList)
    {
        foreach (var tagHelperAttribute in tagHelperAttributeList)
        {
            if (!string.IsNullOrWhiteSpace(tagHelperAttribute.Name))
            {
                tagBuilder.Attributes[tagHelperAttribute.Name] = tagHelperAttribute.Value?.ToString();
            }
        }
    }
}
