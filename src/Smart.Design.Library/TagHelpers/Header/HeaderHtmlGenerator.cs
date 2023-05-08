using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.Resources;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.Header;

/// <inheritdoc/>
public class HeaderHtmlGenerator : IHeaderHtmlGenerator
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;

    /// <summary>
    /// </summary>
    /// <param name="imageHtmlGenerator"></param>
    public HeaderHtmlGenerator(IImageHtmlGenerator imageHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
    }

    /// <inheritdoc/>
    public TagBuilder GenerateHeader(string homePageUrl,
        Dictionary<string, string> languagesAndLinks,
        string? targetLanguage,
        string fullNameWithTrigram,
        string avatarPath,
        Dictionary<string, string> labelsAndLinks,
        string logoutLink)
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

        divRight.InnerHtml.AppendHtml(GetDivRight1(languageCulture.CultureCode));
        divRight.InnerHtml.AppendHtml(GetDivRight2(languagesAndLinks, languageCulture.Language));
        divRight.InnerHtml.AppendHtml(GetDivRight3(fullNameWithTrigram, avatarPath, labelsAndLinks, logoutLink));

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

        var logo = _imageHtmlGenerator.GenerateImage(Image.Logo);

        linkLogo.InnerHtml.AppendHtml(logo);
        divLeft2.InnerHtml.AppendHtml(linkLogo);
        divLeft1.InnerHtml.AppendHtml(divLeft2);

        return divLeft1;
    }

    private IHtmlContent GetDivRight1(string language)
    {
        var divRight1 = new TagBuilder("div");
        divRight1.AddCssClass("c-toolbar__item");

        var helpList = new TagBuilder("ul");
        helpList.AddCssClass("c-pill-navigation");

        var helpLi = new TagBuilder("li");
        helpLi.AddCssClass("c-pill-navigation__item c-pill-navigation__item--has-child-menu");

        var helpButton = new TagBuilder("button");
        helpButton.Attributes["type"] = "button";
        helpButton.Attributes["data-menu"] = "help";

        var svg = _imageHtmlGenerator.GenerateIcon(Image.CircleHelp);
        helpButton.InnerHtml.AppendHtml(svg);

        var textHelp = new TagBuilder("p");
        textHelp.AddCssClass("u-hidden--mobile");
        textHelp.InnerHtml.Append(Translations.Help);
        helpButton.InnerHtml.AppendHtml(textHelp);

        var helpUl = new TagBuilder("ul");
        helpUl.AddCssClass("c-menu c-menu--large");
        helpUl.Attributes["id"] = "help";

        var liMenuHelp = new TagBuilder("li");
        liMenuHelp.AddCssClass("c-menu__info");

        var p = new TagBuilder("p");
        p.AddCssClass("c-menu__subline");
        p.InnerHtml.Append(Translations.HelpAndDocumentation);

        liMenuHelp.InnerHtml.AppendHtml(p);
        helpUl.InnerHtml.AppendHtml(liMenuHelp);

        var liDocumentation = GenerateListItemWithBanner(Translations.Documentation, Translations.DocumentationUrl, Image.ExternalLink, true);
        var liQuestion = GenerateListItemWithBanner(Translations.QandA, Translations.QandAUrl);
        var liContact = GenerateListItemWithBanner(Translations.ContactUs, Translations.ContactUsUrl, Image.None, true);

        helpUl.InnerHtml.AppendHtml(liDocumentation);
        helpUl.InnerHtml.AppendHtml(liQuestion);
        helpUl.InnerHtml.AppendHtml(liContact);

        helpLi.InnerHtml.AppendHtml(helpButton);
        helpLi.InnerHtml.AppendHtml(helpUl);

        helpList.InnerHtml.AppendHtml(helpLi);
        divRight1.InnerHtml.AppendHtml(helpList);

        return divRight1;
    }

    private IHtmlContent GetDivRight2(Dictionary<string, string> languagesAndLink, string language)
    {
        var divRight2 = new TagBuilder("div");
        divRight2.AddCssClass("c-toolbar__item");

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
        divRight2.InnerHtml.AppendHtml(languageList);

        return divRight2;
    }

    private IHtmlContent GetDivRight3(string fullNameWithTrigram, string avatarPath, Dictionary<string, string> labelsAndLinks, string logoutLink)
    {
        var divRight3 = new TagBuilder("div");
        divRight3.AddCssClass("c-toolbar__item");

        var button = new TagBuilder("button");
        button.AddCssClass("c-user-navigation");
        button.Attributes["data-menu"] = "userMenu";
        button.Attributes["href"] = "#";

        var divImage = new TagBuilder("div");
        divImage.AddCssClass("c-avatar c-avatar--img");

        var image = new TagBuilder("img");
        image.Attributes["src"] = avatarPath;
        image.Attributes["alt"] = "avatar";

        divImage.InnerHtml.AppendHtml(image);

        var fullName = new TagBuilder("p");
        fullName.AddCssClass("c-avatar-and-text__text u-hidden--mobile");
        fullName.InnerHtml.Append(fullNameWithTrigram);

        button.InnerHtml.AppendHtml(divImage);
        button.InnerHtml.AppendHtml(fullName);

        var menu = new TagBuilder("ul");
        menu.AddCssClass("c-menu c-menu--xxlarge");
        menu.Attributes["id"] = "userMenu";

        var menuInfo = new TagBuilder("li");
        menuInfo.AddCssClass("c-menu__info");

        var pInfo = new TagBuilder("p");
        pInfo.AddCssClass("c-menu__subline");
        pInfo.InnerHtml.Append(Translations.PersonalInformations);

        menuInfo.InnerHtml.AppendHtml(pInfo);
        menu.InnerHtml.AppendHtml(menuInfo);

        foreach (KeyValuePair<string, string> item in labelsAndLinks)
        {
            var li = GenerateListItemWithBanner(item.Key, item.Value);
            menu.InnerHtml.AppendHtml(li);
        }

        var liSignOut = new TagBuilder("li");
        liSignOut.AddCssClass("c-menu__divider");
        liSignOut.Attributes["role"] = "sign-out";
        menu.InnerHtml.AppendHtml(liSignOut);

        var liSignOutText = new TagBuilder("li");
        liSignOutText.AddCssClass("c-menu__item c-menu__item--danger");
        var hrefSignOut = new TagBuilder("a");
        hrefSignOut.AddCssClass("c-menu__label");
        hrefSignOut.Attributes["href"] = logoutLink;
        var svg = _imageHtmlGenerator.GenerateIcon(Image.SignOut);
        var span = new TagBuilder("span");
        span.InnerHtml.Append(Translations.SignOut);

        hrefSignOut.InnerHtml.AppendHtml(svg);
        hrefSignOut.InnerHtml.AppendHtml(span);
        liSignOutText.InnerHtml.AppendHtml(hrefSignOut);

        menu.InnerHtml.AppendHtml(liSignOutText);

        divRight3.InnerHtml.AppendHtml(button);
        divRight3.InnerHtml.AppendHtml(menu);

        return divRight3;
    }

    private IHtmlContent GenerateListItemWithBanner(string innerHtml, string href, Image icon = Image.None, bool isBlankTarget = false)
    {
        var liItem = new TagBuilder("li");
        liItem.AddCssClass("c-menu__item");
        var link = new TagBuilder("a");
        link.AddCssClass("c-menu__label");
        link.Attributes["target"] = isBlankTarget ? "_blank" : "_self";
        link.Attributes["href"] = href;

        if (icon != Image.None)
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
