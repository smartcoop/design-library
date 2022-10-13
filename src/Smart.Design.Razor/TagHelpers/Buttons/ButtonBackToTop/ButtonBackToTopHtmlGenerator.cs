using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.Buttons.ButtonBackToTop;

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

        span.InnerHtml.AppendHtml(svg);
        button.InnerHtml.AppendHtml(span);

        return button;
    }
}
