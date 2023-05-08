using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.TagHelpers.Icon;
using Smart.Design.Library.TagHelpers.Image;

namespace Smart.Design.Library.TagHelpers.Badge;

public class BadgeHtmlGenerator : IBadgeHtmlGenerator
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;

    public BadgeHtmlGenerator(IImageHtmlGenerator imageHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
    }

    public TagBuilder GenerateSmartBadge(BadgeStyle style, Image.Image icon, BadgeSize size, string? title = default, string? subline = null)
    {
        var badge = new TagBuilder("div");
        badge.AddCssClass($"c-badge c-badge--{style.ToString().ToLowerInvariant()}");

        // No extra css needs to be added when the size default.
        if(size is not BadgeSize.Default)
            badge.AddCssClass($"c-badge--{size.ToString().ToLowerInvariant()}");

        // When rendering a Smart design badge, the icon has precedence over the style.
        var badgeIcon = _imageHtmlGenerator.GenerateIcon(icon is not Image.Image.None ? icon : IconByBadgeStyle(style));
        badge.InnerHtml.AppendHtml(badgeIcon);

        // No point going any further if there is no text associated to the badge.
        if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(subline))
            return badge;

        var badgeAndText = new TagBuilder("div");
        badgeAndText.AddCssClass("c-badge-and-text");
        badgeAndText.InnerHtml.AppendHtml(badge);

        var text = new TagBuilder("div");
        text.AddCssClass("c-badge-and-text__text");

        if (!string.IsNullOrWhiteSpace(subline))
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                var titleSection = new TagBuilder("h4");
                titleSection.AddCssClass("c-h4");
                titleSection.InnerHtml.SetContent(title);

                text.InnerHtml.AppendHtml(title);
            }

            var subLine = new TagBuilder("p");
            subLine.AddCssClass("u-text-muted");
            subLine.InnerHtml.SetContent(subline);
            text.InnerHtml.AppendHtml(subLine);
        }
        else if (!string.IsNullOrWhiteSpace(title))
        {
            text.InnerHtml.SetContent(title);
        }

        if (text.HasInnerHtml)
        {
            badgeAndText.InnerHtml.AppendHtml(text);
        }

        return badgeAndText;
    }

    private Image.Image IconByBadgeStyle(BadgeStyle style)
    {
        return style switch
        {
            BadgeStyle.Default => Image.Image.CircleInformation,
            BadgeStyle.Error   => Image.Image.Close,
            BadgeStyle.Success => Image.Image.Check,
            BadgeStyle.Help    => Image.Image.CircleHelp,
            BadgeStyle.Warning => Image.Image.Warning,
            _                  => throw new ArgumentOutOfRangeException(nameof(style), style, $"No preset badge style for style {style}")
        };
    }
}
