using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Titles.PageTitle;
public class PageTitleHtmlGenerator : IPageTitleHtmlGenerator
{
    public TagBuilder GeneratePageTitleItem(string title, List<string>? infos)
    {
        var div1 = new TagBuilder("div");
        div1.AddCssClass("c-toolbar");

        var div2 = new TagBuilder("div");
        div2.AddCssClass("c-toolbar__left");

        var div2Child = new TagBuilder("div");
        div2Child.AddCssClass("c-toolbar__item");

        var h1 = new TagBuilder("h1");
        h1.AddCssClass("c-toolbar__title");
        h1.InnerHtml.Append(title);

        div2Child.InnerHtml.AppendHtml(h1);
        div2.InnerHtml.AppendHtml(div2Child);
        div1.InnerHtml.AppendHtml(div2);

        if (infos != null && infos.Any())
        {
            div1.InnerHtml.AppendHtml(GetInfos(infos));
        }

        return div1;
    }

    private IHtmlContent GetInfos(List<string> infos)
    {
        var div3 = new TagBuilder("div");
        div3.AddCssClass("c-toolbar__right");

        var div3Child = new TagBuilder("div");
        div3Child.AddCssClass("c-toolbar__item");

        var line = new TagBuilder("p");
        line.AddCssClass("text-muted");

        line.InnerHtml.AppendHtml(infos[0]);
        for (int i = 1; i < infos.Count; i++)
        {
            line.InnerHtml.AppendHtml($"-{infos[i]}");
        }

        div3Child.InnerHtml.AppendHtml(line);
        div3.InnerHtml.AppendHtml(div3Child);

        return div3;
    }
}
