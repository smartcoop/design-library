using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Icon;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart design Icon.
/// The documentation is available <see href="https://design.smart.coop/development/docs/aov-icons.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.IconTagName)]
public class IconTagHelper : TagHelper
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;
    private const string IconAttributeName = "icon";

    [HtmlAttributeName(IconAttributeName)]
    public Image Image { get; set; }

    /// <summary>
    /// Creates a new <see cref="IconTagHelper"/>.
    /// </summary>
    /// <param name="iconHtmlGenerator">The service that generates Smart Design Icons HTML.</param>
    public IconTagHelper(IIconHtmlGenerator iconHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
    }

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var icon = await _iconHtmlGenerator.GenerateIconAsync(Image);

        output.ClearAndMergeAttributes(icon);

        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = icon.TagName;

        output.Content.SetHtmlContent(icon.InnerHtml);
    }
}
