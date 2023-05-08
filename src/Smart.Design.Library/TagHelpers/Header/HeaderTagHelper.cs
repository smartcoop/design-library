using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.Header;

[HtmlTargetElement(TagNames.HeaderTagName)]
public class HeaderTagHelper : TagHelper
{
    private readonly IHeaderHtmlGenerator _headerHtmlGenerator;

    /// <summary>
    /// Home page url from appsettings context
    /// </summary>
    public string HomePageUrl { get; set; }

    /// <summary>
    /// list of available languages
    /// </summary>
    public Dictionary<string, string> LanguagesAndLinks { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Current interface language
    /// </summary>
    public string? TargetLanguage { get; set; }

    /// <summary>
    /// Current user first, last name and trigram
    /// </summary>
    public string FullNameWithTrigram { get; set; } = null!;

    /// <summary>
    /// Path to the current user avatar
    /// </summary>
    public string AvatarPath { get; set; } = "~/images/default_image.svg";

    /// <summary>
    /// Path to logout
    /// </summary>
    public string LogoutLink { get; set; } = null!;

    /// <summary>
    /// Dictionary of label and links items for the drop down menu
    /// </summary>
    public Dictionary<string, string> LabelsAndLinks { get; set; } = new Dictionary<string, string>();

    // <summary>
    /// Creates a new <see cref="HeaderTagHelper"/>.
    /// </summary>
    /// <param name="HeaderTagHelper">The service that generates the Smart Design header with logo and user's profile picture</param>
    public HeaderTagHelper(IHeaderHtmlGenerator headerHtmlGenerator)
    {
        _headerHtmlGenerator = headerHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!LanguagesAndLinks.Any())
        {
            throw new ArgumentException($"{nameof(LanguagesAndLinks)} cannot be empty");
        }

        if (string.IsNullOrEmpty(FullNameWithTrigram))
        {
            throw new ArgumentException($"{nameof(FullNameWithTrigram)} cannot be empty");
        }

        if (!LabelsAndLinks.Any())
        {
            throw new ArgumentException($"{nameof(LabelsAndLinks)} cannot be empty");
        }

        if (!LogoutLink.Any())
        {
            throw new ArgumentException($"{nameof(LogoutLink)} cannot be empty");
        }

        var header = new TagBuilder("header");
        header.AddCssClass("u-position-fixed u-maximize-width");

        header.InnerHtml.SetHtmlContent(_headerHtmlGenerator.GenerateHeader(HomePageUrl, LanguagesAndLinks, TargetLanguage, FullNameWithTrigram, AvatarPath, LabelsAndLinks, LogoutLink));

        output.MergeAttributes(header);
        output.TagName = header.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(header.InnerHtml);
    }
}
