using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.Badge;

public interface IBadgeHtmlGenerator
{
    /// <summary>
    /// Generates a Smart design badge.
    /// </summary>
    /// <param name="style">Style to applied to the badge.</param>
    /// <param name="icon">Icon to use, will override the <paramref name="style" /> default one.</param>
    /// <param name="size">Size of the badge.</param>
    /// <param name="title">Title of the badge if set.</param>
    /// <param name="subline">Subline of the badge if set.</param>
    /// <returns>An instance of a Smart design badge.</returns>
    public TagBuilder GenerateSmartBadge(BadgeStyle style, Image icon, BadgeSize size, string? title = default, string? subline = null);
}
