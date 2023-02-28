using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.Buttons.ButtonBackToTop;

public class ButtonBackToTopHtmlGenerator : IButtonBackToTopHtmlGenerator
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;

    /// <summary>
    /// </summary>
    /// <param name="iconHtmlGenerator"></param>
    public ButtonBackToTopHtmlGenerator(IIconHtmlGenerator iconHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
    }

    /// <inheritdoc />
    public TagBuilder GenerateButtonBackToTop(string label)
    {
        var button = new TagBuilder("button");
        button.AddCssClass("c-button c-button--secondary c-button--icon u-shadow-10");

        var span = new TagBuilder("span");
        span.AddCssClass("c-button__content");

        var svg = _iconHtmlGenerator.GenerateIcon(Image.ArrowUp);

        var accessibility = new TagBuilder("div");
        accessibility.AddCssClass("u-sr-accessible");
        accessibility.InnerHtml.Append(label);

        span.InnerHtml.AppendHtml(svg);
        span.InnerHtml.AppendHtml(accessibility);
        button.InnerHtml.AppendHtml(span);

        return button;
    }
}
