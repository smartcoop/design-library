using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Box;

/// <summary>
/// Generates a box with a title, subtitle and list of labels and values.
/// </summary>
public interface IBoxHtmlGenerator
{
    /// <summary>
    /// Generate a list of values from a <see cref="labelsAndValues"/> dictionnary
    /// </summary>
    /// <param name="titleLabel">The label of title</param>
    /// <param name="title">The title</param>
    /// <param name="subtitle">The sub title</param>
    /// <param name="labelsAndValues">The list of lables and a values</param>
    /// <returns></returns>
    TagBuilder GenerateListOfItems(string titleLabel, string title, string? subtitle, Dictionary<string, string> labelsAndValues);
}
