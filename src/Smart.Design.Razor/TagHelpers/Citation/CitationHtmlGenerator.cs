using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Citation;
public class CitationHtmlGenerator : ICitationHtmlGenerator
{
    public TagBuilder GenerateCitation(string title, string content)
    {
        var contentDiv = new TagBuilder("div");
        contentDiv.AddCssClass("c-content");

        var div = new TagBuilder("div");
        div.AddCssClass("c-citation");

        var h4 = new TagBuilder("h4");
        h4.AddCssClass("h4");
        h4.InnerHtml.Append(title);

        var text = new TagBuilder("p");
        text.InnerHtml.Append(content);

        div.InnerHtml.AppendHtml(h4);
        div.InnerHtml.AppendHtml(text);

        contentDiv.InnerHtml.AppendHtml(div);

        return contentDiv;
    }
}
