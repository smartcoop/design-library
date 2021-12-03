using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.IconList;

public class IconListHtmlGenerator : IIconListHtmlGenerator
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;

    public IconListHtmlGenerator(IIconHtmlGenerator iconHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
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

        var htmlIcon = await _iconHtmlGenerator.GenerateIconAsync(icon);
        li.InnerHtml.AppendHtml(htmlIcon);

        var messageSpan = new TagBuilder("span");
        messageSpan.InnerHtml.SetContent(label!);
        li.InnerHtml.AppendHtml(messageSpan);

        return li;
    }
}
