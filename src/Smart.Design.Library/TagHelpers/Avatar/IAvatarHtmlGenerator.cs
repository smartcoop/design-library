using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Avatar;

public interface IAvatarHtmlGenerator
{
    /// <summary>
    /// Generates a Smart design avatar.
    /// </summary>
    /// <param name="size"></param>
    /// <param name="imageUrl"></param>
    /// <param name="text">Associated text to the avatar</param>
    /// <param name="icon"></param>
    /// <param name="initial"></param>
    /// <param name="link"></param>
    /// <returns>An instance of a Smart design avatar.</returns>
    TagBuilder GenerateAvatar(AvatarSize size, string? imageUrl, string? text, Image.Image icon, string? initial, string? link);
}
