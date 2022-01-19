using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CaseExtensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Icon;

public class IconHtmlGenerator : IIconHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateIcon(Image image)
    {
        var iconDiv = new TagBuilder("div");
        iconDiv.AddCssClass($"o-svg-icon o-svg-icon-{image.ToString().ToKebabCase()}");
        if (image != Image.None)
        {
            var svg = RetrieveSvgFromEmbeddedResources(image);

            // IHtmlContentBuilder.AppendHtml does nothing if the argument is null or empty.
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
            var svg = await RetrieveSvgFromEmbeddedResourcesAsync(image);

            // IHtmlContentBuilder.AppendHtml does nothing if the argument is null or empty.
            iconDiv.InnerHtml.AppendHtml(svg);
        }

        return iconDiv;
    }

    private string? RetrieveSvgFromEmbeddedResources(Image image)
    {
        var resourceStream = GetEmbeddedResourceStream(image);
        if (resourceStream is null)
            return null;

        using var streamReader = new StreamReader(resourceStream);
        return streamReader.ReadToEnd();
    }

    private async Task<string?> RetrieveSvgFromEmbeddedResourcesAsync(Image image)
    {
        var resourceStream = GetEmbeddedResourceStream(image);
        if (resourceStream is null)
            return null;

        using var streamReader = new StreamReader(resourceStream);
        return await streamReader.ReadToEndAsync();
    }

    private Stream? GetEmbeddedResourceStream(Image image)
    {
        if (image == Image.None)
        {
            return null;
        }

        var currentAssembly = Assembly.GetExecutingAssembly();
        var resourceFileName = currentAssembly.GetManifestResourceNames().FirstOrDefault(resourceName => resourceName.Contains(image.ToString().ToKebabCase()));

        if (string.IsNullOrWhiteSpace(resourceFileName))
            return null;

        return currentAssembly.GetManifestResourceStream(resourceFileName);
    }
}
