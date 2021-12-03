using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Smart.Design.Razor.TagHelpers.Extensions;

public static class TagHelperOutputExtensions
{
    /// <summary>
    /// Clear's all attribute of <paramref name="output"/> but keeps <c>class</c> attribute.
    /// The <c>class</c> attribute is retrieved from <paramref name="context"/>
    /// </summary>
    /// <param name="output">The <see cref="TagHelper"/> whose attributes will be erased and class attributes modified.</param>
    /// <param name="context">Context from which the class attributes will be copied into output's.</param>
    public static void ClearAndCopyClassAttribute(this TagHelperOutput output, TagHelperContext context)
    {
        output.Attributes.Clear();
        if (context.AllAttributes.ContainsName("class"))
            output.CopyHtmlAttribute("class", context);
    }

    /// <summary>
    /// Removes all attributes of <see cref="TagHelperOutput"/>
    /// </summary>
    /// <param name="output"></param>
    public static void ClearAllAttributes(this TagHelperOutput output)
    {
        output.Attributes.Clear();
    }

    /// <summary>
    /// Clears all attributes of <paramref name="output" /> and merges the given <paramref name="tagBuilder"/>'s <see cref="TagBuilder.Attributes"/>
    /// into the <paramref name="output"/>.
    /// </summary>
    /// <param name="output">The <see cref="TagHelperOutput"/> this method extends.</param>
    /// <param name="tagBuilder">The <see cref="TagBuilder"/> to merge attributes from.</param>
    public static void ClearAndMergeAttributes(this TagHelperOutput output, TagBuilder tagBuilder)
    {
        output.ClearAllAttributes();
        output.MergeAttributes(tagBuilder);
    }
}
