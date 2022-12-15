using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.AcceptanceCheckbox;
/// <summary>
/// Generates
/// </summary>
public interface IAcceptanceCheckboxHtmlGenerator
{
    /// <summary>
    /// Generate label <see cref="label"/> string, a <see cref="style"/> AcceptanceCheckboxStyle, a <see cref="currentLanguage"/> string
    /// </summary>
    /// <param name="label"></param>
    /// <param name="style"></param>
    /// <param name="currentLanguage"></param>
    /// <returns></returns>
    TagBuilder GenerateAcceptanceCheckbox(string label, AcceptanceCheckboxStyle style, string currentLanguage);
}
