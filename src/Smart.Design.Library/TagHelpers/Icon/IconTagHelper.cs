using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;
using Smart.Design.Library.TagHelpers.Image;

namespace Smart.Design.Library.TagHelpers.Icon;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart design Icon.
/// The documentation is available <see href="https://design.smart.coop/development/docs/aov-icons.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.IconTagName)]
public class IconTagHelper : TagHelper
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;
    private const string IconAttributeName = "icon";

    [HtmlAttributeName(IconAttributeName)]
    public Image.Image Image { get; set; }

    /// <summary>
    /// Creates a new <see cref="IconTagHelper"/>.
    /// </summary>
    /// <param name="imageHtmlGenerator">The service that generates Smart Design Icons HTML.</param>
    public IconTagHelper(IImageHtmlGenerator imageHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
    }

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var icon = await _imageHtmlGenerator.GenerateIconAsync(Image);

        output.ClearAndMergeAttributes(icon);

        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = icon.TagName;

        output.Content.SetHtmlContent(icon.InnerHtml);
    }
}
