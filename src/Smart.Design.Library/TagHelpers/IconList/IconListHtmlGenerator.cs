using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.IconList;

public class IconListHtmlGenerator : IIconListHtmlGenerator
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;

    public IconListHtmlGenerator(IImageHtmlGenerator imageHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
    }

    /// <inheritdoc />
    public TagBuilder GenerateIconList()
    {
        var iconList = new TagBuilder("ul");
        iconList.AddCssClass("c-icon-list");

        return iconList;
    }

    /// <inheritdoc />
    public async Task<TagBuilder> GenerateIconListItemAsync(Image icon, string? label)
    {
        // An Smart design icon item has an icon and a label.
        var li = new TagBuilder("li");
        li.AddCssClass("c-icon-list__item");

        var htmlIcon = await _imageHtmlGenerator.GenerateIconAsync(icon);
        li.InnerHtml.AppendHtml(htmlIcon);

        var messageSpan = new TagBuilder("span");
        messageSpan.InnerHtml.SetContent(label!);
        li.InnerHtml.AppendHtml(messageSpan);

        return li;
    }
}
