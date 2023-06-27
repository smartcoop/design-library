using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Header.NotLoggedInHeader;
public interface INotLoggedInHeaderHtmlGenerator
{
    TagBuilder NotLoggedInHeader(string homePageUrl, Dictionary<string, string> languagesAndLinks, string? targetLanguage);
}
