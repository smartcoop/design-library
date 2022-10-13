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

        var h2 = new TagBuilder("h2");
        h2.AddCssClass("c-toolbar__title");
        h2.InnerHtml.Append(title);

        div3.InnerHtml.AppendHtml(h2);
        div2.InnerHtml.AppendHtml(div3);
        div1.InnerHtml.AppendHtml(div2);

        return div1;
    }
}
