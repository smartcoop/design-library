using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CaseExtensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Icon;

public class IconHtmlGenerator : IIconHtmlGenerator
{
    private static string? s_baseIconPath;
    private static string BaseIconPath => s_baseIconPath ??=
        $"{Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)}/wwwroot/icons";

    /// <inheritdoc />
    public TagBuilder GenerateIcon(Image image)
    {
        var iconDiv = new TagBuilder("div");
        iconDiv.AddCssClass($"o-svg-icon o-svg-icon-{image.ToString().ToKebabCase()}");
        if (image != Image.None)
        {
            var svg = File.ReadAllText($"{BaseIconPath}/{image.ToString().ToKebabCase()}.svg");
            iconDiv.InnerHtml.AppendHtml(svg);
        }

        return iconDiv;
    }

    /// <inheritdoc />
    public async Task<TagBuilder> GenerateIconAsync(Image image)
    {
        var iconDiv = new TagBuilder("div");
        iconDiv.AddCssClass($"o-svg-icon o-svg-icon-{image.ToString().ToKebabCase()}");
        if (image != Image.None)
        {
            var svg = await File.ReadAllTextAsync($"{BaseIconPath}/{image.ToString().ToKebabCase()}.svg");
            iconDiv.InnerHtml.AppendHtml(svg);
        }

        return iconDiv;
    }
}
