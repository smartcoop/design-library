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

        var divRight = new TagBuilder("div");
        divRight.AddCssClass("c-toolbar__right");

        divLeft.InnerHtml.AppendHtml(GetDivLeftHtmlContent(homePageUrl));
        divRight.InnerHtml.AppendHtml(SetLanguageMenu(languagesAndLinks, languageCulture.Language));
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

    private IHtmlContent SetLanguageMenu(Dictionary<string, string> languagesAndLink, string language)
    {
        var languageMenu = new TagBuilder("div");
        languageMenu.AddCssClass("c-toolbar__item");

        var languageList = new TagBuilder("ul");
        languageList.AddCssClass("c-pill-navigation");

        var languageLi = new TagBuilder("li");
        languageLi.AddCssClass("c-pill-navigation__item c-pill-navigation__item--has-child-menu");

        var languageButton = new TagBuilder("button");
        languageButton.Attributes["type"] = "button";
        languageButton.Attributes["data-menu"] = "lang-switch";
        languageButton.InnerHtml.Append(Translations.CurrentLanguage);

        var languageUl = new TagBuilder("ul");
        languageUl.AddCssClass("c-menu c-menu--large");
        languageUl.Attributes["id"] = "lang-switch";

        foreach (KeyValuePair<string, string> item in languagesAndLink)
        {
            if (string.Equals(item.Key, language, StringComparison.OrdinalIgnoreCase))
            {
                var p = new TagBuilder("p");
                p.AddCssClass("c-menu__info u-text-muted");
                p.InnerHtml.Append(item.Key);
                languageUl.InnerHtml.AppendHtml(p);
            }
            else
            {
                var li = GenerateListItemWithBanner(item.Key, item.Value);
                languageUl.InnerHtml.AppendHtml(li);
            }
        }

        languageLi.InnerHtml.AppendHtml(languageButton);
        languageLi.InnerHtml.AppendHtml(languageUl);
        languageList.InnerHtml.AppendHtml(languageLi);
        languageMenu.InnerHtml.AppendHtml(languageList);

        return languageMenu;
    }

    private IHtmlContent GenerateListItemWithBanner(string innerHtml, string href, Image.Image icon = Image.Image.None, bool isBlankTarget = false)
    {
        var liItem = new TagBuilder("li");
        liItem.AddCssClass("c-menu__item");
        var link = new TagBuilder("a");
        link.AddCssClass("c-menu__label");
        link.Attributes["target"] = isBlankTarget ? "_blank" : "_self";
        link.Attributes["href"] = href;

        if (icon != Image.Image.None)
        {
            var svg = _imageHtmlGenerator.GenerateIcon(icon);
            var span = new TagBuilder("span");
            span.InnerHtml.Append(innerHtml);
            link.InnerHtml.AppendHtml(svg);
            link.InnerHtml.AppendHtml(span);
        }
        else
        {
            link.InnerHtml.Append(innerHtml);
        }

        liItem.InnerHtml.AppendHtml(link);
        return liItem;
    }
}
