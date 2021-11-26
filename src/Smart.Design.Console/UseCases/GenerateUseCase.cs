using System;
using Razor.Templating.Core;
using Smart.Design.Console.CommandOptions;
using Smart.Design.Console.Models;
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

                var rawHtml = RazorTemplateEngine
                    .RenderAsync($"/Views/{_options.DesignElementName}.cshtml")
                    .Result;

                var formattedHtml = rawHtml.MinifyHtml().PrettifyHtml();
                response.SetSuccessMessage($"raw html: \n {formattedHtml}");
            }
            catch (Exception e)
            {
                response.AddError(e);
            }

            return response;
        }
    }
}
