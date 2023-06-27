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
    public string HomePageUrl { get; set; }

    public Dictionary<string, string> LanguagesAndLinks { get; set; } = new Dictionary<string, string>();

    public string? TargetLanguage { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {



        var header = new TagBuilder("header");
        header.AddCssClass("u-position-fixed u-maximize-width");
        
    }
}
