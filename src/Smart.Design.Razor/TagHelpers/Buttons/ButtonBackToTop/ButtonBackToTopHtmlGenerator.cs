using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Buttons.ButtonBackToTop;

public class ButtonBackToTopHtmlGenerator : IButtonBackToTopHtmlGenerator
{
    public TagBuilder GenerateButtonBackToTop(string label)
    {
        var button = new TagBuilder("button");
        button.AddCssClass("c-button c-button--secondary c-button--icon u-shadow-10");

        var span = new TagBuilder("span");
        span.AddCssClass("c-button__content");

        var div = new TagBuilder("div");
        div.AddCssClass("o-svg-icon o-svg-icon-arrow-up");

        var svg = new TagBuilder("svg");
        svg.Attributes["width"] = "24";
        svg.Attributes["height"] = "24";
        svg.Attributes["viewBox"] = "0 0 24 24";
        svg.Attributes["fill"] = "none";
        svg.Attributes["xmlns"] = "http://www.w3.org/2000/svg";

        var path = new TagBuilder("path");
        path.Attributes["d"] = "M12 4C12.2652 4 12.5196 4.10536 12.7071 4.29289L18.7071 10.2929C19.0976 10.6834 19.0976 11.3166 18.7071 11.7071C18.3166 12.0976 17.6834 12.0976 17.2929 11.7071L13 7.41421L13 19C13 19.5523 12.5523 20 12 20C11.4477 20 11 19.5523 11 19L11 7.41421L6.70711 11.7071C6.31658 12.0976 5.68342 12.0976 5.29289 11.7071C4.90237 11.3166 4.90237 10.6834 5.29289 10.2929L11.2929 4.29289C11.4804 4.10536 11.7348 4 12 4Z";
        path.Attributes["fill"] = "#595959";

        svg.InnerHtml.AppendHtml(path);
        div.InnerHtml.AppendHtml(svg);
        span.InnerHtml.AppendHtml(div);
        button.InnerHtml.AppendHtml(span);

        return button;
    }
}
