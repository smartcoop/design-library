using Opportunity.DesignSystem.Console.Options;
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

        public string Run()
        {
            RazorTemplateEngine
                .Initialize();

            var html = RazorTemplateEngine
                .RenderAsync($"/Views/Test/{_options.DesignElementName}.cshtml")
                .Result;

            return html.MinifyHtml().PrettifyHtml();
        }
    }
}
