using System;
using System.IO;
using Razor.Templating.Core;
using Smart.Application.Console.Options;
using TreeFormatter;

namespace Smart.Application.Console.UseCases
{
    /// <summary>
    /// Generator html string from component name
    /// </summary>
    public class GenerateUseCase
    {
        private readonly GenerateOptions _options;

        public GenerateUseCase( GenerateOptions options )
        {
            _options = options;
        }

        public string Run()
        {
            RazorTemplateEngine
               .Initialize();

            var html = RazorTemplateEngine
                      .RenderAsync( $"/Views/Test/{_options.DesignElementName}.cshtml" )
                      .Result;

            return html.MinifyHtml().PrettifyHtml();
        }
    }
}
