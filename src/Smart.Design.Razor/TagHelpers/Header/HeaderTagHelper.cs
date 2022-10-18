using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Header;

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
    public Dictionary<string, string> languagesAndLinks { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Current interface language
    /// </summary>
    public string CurrentLanguage { get; set; }

    /// <summary>
    /// Current user full name
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Path to the current user avatar
    /// </summary>
    public string AvatarPath { get; set; }

    /// <summary>
    /// Dictionnary of label and links items for the drop down menu
    /// </summary>
    public Dictionary<string, string> LabelsAndLinks { get; set; } = new Dictionary<string, string>();

    // <summary>
    /// Creates a new <see cref="SideMenuTagHelper"/>.
    /// </summary>
    /// <param name="sideMenuHtmlGenerator">The service that generates Smart Design side menu with labels and navigation links.</param>
    public HeaderTagHelper(IHeaderHtmlGenerator headerHtmlGenerator)
    {
        _headerHtmlGenerator = headerHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!languagesAndLinks.Any())
        {
            throw new ArgumentException($"{nameof(languagesAndLinks)} cannot be null or empty");
        }

        if (string.IsNullOrEmpty(UserName))
        {
            throw new ArgumentException($"{nameof(UserName)} cannot be null or empty");
        }

        if (!LabelsAndLinks.Any())
        {
            throw new ArgumentException($"{nameof(LabelsAndLinks)} cannot be null or empty");
        }

        if (string.IsNullOrEmpty(AvatarPath))
        {
            AvatarPath = "~/unity/images/default_image.jpg";
        }

        var header = new TagBuilder("header");
        header.AddCssClass("u-position-fixed u-maximize-width");

        header.InnerHtml.SetHtmlContent(_headerHtmlGenerator.GenerateHeader(HomePageUrl, languagesAndLinks, CurrentLanguage, UserName, AvatarPath, LabelsAndLinks));

        output.MergeAttributes(header);
        output.TagName = header.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(header.InnerHtml);
    }
}
