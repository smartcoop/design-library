using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Box;

/// <summary>
/// Generate a box with a title, sub title and list of labels and values.
/// </summary>
public interface IBoxHtmlGenerator
{
    /// <summary>
    /// Generate a list of value from a <see cref="labelAndLinks"/> dictionnary
    /// </summary>
    /// <param name="labelTitle">The label of title</param>
    /// <param name="title">The title</param>
    /// <param name="subTitle">The sub title</param>
    /// <param name="labelAndLinks">The list of lables and a values</param>
    /// <returns></returns>
    TagBuilder GenerateListOfItems(string labelTitle, string title, string? subTitle, Dictionary<string, string> labelAndValues);
}
