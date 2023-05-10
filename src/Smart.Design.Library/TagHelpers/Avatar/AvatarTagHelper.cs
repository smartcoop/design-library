using System;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.Avatar;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart design avatar.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-avatar.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.Avatar)]
public class AvatarTagHelper : TagHelper
{
    private const string AvatarSizeAttributeName = "size";
    private const string AvatarLinkAttributeName = "link";
    private const string IconAttributeName = "icon";
    private const string ImageUrlAttributeName = "imageUrl";
    private const string InitialsAttributeName = "initials";
    private const string TextAttributeName = "text";

    private readonly IAvatarHtmlGenerator _avatarHtmlGenerator;

    [HtmlAttributeName(AvatarSizeAttributeName)]
    public AvatarSize Size { get; set; } = AvatarSize.Medium;

    [HtmlAttributeName(IconAttributeName)]
    public Image.Image Icon { get; set; }

    [HtmlAttributeName(ImageUrlAttributeName)]
    public string? ImageUrl { get; set; }

    [HtmlAttributeName(InitialsAttributeName)]
    public string? Initials { get; set; }

    [HtmlAttributeName(AvatarLinkAttributeName)]
    public string? Link { get; set; }

    [HtmlAttributeName(TextAttributeName)]
    public string? Text { get; set; }

    public AvatarTagHelper(IAvatarHtmlGenerator avatarHtmlGenerator)
    {
        _avatarHtmlGenerator = avatarHtmlGenerator;
    }

    public override void Init(TagHelperContext context)
    {
        if (Icon != Image.Image.None && !string.IsNullOrWhiteSpace(ImageUrl))
        {
            throw new InvalidOperationException($"Properties {nameof(Icon)} and {nameof(ImageUrl)} cannot be set at the same time.");
        }
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var avatar = _avatarHtmlGenerator.GenerateAvatar(Size, ImageUrl, Text, Icon, Initials, Link);

        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = avatar.TagName;
        output.ClearAllAttributes();
        output.MergeAttributes(avatar);
        output.Content.SetHtmlContent(avatar.InnerHtml);
    }
}
