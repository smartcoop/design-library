using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.Badge;

public class BadgeHtmlGenerator : IBadgeHtmlGenerator
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;

    public BadgeHtmlGenerator(IIconHtmlGenerator iconHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
    }

    public TagBuilder GenerateSmartBadge(BadgeStyle style, Image icon, BadgeSize size, string? title = default, string? subline = null)
    {
        var badge = new TagBuilder("div");
        badge.AddCssClass($"c-badge c-badge--{style.ToString().ToLowerInvariant()}");

        // No extra css needs to be added when the size default.
        if(size is not BadgeSize.Default)
            badge.AddCssClass($"c-badge--{size.ToString().ToLowerInvariant()}");

        // When rendering a Smart design badge, the icon has precedence over the style.
        var badgeIcon = _iconHtmlGenerator.GenerateIcon(icon is not Image.None ? icon : IconByBadgeStyle(style));
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

    private Image IconByBadgeStyle(BadgeStyle style)
    {
        return style switch
        {
            BadgeStyle.Default => Image.CircleInformation,
            BadgeStyle.Error   => Image.Close,
            BadgeStyle.Success => Image.Check,
            BadgeStyle.Help    => Image.CircleHelp,
            BadgeStyle.Warning => Image.Warning,
            _                  => throw new ArgumentOutOfRangeException(nameof(style), style, $"No preset badge style for style {style}")
        };
    }
}
