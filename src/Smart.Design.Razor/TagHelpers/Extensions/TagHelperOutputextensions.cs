using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Smart.Design.Razor.TagHelpers.Extensions;

/// <summary>
/// Defines extension methods on <see cref="TagHelperOutput"/>.
/// </summary>
public static class TagHelperOutputExtensions
{
    /// <summary>
    /// Clears every attributes of <paramref name="output"/> but keeps &lt;class&gt; attribute.
    /// The &lt;class&gt; attribute is retrieved from <paramref name="context"/>.
    /// </summary>
    /// <param name="output">The <see cref="TagHelper"/> whose attributes will be erased and class attributes modified.</param>
    /// <param name="context">Context from which the class attributes will be copied into output's.</param>
    public static void ClearAndCopyClassAttribute(this TagHelperOutput output, TagHelperContext context)
    {
        output.Attributes.Clear();
        if (context.AllAttributes.ContainsName("class"))
        {
            output.CopyHtmlAttribute("class", context);
        }
    }

    /// <summary>
    /// Removes every attributes from <paramref name="output"/>.
    /// </summary>
    /// <param name="output">The <see cref="TagHelperOutput"/> from which every attributes will be removed.</param>
    public static void ClearAllAttributes(this TagHelperOutput output)
    {
        output.Attributes.Clear();
    }

    /// <summary>
    /// Clears every attributes from <paramref name="output" /> and merges the given <paramref name="tagBuilder"/>'s <see cref="TagBuilder.Attributes"/>
    /// into <paramref name="output"/>.
    /// </summary>
    /// <param name="output">The <see cref="TagHelperOutput"/> this method extends.</param>
    /// <param name="tagBuilder">The <see cref="TagBuilder"/> to merge attributes from.</param>
    public static void ClearAndMergeAttributes(this TagHelperOutput output, TagBuilder tagBuilder)
    {
        output.ClearAllAttributes();
        output.MergeAttributes(tagBuilder);
    }
}
