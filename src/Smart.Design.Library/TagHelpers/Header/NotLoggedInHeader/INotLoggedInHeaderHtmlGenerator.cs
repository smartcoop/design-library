using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Header.NotLoggedInHeader;
public interface INotLoggedInHeaderHtmlGenerator
{
    TagBuilder GenerateNotLoggedInHeader(string homePageUrl, Dictionary<string, string> languagesAndLinks, string? targetLanguage, List<StepperItem>? stepperItems);
}
