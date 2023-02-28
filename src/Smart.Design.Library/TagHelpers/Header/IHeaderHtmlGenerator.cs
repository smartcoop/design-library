using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Header;
/// <summary>
/// Generate the header component for a <see cref="HeaderTagHelper"/>
/// </summary>
public interface IHeaderHtmlGenerator
{
    /// <summary>
    /// Generate generic header with a <see cref="homePageUrl"/> string, a <see cref="logoPath"/> string, a <see cref="languagesAndLinks"/> dictionary, a <see cref="targetLanguage"/> string?,
    /// a <see cref="fullNameWithTrigram"/> string,  a <see cref="avatarPath"/> string, <see cref="labelsAndLinks"/> dictionary , a <see cref="logoutLink"/> string.
    /// </summary>
    /// <param name="homePageUrl"></param>
    /// <param name="logoPath"></param>
    /// <param name="languagesAndLinks"></param>
    /// <param name="targetLanguage"></param>
    /// <param name="fullNameWithTrigram"></param>
    /// <param name="avatarPath"></param>
    /// <param name="labelsAndLinks"></param>
    /// <param name="logoutLink"></param>
    /// <returns></returns>
    TagBuilder GenerateHeader(string homePageUrl,
                              string logoPath,
                              Dictionary<string, string> languagesAndLinks,
                              string? targetLanguage,
                              string fullNameWithTrigram,
                              string avatarPath,
                              Dictionary<string, string> labelsAndLinks,
                              string logoutLink);
}
