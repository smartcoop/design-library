using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Smart.Design.Razor.TagHelpers.Header;
/// <summary>
/// Generate the header component for a <see cref="HeaderTagHelper"/>
/// </summary>
public interface IHeaderHtmlGenerator
{
    /// <summary>
    /// Generate generic header with a <see cref="homePageUrl"/>, string a <see cref="languagesAndLinks"/> dictionary, a <see cref="currentLanguage"/> string,
    /// a <see cref="fullNameWithTrigram"/> string,  a <see cref="avatarPath"/> string, <see cref="labelsAndLinks"/> dictionary.
    /// </summary>
    /// <param name="homePageUrl"></param>
    /// <param name="languagesAndLinks"></param>
    /// <param name="currentLanguage"></param>
    /// <param name="fullNameWithTrigram"></param>
    /// <param name="avatarPath"></param>
    /// <param name="labelsAndLinks"></param>
    /// <returns></returns>
    TagBuilder GenerateHeader(string homePageUrl,
                              Dictionary<string, string> languagesAndLinks,
                              string currentLanguage,
                              string fullNameWithTrigram,
                              string avatarPath,
                              Dictionary<string, string> labelsAndLinks);
}
