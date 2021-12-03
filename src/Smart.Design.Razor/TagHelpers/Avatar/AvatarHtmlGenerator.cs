using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.Avatar;

public class AvatarHtmlGenerator : IAvatarHtmlGenerator
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;

    public AvatarHtmlGenerator(IIconHtmlGenerator iconHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
    }

    /// <inheritdoc />
    public TagBuilder GenerateAvatar(AvatarSize size, string? imageUrl, string? text, Image icon, string? initial, string? link)
    {
        var avatar = new TagBuilder("div");
        var avatarClass = $"c-avatar c-avatar--{size.ToString().ToLowerInvariant()}";

        // If an image is set we need to add the following class.
        if (!string.IsNullOrWhiteSpace(imageUrl))
        {
            avatarClass += " c-avatar--img";
        }
        avatar.AddCssClass(avatarClass);

        if (!string.IsNullOrWhiteSpace(imageUrl))
        {
            var image = new TagBuilder("img")
            {
                Attributes =
                {
                    ["src"] = imageUrl,
                    ["alt"] = "avatar"
                }
            };
            avatar.InnerHtml.AppendHtml(image);
        }

        if (icon != Image.None)
        {
            var iconHtml = _iconHtmlGenerator.GenerateIcon(icon);
            avatar.InnerHtml.AppendHtml(iconHtml);
        }

        if (!string.IsNullOrWhiteSpace(initial))
        {
            avatar.InnerHtml.Append(initial);
        }

        if (!string.IsNullOrWhiteSpace(link))
        {
            var newAvatar = new TagBuilder("a");
            newAvatar.AddCssClass(avatarClass);
            newAvatar.Attributes["href"] = link;
            newAvatar.InnerHtml.SetHtmlContent(avatar.InnerHtml);
            avatar = newAvatar;
        }

        // Generate the div containing text.
        // When text is defined the root tag is no longer the avatar, so we need to encapsulate avatar into another div.
        if (!string.IsNullOrWhiteSpace(text))
        {
            var divText = new TagBuilder("div");
            var paragraph = new TagBuilder("p");
            paragraph.AddCssClass("c-avatar-and-text__text");
            paragraph.InnerHtml.SetContent(text);
            divText.InnerHtml.SetHtmlContent(paragraph);

            var textAvatarContainer = new TagBuilder("div");
            textAvatarContainer.AddCssClass("c-avatar-and-text");

            textAvatarContainer.InnerHtml.SetHtmlContent(avatar);
            textAvatarContainer.InnerHtml.AppendHtml(divText);

            avatar = textAvatarContainer;
        }

        return avatar;
    }
}
