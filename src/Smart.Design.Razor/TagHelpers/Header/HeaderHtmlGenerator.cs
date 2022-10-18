using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Header;

public class HeaderHtmlGenerator : IHeaderHtmlGenerator
{
    /// <inheritdoc/>
    public TagBuilder GenerateHeader(string homePageUrl,
                                     Dictionary<string, string> languagesAndLinks,
                                     string currentLanguage,
                                     string userName,
                                     string avatarPath,
                                     Dictionary<string, string> labelsAndLinks)
    {
        var div1 = new TagBuilder("div");
        div1.AddCssClass("c-navbar c-navbar--scrollable");

        var div2 = new TagBuilder("div");
        div2.AddCssClass("c-toolbar");

        var divLeft = new TagBuilder("div");
        divLeft.AddCssClass("c-toolbar__left");
        divLeft.InnerHtml.AppendHtml(GetDivLeftHtmlContent(homePageUrl));

        var divRight = new TagBuilder("div");
        divRight.AddCssClass("c-toolbar__right");

        divRight.InnerHtml.AppendHtml(GetDivRight1(currentLanguage, languagesAndLinks));
        divRight.InnerHtml.AppendHtml(GetDivRight2(userName, avatarPath, labelsAndLinks));

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

        var logo = new TagBuilder("img");
        logo.Attributes["src"] = "/images/logo.svg";
        logo.Attributes["alt"] = "Smart";

        linkLogo.InnerHtml.AppendHtml(logo);
        divLeft2.InnerHtml.AppendHtml(linkLogo);
        divLeft1.InnerHtml.AppendHtml(divLeft2);

        return divLeft1;
    }

    private IHtmlContent GetDivRight1(string currentLanguage, Dictionary<string, string> languagesAndLink)
    {
        var divRight1 = new TagBuilder("div");
        divRight1.AddCssClass("c-toolbar__item");

        var nav = new TagBuilder("nav");
        var languageList = new TagBuilder("ul");
        languageList.AddCssClass("c-pill-navigation");

        var languageLi = new TagBuilder("li");
        languageLi.AddCssClass("c-pill-navigation__item c-pill-navigation__item--has-child-menu");

        var languageButton = new TagBuilder("button");
        languageButton.Attributes["type"] = "button";
        languageButton.Attributes["data-menu"] = "lang-switch";
        languageButton.InnerHtml.Append(currentLanguage);

        var languageUl = new TagBuilder("ul");
        languageUl.AddCssClass("c-menu c-menu--large");
        languageUl.Attributes["id"] = "lang-switch";

        foreach (KeyValuePair<string, string> item in languagesAndLink)
        {
            var li = new TagBuilder("li");
            li.AddCssClass("c-menu__item");
            li.InnerHtml.Append(item.Key);

            var href = new TagBuilder("a");
            href.AddCssClass("c-menu__label");
            languageButton.Attributes["href"] = item.Value;

            li.InnerHtml.AppendHtml(href);
            languageUl.InnerHtml.AppendHtml(li);
        }

        languageLi.InnerHtml.AppendHtml(languageButton);
        languageLi.InnerHtml.AppendHtml(languageUl);

        languageList.InnerHtml.AppendHtml(languageLi);
        nav.InnerHtml.AppendHtml(languageList);
        divRight1.InnerHtml.AppendHtml(nav);

        return divRight1;
    }

    private IHtmlContent GetDivRight2(string userName, string avatarPath, Dictionary<string, string> labelsAndLinks)
    {
        var divRight2 = new TagBuilder("div");
        divRight2.AddCssClass("c-toolbar__item");

        var button = new TagBuilder("button");
        button.AddCssClass("c-user-navigation");
        button.Attributes["data-menu"] = "userMenu";

        var divImage = new TagBuilder("div");
        divImage.AddCssClass("c-avatar c-avatar--img");

        var image = new TagBuilder("img");
        image.Attributes["src"] = avatarPath;
        image.Attributes["alt"] = "avatar";

        divImage.InnerHtml.AppendHtml(image);

        var fullName = new TagBuilder("p");
        fullName.AddCssClass("c-avatar-and-text__text");
        fullName.InnerHtml.Append(userName);

        button.InnerHtml.AppendHtml(divImage);
        button.InnerHtml.AppendHtml(fullName);

        var menu = new TagBuilder("ul");
        menu.AddCssClass("c-menu c-menu--large");
        menu.Attributes["id"] = "userMenu";

        foreach (KeyValuePair<string, string> item in labelsAndLinks)
        {
            var li = new TagBuilder("li");
            li.AddCssClass("c-menu__item");

            var linkMenu = new TagBuilder("a");
            linkMenu.AddCssClass("c-menu__label");
            linkMenu.Attributes["href"] = item.Value;
            linkMenu.InnerHtml.Append(item.Key);

            var divider = new TagBuilder("li");
            divider.AddCssClass("c-menu__divider");
            divider.Attributes["role"] = "presentational";

            li.InnerHtml.AppendHtml(linkMenu);
            menu.InnerHtml.AppendHtml(li);
        }

        divRight2.InnerHtml.AppendHtml(button);
        divRight2.InnerHtml.AppendHtml(menu);

        return divRight2;
    }
}
