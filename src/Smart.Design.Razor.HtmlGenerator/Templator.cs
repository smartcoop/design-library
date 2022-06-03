using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Razor.Templating.Core;

namespace Smart.Design.Razor.HtmlGenerator;

public class Templator
{
    private readonly ApplicationPartManager _applicationPartManager;

    private static readonly string[] FilesThatAreNotTemplates =
    {
        "_ViewImports.cshtml",
        "_ViewStart.cshtml",
        "_Layout.cshtml"
    };

    public Templator(ApplicationPartManager applicationPartManager)
    {
        _applicationPartManager = applicationPartManager;
    }

    /// <summary>
    /// Checks if a given path points to a cshtml that is actually a template.
    /// We have files such _Layout.cshtml that should not be rendered.
    /// </summary>
    /// <returns></returns>
    private bool IsATemplate(string path)
    {
        return !FilesThatAreNotTemplates.Any(path.Contains);
    }

    /// <summary>
    /// Retrieves the template' paths. We need them for the rendering.
    /// </summary>
    /// <returns></returns>
    private string[] GetPagePaths()
    {
        var feature = new ViewsFeature();
        _applicationPartManager.PopulateFeature(feature);
        return feature.ViewDescriptors
            .Where(descriptor => descriptor.RelativePath.StartsWith("/Pages") && IsATemplate(descriptor.RelativePath))
            .Select(descriptor => descriptor.RelativePath).ToArray();
    }

    private string GetTemplateName(string templatePath)
    {
        var fileInfo = new FileInfo(templatePath);
        var fileName = fileInfo.Name.Replace("cshtml", "html");
        return fileName;
    }

    public async Task GenerateAsync()
    {
        var templatePaths = GetPagePaths();

        foreach (var templatePath in templatePaths)
        {
            // Get the actual file name.
            var fileName = GetTemplateName(templatePath);

            // Write the rendered output.
            var html = await RazorTemplateEngine.RenderAsync(templatePath);
            await File.WriteAllTextAsync(fileName, html);

            // Open every templates in the browser.
            // To remove once we start having too many templates.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(@"explorer", fileName);
            }
        }
    }
}