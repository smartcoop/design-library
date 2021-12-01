using System;
using Razor.Templating.Core;
using Smart.Design.HtmlGenerator.CommandOptions;
using Smart.Design.HtmlGenerator.Models;
using TreeFormatter;

namespace Smart.Design.HtmlGenerator.UseCases;

/// <summary>
///     Generator of HTML string from design element name
/// </summary>
public class GenerateUseCase
{
    private readonly GenerateOptions _options;

    public GenerateUseCase(GenerateOptions options)
    {
        _options = options;
    }

    public CommandResponse Run()
    {
        CommandResponse response = new();
        try
        {
            RazorTemplateEngine.Initialize();

            var rawHtml = RazorTemplateEngine
                .RenderAsync($"/Views/{_options.DesignElementName}.cshtml")
                .GetAwaiter().GetResult();

            var formattedHtml = rawHtml.MinifyHtml().PrettifyHtml();
            response.SetSuccessMessage(formattedHtml);
        }
        catch (Exception e)
        {
            response.AddError(e);
        }

        return response;
    }
}
