using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.Resources;
using Smart.Design.Library.TagHelpers.Image;

namespace Smart.Design.Library.TagHelpers.Header.NotLoggedInHeader;
public class NotLoggedInHeaderHtmlGenerator : INotLoggedInHeaderHtmlGenerator
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;

    public NotLoggedInHeaderHtmlGenerator(IImageHtmlGenerator imageHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
    }


    public TagBuilder GenerateNotLoggedInHeader(string homePageUrl, Dictionary<string, string> languagesAndLinks, string? targetLanguage)
    {

        (string CultureCode, string Language) languageCulture = targetLanguage?.ToUpper() switch
        {
            "FR" => ("FR", "Français"),
            "NL" => ("NL", "Nederlands"),
            _ => ("EN", "English")
        };
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(languageCulture.CultureCode);


        var div1 = new TagBuilder("div");
        div1.AddCssClass("c-navbar");

        var div2 = new TagBuilder("div");
        div2.AddCssClass("c-toolbar");

        var divLeft = new TagBuilder("div");
        divLeft.AddCssClass("c-toolbar__left");
        divLeft.InnerHtml.AppendHtml(GetDivLeftHtmlContent(homePageUrl));

        var divRight = new TagBuilder("div");
        divRight.AddCssClass("c-toolbar__right");

        //divRight.InnerHtml.AppendHtml(GetDivRight1(languageCulture.CultureCode));
        //divRight.InnerHtml.AppendHtml(GetDivRight2(languagesAndLinks, languageCulture.Language));
        //divRight.InnerHtml.AppendHtml(GetDivRight3(fullNameWithTrigram, avatarPath, labelsAndLinks, logoutLink));

        div2.InnerHtml.AppendHtml(divLeft);
        div2.InnerHtml.AppendHtml(divRight);
        div1.InnerHtml.AppendHtml(div2);

        return div1;
    }

    private IHtmlContent GetDivLeftHtmlContent(string homePageUrl)
    {
        var divLeft1 = new TagBuilder("div");
        divLeft1.AddCssClass("c-toolbar__item");

        var divLeft2 = new TagBuilder("div");
        divLeft2.AddCssClass("c-brand c-brand--xsmall");

        var linkLogo = new TagBuilder("a");
        linkLogo.Attributes["href"] = homePageUrl;

        var logo = _imageHtmlGenerator.GenerateImage(Image.Image.Logo);

        linkLogo.InnerHtml.AppendHtml(logo);
        divLeft2.InnerHtml.AppendHtml(linkLogo);
        divLeft1.InnerHtml.AppendHtml(divLeft2);

        return divLeft1;
    }
}
