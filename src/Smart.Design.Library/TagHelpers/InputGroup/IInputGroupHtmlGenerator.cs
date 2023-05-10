using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Library.TagHelpers.InputGroup;

/// <summary>
/// Generates HTML for the Smart Design input group.
/// </summary>
public interface IInputGroupHtmlGenerator
{
    /// <summary>
    /// Generates an Smart design input group.
    /// See documentation <see href="https://design.smart.coop/development/docs/c-input-group.html">here</see>.
    /// </summary>
    /// <param name="viewContext"></param>
    /// <param name="id">d of the &lt;input&gt; element.</param>
    /// <param name="name">Name of the &lt;input&gt; element.</param>
    /// <param name="placeholder">Placeholder of the &lt;input&gt; element.</param>
    /// <param name="value">HTML value of the &lt;input&gt; element.</param>
    /// <param name="for">ModelExpression associated with the component.</param>
    /// <param name="alignment">The alignment of <paramref name="text"/> or <paramref name="icon"/>. Can be at the start or beginning</param>
    /// <param name="icon">An <see cref="Icon"/> that can be aligned at the start or the end of the input group.</param>
    /// <param name="text"></param>
    /// <returns>A instance of an input group component.</returns>
    /// <remarks>There can be only either one icon or one extra content at a time.</remarks>
    /// <exception><see cref="ArgumentException"/> if <paramref name="text"/> and <paramref name="icon"/> have a value.</exception>
    TagBuilder GenerateInputGroup(ViewContext? viewContext,
        string? id,
        string? name,
        string? placeholder,
        string? value,
        ModelExpression? @for,
        Alignment alignment,
        Image.Image icon, string? text);
}
