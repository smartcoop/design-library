using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Library.TagHelpers.Elements.Input;

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

    TagBuilder GenerateInputNumber(string? id, string? name, double? value, string? placeholder, ModelExpression? @for);

    /// <summary>
    /// Generates an <input[type='tel'>; compliant with Smart design.
    /// </summary>
    /// /// <param name="viewContext">A <see cref="ViewContext"/> instance for the current scope.</param>
    /// <param name="id">Id attribute of the element.</param>
    /// <param name="name">Name attribute of the element.</param>
    /// /// <param name="placeholder"></param>
    /// <param name="value">The value of the input.</param>
    /// <param name="phoneType">Phone type is the type of the phone you want. Fix or mobile.</param>
    /// <param name="maxLength">The maximum lenght of the input.</param>
    /// <param name="minLength">The minimum length of the input.</param>
    /// <param name="pattern">The pattern with which the value of the input must comply.</param>
    /// <param name="readOnly">The attribute determine if the input can be modified.</param>
    /// <param name="size">The size attribute is a numeric value indicating how many characters wide the input field should be.</param>
    /// <param name="for">The <see cref="ModelExpression"/> associated to the html element.</param>
    /// <returns></returns>
    TagBuilder GenerateInputTel(
        ViewContext? viewContext,
        string? id,
        string? name,
        string? placeholder,
        object? value,
        PhoneType? phoneType,
        // int? maxLength,
        // int? minLength,
        // string? pattern,
        // string? readOnly,
        // int? size,
        ModelExpression? @for);

    /// <summary>
    /// Generates a &lt;input[type='email']&gt; compliant with Smart design guidelines.
    /// </summary>
    /// <param name="viewContext">A <see cref="ViewContext"/> instance for the current scope.</param>
    /// <param name="id">Id of the element</param>
    /// <param name="name">The name of the element</param>
    /// <param name="placeholder"></param>
    /// <param name="value">The value of the input</param>
    /// <param name="for">The <see cref="ModelExpression"/> for the <paramref name="name"/>.</param>
    /// <returns></returns>
    TagBuilder GenerateInputEmail(
        ViewContext? viewContext,
        string? id,
        string? name,
        string? placeholder,
        object? value,
        ModelExpression? @for);

    /// <summary>
    /// Generates a <input[type='date']> compliant with Smart design guidelines.
    /// </summary>
    /// <param name="viewContext">A <see cref="ViewContext"/> instance for the current scope.</param>
    /// <param name="id">Id of the element</param>
    /// <param name="name">The name of the element</param>
    /// <param name="placeholder"></param>
    /// <param name="value">The value of the input</param>
    /// <param name="for">The <see cref="ModelExpression"/> for the <paramref name="name"/>.</param>
    /// <returns></returns>
    TagBuilder GenerateInputDate(
        ViewContext? viewContext,
        string? id,
        string? name,
        string? placeholder,
        DateTime? value,
        ModelExpression? @for);
}
