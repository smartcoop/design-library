using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;

namespace Smart.Design.Library.TagHelpers.Header.NotLoggedInHeader;

[HtmlTargetElement(TagNames.NotLoggedInHeaderTagName)]
public class NotLoggedInHeaderTagHelper : TagHelper
{
    private readonly INotLoggedInHeaderHtmlGenerator _notLoggedInHeaderHtmlGenerator;
    public string HomePageUrl { get; set; }

    public Dictionary<string, string> LanguagesAndLinks { get; set; }

    public string? TargetLanguage { get; set; }

    public NotLoggedInHeaderTagHelper(INotLoggedInHeaderHtmlGenerator notLoggedInHeaderHtmlGenerator)
    {
        _notLoggedInHeaderHtmlGenerator = notLoggedInHeaderHtmlGenerator;
    }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {

        if (!LanguagesAndLinks.Any())
        {
            throw new ArgumentException($"{nameof(LanguagesAndLinks)} cannot be empty");
        }

        var header = new TagBuilder("header");
        header.AddCssClass("o-container-vertical c-navbar c-navbar--white c-navbar--entry");
        header.InnerHtml.SetHtmlContent(_notLoggedInHeaderHtmlGenerator.GenerateNotLoggedInHeader(HomePageUrl, LanguagesAndLinks, TargetLanguage));
        output.MergeAttributes(header);
        output.TagName = header.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(header.InnerHtml);
    }
}
