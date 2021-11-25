using Definux.HtmlBuilder;
using Microsoft.Extensions.DependencyInjection;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Presentation.Mvc
{
    public static class StartupDependencies
    {
        public static IServiceCollection Configure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISmartHtmlGenerator, SmartHtmlGenerator>();
            serviceCollection.AddScoped<HtmlBuilder>();
            return serviceCollection;
        }
    }
}
