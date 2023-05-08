using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.TagHelpers.Icon;
using Smart.Design.Library.TagHelpers.Image;

namespace Smart.Design.Library.TagHelpers.GlobalBanner;

public class GlobalBannerHtmlGenerator : IGlobalBannerHtmlGenerator
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;

    /// <summary>
    /// Creates a new <see cref="GlobalBannerHtmlGenerator"/>.
    /// </summary>
    /// <param name="imageHtmlGenerator">Services that will serve the HTML for icons.</param>
    public GlobalBannerHtmlGenerator(IImageHtmlGenerator imageHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
    }

    /// <inheritdoc />
    public TagBuilder GenerateGlobalBanner(GlobalBannerType globalBannerType, string? label)
    {
        var globalBanner = new TagBuilder("div");
        var extraClass = globalBannerType == GlobalBannerType.Info ? "default" : "warning";
        globalBanner.AddCssClass($"c-global-banner c-global-banner--{extraClass}");

        // Leading icon can be either info a info or a warning.
        var leadIcon = globalBannerType == GlobalBannerType.Info ? _imageHtmlGenerator.GenerateIcon(Image.Image.CircleInformation) : _imageHtmlGenerator.GenerateIcon(Image.Image.Warning);

        // Label is the inner html of a paragraph inside a div.
        var labelDiv = new TagBuilder("div");
        labelDiv.AddCssClass("c-global-banner__label");
        var paragraph = new TagBuilder("p");
        paragraph.InnerHtml.Append(label!);
        labelDiv.InnerHtml.AppendHtml(paragraph);

        // The button is aligned at the end.
        var button = new TagBuilder("button");
        button.AddCssClass("c-button c-button--borderless c-button--icon");
        button.Attributes["type"] = "button";
        button.Attributes["data-banner-close"] = "data-banner-close";

        // Content of the button
        var spanContent = new TagBuilder("span");
        spanContent.AddCssClass("c-button__content");
        var closeIcon = _imageHtmlGenerator.GenerateIcon(Image.Image.Close);
        spanContent.InnerHtml.AppendHtml(closeIcon);

        // Accessibility
        var accessibilityDiv = new TagBuilder("div");
        accessibilityDiv.AddCssClass("u-sr-accessible");
        accessibilityDiv.InnerHtml.SetContent("Close");
        spanContent.InnerHtml.AppendHtml(accessibilityDiv);

        button.InnerHtml.AppendHtml(spanContent);

        globalBanner.InnerHtml.AppendHtml(leadIcon);
        globalBanner.InnerHtml.AppendHtml(labelDiv);
        globalBanner.InnerHtml.AppendHtml(button);

        return globalBanner;
    }
}
