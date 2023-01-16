using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.SideMenu;

/// <summary>
/// Implementation of a Smart design side menu.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-side-menu.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.SideMenuTagName)]
public class SideMenuTagHelper : TagHelper
{
    private readonly ISideMenuHtmlGenerator _sideMenuHtmlGenerator;

    /// <summary>
    /// Dictionnary of label and links items for the side menu
    /// </summary>
    public Dictionary<string, string> LabelAndLinks { get; set; } = new();

    /// <summary>
    /// Creates a new <see cref="SideMenuTagHelper"/>.
    /// </summary>
    /// <param name="sideMenuHtmlGenerator">The service that generates Smart Design side menu with labels and navigation links.</param>
    public SideMenuTagHelper(ISideMenuHtmlGenerator sideMenuHtmlGenerator)
    {
        _sideMenuHtmlGenerator = sideMenuHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!LabelAndLinks.Any())
        {
            throw new ArgumentException($"{nameof(LabelAndLinks)} cannot be null or empty");
        }

        var menu = _sideMenuHtmlGenerator.GenerateListOfItems(LabelAndLinks);
        output.MergeAttributes(menu);
        output.TagName = menu.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(menu.InnerHtml);
    }
}
