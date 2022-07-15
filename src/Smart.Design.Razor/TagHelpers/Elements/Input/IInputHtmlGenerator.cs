using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Razor.TagHelpers.Elements.Input;

/// <summary>
/// Generates HTML for &lt;input&gt; elements.
/// </summary>
public interface IInputHtmlGenerator
{
    /// <summary>
    /// Generates a &lt;input[type='text']&gt; compliant with Smart design guidelines.
    /// </summary>
    /// <param name="viewContext">A <see cref="ViewContext"/> instance for the current scope.</param>
    /// <param name="id">Id of the element</param>
    /// <param name="name">The name of the element</param>
    /// <param name="placeholder"></param>
    /// <param name="value">The value of the input</param>
    /// <param name="for">The <see cref="ModelExpression"/> for the <paramref name="name"/>.</param>
    /// <returns></returns>
    TagBuilder GenerateInputText(
        ViewContext? viewContext,
        string? id,
        string? name,
        string? placeholder,
        object? value,
        ModelExpression? @for);


    /// <summary>
    /// Generates an &lt;input[type='time']&gt; compliant with Smart design.
    /// </summary>
    /// <param name="id">Id attribute of the element.</param>
    /// <param name="name">Name attribute of the element.</param>
    /// <param name="value">The value of the input.</param>
    /// <param name="for">The <see cref="ModelExpression"/> associated to the html element.</param>
    /// <returns></returns>
    TagBuilder GenerateInputTime(string? id, string? name, DateTime? value, ModelExpression? @for);
}
