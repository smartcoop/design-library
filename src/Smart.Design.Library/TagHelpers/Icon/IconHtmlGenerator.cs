using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CaseExtensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Icon;

/// <summary>
/// Generates HTML to render Smart Design Icons.
/// </summary>
public class IconHtmlGenerator : IIconHtmlGenerator
{
    private static readonly Lazy<Dictionary<Image, string>> ImagesMappedWithTheirEmbeddedResourceName = new(MakeSvgDictionary);

    /// <inheritdoc />
    public TagBuilder GenerateIcon(Image image)
    {
        var iconDiv = new TagBuilder("div");
        iconDiv.AddCssClass($"o-svg-icon o-svg-icon-{image.ToString().ToKebabCase()}");
        if (image != Image.None)
        {
            var svg = RetrieveSvgFromEmbeddedResources(image);

            // IHtmlContentBuilder.AppendHtml does nothing if the argument is null or empty.
            iconDiv.InnerHtml.AppendHtml(svg!);
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
            var svg = await RetrieveSvgFromEmbeddedResourcesAsync(image);

            // IHtmlContentBuilder.AppendHtml does nothing if the argument is null or empty.
            iconDiv.InnerHtml.AppendHtml(svg!);
        }

        return iconDiv;
    }

    private string? RetrieveSvgFromEmbeddedResources(Image image)
    {
        var resourceStream = GetEmbeddedResourceStream(image);
        if (resourceStream is null)
        {
            return null;
        }

        using var streamReader = new StreamReader(resourceStream);
        return streamReader.ReadToEnd();
    }

    private async Task<string?> RetrieveSvgFromEmbeddedResourcesAsync(Image image)
    {
        var resourceStream = GetEmbeddedResourceStream(image);
        if (resourceStream is null)
        {
            return null;
        }

        using var streamReader = new StreamReader(resourceStream);
        return await streamReader.ReadToEndAsync();
    }

    private Stream? GetEmbeddedResourceStream(Image image)
    {
        if (image == Image.None || !ImagesMappedWithTheirEmbeddedResourceName.Value.ContainsKey(image))
        {
            return null;
        }

        var currentAssembly = Assembly.GetExecutingAssembly();
        return currentAssembly.GetManifestResourceStream(ImagesMappedWithTheirEmbeddedResourceName.Value[image]);
    }

    private static Dictionary<Image, string> MakeSvgDictionary()
    {
        var imageMappedWithResourceNames = new Dictionary<Image, string>();
        var iconResourceNames = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceNames()
            .Where(name => name.StartsWith("Smart.Design.Library.wwwroot.icons"));

        foreach (var iconResourceName in iconResourceNames)
        {
            var svgName = iconResourceName.Split(".")[^2];

            if (Enum.TryParse<Image>(svgName.ToPascalCase(), true, out var @enum))
            {
                imageMappedWithResourceNames[@enum] = iconResourceName;
            }
        }

        return imageMappedWithResourceNames;
    }
}
