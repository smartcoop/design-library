using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Titles.PageTitle;
public class PageTitleHtmlGenerator : IPageTitleHtmlGenerator
{
    public TagBuilder GeneratePageTitleItem(string title)
    {
        var div1 = new TagBuilder("div");
        div1.AddCssClass("c-toolbar");

        var div2 = new TagBuilder("div");
        div2.AddCssClass("c-toolbar__left");

        var div3 = new TagBuilder("div");
        div3.AddCssClass("c-toolbar__item");

        var h1 = new TagBuilder("h1");
        h1.AddCssClass("c-toolbar__title");
        h1.InnerHtml.Append(title);

        div3.InnerHtml.AppendHtml(h1);
        div2.InnerHtml.AppendHtml(div3);
        div1.InnerHtml.AppendHtml(div2);

        return div1;
    }
}
