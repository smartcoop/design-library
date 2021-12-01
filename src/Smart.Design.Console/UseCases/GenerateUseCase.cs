using System;
using Microsoft.Extensions.Logging;
using Razor.Templating.Core;
using Smart.Design.Console.CommandOptions;
using Smart.Design.Console.Models;
using Smart.Design.RazorView;
using TreeFormatter;

namespace Smart.Design.Console.UseCases
{
    /// <summary>
    ///     Generator html string from component name
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
                RazorTemplateEngine
                    .Initialize();

                string rawHtml = RazorTemplateEngine
                    .RenderAsync($"/Views/{_options.DesignElementName}.cshtml")
                    .Result;

                string formattedHtml = rawHtml.MinifyHtml().PrettifyHtml();
                response.SetSuccessMessage(formattedHtml);
            }
            catch (Exception e)
            {
                response.AddError(e);
            }

            return response;
        }
    }
}
