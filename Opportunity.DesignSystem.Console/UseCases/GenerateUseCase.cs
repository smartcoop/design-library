using System;
using Opportunity.DesignSystem.Console.CommandOptions;
using Opportunity.DesignSystem.Console.Models;
using Razor.Templating.Core;
using TreeFormatter;

namespace Opportunity.DesignSystem.Console.UseCases
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
