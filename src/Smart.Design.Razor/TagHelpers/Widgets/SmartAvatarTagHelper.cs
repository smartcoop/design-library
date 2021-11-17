using System;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Widgets
{
    /// <summary>
    /// <see cref="ITagHelper"/> implementation of the smart design avatar.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-avatar.html">here</see>.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartAvatar)]
    public class SmartAvatarTagHelper : TagHelper
    {
        private readonly ISmartHtmlGenerator _smartHtmlGenerator;
        private const string AvatarSizeAttributeName = "size";
        private const string AvatarLinkAttributeName = "link";
        private const string IconAttributeName = "icon";
        private const string ImageUrlAttributeName = "imageUrl";
        private const string InitialsAttributeName = "initials";
        private const string TextAttributeName = "text";

        [HtmlAttributeName(AvatarSizeAttributeName)]
        public AvatarSize Size { get; set; } = AvatarSize.Medium;

        [HtmlAttributeName(IconAttributeName)]
        public Icon Icon { get; set; }

        [HtmlAttributeName(ImageUrlAttributeName)]
        public string ImageUrl { get; set; }

        [HtmlAttributeName(InitialsAttributeName)]
        public string Initials { get; set; }

        [HtmlAttributeName(AvatarLinkAttributeName)]
        public string Link { get; set; }

        [HtmlAttributeName(TextAttributeName)]
        public string Text { get; set; }

        public SmartAvatarTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Init(TagHelperContext context)
        {
            if (Icon != Icon.None && !string.IsNullOrWhiteSpace(ImageUrl))
            {
                throw new InvalidOperationException($"Properties {nameof(Icon)} and {nameof(ImageUrl)} cannot be set at the same time.");
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var avatar = _smartHtmlGenerator.GenerateAvatar(Size, ImageUrl, Text, Icon, Initials, Link);

            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = avatar.TagName;
            output.ClearAllAttributes();
            output.MergeAttributes(avatar);
            output.Content.SetHtmlContent(avatar.InnerHtml);
        }
    }
}
